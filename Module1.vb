Imports System.Data.Odbc
Module Module1
    Public Conn As OdbcConnection
    Public Da As OdbcDataAdapter
    Public Rd As OdbcDataReader
    Public Ds As DataSet
    Public Cmd As OdbcCommand
    Public Mydb As String
    Public Sub koneksi()
        Mydb = "Driver={Mysql ODBC 3.51 Driver};Database=penjadwalan;server=localhost;uid=root;"
        Conn = New OdbcConnection(Mydb)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub
End Module
