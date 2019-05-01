Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim OBJEREP As New CrystalReport1
        CrystalReportViewer1.ReportSource = OBJEREP
    End Sub
End Class