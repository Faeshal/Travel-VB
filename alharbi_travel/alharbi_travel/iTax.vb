Public Class iTax

    Public mcTax_Rate As Double = 0.75

    Public Function cFindTax(ByVal cAmount As Double) As Double
        cFindTax = cAmount - (cAmount * mcTax_Rate)
    End Function
End Class
