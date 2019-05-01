
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TECAirlinesDBDataSet.EMAIL_CONFIRMATION' table. You can move, or remove it, as needed.
        Me.EMAIL_CONFIRMATIONTableAdapter.Fill(Me.TECAirlinesDBDataSet.EMAIL_CONFIRMATION)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.Show()
    End Sub
End Class