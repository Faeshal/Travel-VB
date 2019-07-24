Imports System.Data.Odbc
Public Class Form2
    Dim CONN As OdbcConnection
    Dim CMD As OdbcCommand
    Dim DS As New DataSet
    Dim DA As OdbcDataAdapter
    Dim RD As OdbcDataReader
    Dim LokasiData As String
    Dim kelas As String
    Dim ticket As String
    Dim classify As String





    Sub Koneksi()
        LokasiData = "Driver={MySQL ODBC 3.51 Driver};Database=travel;server=localhost;uid=root"
        CONN = New OdbcConnection(LokasiData)
        If CONN.State = ConnectionState.Closed Then
            CONN.Open()
        End If
    End Sub



    Sub TampilGrid()
        Call Koneksi()
        DA = New OdbcDataAdapter("select * From travel ", CONN)
        DS = New DataSet
        DA.Fill(DS, "travel")
        DataGridView1.DataSource = DS.Tables("travel")
        DataGridView1.ReadOnly = True
        DataGridView1.Refresh()

    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call TampilGrid()
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue
        DataGridView1.Columns(0).Width = 53
        DataGridView1.Columns(3).Width = 65
        DataGridView1.Columns(10).Width = 40

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Dim response As MsgBoxResult
        response = MsgBox("Are You Sure Want to LogOut??", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm")
        If response = MsgBoxResult.Yes Then
            Me.Hide()
            frmLogin.Show()
        ElseIf response = MsgBoxResult.No Then
            Exit Sub
        End If
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click
        Form1.Show()
        Me.Hide()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call Koneksi()

        If RadioButton1.Checked = True Then
            kelas = RadioButton1.Text
        ElseIf RadioButton2.Checked = True Then
            kelas = RadioButton2.Text
        ElseIf RadioButton3.Checked = True Then
            kelas = RadioButton3.Text
        End If

        If RadioButton4.Checked = True Then
            ticket = RadioButton4.Text
        ElseIf RadioButton5.Checked = True Then
            ticket = RadioButton5.Text
        ElseIf RadioButton6.Checked = True Then
            ticket = RadioButton6.Text
        End If

        If RadioButton7.Checked = True Then
            classify = RadioButton7.Text
        ElseIf RadioButton8.Checked = True Then
            classify = RadioButton8.Text
        ElseIf RadioButton9.Checked = True Then
            classify = RadioButton9.Text
        End If



        Dim edit As String = "update travel set nama='" & TextBox2.Text & "',address='" & TextBox3.Text & "',postcode='" & TextBox4.Text & "',phone='" & TextBox5.Text & "',email='" & TextBox6.Text & "',departure='" & ComboBox1.Text & "',destination='" & ComboBox2.Text & "',accomodation='" & ComboBox3.Text & "',airlines='" & ComboBox4.Text & "',ket='" & txreturn.Text & "', flight='" & DateTimePicker1.Text & "',class='" & kelas & "' ,ticket='" & ticket & "' ,classify='" & classify & "'  where noktp='" & TextBox1.Text & "'"
        CMD = New OdbcCommand(edit, CONN)
        CMD.ExecuteNonQuery()
        MsgBox("Data Berhasil diUpdate")
        Call TampilGrid()
        Call KosongkanData()
    End Sub
    Sub KosongkanData()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        txreturn.Text = ""

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""

        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
        RadioButton6.Checked = False
        RadioButton7.Checked = False
        RadioButton8.Checked = False
        RadioButton9.Checked = False

    End Sub

    Private Sub TextBox1_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        TextBox1.MaxLength = 6
        If e.KeyChar = Chr(13) Then
            Call Koneksi()
            CMD = New OdbcCommand("Select * From travel  where noktp='" & TextBox1.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()
            If Not RD.HasRows Then
                MsgBox("NO KTP Tidak Ada, Silahkan coba lagi!")
                TextBox1.Focus()
            Else
                TextBox2.Text = RD.Item("nama")
                TextBox3.Text = RD.Item("address")
                TextBox4.Text = RD.Item("postcode")
                TextBox5.Text = RD.Item("phone")
                TextBox6.Text = RD.Item("email")

                ComboBox1.Text = RD.Item("departure")
                ComboBox2.Text = RD.Item("destination")
                ComboBox3.Text = RD.Item("accomodation")
                ComboBox4.Text = RD.Item("airlines")
                txreturn.Text = RD.Item("ket")
                DateTimePicker1.Text = RD.Item("flight")






                If RD.Item("class") = "Standard" Then
                    RadioButton1.Checked = True
                ElseIf RD.Item("class") = "Economy" Then
                    RadioButton2.Checked = True
                Else
                    RadioButton3.Checked = True
                End If


                If RD.Item("ticket") = "Single" Then
                    RadioButton4.Checked = True
                ElseIf RD.Item("ticket") = "Return" Then
                    RadioButton5.Checked = True
                Else
                    RadioButton6.Checked = True
                End If

                If RD.Item("classify") = "Adult" Then
                    RadioButton7.Checked = True
                ElseIf RD.Item("classify") = "Child" Then
                    RadioButton8.Checked = True
                Else
                    RadioButton9.Checked = True
                End If
            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("Silahkan Pilih Data yang akan di hapus dengan Masukan NIM dan ENTER")
        Else
            If MessageBox.Show("Yakin akan dihapus..?", "", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Call Koneksi()
                Dim hapus As String = "delete From travel  where noktp='" & TextBox1.Text & "'"
                CMD = New OdbcCommand(hapus, CONN)
                CMD.ExecuteNonQuery()
                Call TampilGrid()
                Call KosongkanData()
            End If
        End If
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        Call Koneksi()
        CMD = New OdbcCommand("select * from travel where noktp like '%" & TextBox7.Text & "%'", CONN)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            Call Koneksi()
            DA = New OdbcDataAdapter("select * from travel where noktp like '%" & TextBox7.Text & "%'", CONN)
            DS = New DataSet
            DA.Fill(DS, "travel")
            DataGridView1.DataSource = DS.Tables("travel")
            DataGridView1.ReadOnly = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Dim response As MsgBoxResult
        response = MsgBox("Are You Sure Want to LogOut??", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm")
        If response = MsgBoxResult.Yes Then
            End
        ElseIf response = MsgBoxResult.No Then
            Exit Sub
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        Call Koneksi()
        CMD = New OdbcCommand("select * from travel where nama like '%" & TextBox8.Text & "%'", CONN)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            Call Koneksi()
            DA = New OdbcDataAdapter("select * from travel where nama like '%" & TextBox8.Text & "%'", CONN)
            DS = New DataSet
            DA.Fill(DS, "travel")
            DataGridView1.DataSource = DS.Tables("travel")
            DataGridView1.ReadOnly = True
        End If
    End Sub
End Class