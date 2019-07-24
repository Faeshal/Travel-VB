Imports System.Data.Odbc
Public Class Form1
    Dim bergerak As Integer
    Dim tulisan As String
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
        DA.Fill(DS, "tbl_mahasiswa")

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        rtReceipt.Clear()
        txtFirstname.Clear()
        txtPostCode.Clear()
        txtEmail.Clear()
        txtTelephone.Clear()
        txtSurename.Clear()
        txtAddress.Clear()

        lblSubtotal.Text = "None"
        lblTax.Text = "None"
        lblTotal.Text = "None"

        cmbAccommodation.Text = "Select ..."
        cmbDeparture.Text = "Select ..."
        cmbDestination.Text = "Select ..."
        cmbAirlines.Text = "Select ..."

        rbSpecial.Checked = False



        rbReturn.Checked = False
        rbSingle.Checked = False

        rbEconomy.Checked = False
        rbFirstClass.Checked = False
        rbStandard.Checked = False

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblTime.Text = TimeOfDay
        lblDate.Text = Today
    End Sub
    Private Sub btnReceipt_Click(sender As Object, e As EventArgs) Handles btnReceipt.Click

        rtReceipt.AppendText(vbTab + "    ALHARBI TRAVEL AGENCY" + vbNewLine)
        rtReceipt.AppendText("===============================" + vbNewLine)
        rtReceipt.AppendText("FirstName" + vbTab + txtFirstname.Text + vbNewLine)
        rtReceipt.AppendText("ID Code" + vbTab + txtSurename.Text + vbNewLine)
        rtReceipt.AppendText("Adress" + vbTab + txtAddress.Text + vbNewLine)
        rtReceipt.AppendText("Post Code" + vbTab + txtPostCode.Text + vbNewLine)
        rtReceipt.AppendText("Telephone" + vbTab + txtTelephone.Text + vbNewLine)
        rtReceipt.AppendText("Email" + vbTab + vbTab + txtEmail.Text + vbNewLine)
        rtReceipt.AppendText("Departure" + vbTab + cmbDeparture.Text + vbNewLine)
        rtReceipt.AppendText("Destination" + vbTab + cmbDestination.Text + vbNewLine)
        rtReceipt.AppendText("Accommo" + vbTab + cmbAccommodation.Text + vbNewLine)
        rtReceipt.AppendText("Airlines" + vbTab + cmbAirlines.Text + vbNewLine)
        rtReceipt.AppendText("Date" + vbTab + vbTab + DateTimePicker1.Text + vbNewLine)
        rtReceipt.AppendText("---------------------------------------------------" + vbNewLine)
        rtReceipt.AppendText("Tax" + vbTab + vbTab + lblTax.Text + vbNewLine)
        rtReceipt.AppendText("SubTotal" + vbTab + lblSubtotal.Text + vbNewLine)
        rtReceipt.AppendText("Total" + vbTab + vbTab + lblTotal.Text + vbNewLine)
        rtReceipt.AppendText("---------------------------------------------------" + vbNewLine)
        rtReceipt.AppendText(vbTab + "  " + lblTime.Text + vbTab + lblDate.Text + vbNewLine)
        rtReceipt.AppendText("     Thank You For Using Our Services" + vbNewLine)
        rtReceipt.AppendText("---------------------------------------------------" + vbNewLine)

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Travelprice As New cPrice
        Dim AirTax As New iTax
        Dim TravelCost, TaxCost, Total As Double

        Dim AirportCost As Double = Travelprice.Airport_Tax + Travelprice.Air_Miles + Travelprice.Insurance + Travelprice.Ext_Luggage

        If (cmbDestination.Text = "Riyadh , Saudi Arabia") And (rbStandard.Checked = True) And (rbSingle.Checked = True) Then
            TravelCost = Travelprice.Riyadh + Travelprice.Std_Flight + AirportCost + Travelprice.Acc_Single
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Riyadh , Saudi Arabia") And (rbStandard.Checked = True) And (rbReturn.Checked = True) Then
            TravelCost = Travelprice.Riyadh + Travelprice.Std_Flight + AirportCost + Travelprice.Acc_Public
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Riyadh , Saudi Arabia") And (rbStandard.Checked = True) And (rbSpecial.Checked = True) Then
            TravelCost = Travelprice.Riyadh + Travelprice.Std_Flight + AirportCost + Travelprice.Acc_Extra
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)



        ElseIf (cmbDestination.Text = "Riyadh , Saudi Arabia") And (rbEconomy.Checked = True) And (rbSingle.Checked = True) Then
            TravelCost = Travelprice.Riyadh + Travelprice.Eco_Flight + AirportCost + Travelprice.Acc_Single
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Riyadh , Saudi Arabia") And (rbEconomy.Checked = True) And (rbReturn.Checked = True) Then
            TravelCost = Travelprice.Riyadh + Travelprice.Eco_Flight + AirportCost + +Travelprice.Acc_Public
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Riyadh , Saudi Arabia") And (rbEconomy.Checked = True) And (rbSpecial.Checked = True) Then
            TravelCost = Travelprice.Riyadh + Travelprice.Eco_Flight + AirportCost + Travelprice.Acc_Extra
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Riyadh , Saudi Arabia") And (rbFirstClass.Checked = True) And (rbSingle.Checked = True) Then
            TravelCost = Travelprice.Riyadh + Travelprice.Firstclass_Flight + AirportCost + Travelprice.Acc_Single
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)


        ElseIf (cmbDestination.Text = "Riyadh , Saudi Arabia") And (rbFirstClass.Checked = True) And (rbReturn.Checked = True) Then
            TravelCost = Travelprice.Riyadh + Travelprice.Firstclass_Flight + AirportCost + Travelprice.Acc_Public
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Riyadh , Saudi Arabia") And (rbFirstClass.Checked = True) And (rbSpecial.Checked = True) Then
            TravelCost = Travelprice.Riyadh + Travelprice.Firstclass_Flight + AirportCost + Travelprice.Acc_Extra
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)


        ElseIf (cmbDestination.Text = "Jeddah , Saudi Arabia") And (rbStandard.Checked = True) And (rbSingle.Checked = True) Then
            TravelCost = Travelprice.Jeddah + Travelprice.Std_Flight + AirportCost + Travelprice.Acc_Single
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Jeddah , Saudi Arabia") And (rbStandard.Checked = True) And (rbReturn.Checked = True) Then
            TravelCost = Travelprice.Jeddah + Travelprice.Std_Flight + AirportCost + Travelprice.Acc_Public
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Jeddah , Saudi Arabia") And (rbStandard.Checked = True) And (rbSpecial.Checked = True) Then
            TravelCost = Travelprice.Jeddah + Travelprice.Std_Flight + AirportCost + Travelprice.Acc_Extra
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)



        ElseIf (cmbDestination.Text = "Jeddah , Saudi Arabia") And (rbEconomy.Checked = True) And (rbSingle.Checked = True) Then
            TravelCost = Travelprice.Jeddah + Travelprice.Eco_Flight + AirportCost + Travelprice.Acc_Single
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Jeddah , Saudi Arabia") And (rbEconomy.Checked = True) And (rbReturn.Checked = True) Then
            TravelCost = Travelprice.Jeddah + Travelprice.Eco_Flight + AirportCost + Travelprice.Acc_Public
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)
        ElseIf (cmbDestination.Text = "Jeddah , Saudi Arabia") And (rbEconomy.Checked = True) And (rbSpecial.Checked = True) Then
            TravelCost = Travelprice.Jeddah + Travelprice.Eco_Flight + AirportCost + Travelprice.Acc_Extra
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Jeddah , Saudi Arabia") And (rbFirstClass.Checked = True) And (rbSingle.Checked = True) Then
            TravelCost = Travelprice.Jeddah + Travelprice.Firstclass_Flight + AirportCost + Travelprice.Acc_Single
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Jeddah , Saudi Arabia") And (rbFirstClass.Checked = True) And (rbReturn.Checked = True) Then
            TravelCost = Travelprice.Jeddah + Travelprice.Firstclass_Flight + AirportCost + Travelprice.Acc_Public
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Jeddah , Saudi Arabia") And (rbFirstClass.Checked = True) And (rbSpecial.Checked = True) Then
            TravelCost = Travelprice.Jeddah + Travelprice.Firstclass_Flight + AirportCost + Travelprice.Acc_Extra
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Medina, Saudi Arabia") And (rbStandard.Checked = True) And (rbSingle.Checked = True) Then
            TravelCost = Travelprice.Medina + Travelprice.Std_Flight + AirportCost + Travelprice.Acc_Single
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Medina, Saudi Arabia") And (rbStandard.Checked = True) And (rbReturn.Checked = True) Then
            TravelCost = Travelprice.Medina + Travelprice.Std_Flight + AirportCost + Travelprice.Acc_Public
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Medina, Saudi Arabia") And (rbStandard.Checked = True) And (rbSpecial.Checked = True) Then
            TravelCost = Travelprice.Medina + Travelprice.Std_Flight + AirportCost + Travelprice.Acc_Extra
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)



        ElseIf (cmbDestination.Text = "Medina, Saudi Arabia") And (rbEconomy.Checked = True) And (rbSingle.Checked = True) Then
            TravelCost = Travelprice.Medina + Travelprice.Eco_Flight + AirportCost + Travelprice.Acc_Single
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Medina, Saudi Arabia") And (rbEconomy.Checked = True) And (rbReturn.Checked = True) Then
            TravelCost = Travelprice.Medina + Travelprice.Eco_Flight + AirportCost + Travelprice.Acc_Public
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Medina, Saudi Arabia") And (rbEconomy.Checked = True) And (rbSpecial.Checked = True) Then
            TravelCost = Travelprice.Medina + Travelprice.Eco_Flight + AirportCost + Travelprice.Acc_Extra
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)



        ElseIf (cmbDestination.Text = "Medina, Saudi Arabia") And (rbFirstClass.Checked = True) And (rbSingle.Checked = True) Then
            TravelCost = Travelprice.Medina + Travelprice.Firstclass_Flight + Travelprice.Acc_Single
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Medina, Saudi Arabia") And (rbFirstClass.Checked = True) And (rbReturn.Checked = True) Then
            TravelCost = Travelprice.Medina + Travelprice.Firstclass_Flight + Travelprice.Acc_Public
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Medina, Saudi Arabia") And (rbFirstClass.Checked = True) And (rbSpecial.Checked = True) Then
            TravelCost = Travelprice.Medina + Travelprice.Firstclass_Flight + Travelprice.Acc_Extra
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)






        ElseIf (cmbDestination.Text = "Dubai, UAE") And (rbStandard.Checked = True) And (rbSingle.Checked = True) Then
            TravelCost = Travelprice.Dubai + Travelprice.Std_Flight + AirportCost + Travelprice.Acc_Single
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Dubai, UAE") And (rbStandard.Checked = True) And (rbReturn.Checked = True) Then
            TravelCost = Travelprice.Dubai + Travelprice.Std_Flight + AirportCost + Travelprice.Acc_Public
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Dubai, UAE") And (rbStandard.Checked = True) And (rbSpecial.Checked = True) Then
            TravelCost = Travelprice.Dubai + Travelprice.Std_Flight + AirportCost + Travelprice.Acc_Extra
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Dubai, UAE") And (rbEconomy.Checked = True) And (rbSingle.Checked = True) Then
            TravelCost = Travelprice.Dubai + Travelprice.Eco_Flight + AirportCost + Travelprice.Acc_Single
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Dubai, UAE") And (rbEconomy.Checked = True) And (rbReturn.Checked = True) Then
            TravelCost = Travelprice.Dubai + Travelprice.Eco_Flight + AirportCost + Travelprice.Acc_Public
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Dubai, UAE") And (rbEconomy.Checked = True) And (rbSpecial.Checked = True) Then
            TravelCost = Travelprice.Dubai + Travelprice.Eco_Flight + AirportCost + Travelprice.Acc_Extra
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Dubai, UAE") And (rbFirstClass.Checked = True) And (rbSingle.Checked = True) Then
            TravelCost = Travelprice.Dubai + Travelprice.Firstclass_Flight + AirportCost + Travelprice.Acc_Single
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Dubai, UAE") And (rbFirstClass.Checked = True) And (rbReturn.Checked = True) Then
            TravelCost = Travelprice.Dubai + Travelprice.Firstclass_Flight + AirportCost + Travelprice.Acc_Public
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Dubai, UAE") And (rbFirstClass.Checked = True) And (rbSpecial.Checked = True) Then
            TravelCost = Travelprice.Dubai + Travelprice.Firstclass_Flight + AirportCost + Travelprice.Acc_Extra
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)






        ElseIf (cmbDestination.Text = "Cairo,Egypt") And (rbStandard.Checked = True) And (rbSingle.Checked = True) Then
            TravelCost = Travelprice.Cairo + Travelprice.Std_Flight + AirportCost + Travelprice.Acc_Single
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Cairo,Egypt") And (rbStandard.Checked = True) And (rbReturn.Checked = True) Then
            TravelCost = Travelprice.Cairo + Travelprice.Std_Flight + AirportCost + Travelprice.Acc_Public
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)


        ElseIf (cmbDestination.Text = "Cairo,Egypt") And (rbStandard.Checked = True) And (rbSpecial.Checked = True) Then
            TravelCost = Travelprice.Cairo + Travelprice.Std_Flight + AirportCost + Travelprice.Acc_Extra
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)


        ElseIf (cmbDestination.Text = "Cairo,Egypt") And (rbEconomy.Checked = True) And (rbSingle.Checked = True) Then
            TravelCost = Travelprice.Cairo + Travelprice.Eco_Flight + AirportCost + Travelprice.Acc_Single
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)


        ElseIf (cmbDestination.Text = "Cairo,Egypt") And (rbEconomy.Checked = True) And (rbReturn.Checked = True) Then
            TravelCost = Travelprice.Cairo + Travelprice.Eco_Flight + AirportCost + Travelprice.Acc_Public
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)


        ElseIf (cmbDestination.Text = "Cairo,Egypt") And (rbEconomy.Checked = True) And (rbSpecial.Checked = True) Then
            TravelCost = Travelprice.Cairo + Travelprice.Eco_Flight + AirportCost + Travelprice.Acc_Extra
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Cairo,Egypt") And (rbFirstClass.Checked = True) And (rbSingle.Checked = True) Then
            TravelCost = Travelprice.Cairo + Travelprice.Firstclass_Flight + AirportCost + Travelprice.Acc_Single
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Cairo,Egypt") And (rbFirstClass.Checked = True) And (rbReturn.Checked = True) Then
            TravelCost = Travelprice.Cairo + Travelprice.Firstclass_Flight + AirportCost + Travelprice.Acc_Public
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)

        ElseIf (cmbDestination.Text = "Cairo,Egypt") And (rbFirstClass.Checked = True) And (rbSpecial.Checked = True) Then
            TravelCost = Travelprice.Cairo + Travelprice.Firstclass_Flight + AirportCost + Travelprice.Acc_Extra
            TaxCost = AirTax.cFindTax(TravelCost)
            Total = TravelCost + TaxCost

            lblTax.Text = FormatCurrency(TaxCost)
            lblSubtotal.Text = FormatCurrency(TravelCost)
            lblTotal.Text = FormatCurrency(Total)



        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tulisan = Label21.Text

        rbSingle.Checked = False


    End Sub

    Private Sub rtReceipt_TextChanged(sender As Object, e As EventArgs) Handles rtReceipt.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        Label21.Text = bergerak
        tulisan = Microsoft.VisualBasic.Right(tulisan, Len(tulisan) - 1) & Microsoft.VisualBasic.Left(tulisan, 1)
        Label21.Text = tulisan
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PrintDocument1.Print()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If rtReceipt.Text = "" Then
            MsgBox("Please,Complete the Registration,and press Total then Report")
        Else
            PrintPreviewDialog1.ShowDialog()
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim font1 As New Font("Arial", 16, FontStyle.Regular)
        e.Graphics.DrawString(rtReceipt.Text, Font, Brushes.Black, 100, 100)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        rtmessage.Clear()
        rtadvice.Clear()
        txtid.Clear()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (txtid.Text = "") Then
            MsgBox(" Please Enter Your ID Code", MsgBoxStyle.Critical, "Warning")
        ElseIf (rtadvice.Text = "") Then
            MsgBox(" Please Type Your Advice", MsgBoxStyle.Critical, "Warning")
        ElseIf (rtmessage.Text = "") Then
            MsgBox("  Please Type Your Message", MsgBoxStyle.Critical, "Warning")
        Else
            MsgBox("Message Was Send", MsgBoxStyle.Information, "Information")
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Label26.Visible = Not Label26.Visible
    End Sub

    Private Sub DataToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Form2.Show()
        Me.Hide()

    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        If txtFirstname.Text = "" Or txtSurename.Text = "" Or txtAddress.Text = "" Or txtPostCode.Text = "" Or txtTelephone.Text = "" Or txtEmail.Text = "" Then
            MsgBox("Silahkan Isi Semua Form")
        Else
            Call Koneksi()
            If rbStandard.Checked = True Then
                kelas = rbStandard.Text
            ElseIf rbEconomy.Checked = True Then
                kelas = rbEconomy.Text
            ElseIf rbFirstClass.Checked = True Then
                kelas = rbFirstClass.Text
            End If

            If rbSingle.Checked = True Then
                ticket = rbSingle.Text
            ElseIf rbReturn.Checked = True Then
                ticket = rbReturn.Text
            ElseIf rbSpecial.Checked = True Then
                ticket = rbSpecial.Text
            End If

            If rbAdult.Checked = True Then
                classify = rbAdult.Text
            ElseIf rbChild.Checked = True Then
                classify = rbChild.Text
            ElseIf rbDis.Checked = True Then
                classify = rbDis.Text
            End If



            Dim simpan As String = "insert into travel values ('" & txtFirstname.Text & "','" & txtSurename.Text & "','" & txtAddress.Text & "','" & txtPostCode.Text & "','" & txtTelephone.Text & "','" & txtEmail.Text & "','" & cmbDeparture.Text & "','" & cmbDestination.Text & "','" & cmbAccommodation.Text & "','" & cmbAirlines.Text & "','" & txreturn.Text & "','" & DateTimePicker1.Text & "','" & kelas & "','" & ticket & "','" & classify & "')"
            CMD = New OdbcCommand(simpan, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Input data berhasil")
            Call KosongkanData()
            Call TampilGrid()

        End If
    End Sub
    Sub KosongkanData()
        txtFirstname.Text = ""
        txtSurename.Text = ""
        txtAddress.Text = ""
        txtPostCode.Text = ""
        txtTelephone.Text = ""
        txtEmail.Text = ""
        lblSubtotal.Text = ""
        lblTax.Text = ""
        lblTotal.Text = ""

        cmbAccommodation.Text = "Select ..."
        cmbDeparture.Text = "Select ..."
        cmbDestination.Text = "Select ..."
        cmbAirlines.Text = "Select ..."
        rbStandard.Checked = False
        rbEconomy.Checked = False
        rbFirstClass.Checked = False
        rbSingle.Checked = False
        rbReturn.Checked = False
        rbSpecial.Checked = False
        rbAdult.Checked = False
        rbChild.Checked = False
        rbDis.Checked = False

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

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Form2.Show()
        Me.Hide()
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


End Class
