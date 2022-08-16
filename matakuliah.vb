Imports System.Data.Odbc
Public Class matakuliah
    Sub matakuliah()

        cmbmatkul.Items.Add("Bahasa Inggris I")
        cmbmatkul.Items.Add("Bahasa Inggris 2")
        cmbmatkul.Items.Add("Matematika Komputer")
        cmbmatkul.Items.Add("Algoritma & Pemograman")
        cmbmatkul.Items.Add("Prak.Algoritma & Pemograman")
        cmbmatkul.Items.Add("Prak.Pemograman Visual.Net")
        cmbmatkul.Items.Add("Pemogrman Visual.Net")
        cmbmatkul.Items.Add("Pendidikan Agama Islam")
        cmbmatkul.Items.Add("Pendidikan Agama Protestan")
        cmbmatkul.Items.Add("Pendidikan Agama Hindu")
        cmbmatkul.Items.Add("Pendidikan Agama Budha")
        cmbmatkul.Items.Add("Pendidikan Pamcasila Dan Kewarganegaraan")
        cmbmatkul.Items.Add("Elektronika Analog")
        cmbmatkul.Items.Add("Desan Grafis & Multimedia")
        cmbmatkul.Items.Add("Pendidikan Agama Katolik")
        cmbmatkul.Items.Add("Kalkulus I")
        cmbmatkul.Items.Add("Statistika")
        cmbmatkul.Items.Add("Pengantar Forensik")
        cmbmatkul.Items.Add("Interaksi Manusia dan komputer")

    End Sub
    Sub kosong()
        TextBox1.Text = ""
        cmbmatkul.Text = "Bahasa Inggris I"
        cmbmatkul.Focus()
        ComboBox2.Text = "Sistem Informasi"
        ComboBox3.Text = "1"
        ComboBox4.Text = "A"
        txtsks.Text = ""
        kd.Text = ""
    End Sub
    Sub Cari()
        Dim str As String
        str = "SELECT * from matkul where Kode_Matakuliah like '%" & txtcari.Text & "%' or Matakuliah like '%" & txtcari.Text & "%' or Nama_Dosen like '%" & txtcari.Text & "%' or SKS like '%" & txtcari.Text & "%' Or Kelas like '%" & txtcari.Text & "%' or Prodi  like '%" & txtcari.Text & "%' or Semester  like '%" & txtcari.Text & "%'"
        Cmd = New OdbcCommand(str, Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Da = New OdbcDataAdapter("SELECT * from matkul where Kode_Matakuliah like '%" & txtcari.Text & "%' or Matakuliah like '%" & txtcari.Text & "%' or Nama_Dosen like '%" & txtcari.Text & "%' or SKS like '%" & txtcari.Text & "%' Or Kelas like '%" & txtcari.Text & "%' or Prodi  like '%" & txtcari.Text & "%' or Semester  like '%" & txtcari.Text & "%'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "matkul")
            DataGridView1.DataSource = Ds.Tables("matkul")
            DataGridView1.ReadOnly = True
        End If
    End Sub
    Sub updatedata()

        Try

            Call koneksi()
            Dim str As String

            str = "Update matkul set  SKS = '" & txtsks.Text & "', Nama_Dosen = '" & ComboBox1.Text & "' where Kode_Matakuliah = '" & kd.Text & "'"

            Cmd = New OdbcCommand(str, Conn)

            Cmd.ExecuteNonQuery()

            MessageBox.Show("Update Data Siswa Berhasil Dilakukan.")

        Catch ex As Exception

            MessageBox.Show("Update data gagal dilakukan")

        End Try

    End Sub
    Sub CariKode()
        On Error Resume Next
        Dim kode As String
        Dim urutan As String
        Dim hitung As Long

        If cmbmatkul.Text = "Bahasa Inggris I" Then
            cmbmatkul1.Text = "000"
        ElseIf cmbmatkul.Text = "Bahasa Inggris 2" Then
            cmbmatkul1.Text = "001"
        ElseIf cmbmatkul.Text = "Matematika Komputer" Then
            cmbmatkul1.Text = "002"
        ElseIf cmbmatkul.Text = "Algoritma & Pemograman" Then
            cmbmatkul1.Text = "003"
        ElseIf cmbmatkul.Text = "Prak.Algoritma & Pemograman" Then
            cmbmatkul1.Text = "005"
        ElseIf cmbmatkul.Text = "Prak.Pemograman Visual.Net" Then
            cmbmatkul1.Text = "006"
        ElseIf cmbmatkul.Text = "Pemogrman Visual.Net" Then
            cmbmatkul1.Text = "007"
        ElseIf cmbmatkul.Text = "Pendidikan Agama Islam" Then
            cmbmatkul1.Text = "008"
        ElseIf cmbmatkul.Text = "Pendidikan Agama Protestan" Then
            cmbmatkul1.Text = "009"
        ElseIf cmbmatkul.Text = "Pendidikan Agama Budha" Then
            cmbmatkul1.Text = "010"
        ElseIf cmbmatkul.Text = "Pendidikan Agama Katholik" Then
            cmbmatkul1.Text = "020"
        ElseIf cmbmatkul.Text = "Pendidikan Agama Hindu" Then
            cmbmatkul1.Text = "030"
        ElseIf cmbmatkul.Text = "Pendidikan Pamcasila Dan Kewarganegaraan" Then
            cmbmatkul1.Text = "040"
        ElseIf cmbmatkul.Text = "Elektronika Analog" Then
            cmbmatkul1.Text = "050"
        ElseIf cmbmatkul.Text = "Desan Grafis & Multimedia" Then
            cmbmatkul1.Text = "060"
        ElseIf cmbmatkul.Text = "Kalkulus I" Then
            cmbmatkul1.Text = "080"
        ElseIf cmbmatkul.Text = "Statistika" Then
            cmbmatkul1.Text = "090"
        ElseIf cmbmatkul.Text = "Pengantar Forensik" Then
            cmbmatkul1.Text = "011"
        ElseIf cmbmatkul.Text = "Interaksi Manusia dan komputer" Then
            cmbmatkul1.Text = "012"
        End If
        If ComboBox2.Text = "Sistem Informasi" Then
            kode = "SI" + ComboBox3.Text + "-" + ComboBox4.Text + cmbmatkul1.Text
        ElseIf ComboBox2.Text = "Teknik Informatika" Then
            kode = "TI" + ComboBox3.Text + "-" + ComboBox4.Text + cmbmatkul1.Text
        ElseIf ComboBox2.Text = "Manajemen Informasi" Then
            kode = "MI" + ComboBox3.Text + "-" + ComboBox4.Text + cmbmatkul1.Text
        Else
            kode = "RPL" + ComboBox3.Text + "-" + ComboBox4.Text + cmbmatkul1.Text
        End If
        TextBox1.Text = kode
    End Sub
    Sub awal()

        Call tampildata()
        Call kosong()

        Call mati()

        btntambah.Enabled = True

        btnhapus.Enabled = False

        btnbatal.Enabled = False

        btnkeluar.Enabled = True
        replacebtn.Enabled = True





    End Sub
    Sub hidup()

        cmbmatkul.Enabled = True
        txtsks.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
    End Sub

    Sub mati()
        cmbmatkul.Enabled = False
        txtsks.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        kd.Enabled = False


    End Sub
    Sub tampildata()

        Da = New OdbcDataAdapter("select *from matkul", Conn)

        Ds = New DataSet

        Ds.Clear()

        Da.Fill(Ds, "matkul")

        DataGridView1.DataSource = Ds.Tables("matkul")

        Conn.Close()

        Da.Dispose()

        Da.Dispose()

    End Sub
    Sub smester()
        ComboBox3.Items.Add("1")
        ComboBox3.Items.Add("2")
        ComboBox3.Items.Add("3")
        ComboBox3.Items.Add("4")
        ComboBox3.Items.Add("5")
        ComboBox3.Items.Add("6")
    End Sub
    Sub kls()
        ComboBox4.Items.Add("A")
        ComboBox4.Items.Add("B")
        ComboBox4.Items.Add("C")
        ComboBox4.Items.Add("D")
        ComboBox4.Items.Add("F")
        ComboBox4.Items.Add("G")
        ComboBox4.Items.Add("H")
        ComboBox4.Items.Add("I")
    End Sub
    Sub comboboxdosen()
        Call koneksi()
        Da = New Odbc.OdbcDataAdapter("SELECT Nama_Dosen,NIDN FROM Pegawai", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "matkul")
        ComboBox1.DataSource = (Ds.Tables("matkul"))
        Me.ComboBox1.ValueMember = "NIDN"
        Me.ComboBox1.DisplayMember = "Nama_Dosen"
    End Sub
    Sub prodi()
        ComboBox2.Items.Add("Sistem Informasi")
        ComboBox2.Items.Add("Teknik Informatika")
        ComboBox2.Items.Add("Manajemen Informasi")
        ComboBox2.Items.Add("Rekayasa Perangkat Lunak")
    End Sub
    Private Sub matakuliah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call comboboxdosen()
        Call koneksi()
        Call awal()
        Call prodi()
        Call smester()
        Call matakuliah()
        Call kls()
    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Call CariKode()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        MsgBox("Anda yakin ingin keluar", MsgBoxStyle.OkCancel, "pesan")
        If MsgBoxResult.Ok Then
            Close()
        End If
        formmenu.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub txtnama_TextChanged(sender As Object, e As EventArgs) Handles txtsks.TextChanged

    End Sub

    Private Sub txtnip_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        Call awal()

        Call kosong()

        Call mati()
        btntambah.Text = "Tambah"
        replacebtn.Text = "Edit"

    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If kd.Text = "" Then
            MsgBox("Field tidak boleh kosong!!!", MsgBoxStyle.Critical, "Pesan")

        Else
            Call koneksi()
            Mydb = "Delete from matkul where Kode_Matakuliah= '" & kd.Text & "'"
            Cmd = New OdbcCommand(Mydb, Conn)
            Cmd.ExecuteNonQuery()
            MsgBox("Data berhasil dihapus", MsgBoxStyle.OkOnly, "pesan")
            Call tampildata()
            Me.kd.Focus()
            Call kosong()
        End If

    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        If btntambah.Text = "Tambah" Then

            Call hidup()
            Call CariKode()
            cmbmatkul.Focus()
            btnhapus.Enabled = False
            btnbatal.Enabled = True
            btnkeluar.Enabled = True
            replacebtn.Enabled = False
            btntambah.Text = "Simpan"
        Else
            If txtsks.Text = "" Then
                MsgBox("Silahkan Isi Semua Field!", MsgBoxStyle.Critical, "Pesan")

            Else

                Call koneksi()
                Cmd = New OdbcCommand("Select * From matkul where Kode_Matakuliah = '" & TextBox1.Text & "' ", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows() Then
                    MsgBox("Data Sudah Ada!!!", MsgBoxStyle.Information, "pesan")
                Else
                    Mydb = "insert into matkul (Kode_Matakuliah, Matakuliah, SKS, Nama_Dosen, Prodi,Semester,Kelas) values('" & TextBox1.Text & "', '" & cmbmatkul.Text & "', '" & txtsks.Text & "', '" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & ComboBox4.Text & "' )"
                    Cmd = New OdbcCommand(Mydb, Conn)
                    Cmd.ExecuteNonQuery()
                    MsgBox("Data berhasil disimpan", MsgBoxStyle.Information, "Pesan")
                    Call tampildata()
                    cmbmatkul.Text = "Bahasa Inggris I"
                    cmbmatkul.Focus()
                    ComboBox2.Text = "Sistem Informasi"
                    txtsks.Text = ""
                    Call mati()

                End If
                btntambah.Text = "Tambah"
                cmbmatkul.Focus()
                btnhapus.Enabled = True
                btnbatal.Enabled = False
                btnkeluar.Enabled = True
                replacebtn.Enabled = True
            End If


        End If
    End Sub
    Sub matkul()


    End Sub
    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btncari.Click
        Call koneksi()
        Call Cari()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Call CariKode()
    End Sub

    Private Sub replacebtn_Click(sender As Object, e As EventArgs) Handles replacebtn.Click
        Call koneksi()
        If replacebtn.Text = "Edit" Then
            replacebtn.Text = "Selesai"
            MsgBox("Masukan Kode Matakuliah Yang Ingin Diubah Datanya 
            Pada Kolom !!!!Kode Data Yang Diedit!!!")
            btnhapus.Enabled = True
            btnbatal.Enabled = True
            btntambah.Enabled = False
            txtsks.Enabled = True
            ComboBox1.Enabled = True
            kd.Enabled = True
        Else
            btnhapus.Enabled = False
            btnbatal.Enabled = False
            btntambah.Enabled = True
            Call updatedata()
            Call tampildata()
            cmbmatkul.Text = "Bahasa Inggris I"
            cmbmatkul.Focus()
            ComboBox2.Text = "Sistem Informasi"
            txtsks.Text = ""
            kd.Text = ""
            replacebtn.Text = "Edit"
            kd.Enabled = False
            Call mati()
        End If
    End Sub


    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbmatkul.SelectedIndexChanged
        Call CariKode()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Call CariKode()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Call CariKode()
    End Sub

    Private Sub GunaVScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles GunaVScrollBar1.Scroll

    End Sub

    Private Sub txtcari_TextChanged(sender As Object, e As EventArgs) Handles txtcari.TextChanged

    End Sub

    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs) Handles Panel8.Paint

    End Sub
End Class