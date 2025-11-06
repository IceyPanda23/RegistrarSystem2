<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        agent_cb = New GroupBox()
        receivingagent_cb = New ComboBox()
        receivingagent_labo = New Label()
        senderagent_labo = New Label()
        counter_cb = New ComboBox()
        counter_labo = New Label()
        ComboBox1 = New ComboBox()
        broker_labo = New Label()
        certificateno_tb = New TextBox()
        certificatenumber_labo = New Label()
        documenttype_cb = New ComboBox()
        documenttype_labo = New Label()
        datereceived_labo = New Label()
        datereceived_calend = New DateTimePicker()
        GroupBox2 = New GroupBox()
        Button1 = New Button()
        Submit_buto = New Button()
        DataGridView1 = New DataGridView()
        Label1 = New Label()
        agent_cb.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' agent_cb
        ' 
        agent_cb.Controls.Add(Label1)
        agent_cb.Controls.Add(receivingagent_cb)
        agent_cb.Controls.Add(receivingagent_labo)
        agent_cb.Controls.Add(senderagent_labo)
        agent_cb.Controls.Add(counter_cb)
        agent_cb.Controls.Add(counter_labo)
        agent_cb.Controls.Add(ComboBox1)
        agent_cb.Controls.Add(broker_labo)
        agent_cb.Controls.Add(certificateno_tb)
        agent_cb.Controls.Add(certificatenumber_labo)
        agent_cb.Controls.Add(documenttype_cb)
        agent_cb.Controls.Add(documenttype_labo)
        agent_cb.Controls.Add(datereceived_labo)
        agent_cb.Controls.Add(datereceived_calend)
        agent_cb.Location = New Point(12, 22)
        agent_cb.Name = "agent_cb"
        agent_cb.Size = New Size(764, 240)
        agent_cb.TabIndex = 0
        agent_cb.TabStop = False
        agent_cb.Text = "Document Receiving"
        ' 
        ' receivingagent_cb
        ' 
        receivingagent_cb.FormattingEnabled = True
        receivingagent_cb.Location = New Point(134, 167)
        receivingagent_cb.Name = "receivingagent_cb"
        receivingagent_cb.Size = New Size(200, 23)
        receivingagent_cb.TabIndex = 13
        ' 
        ' receivingagent_labo
        ' 
        receivingagent_labo.AutoSize = True
        receivingagent_labo.Location = New Point(6, 170)
        receivingagent_labo.Name = "receivingagent_labo"
        receivingagent_labo.Size = New Size(99, 15)
        receivingagent_labo.TabIndex = 11
        receivingagent_labo.Text = "Receiving Agent :"
        ' 
        ' senderagent_labo
        ' 
        senderagent_labo.AutoSize = True
        senderagent_labo.Location = New Point(6, 203)
        senderagent_labo.Name = "senderagent_labo"
        senderagent_labo.Size = New Size(84, 15)
        senderagent_labo.TabIndex = 10
        senderagent_labo.Text = "Sender Agent :"
        ' 
        ' counter_cb
        ' 
        counter_cb.FormattingEnabled = True
        counter_cb.Location = New Point(134, 135)
        counter_cb.Name = "counter_cb"
        counter_cb.Size = New Size(200, 23)
        counter_cb.TabIndex = 9
        ' 
        ' counter_labo
        ' 
        counter_labo.AutoSize = True
        counter_labo.Location = New Point(6, 138)
        counter_labo.Name = "counter_labo"
        counter_labo.Size = New Size(56, 15)
        counter_labo.TabIndex = 8
        counter_labo.Text = "Counter :"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(134, 106)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(200, 23)
        ComboBox1.TabIndex = 7
        ' 
        ' broker_labo
        ' 
        broker_labo.AutoSize = True
        broker_labo.Location = New Point(6, 109)
        broker_labo.Name = "broker_labo"
        broker_labo.Size = New Size(47, 15)
        broker_labo.TabIndex = 6
        broker_labo.Text = "Broker :"
        ' 
        ' certificateno_tb
        ' 
        certificateno_tb.Location = New Point(134, 77)
        certificateno_tb.Name = "certificateno_tb"
        certificateno_tb.Size = New Size(200, 23)
        certificateno_tb.TabIndex = 5
        ' 
        ' certificatenumber_labo
        ' 
        certificatenumber_labo.AutoSize = True
        certificatenumber_labo.Location = New Point(6, 80)
        certificatenumber_labo.Name = "certificatenumber_labo"
        certificatenumber_labo.Size = New Size(82, 15)
        certificatenumber_labo.TabIndex = 4
        certificatenumber_labo.Text = "Cerificate No :"
        ' 
        ' documenttype_cb
        ' 
        documenttype_cb.FormattingEnabled = True
        documenttype_cb.Location = New Point(134, 48)
        documenttype_cb.Name = "documenttype_cb"
        documenttype_cb.Size = New Size(200, 23)
        documenttype_cb.TabIndex = 3
        ' 
        ' documenttype_labo
        ' 
        documenttype_labo.AutoSize = True
        documenttype_labo.Location = New Point(6, 51)
        documenttype_labo.Name = "documenttype_labo"
        documenttype_labo.Size = New Size(97, 15)
        documenttype_labo.TabIndex = 2
        documenttype_labo.Text = "Document Type :"
        ' 
        ' datereceived_labo
        ' 
        datereceived_labo.AutoSize = True
        datereceived_labo.Location = New Point(6, 22)
        datereceived_labo.Name = "datereceived_labo"
        datereceived_labo.Size = New Size(87, 15)
        datereceived_labo.TabIndex = 1
        datereceived_labo.Text = "Date Received :"
        ' 
        ' datereceived_calend
        ' 
        datereceived_calend.Location = New Point(134, 16)
        datereceived_calend.Name = "datereceived_calend"
        datereceived_calend.Size = New Size(200, 23)
        datereceived_calend.TabIndex = 0
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(Button1)
        GroupBox2.Controls.Add(Submit_buto)
        GroupBox2.Location = New Point(12, 268)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(764, 54)
        GroupBox2.TabIndex = 1
        GroupBox2.TabStop = False
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(214, 22)
        Button1.Name = "Button1"
        Button1.Size = New Size(135, 23)
        Button1.TabIndex = 1
        Button1.Text = "Receive Task"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Submit_buto
        ' 
        Submit_buto.Location = New Point(28, 22)
        Submit_buto.Name = "Submit_buto"
        Submit_buto.Size = New Size(139, 23)
        Submit_buto.TabIndex = 0
        Submit_buto.Text = "Submit Task"
        Submit_buto.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(12, 336)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(764, 166)
        DataGridView1.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(134, 203)
        Label1.Name = "Label1"
        Label1.Size = New Size(116, 15)
        Label1.TabIndex = 14
        Label1.Text = "Logged In Username"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 514)
        Controls.Add(DataGridView1)
        Controls.Add(GroupBox2)
        Controls.Add(agent_cb)
        Name = "Form1"
        Text = "Form1"
        agent_cb.ResumeLayout(False)
        agent_cb.PerformLayout()
        GroupBox2.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents agent_cb As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents datereceived_labo As Label
    Friend WithEvents datereceived_calend As DateTimePicker
    Friend WithEvents documenttype_labo As Label
    Friend WithEvents documenttype_cb As ComboBox
    Friend WithEvents certificateno_tb As TextBox
    Friend WithEvents certificatenumber_labo As Label
    Friend WithEvents broker_labo As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents counter_cb As ComboBox
    Friend WithEvents counter_labo As Label
    Friend WithEvents receivingagent_labo As Label
    Friend WithEvents senderagent_labo As Label
    Friend WithEvents receivingagent_cb As ComboBox
    Friend WithEvents Submit_buto As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label

End Class
