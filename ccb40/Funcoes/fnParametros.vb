Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen

Namespace BLL
    Public Class fnParametros
        Public Sub CarregaParametros(id As Integer)
            'Recupera dados do servidor no registro
            Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\ccb4")
            If (key IsNot Nothing) Then
                Try
                    Dim bllParametros As New ParametroBLL()

                    Dim prm As Parametro = bllParametros.CarregaParametros(id)

                    My.Settings.SeesaoTimeOut = prm.SessaoTimeOut
                    My.Settings.TempoAtualizaPedidos = prm.TempoAtualizaPedidos
                    My.Settings.corTarefaSelecionada = prm.corTarefaSelecionada
                    My.Settings.corCriacaoNormal = prm.corCriacaoNormal
                    My.Settings.corCriacaoUrgente = prm.corCriacaoUrgente
                    My.Settings.corPedidoNormal = prm.corPedidoNormal
                    My.Settings.corPedidoMensal = prm.corPedidoMensal
                Finally
                    key.Close()
                End Try
            End If
        End Sub

        Public Sub GravaParametros(id As Integer)
            'Grava dados do servidor no registro
            Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\ccb4")

            Try
                Dim modelo As New Parametro()

                modelo.ID = id
                'Considera 1 como sendo o perfil válido
                modelo.SessaoTimeOut = My.Settings.SeesaoTimeOut
                modelo.TempoAtualizaPedidos = My.Settings.TempoAtualizaPedidos
                modelo.corTarefaSelecionada = My.Settings.corTarefaSelecionada
                modelo.corCriacaoNormal = My.Settings.corCriacaoNormal
                modelo.corCriacaoUrgente = My.Settings.corCriacaoUrgente
                modelo.corPedidoNormal = My.Settings.corPedidoNormal
                modelo.corPedidoMensal = My.Settings.corPedidoMensal

                Dim bllParametros As New ParametroBLL()

                bllParametros.GravaParametros(modelo)
            Finally
                key.Close()
            End Try
        End Sub
    End Class
End Namespace

