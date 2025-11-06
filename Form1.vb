Imports System.Data.SqlClient
Imports System.Data
Imports Microsoft.SqlServer.Server

Public Class Form1
    Dim connectionString As String = "Data Source=192.168.11.3;Initial Catalog=Simple;User ID=sa;Password=skyblue2009*;"
    Dim connection As SqlConnection
    Dim adapter As SqlDataAdapter
    Dim builder As SqlCommandBuilder
    Dim dt As DataTable
    Dim dtt As DataTable
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles agent_cb.Enter

    End Sub
    Private Sub LoadData()
        connection = New SqlConnection(connectionString)
        adapter = New SqlDataAdapter("SELECT * FROM Registrarss", connection)
        builder = New SqlCommandBuilder(adapter)

        dtt = New DataTable()
        adapter.Fill(dtt)

        DataGridView1.DataSource = dtt

        ' Protect system fields from editing
        With DataGridView1
            .Columns("Id").ReadOnly = True
            .Columns("CreatedDate").ReadOnly = True
            .Columns("UpdatedDate").ReadOnly = True
            .Columns("Status").ReadOnly = True
            .Columns("Id").Visible = False

        End With
    End Sub
    Private Sub Loaddropdowns(cb As ComboBox, column_name As String, table_name As String)

        Dim query As String = $"SELECT DISTINCT  {column_name} FROM [dbo].[{table_name}]"
        Dim query2 As String = "SELECT 
                                DISTINCT (LTRIM(RTRIM(
                                    ISNULL(
                                        UPPER(LEFT(SUBSTRING(UserName, 1, CHARINDEX('.', UserName + '.') - 1), 1)) +
                                        LOWER(SUBSTRING(UserName, 2, CHARINDEX('.', UserName + '.') - 2)),
                                        ''
                                    ) 
                                    + ' ' + 
                                    ISNULL(
                                        UPPER(LEFT(SUBSTRING(UserName, CHARINDEX('.', UserName + '.') + 1, LEN(UserName)), 1)) +
                                        LOWER(SUBSTRING(UserName, CHARINDEX('.', UserName + '.') + 2, LEN(UserName))),
                                        ''
                                    )
                                ))) AS displayname
                            FROM [dbo].[User];
                            "

        If cb Is receivingagent_cb Then
            query = query2
        End If
        Using connn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, connn)
                connn.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                cb.Items.Clear()
                While reader.Read()
                    cb.Items.Add(reader(column_name).ToString())
                End While
            End Using
        End Using
    End Sub


    Private Sub LoadBrokerswCodes(cb As ComboBox)
        Dim query As String = "SELECT [Agent Code], [Agent Name] FROM Agent"

        Using connnn As New SqlConnection("Data Source=192.168.11.3;Initial Catalog=Simple;User ID=sa;Password=skyblue2009*;")
            Using cmd As New SqlCommand(query, connnn)
                Try
                    connnn.Open()
                    Dim dt As New DataTable()
                    dt.Load(cmd.ExecuteReader())
                    ' 👇 Add a display column combining code and name
                    dt.Columns.Add("DisplayText", GetType(String))
                    For Each row As DataRow In dt.Rows
                        row("DisplayText") = $"{row("Agent Code")} - {row("Agent Name")}"
                    Next

                    ' Bind the DataTable to the ComboBox
                    cb.DataSource = dt
                    cb.DisplayMember = "DisplayText"   ' What user sees
                    cb.ValueMember = "Agent Name"     ' What you can use in code
                    cb.SelectedIndex = -1             ' Optional: no preselection

                Catch ex As Exception
                    MessageBox.Show("Error loading ComboBox: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles datereceived_labo.Click

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
        'Loaddropdowns(cb:=broker_cb, column_name:="AgentName", table_name:="Agent")
        Loaddropdowns(cb:=receivingagent_cb, column_name:="displayname", table_name:="User")
        LoadBrokerswCodes(cb:=broker_cb)
        Loaddropdowns(cb:=counter_cb, column_name:="RegisterDisplayName", table_name:="RegisterDetails")
        documenttype_cb.Items.Clear()
        documenttype_cb.Items.Add("Indemnity")
        documenttype_cb.Items.Add("Opt-In")
        documenttype_cb.Items.Add("Immobilization")
        documenttype_cb.Items.Add("Opt-In")
        documenttype_cb.Items.Add("Private Transfers")
        documenttype_cb.Items.Add("Poxy")
        documenttype_cb.Items.Add("Correspondence")
        documenttype_cb.Items.Add("Others")

    End Sub


    Private Sub Submit_buto_Click(sender As Object, e As EventArgs) Handles Submit_buto.Click
        ' ⚙️ Adjust your connection string
        Dim connectionString As String = "Server=192.168.11.3;Database=Simple;User ID=sa;Password=skyblue2009*;"

        ' Example: assume your table has these columns
        ' AgentCode, AgentName, Amount, Description, Status, CreatedBy, etc.
        Dim document_typee As String = documenttype_cb.Text
        Dim receivingName As String = receivingagent_cb.Text
        Dim CertNo As String = certificateno_tb.Text.Trim()
        'Dim amount As Decimal = Decimal.Parse(amount_txt.Text)
        Dim Counterr As String = counter_cb.Text
        Dim brokerName As String = broker_cb.Text
        'Dim createdBy As String = Environment.UserName  ' or whatever user field you track

        Dim query As String = "
            INSERT INTO dbo.Registrarss (Category, ReceivingAgent, CertificateNo, Broker, Counter)
            VALUES (@Category, @ReceivingAgent, @CertificateNo, @Broker, @Counter);
        "

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                ' ✅ Match parameter names with query
                cmd.Parameters.AddWithValue("@Category", document_typee)
                cmd.Parameters.AddWithValue("@ReceivingAgent", receivingName)
                cmd.Parameters.AddWithValue("@CertificateNo", CertNo)
                cmd.Parameters.AddWithValue("@Broker", brokerName)
                cmd.Parameters.AddWithValue("@Counter", Counterr)
                Try
                    conn.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Record saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadData() ' optional — refresh DataGridView
                    Else
                        MessageBox.Show("No record inserted.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Catch ex As SqlException
                    MessageBox.Show("SQL Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub


    Private Sub documenttype_cb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles documenttype_cb.SelectedIndexChanged

    End Sub

    Private Sub certificatenumber_labo_Click(sender As Object, e As EventArgs) Handles certificatenumber_labo.Click

    End Sub

    Private Sub receivingagent_cb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles receivingagent_cb.SelectedIndexChanged

    End Sub

    Private Sub broker_cb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles broker_cb.SelectedIndexChanged

    End Sub

    Private Sub senderagent_labo_Click(sender As Object, e As EventArgs) Handles senderagent_labo.Click

    End Sub

    Private Sub receivetask_buto_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.EndEdit()
        adapter.Update(dtt)
        LoadData()
    End Sub
End Class
