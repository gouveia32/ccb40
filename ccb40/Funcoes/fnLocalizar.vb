Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen
Namespace BLL
    Public Class fnLocalizar
        Private ra As New fnRetiraAcento()

        Public Sub Localizar(dgRegistros As GridView, filtroValor As String, ri As Integer, PraFrente As Boolean, Optional Msg As Boolean = True)
            Dim mValor As String() = New String(0) {}
            Dim opOu As Boolean = False
            Dim flEncontrou As Boolean() = New Boolean(0) {}
            Dim txt As String
            Dim todos As Boolean
            Dim c As Integer

            'splashScreenManager1.ShowWaitForm();
            Try
                'fp.sbBarra.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                SplashScreenManager.ShowDefaultWaitForm("Aguarde", "Localizando...")

                filtroValor = ra.RetiraAcento(filtroValor)

                If filtroValor.Contains("=") Then
                    'Campo:conteudo
                    mValor = filtroValor.Split("=")

                    For c = 0 To dgRegistros.Columns.Count - 1
                        If mValor(0) = dgRegistros.Columns(c).FieldName.ToUpper() Then
                            ' realiza a busca pela coluna encontrada
                            For r As Integer = ri To dgRegistros.RowCount - 1
                                txt = ra.RetiraAcento(dgRegistros.GetDataRow(r).ItemArray(c).ToString())
                                If txt = (mValor(1)) Then
                                    dgRegistros.FocusedRowHandle = r
                                    Return

                                End If

                            Next
                        End If

                    Next
                ElseIf filtroValor.Contains("|") Then
                    mValor = filtroValor.Split("|")
                    opOu = True
                Else
                    mValor = filtroValor.Split("&")
                    opOu = False
                End If
                Array.Resize(flEncontrou, mValor.Length)
                If PraFrente Then
                    For r As Integer = ri To dgRegistros.RowCount - 1
                        'fp.sbBarra.EditValue = r;
                        ' set todos como falso
                        For a As Integer = 0 To mValor.Length - 1
                            flEncontrou(a) = False
                        Next
                        For c = 0 To dgRegistros.Columns.Count - 1
                            If dgRegistros.GetDataRow(r).ItemArray(c) Is Nothing Then
                                Continue For
                            End If
                            txt = ra.RetiraAcento(dgRegistros.GetDataRow(r).ItemArray(c).ToString())
                            For a As Integer = 0 To mValor.Length - 1
                                If txt.Contains(mValor(a)) Then
                                    flEncontrou(a) = True
                                    'valida a exp atual
                                    If opOu Then
                                        dgRegistros.FocusedRowHandle = Convert.ToInt32(dgRegistros.GetRowHandle(r))

                                        Return
                                    End If
                                End If
                            Next
                        Next
                        If Not opOu Then
                            todos = True
                            For a As Integer = 0 To flEncontrou.Length - 1
                                If Not flEncontrou(a) Then
                                    todos = False
                                    'pelo menos falso
                                End If
                            Next
                            If todos Then
                                dgRegistros.FocusedRowHandle = Convert.ToInt32(dgRegistros.GetRowHandle(r))
                                Return
                            End If
                        End If
                    Next
                    If Msg Then
                        MessageBox.Show("Fim do arquivo!")
                    End If
                Else
                    'procura para trás
                    For r As Integer = ri To 0 Step -1
                        'fp.sbBarra.EditValue = r;
                        ' set todos como falso
                        For a As Integer = 0 To mValor.Length - 1
                            flEncontrou(a) = False
                        Next
                        For c = 0 To dgRegistros.Columns.Count - 1
                            If dgRegistros.GetDataRow(r).ItemArray(c) Is Nothing Then
                                Continue For
                            End If
                            txt = ra.RetiraAcento(dgRegistros.GetDataRow(r).ItemArray(c).ToString())
                            For a As Integer = 0 To mValor.Length - 1
                                If txt.Contains(mValor(a)) Then
                                    flEncontrou(a) = True
                                    'valida a exp atual
                                    If opOu Then
                                        dgRegistros.FocusedRowHandle = Convert.ToInt32(dgRegistros.GetRowHandle(r))
                                        Return
                                    End If
                                End If
                            Next
                        Next
                        If Not opOu Then
                            todos = True
                            For a As Integer = 0 To flEncontrou.Length - 1
                                If Not flEncontrou(a) Then
                                    todos = False
                                    'pelo menos falso
                                End If
                            Next
                            If todos Then
                                dgRegistros.FocusedRowHandle = Convert.ToInt32(dgRegistros.GetRowHandle(r))
                                Return
                            End If
                        End If
                    Next
                    If Msg Then
                        MessageBox.Show("Início do arquivo!")
                    End If
                End If
            Catch erro As Exception
                MessageBox.Show(erro.Message)
            Finally
                SplashScreenManager.CloseForm()
            End Try
        End Sub
    End Class
End Namespace
