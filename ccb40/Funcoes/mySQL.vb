Imports System.Globalization
Imports MySql.Data.MySqlClient
Module MySQL
    Public Conn As MySqlConnection

    Public Function MySQL_Conn() As MySqlConnection
        Try
            'Connect to database
            MySQL_Conn = New MySqlConnection
            MySQL_Conn.ConnectionString = My.Settings.ConnectionString
            MySQL_Conn = New MySqlConnection(MySQL_Conn.ConnectionString)

            MySQL_Conn.Open()
            My.Settings.ConectadoMySql = True
            MySQL_Select(MySQL_Conn, "SET lc_time_names = 'pt_BR';")

        Catch e As Exception

            My.Settings.ConectadoMySql = False
            MySQL_Conn = Nothing
        End Try
    End Function

    Public Function MySQL_Select(ByRef MySQL_Conn As MySqlConnection, ByVal strSQL As String) As DataTable

        Dim da As New MySqlDataAdapter(strSQL, MySQL_Conn)

        MySQL_Select = New DataTable
        If MySQL_Conn.State = ConnectionState.Closed Then
            MySQL_Conn.Open()
        End If
        '---preenche o dataset--
        Try
            da.Fill(MySQL_Select)
        Catch ex As Exception

        End Try
        '---fecha a conexao---
        'MySQL_Conn.Close()
    End Function

    Public Sub MySQL_cmd(ByRef MySQL_Conn As MySqlConnection, ByVal strSQL As String)
        'Update data
        Dim comm As MySqlCommand = New MySqlCommand()

        With comm
            .CommandType = CommandType.Text
            .CommandText = strSQL
            .Connection = MySQL_Conn
        End With
        'MySQL_Conn.Open()
        comm.ExecuteNonQuery() 'Executa SQL
        'MySQL_Conn.Close()

    End Sub
    Public Sub GravaLog(ByRef MySQL_Conn As MySqlConnection, ByRef Grupo As String, ByVal SubGrupo As String, ByVal objeto As String, ByVal Descricao As String)

        MySQL_cmd(MySQL_Conn, "INSERT INTO log (data,grupo,sub_grupo,objeto, descricao) VALUES ('" _
                  & Format(Now(), "yyyy-MM-dd hh:mm:ss") & "','" & Grupo & "','" & SubGrupo & "','" & objeto & "','" & Descricao & "')")

    End Sub

    Public Function RetiraAcento(ByVal Str As String) As String
        RetiraAcento = Replace(Str.ToUpper, "�", "A")
        RetiraAcento = Replace(RetiraAcento, "�", "A")
        RetiraAcento = Replace(RetiraAcento, "�", "A")
        RetiraAcento = Replace(RetiraAcento, "�", "A")
        RetiraAcento = Replace(RetiraAcento, "�", "E")
        RetiraAcento = Replace(RetiraAcento, "�", "E")
        RetiraAcento = Replace(RetiraAcento, "�", "I")
        RetiraAcento = Replace(RetiraAcento, "�", "O")
        RetiraAcento = Replace(RetiraAcento, "�", "O")
        RetiraAcento = Replace(RetiraAcento, "�", "U")
        RetiraAcento = Replace(RetiraAcento, "�", "C")
        RetiraAcento = RetiraAcento
        'Str = ace("�", "c").Replace("�", "a").Replace("�", "a").Replace("�", "a").Replace("�", "a").Replace("�", "a").Replace("�", "e").Replace("�", "e").Replace("�", "e").Replace("�", "e").Replace("�", "i").Replace("�", "i").Replace("�", "i").Replace("�", "i").Replace("�", "o").Replace("�", "o").Replace("�", "o").Replace("�", "o").Replace("�", "o").Replace("�", "u").Replace("�", "u").Replace("�", "u").Replace("�", "u").Replace("�", "y").Replace("�", "y").Replace("�", "c")
        'Str = Str.Replace("�", "a").Replace("�", "a").Replace("�", "a").Replace("�", "a").Replace("�", "a").Replace("�", "e").Replace("�", "e").Replace("�", "e").Replace("�", "e").Replace("�", "i").Replace("�", "i").Replace("�", "i").Replace("�", "i").Replace("�", "o").Replace("�", "o").Replace("�", "o").Replace("�", "o").Replace("�", "o").Replace("�", "u").Replace("�", "u").Replace("�", "u").Replace("�", "u").Replace("�", "y").Replace("�", "y").Replace("�", "nh").Replace("�", "c").Replace("�", "a").Replace("�", "a").Replace("�", "a").Replace("�", "a").Replace("�", "a").Replace("�", "e").Replace("�", "e").Replace("�", "e").Replace("�", "e").Replace("�", "i").Replace("�", "i").Replace("�", "i").Replace("�", "i").Replace("�", "o").Replace("�", "o").Replace("�", "o").Replace("�", "o").Replace("�", "o").Replace("�", "u").Replace("�", "u").Replace("�", "u").Replace("�", "u").Replace("�", "y").Replace("�", "y").Replace("�", "c")
    End Function

    Public Function RemoveAcentos(ByVal Texto As String) As String
        Dim ComAcentos As String
        Dim SemAcentos As String
        Dim Resultado As String
        Dim Cont As Integer
        'Conjunto de Caracteres com acentos
        ComAcentos = "����������������������������������������������"
        'Conjunto de Caracteres sem acentos
        SemAcentos = "AIOUEAIOUEAIOUEAOAIOUEaioueaioueaioueaoaioueCc"
        Cont = 0
        Resultado = Texto
        Do While Cont < Len(ComAcentos)
            Cont = Cont + 1
            Resultado = Replace(Resultado, Mid(ComAcentos, Cont, 1), Mid(SemAcentos, Cont, 1))
        Loop
        RemoveAcentos = Resultado
    End Function

    Public Function palavrasem(ByVal pesq As String) As String

        palavrasem = Replace(pesq, "a", "[a, � , �]")
        palavrasem = Replace(palavrasem, "A", "[A, �, �]")
        palavrasem = Replace(palavrasem, "e", "[e, � , � , �]")
        palavrasem = Replace(palavrasem, "E", "[E , � , �]")
        palavrasem = Replace(palavrasem, "i", "[i , � , �]")
        palavrasem = Replace(palavrasem, "I", "[I , �]")
        palavrasem = Replace(palavrasem, "o", "[o , � , � , � , �]")
        palavrasem = Replace(palavrasem, "O", "[O , � , � , �]")
        palavrasem = Replace(palavrasem, "u", "[u , � , �]")
        palavrasem = Replace(palavrasem, "U", "[U , �]")
        palavrasem = Replace(palavrasem, "c", "[c , �]")
        palavrasem = Replace(palavrasem, "C", "[C , �]")
        palavrasem = palavrasem
    End Function

    Public Function palavracom(ByVal Pesq As String) As String
        palavracom = Replace(Pesq, "�", "[a]")
        palavracom = Replace(palavracom, "�", "[A]")
        palavracom = Replace(palavracom, "�", "[a]")
        palavracom = Replace(palavracom, "�", "[A]")
        palavracom = Replace(palavracom, "�", "[e]")
        palavracom = Replace(palavracom, "�", "[E]")
        palavracom = Replace(palavracom, "�", "[i]")
        palavracom = Replace(palavracom, "�", "[I]")
        palavracom = Replace(palavracom, "�", "[o]")
        palavracom = Replace(palavracom, "�", "[O]")
        palavracom = Replace(palavracom, "�", "[u]")
        palavracom = Replace(palavracom, "�", "[U]")
        palavracom = Replace(palavracom, "�", "[c]")
        palavracom = Replace(palavracom, "�", "[C]")
        palavracom = palavracom

    End Function

End Module