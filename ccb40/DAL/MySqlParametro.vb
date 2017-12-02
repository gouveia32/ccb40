Namespace DAL
    Public Class MySqlParametro
        Private m_parametro As String
        Private m_valor As Object

        Public Property Parametro() As String
            Get
                Return m_parametro
            End Get
            Set
                m_parametro = Value
            End Set
        End Property

        Public Property Valor() As Object
            Get
                Return m_valor
            End Get
            Set
                m_valor = Value
            End Set
        End Property

        Public Sub New(parametro As String, valor As Object)
            Me.Parametro = parametro
            Me.Valor = valor
        End Sub
    End Class
End Namespace