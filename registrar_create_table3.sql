-- Drop table if it exists (optional)
IF OBJECT_ID('dbo.Registrarss', 'U') IS NOT NULL
    DROP TABLE dbo.Registrarss;
GO

-- Create the table
CREATE TABLE dbo.Registrarss
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Received BIT NOT NULL DEFAULT 0,                           -- Default 0
    Category NVARCHAR(100),
    SubmittingAgent NVARCHAR(100),
    ReceivingAgent NVARCHAR(100),
    Status NVARCHAR(50) NOT NULL DEFAULT 'NEW',                -- Auto set to 'NEW'
    CertificateNo NVARCHAR(100),
    Broker NVARCHAR(100),
    Counter NVARCHAR(100),
    CreatedDate DATETIME2 NOT NULL DEFAULT DATEADD(HOUR, 3, SYSUTCDATETIME()),  -- Nairobi time
    UpdatedDate DATETIME2 NULL,                                -- Updated on change
    Result NVARCHAR(10) NULL CHECK (Result IN ('SUCCESS', 'REJECTED') OR Result IS NULL),
    RejectionReason NVARCHAR(255) NULL                         -- Required when Result='REJECTED'
);
GO


-----------------------------------------------------------------
-- Trigger: Automatically updates UpdatedDate on every update
-----------------------------------------------------------------
CREATE TRIGGER trg_Registrarss_UpdateDate
ON dbo.Registrarss
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE c
    SET c.UpdatedDate = DATEADD(HOUR, 3, SYSUTCDATETIME())
    FROM dbo.Registrarss c
    INNER JOIN inserted i ON c.Id = i.Id;
END;
GO


-----------------------------------------------------------------
-- Trigger: Enforce business rules and protect system fields
-----------------------------------------------------------------
CREATE TRIGGER trg_Registrarss_ProtectAndValidate
ON dbo.Registrarss
INSTEAD OF UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Prevent changing CreatedDate or Status manually,
    -- and ensure Result logic is respected.
    UPDATE c
    SET
        Category = ISNULL(i.Category, c.Category),
        CertificateNo = ISNULL(i.CertificateNo, c.CertificateNo),
        Broker = ISNULL(i.Broker, c.Broker),
        Counter = ISNULL(i.Counter, c.Counter),
        SubmittingAgent = ISNULL(i.SubmittingAgent, c.SubmittingAgent),
        ReceivingAgent = ISNULL(i.ReceivingAgent, c.ReceivingAgent),
        Received = ISNULL(i.Received, c.Received),

        -- Allow setting Result only if NULL before
        Result = CASE 
                    WHEN c.Result IS NULL AND (i.Result IN ('SUCCESS', 'REJECTED')) THEN i.Result
                    ELSE c.Result
                 END,

        -- Set or retain RejectionReason
        RejectionReason = CASE 
                    WHEN c.Result IS NULL AND i.Result = 'REJECTED' THEN i.RejectionReason
                    WHEN c.Result = 'REJECTED' THEN c.RejectionReason  -- Prevent editing after
                    ELSE i.RejectionReason  -- Keep it if other updates
                 END,

        UpdatedDate = DATEADD(HOUR, 3, SYSUTCDATETIME())
    FROM dbo.Registrarss c
    INNER JOIN inserted i ON c.Id = i.Id;

    -- Validation: if Result='REJECTED', RejectionReason must not be NULL
    IF EXISTS (
        SELECT 1 FROM inserted i
        INNER JOIN dbo.Registrarss c ON c.Id = i.Id
        WHERE c.Result = 'REJECTED' AND (c.RejectionReason IS NULL OR LTRIM(RTRIM(c.RejectionReason)) = '')
    )
    BEGIN
        RAISERROR('RejectionReason must be provided when Result is REJECTED.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO
