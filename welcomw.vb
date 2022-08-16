Public Class welcomw
    Private Sub btnkeluar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs)
        Form1.ShowDialog()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub welcomw_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub buton1_Click(sender As Object, e As EventArgs) Handles buton1.Click
        Me.Hide()
        Dim dr As DialogResult
        Dim f As New Form1()
        dr = f.ShowDialog()
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        jadwal.ShowDialog()
    End Sub
End Class