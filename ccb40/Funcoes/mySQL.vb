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
        RetiraAcento = Replace(Str.ToUpper, "Ã", "A")
        RetiraAcento = Replace(RetiraAcento, "Á", "A")
        RetiraAcento = Replace(RetiraAcento, "Â", "A")
        RetiraAcento = Replace(RetiraAcento, "À", "A")
        RetiraAcento = Replace(RetiraAcento, "É", "E")
        RetiraAcento = Replace(RetiraAcento, "Ê", "E")
        RetiraAcento = Replace(RetiraAcento, "Í", "I")
        RetiraAcento = Replace(RetiraAcento, "Ó", "O")
        RetiraAcento = Replace(RetiraAcento, "Õ", "O")
        RetiraAcento = Replace(RetiraAcento, "Ú", "U")
        RetiraAcento = Replace(RetiraAcento, "Ç", "C")
        RetiraAcento = RetiraAcento
        'Str = ace("ç", "c").Replace("á", "a").Replace("à", "a").Replace("â", "a").Replace("ã", "a").Replace("ä", "a").Replace("é", "e").Replace("è", "e").Replace("ê", "e").Replace("ë", "e").Replace("í", "i").Replace("ì", "i").Replace("î", "i").Replace("ï", "i").Replace("ó", "o").Replace("ò", "o").Replace("ô", "o").Replace("õ", "o").Replace("ö", "o").Replace("ú", "u").Replace("ù", "u").Replace("û", "u").Replace("ü", "u").Replace("ý", "y").Replace("ÿ", "y").Replace("ç", "c")
        'Str = Str.Replace("á", "a").Replace("à", "a").Replace("â", "a").Replace("ã", "a").Replace("ä", "a").Replace("é", "e").Replace("è", "e").Replace("ê", "e").Replace("ë", "e").Replace("í", "i").Replace("ì", "i").Replace("î", "i").Replace("ï", "i").Replace("ó", "o").Replace("ò", "o").Replace("ô", "o").Replace("õ", "o").Replace("ö", "o").Replace("ú", "u").Replace("ù", "u").Replace("û", "u").Replace("ü", "u").Replace("ý", "y").Replace("ÿ", "y").Replace("ñ", "nh").Replace("ç", "c").Replace("á", "a").Replace("à", "a").Replace("â", "a").Replace("ã", "a").Replace("ä", "a").Replace("é", "e").Replace("è", "e").Replace("ê", "e").Replace("ë", "e").Replace("í", "i").Replace("ì", "i").Replace("î", "i").Replace("ï", "i").Replace("ó", "o").Replace("ò", "o").Replace("ô", "o").Replace("õ", "o").Replace("ö", "o").Replace("ú", "u").Replace("ù", "u").Replace("û", "u").Replace("ü", "u").Replace("ý", "y").Replace("ÿ", "y").Replace("ç", "c")
    End Function

    Public Function RemoveAcentos(ByVal Texto As String) As String
        Dim ComAcentos As String
        Dim SemAcentos As String
        Dim Resultado As String
        Dim Cont As Integer
        'Conjunto de Caracteres com acentos
        ComAcentos = "ÁÍÓÚÉÄÏÖÜËÀÌÒÙÈÃÕÂÎÔÛÊáíóúéäïöüëàìòùèãõâîôûêÇç"
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

        palavrasem = Replace(pesq, "a", "[a, á , ã]")
        palavrasem = Replace(palavrasem, "A", "[A, Á, Ã]")
        palavrasem = Replace(palavrasem, "e", "[e, é , è , ê]")
        palavrasem = Replace(palavrasem, "E", "[E , É , Ê]")
        palavrasem = Replace(palavrasem, "i", "[i , í , ì]")
        palavrasem = Replace(palavrasem, "I", "[I , Í]")
        palavrasem = Replace(palavrasem, "o", "[o , ó , ò , ô , õ]")
        palavrasem = Replace(palavrasem, "O", "[O , Ó , Ô , Õ]")
        palavrasem = Replace(palavrasem, "u", "[u , ú , ù]")
        palavrasem = Replace(palavrasem, "U", "[U , Ú]")
        palavrasem = Replace(palavrasem, "c", "[c , ç]")
        palavrasem = Replace(palavrasem, "C", "[C , Ç]")
        palavrasem = palavrasem
    End Function

    Public Function palavracom(ByVal Pesq As String) As String
        palavracom = Replace(Pesq, "ã", "[a]")
        palavracom = Replace(palavracom, "Ã", "[A]")
        palavracom = Replace(palavracom, "á", "[a]")
        palavracom = Replace(palavracom, "Á", "[A]")
        palavracom = Replace(palavracom, "ê", "[e]")
        palavracom = Replace(palavracom, "Ê", "[E]")
        palavracom = Replace(palavracom, "í", "[i]")
        palavracom = Replace(palavracom, "Í", "[I]")
        palavracom = Replace(palavracom, "õ", "[o]")
        palavracom = Replace(palavracom, "Õ", "[O]")
        palavracom = Replace(palavracom, "ú", "[u]")
        palavracom = Replace(palavracom, "Ú", "[U]")
        palavracom = Replace(palavracom, "ç", "[c]")
        palavracom = Replace(palavracom, "Ç", "[C]")
        palavracom = palavracom

    End Function

End Module