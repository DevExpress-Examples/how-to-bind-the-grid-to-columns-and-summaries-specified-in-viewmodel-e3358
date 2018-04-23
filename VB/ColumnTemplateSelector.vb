Imports Microsoft.VisualBasic
Imports System.Windows.Controls
Imports System.Windows
Imports Model
#If SILVERLIGHT Then
Imports DevExpress.Xpf.Core.Native
#End If

Namespace View
	Public Class ColumnTemplateSelector
		Inherits DataTemplateSelector
		Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
			Dim column As Column = CType(item, Column)
#If SILVERLIGHT Then
			Return CType(LayoutHelper.FindParentObject(Of UserControl)(container).Resources(column.Settings & "ColumnTemplate"), DataTemplate)
#Else
			Return CType((CType(container, Control)).FindResource(column.Settings & "ColumnTemplate"), DataTemplate)
#End If
		End Function
	End Class
End Namespace