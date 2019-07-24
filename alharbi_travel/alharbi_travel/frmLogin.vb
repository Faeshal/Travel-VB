Imports System.Data.Odbc
Public Class frmLogin
    Dim CONN As OdbcConnection
    Dim CMD As OdbcCommand
    Dim DS As New DataSet
    Dim DA As OdbcDataAdapter
    Dim RD As OdbcDataReader
    Dim LokasiData As String

    Sub Koneksi()
        LokasiData = "Driver={MySQL ODBC 3.51 Driver};Database=travel;server=localhost;uid=root"
        CONN = New OdbcConnection(LokasiData)
        If CONN.State = ConnectionState.Closed Then
            CONN.Open()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call Koneksi()

        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("data login belum lengkap")

        Else

            Call Koneksi()
            CMD = New OdbcCommand("select * from login where user='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()
            If RD.HasRows Then
                Form1.Show()
            Else
                MsgBox("User & Password Wrong")
            End If

        End If
        Call reset()

    End Sub

    Sub reset()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End

    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class