Imports System.Data.SqlClient
Imports System.Data

Public Class Form1
    Dim connectionString As String = "Data Source=192.168.11.3;Initial Catalog=Simple;User ID=sa;Password=skyblue2009*;"
    Dim connection As SqlConnection
    Dim adapter As SqlDataAdapter
    Dim builder As SqlCommandBuilder
    Dim dt As DataTable
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles agent_cb.Enter

    End Sub
    Private Sub LoadData()
        connection = New SqlConnection(connectionString)
        adapter = New SqlDataAdapter("SELECT * FROM Registrarss", connection)
        builder = New SqlCommandBuilder(adapter)

        dt = New DataTable()
        adapter.Fill(dt)

        DataGridView1.DataSource = dt

        ' Protect system fields from editing
        With DataGridView1
            .Columns("Id").ReadOnly = True
            .Columns("CreatedDate").ReadOnly = True
            .Columns("UpdatedDate").ReadOnly = True
            .Columns("Status").ReadOnly = True
        End With
    End Sub
    Private Sub LoadBrokers()
        Dim query As String = "SELECT DISTINCT UserName FROM Registrarss ORDER BY Broker"

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, con)
                con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                documenttype_cb.Items.Clear()
                While reader.Read()
                    documenttype_cb.Items.Add(reader("Broker").ToString())
                End While
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
    End Sub

    Private Sub Submit_buto_Click(sender As Object, e As EventArgs) Handles Submit_buto.Click
        Try
            DataGridView1.EndEdit()
            adapter.update(dt)
            MessageBox.Show("Changes saved successfully.")
            LoadData()
        Catch ex As SqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub documenttype_cb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles documenttype_cb.SelectedIndexChanged

    End Sub

    Private Sub certificatenumber_labo_Click(sender As Object, e As EventArgs) Handles certificatenumber_labo.Click

    End Sub
End Class
