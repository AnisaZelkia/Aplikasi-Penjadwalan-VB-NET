Imports System.Data.Odbc
Public Class ruangan
    Sub hidup()
        txtruangan.Enabled = True
        ComboBox1.Enabled = True
        ComboBox5.Enabled = True
        DateTimePicker2.Enabled = True
        DateTimePicker1.Enabled = True


    End Sub

    Sub mati()
        txtruangan.Enabled = False
        ComboBox1.Enabled = False
        ComboBox5.Enabled = False
        DateTimePicker2.Enabled = False
        DateTimePicker1.Enabled = False

    End Sub

    Sub kosong()
        txtruangan.Text = ""
        ComboBox1.Text = "Senin"
        ComboBox5.ResetText()
        DateTimePicker1.ResetText()
        DateTimePicker2.ResetText()
        txtruangan.Focus()
    End Sub
    Sub Cari()
        Dim str As String
        str = "SELECT * from ruangan where Ruangan like '%" & txtcari.Text & "%' or Kode_Matakuliah like '%" & txtcari.Text & "%' or Hari like '%" & txtcari.Text & "%' or Mulai like '%" & txtcari.Text & "%' Or Selesai like '%" & txtcari.Text & "%'"
        Cmd = New OdbcCommand(str, Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Da = New OdbcDataAdapter("SELECT * from ruangan where Ruangan like '%" & txtcari.Text & "%' or Kode_Matakuliah like '%" & txtcari.Text & "%' or Hari like '%" & txtcari.Text & "%' or Mulai like '%" & txtcari.Text & "%' Or Selesai like '%" & txtcari.Text & "%'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "ruangan")
            DataGridView1.DataSource = Ds.Tables("ruangan")
            DataGridView1.ReadOnly = True
        End If
    End Sub
    Sub awal()

        Call tampildata()

        Call kosong()

        Call mati()
        replacebtn.Enabled = True
        btntambah.Enabled = True

        btnhapus.Enabled = False

        btnbatal.Enabled = False

        btnkeluar.Enabled = True

    End Sub
    Sub tampildata()

        Da = New OdbcDataAdapter("select *from ruangan", Conn)

        Ds = New DataSet

        Ds.Clear()

        Da.Fill(Ds, "ruangan")

        DataGridView1.DataSource = Ds.Tables("ruangan")

        Conn.Close()

        Da.Dispose()

        Da.Dispose()


    End Sub

    Sub hari()
        ComboBox1.Items.Add("Senin")
        ComboBox1.Items.Add("Selasa")
        ComboBox1.Items.Add("Rabu")
        ComboBox1.Items.Add("Kamis")
        ComboBox1.Items.Add("Jumat")
        ComboBox1.Items.Add("Sabtu")
    End Sub
    Sub comboboxmatkul()
        Call koneksi()
        Da = New Odbc.OdbcDataAdapter("SELECT Kode_Matakuliah FROM matkul", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "matkul")
        ComboBox5.DataSource = (Ds.Tables("matkul"))
        Me.ComboBox5.ValueMember = "Kode_Matakuliah"
        Me.ComboBox5.DisplayMember = "Kode_Matakuliah"
    End Sub

    Private Sub GunaVScrollBar1_Scroll(sender As Object, e As ScrollEventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ruangan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        Call awal()
        Call hari()
        Call comboboxmatkul()

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GunaDateTimePicker1_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateTimePicker2_ValueChanged_1(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged

    End Sub


    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged

    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        Call koneksi()
        Mydb = "Delete from ruangan where Ruangan = '" & txtruangan.Text & "'"
        Cmd = New OdbcCommand(Mydb, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Data berhasil dihapus", MsgBoxStyle.OkOnly, "pesan")
        Call tampildata()
        Me.txtruangan.Focus()
        txtruangan.Clear()
        ComboBox1.Text = "Senin"

    End Sub
    Sub updatedata()


        Call koneksi()
            Dim str As String
            Cmd = New OdbcCommand("SELECT *FROM ruangan where Ruangan ='" & txtruangan.Text & "' AND Mulai = '" & DateTimePicker2.Text & "'  AND Hari = '" & ComboBox1.Text & "'  OR  Kode_Matakuliah = '" & ComboBox5.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
        If Rd.HasRows() Then
            MsgBox("Ruangan Sudah Diisi Silahkan Isi Ruangan yang lain Atau Masukan Waktu yang Berbeda !!!", MsgBoxStyle.Information, "Pesan")
        Else

            Try
                str = "Update ruangan set  Hari = '" & ComboBox1.Text & "', Kode_Matakuliah = '" & ComboBox5.Text & "', Mulai = '" & DateTimePicker2.Text & "', Selesai = '" & DateTimePicker1.Text & "' where Ruangan= '" & txtruangan.Text & "'"

                Cmd = New OdbcCommand(str, Conn)

                Cmd.ExecuteNonQuery()

                MessageBox.Show("Update Data Siswa Berhasil Dilakukan.")

            Catch ex As Exception

                MessageBox.Show("Update data gagal dilakukan")

            End Try
        End If
        End

    End Sub
    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        Call awal()


        Call kosong()

        Call mati()
        btntambah.Text = "Tambah"
        replacebtn.Text = "Edit"

    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles replacebtn.Click
        Call koneksi()
        If replacebtn.Text = "Edit" Then
            replacebtn.Text = "Selesai"
            btnhapus.Enabled = True
            btntambah.Enabled = False
            btnbatal.Enabled = True
            Call hidup()
        Else
            replacebtn.Text = "Edit"
            btnhapus.Enabled = False
            btntambah.Enabled = True
            btnbatal.Enabled = False
            Call updatedata()
            Call tampildata()
            Call kosong()
            Call mati()
        End If
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        MsgBox("Anda yakin ingin keluar", MsgBoxStyle.OkCancel, "pesan")
        If MsgBoxResult.Ok Then
            Close()
        End If
        formmenu.Show()
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        btnkeluar.Enabled = True
        If btntambah.Text = "Tambah" Then

            replacebtn.Enabled = False
            Call hidup()
            txtruangan.Focus()
            btnbatal.Enabled = True
            Call koneksi()
            btntambah.Text = "Simpan"
        Else
            If txtruangan.Text = "" Then

                MsgBox("Ruangan Belum diisi!", MsgBoxStyle.Critical, "Pesan")
            Else

                Cmd = New OdbcCommand("SELECT *FROM ruangan where Ruangan ='" & txtruangan.Text & "' AND Mulai = '" & DateTimePicker2.Text & "'  AND Hari = '" & ComboBox1.Text & "'  OR  Kode_Matakuliah = '" & ComboBox5.Text & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows() Then
                    MsgBox("Ruangan Sudah Diisi Silahkan Isi Ruangan yang lain Atau Masukan Waktu yang Berbeda !!!", MsgBoxStyle.Information, "Pesan")
                Else
                    Mydb = "insert into ruangan values('" & txtruangan.Text & "', '" & ComboBox5.Text & "','" & ComboBox1.Text & "' , '" & DateTimePicker2.Text & "','" & DateTimePicker1.Text & "')"
                    Cmd = New OdbcCommand(Mydb, Conn)
                    Cmd.ExecuteNonQuery()
                    MsgBox("Data berhasil disimpan", MsgBoxStyle.Information, "Pesan")
                    Call tampildata()
                    Call kosong()
                End If
                btntambah.Text = "Tambah"
                Call mati()
                btnhapus.Enabled = False
                btnbatal.Enabled = False
                btnkeluar.Enabled = True
                replacebtn.Enabled = True
            End If


        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub btncari_Click(sender As Object, e As EventArgs) Handles btncari.Click
        Call koneksi()
        Call Cari()
    End Sub
End Class