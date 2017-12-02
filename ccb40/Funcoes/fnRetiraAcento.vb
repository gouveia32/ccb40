Namespace BLL
    Class fnRetiraAcento
        Public Function RetiraAcento(str As String) As String
            str = str.ToUpper().Replace("Ã", "A")
            str = str.ToUpper().Replace("Á", "A")
            str = str.ToUpper().Replace("Â", "A")
            str = str.ToUpper().Replace("À", "A")
            str = str.ToUpper().Replace("É", "E")
            str = str.ToUpper().Replace("Ê", "E")
            str = str.ToUpper().Replace("Í", "I")
            str = str.ToUpper().Replace("Ó", "O")
            str = str.ToUpper().Replace("Õ", "O")
            str = str.ToUpper().Replace("Ú", "U")
            str = str.ToUpper().Replace("Ç", "C")

            Return str

        End Function
    End Class
End Namespace
