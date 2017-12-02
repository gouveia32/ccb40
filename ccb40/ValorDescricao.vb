Public Class ValorDescricao
    Public Value As Object
    Public Description As String

    Public Sub New(ByVal NewValue As Object, ByVal NewDescription As String)
        Value = NewValue
        Description = NewDescription
    End Sub

    Public Overrides Function ToString() As String
        Return Description
    End Function

End Class

Public Class datetmpicker
    Inherits System.Windows.Forms.DateTimePicker
    Public Sub New()
        Checked = False
        Enabled = False
        Format = System.Windows.Forms.DateTimePickerFormat.Short
        ShowCheckBox = True
        Size = New System.Drawing.Size(120, 22)
    End Sub
    Private Sub myBindingContextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.BindingContextChanged
        If Value = CDate(Text) Then
            Checked = False
        End If
    End Sub

End Class


Public Class DocumentWithTOC
    ' ----- This class enhances the .NET PrintDocument class by adding
    '       a Table of Contents index. This allows a user to quickly
    '       jump to a section of the document.
    Inherits System.Drawing.Printing.PrintDocument

    Protected Overrides Sub OnBeginPrint(ByVal e As System.Drawing.Printing.PrintEventArgs)
        ' ----- Before printing, create room for a table of contents.
        MyBase.OnBeginPrint(e)
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        ' ----- Free the memory associated with the table of conents.
        MyBase.Dispose(disposing)
    End Sub
End Class

