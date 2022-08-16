Imports System.Data.Odbc
Public Class jadwal
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
    Sub tampil()

        Da = New OdbcDataAdapter("SELECT r.Kode_Matakuliah, m.Matakuliah, m.SKS, r.Ruangan, r.Hari, r.Mulai, r.Selesai , m.Nama_Dosen FROM matkul AS m INNER JOIN ruangan AS r ON m.Kode_Matakuliah = r.Kode_Matakuliah", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "matkul")
        DataGridView1.DataSource = Ds.Tables("matkul")
        DataGridView1.ReadOnly = True
    End Sub
    Private Sub jadwal_Load(sender As Object, e As EventArgs)

    End Sub
    Sub semester()
        Dim a As Integer
        For a = 1 To 6
            cmbsmster.Items.Add(a)
        Next

    End Sub
    Sub prodi()
        ComboBox2.Items.Add("Sistem Informasi")
        ComboBox2.Items.Add("Teknik Informatika")
        ComboBox2.Items.Add("Manajemen Informasi")
        ComboBox2.Items.Add("Rekayasa Perangkat Lunak")
    End Sub
    Sub kosong()
        ComboBox2.Items.Remove("Sistem Informasi")
        ComboBox2.Items.Remove("Teknik Informatika")
        ComboBox2.Items.Remove("Manajemen Informasi")
        ComboBox2.Items.Remove("Rekayasa Perangkat Lunak")
    End Sub
    Private Sub btncari_Click(sender As Object, e As EventArgs) Handles btncari.Click
        Call koneksi()
        Dim str As String
        str = "SELECT r.Kode_Matakuliah, m.Matakuliah, m.SKS, r.Ruangan, r.Hari, r.Mulai, r.Selesai , m.Nama_Dosen FROM matkul AS m INNER JOIN ruangan AS r ON m.Kode_Matakuliah = r.Kode_Matakuliah Where r.Kode_Matakuliah like '%" & txtcari.Text & "%' or m.Matakuliah like '%" & txtcari.Text & "%' or m.SKS like '%" & txtcari.Text & "%' or r.Hari like '%" & txtcari.Text & "%' or r.Ruangan like '%" & txtcari.Text & "%' or r.Mulai like '%" & txtcari.Text & "%' or r.Selesai like '%" & txtcari.Text & "%' or m.Nama_Dosen like '%" & txtcari.Text & "%'"
        Cmd = New OdbcCommand(str, Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            MsgBox("Data Tidak Ditemukan....")
        Else
            Da = New OdbcDataAdapter("SELECT r.Kode_Matakuliah, m.Matakuliah, r.Ruangan, m.SKS, r.Hari, r.Mulai, r.Selesai , m.Nama_Dosen FROM matkul AS m INNER JOIN ruangan AS r ON m.Kode_Matakuliah = r.Kode_Matakuliah Where r.Kode_Matakuliah like '%" & txtcari.Text & "%' or m.Matakuliah like '%" & txtcari.Text & "%' or m.SKS like '%" & txtcari.Text & "%' or r.Hari like '%" & txtcari.Text & "%' or r.Ruangan like '%" & txtcari.Text & "%' or r.Mulai like '%" & txtcari.Text & "%' or r.Selesai like '%" & txtcari.Text & "%' or m.Nama_Dosen like '%" & txtcari.Text & "%'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "matkul")
            DataGridView1.DataSource = Ds.Tables("matkul")
            DataGridView1.ReadOnly = True
        End If

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        If btnkeluar.Text = "Cek Jadwal" Then
            If TextBox1.Text = "" Then
                MsgBox("Silahkan Isi Field Yang Kosong")
            Else
                btnkeluar.Text = "Selesai"
                Dim str As String
                str = "SELECT r.Kode_Matakuliah, m.Matakuliah, m.SKS, r.Ruangan, r.Hari, r.Mulai, r.Selesai , m.Nama_Dosen FROM matkul AS m INNER JOIN ruangan AS r ON m.Kode_Matakuliah = r.Kode_Matakuliah Where m.Kelas ='" & TextBox1.Text & "' And m.Prodi = '" & ComboBox2.Text & "' And m.Semester = '" & cmbsmster.Text & "' "
                Cmd = New OdbcCommand(str, Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Not Rd.HasRows Then
                    MsgBox("Data Tidak Ditemukan....")
                Else
                    Da = New OdbcDataAdapter("SELECT r.Kode_Matakuliah, m.Matakuliah, m.SKS, r.Ruangan, r.Hari, r.Mulai, r.Selesai , m.Nama_Dosen FROM matkul AS m INNER JOIN ruangan AS r ON m.Kode_Matakuliah = r.Kode_Matakuliah Where m.Kelas ='" & TextBox1.Text & "' And m.Prodi = '" & ComboBox2.Text & "' And m.Semester = '" & cmbsmster.Text & "'", Conn)
                    Ds = New DataSet
                    Da.Fill(Ds, "matkul")
                    DataGridView1.DataSource = Ds.Tables("matkul")
                    DataGridView1.ReadOnly = True
                End If

            End If
        Else
            Call tampil()
            btnkeluar.Text = "Cek Jadwal"
            TextBox1.Text = ""
            TextBox1.Focus()
            ComboBox2.Text = "Sistem Informasi"
            cmbsmster.Text = "1"
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub jadwal_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        Call koneksi()
        Call tampil()
        Call kosong()
        Call prodi()
        Call semester()
    End Sub

    Private Sub GunaComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsmster.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox2.KeyPress

    End Sub
End Class