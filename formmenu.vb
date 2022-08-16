Imports System.Data.Odbc
Public Class formmenu
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = " Pilih Data Yang Diupdate" Then
            Button2.Text = " Update Data"
            RadioButton1.Enabled = True
            RButton2.Enabled = True
            GunaRadioButton1.Enabled = True
        Else
            If RadioButton1.Checked = True Then
                Form2.ShowDialog()
            ElseIf RButton2.Checked = True Then
                matakuliah.ShowDialog()
            Else
                ruangan.ShowDialog()

            End If
            RadioButton1.Enabled = False
            RButton2.Enabled = False
            GunaRadioButton1.Enabled = False
            Button2.Text = " Pilih Data Yang Diupdate"

        End If
    End Sub

    Private Sub btncari_Click(sender As Object, e As EventArgs) Handles btncari.Click
        Call koneksi()

        If Button1.Text = "  Data Pegawai" Then
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
            Else
                MsgBox("Data Tidak Ditemukan....", "pesan")
            End If
        ElseIf Button3.Text = "  Mata Kuliah" Then
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
            Else
                MsgBox("Data Tidak Ditemukan...", "pesan")
            End If
        ElseIf Button5.Text = "  Ruangan" Then
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
            Else
                MsgBox("Data Tidak Ditemukan...", "pesan")
            End If
        ElseIf Button6.Text = "  Jadwal" Then
            Dim str As String
            str = "SELECT r.Kode_Matakuliah, m.Matakuliah, m.SKS, r.Hari, r.Mulai, r.Selesai , m.Nama_Dosen FROM matkul AS m INNER JOIN ruangan AS r ON m.Kode_Matakuliah = r.Kode_Matakuliah Where r.Kode_Matakuliah like '%" & txtcari.Text & "%' or m.Matakuliah like '%" & txtcari.Text & "%' or m.SKS like '%" & txtcari.Text & "%' or r.Hari like '%" & txtcari.Text & "%' or r.Mulai like '%" & txtcari.Text & "%' or r.Selesai like '%" & txtcari.Text & "%' or m.Nama_Dosenlike '%" & txtcari.Text & "%'"
            Cmd = New OdbcCommand(str, Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                Da = New OdbcDataAdapter("SELECT r.Kode_Matakuliah, m.Matakuliah, m.SKS, r.Hari, r.Mulai, r.Selesai , m.Nama_Dosen FROM matkul AS m INNER JOIN ruangan AS r ON m.Kode_Matakuliah = r.Kode_Matakuliah Where r.Kode_Matakuliah like '%" & txtcari.Text & "%' or m.Matakuliah like '%" & txtcari.Text & "%' or m.SKS like '%" & txtcari.Text & "%' or r.Hari like '%" & txtcari.Text & "%' or r.Mulai like '%" & txtcari.Text & "%' or r.Selesai like '%" & txtcari.Text & "%' or m.Nama_Dosenlike '%" & txtcari.Text & "%'", Conn)
                Ds = New DataSet
                Da.Fill(Ds, "matkul")
                DataGridView1.DataSource = Ds.Tables("matkul")
                DataGridView1.ReadOnly = True
            Else
                MsgBox("Data Tidak Ditemukan....", "pesan")
            End If

        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub
End Class