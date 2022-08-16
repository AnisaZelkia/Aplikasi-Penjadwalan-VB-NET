Imports System.Data
Imports System.Data.Odbc
Public Class Form2
    Sub hidup()

        txtnip.Enabled = True
        txtnama.Enabled = True
        TextBox2.Enabled = True
        TextBox4.Enabled = True
        RichTextBox1.Enabled = True
    End Sub
    Sub cari()
        Dim str As String
        str = "SELECT * from pegawai where NIDN like '%" & txtcari.Text & "%' or Nama_Dosen like '%" & txtcari.Text & "%' or Alamat like '%" & txtcari.Text & "%' or Telp like '%" & txtcari.Text & "%' Or Email like '%" & txtcari.Text & "%'"
        Cmd = New OdbcCommand(str, Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Da = New OdbcDataAdapter("SELECT * from pegawai where NIDN like '%" & txtcari.Text & "%' or Nama_Dosen like '%" & txtcari.Text & "%' or Alamat like '%" & txtcari.Text & "%' or Telp like '%" & txtcari.Text & "%' Or Email like '%" & txtcari.Text & "%'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "pegawai")
            DataGridView1.DataSource = Ds.Tables("pegawai")
            DataGridView1.ReadOnly = True
        End If
    End Sub
    Sub mati()
        txtnip.Enabled = False
        txtnama.Enabled = False
        TextBox2.Enabled = False
        TextBox4.Enabled = False
        RichTextBox1.Enabled = False
    End Sub

    Sub kosong()
        txtnip.Text = ""
        txtnama.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        RichTextBox1.Text = ""
    End Sub
    Sub updatedata()
        Try
            Call koneksi()
            Dim str As String
            str = "Update pegawai set  Nama_Dosen = '" & txtnama.Text & "', Alamat = '" & RichTextBox1.Text & "',  NIDN = '" & txtnip.Text & "', Telp  = '" & TextBox4.Text & "',  Email = '" & TextBox2.Text & "' where NIDN = '" & txtnip.Text & "'"
            Cmd = New OdbcCommand(str, Conn)
            Cmd.ExecuteNonQuery()
            MessageBox.Show("Update Data Siswa Berhasil Dilakukan.")

        Catch ex As Exception

            MessageBox.Show("Update data gagal dilakukan")

        End Try
    End Sub

    Sub tampil()
        txtnip.Text = Rd.Item("NIDN")
        txtnama.Text = Rd.Item("Nama")
        TextBox2.Text = Rd.Item("E-Mail")
        TextBox4.Text = Rd.Item("Telp")
        RichTextBox1.Text = Rd.Item("Alamat")
    End Sub
    Sub awal()

        Call tampildata()

        Call kosong()

        Call mati()

        btntambah.Enabled = True

        replacebtn.Enabled = False

        btnhapus.Enabled = False

        btnbatal.Enabled = False

        btnkeluar.Enabled = True
        replacebtn.Enabled = True

    End Sub
    Sub tampildata()

        Da = New OdbcDataAdapter("select *from pegawai", Conn)

        Ds = New DataSet

        Ds.Clear()

        Da.Fill(Ds, "pegawai")

        DataGridView1.DataSource = Ds.Tables("pegawai")

        Conn.Close()

        Da.Dispose()

        Da.Dispose()



    End Sub


    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
    Private Sub txtnip_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnip.KeyPress
        If Asc(e.KeyChar) = 13 Then

            txtnip.Focus()
            Call koneksi()
            Mydb = "select * from pegawai where NIDN = '" & txtnip.Text & "'"
            Cmd = New OdbcCommand(Mydb, Conn)
            Rd = Cmd.ExecuteReader
            If Rd.Read = True Then
                MsgBox("Data sudah ada!!!", MsgBoxStyle.Information, "pesan")
                Me.txtnip.Clear()
                Me.txtnip.Focus()
            End If

        End If
    End Sub

    Private Sub txtnama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnama.KeyPress
        If Asc(e.KeyChar) = 13 Then

            replacebtn.Focus()

        End If
    End Sub


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles replacebtn.Click
        Call koneksi()
        If replacebtn.Text = "Edit" Then
            replacebtn.Text = "Selesai"
            MsgBox("Masukan NIDN Dosen Yang Ingin Diubah Datanya")
            Call hidup()
            btntambah.Enabled = False
            btnhapus.Enabled = True
            btnbatal.Enabled = True
        Else
            replacebtn.Text = "Edit"

            Call updatedata()
            Call tampildata()
            btntambah.Enabled = True
            btnhapus.Enabled = False
            btnbatal.Enabled = False
            Call kosong()
            Call mati()

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        MsgBox("Anda yakin ingin keluar", MsgBoxStyle.OkCancel, "pesan")
        If MsgBoxResult.Ok Then
            Close()
        End If
        formmenu.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        Call koneksi()
        Mydb = "Delete from pegawai where NIDN = '" & txtnip.Text & "'"
        Cmd = New OdbcCommand(Mydb, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Data berhasil dihapus", MsgBoxStyle.OkOnly, "pesan")
        Call tampildata()
        Me.txtnip.Focus()
        txtnip.Clear()
        TextBox2.Clear()
        txtnama.Clear()
        TextBox4.Clear()
        RichTextBox1.Clear()
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        If btntambah.Text = "Tambah" Then
            btntambah.Text = "Simpan"
            Call hidup()
            btnhapus.Enabled = False
            btnbatal.Enabled = True
            btnkeluar.Enabled = True
            replacebtn.Enabled = False
        Else
            If txtnip.Text = "" Or RichTextBox1.Text = "" Or txtnama.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Then
                MsgBox("Silahkan Isi Semua Field!", MsgBoxStyle.Critical, "Pesan")

            Else

                Call koneksi()
                    Cmd = New OdbcCommand("Select * From pegawai where NIDN  = '" & txtnip.Text & "' ", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                If Rd.HasRows() Then
                    MsgBox("NIDN Tidak boleh Sama!!!", MsgBoxStyle.Information, "pesan")
                Else
                    Mydb = "insert into pegawai values('" & txtnip.Text & "', '" & txtnama.Text & "', '" & RichTextBox1.Text & "','" & TextBox4.Text & "', '" & TextBox2.Text & "' )"
                    Cmd = New OdbcCommand(Mydb, Conn)
                    Cmd.ExecuteNonQuery()
                    MsgBox("Data berhasil disimpan", MsgBoxStyle.Information, "pesan")
                    Call tampildata()
                    txtnip.Clear()
                    txtnama.Clear()
                    TextBox2.Clear()
                    TextBox4.Clear()
                    RichTextBox1.Clear()
                    txtnip.Focus()
                    Me.txtnip.Focus()
                    Me.txtnip.Clear()
                End If
                btntambah.Text = "Tambah"
                Call mati()
                btnhapus.Enabled = False
                btnbatal.Enabled = False
                btnkeluar.Enabled = False
                replacebtn.Enabled = True
            End If
            End If


    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        Call awal()
    End Sub


    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        Call awal()
        btntambah.Text = "Tambah"
        replacebtn.Text = "Edit"

        Call kosong()

        Call mati()


    End Sub

    Private Sub replacebtn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btncari_Click(sender As Object, e As EventArgs) Handles btncari.Click
        Call koneksi()
        Call Cari()
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub
End Class