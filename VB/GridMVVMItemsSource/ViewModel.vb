Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Reflection
Imports System.Xml.Serialization
Imports DevExpress.Data

Namespace Model
	Public Class ViewModel
		Private privateCities As List(Of String)
		Public Property Cities() As List(Of String)
			Get
				Return privateCities
			End Get
			Private Set(ByVal value As List(Of String))
				privateCities = value
			End Set
		End Property
		Private privateSource As IList(Of Employee)
		Public Property Source() As IList(Of Employee)
			Get
				Return privateSource
			End Get
			Private Set(ByVal value As IList(Of Employee))
				privateSource = value
			End Set
		End Property
		Private privateColumns As ObservableCollection(Of Column)
		Public Property Columns() As ObservableCollection(Of Column)
			Get
				Return privateColumns
			End Get
			Private Set(ByVal value As ObservableCollection(Of Column))
				privateColumns = value
			End Set
		End Property
		Private privateTotalSummary As ObservableCollection(Of Summary)
		Public Property TotalSummary() As ObservableCollection(Of Summary)
			Get
				Return privateTotalSummary
			End Get
			Private Set(ByVal value As ObservableCollection(Of Summary))
				privateTotalSummary = value
			End Set
		End Property
		Private privateGroupSummary As ObservableCollection(Of Summary)
		Public Property GroupSummary() As ObservableCollection(Of Summary)
			Get
				Return privateGroupSummary
			End Get
			Private Set(ByVal value As ObservableCollection(Of Summary))
				privateGroupSummary = value
			End Set
		End Property
		Public Sub New()
			Source = EmployeesData.DataSource
			Dim cities As New List(Of String)()
			For Each employee As Employee In Source
				If (Not cities.Contains(employee.City)) Then
					cities.Add(employee.City)
				End If
			Next employee
			Cities = cities
			Columns = New ObservableCollection(Of Column) (New Column() {New Column() With {.FieldName="FirstName", .Settings = SettingsType.Default}, New Column() With {.FieldName="LastName", .Settings = SettingsType.Default}, New Column() With {.FieldName="BirthDate", .Settings = SettingsType.Default}, New ComboColumn() With {.FieldName="City", .Settings = SettingsType.Combo, .Source = Cities}, New Column() With {.FieldName="ImageData", .Settings = SettingsType.Image}})
			TotalSummary = New ObservableCollection(Of Summary) (New Summary() {New Summary() With {.Type = SummaryItemType.Count, .FieldName = "FirstName"}, New Summary() With {.Type = SummaryItemType.Max, .FieldName = "BirthDate"}})
			GroupSummary = New ObservableCollection(Of Summary) (New Summary() {New Summary() With {.Type = SummaryItemType.Count, .FieldName = "FirstName"}})
		End Sub
	End Class

	Public Enum SettingsType
		[Default]
		Combo
		Image
	End Enum

	Public Class Summary
		Private privateType As SummaryItemType
		Public Property Type() As SummaryItemType
			Get
				Return privateType
			End Get
			Set(ByVal value As SummaryItemType)
				privateType = value
			End Set
		End Property
		Private privateFieldName As String
		Public Property FieldName() As String
			Get
				Return privateFieldName
			End Get
			Set(ByVal value As String)
				privateFieldName = value
			End Set
		End Property
	End Class

	Public Class Column
		Private privateFieldName As String
		Public Property FieldName() As String
			Get
				Return privateFieldName
			End Get
			Set(ByVal value As String)
				privateFieldName = value
			End Set
		End Property
		Private privateSettings As SettingsType
		Public Property Settings() As SettingsType
			Get
				Return privateSettings
			End Get
			Set(ByVal value As SettingsType)
				privateSettings = value
			End Set
		End Property
	End Class
	Public Class ComboColumn
		Inherits Column
		Private privateSource As IList
		Public Property Source() As IList
			Get
				Return privateSource
			End Get
			Set(ByVal value As IList)
				privateSource = value
			End Set
		End Property
	End Class

	<XmlRoot("Employees")> _
	Public Class EmployeesData
		Inherits List(Of Employee)
		Public Shared ReadOnly Property DataSource() As IList(Of Employee)
			Get

				Dim s As New XmlSerializer(GetType(EmployeesData))
#If SILVERLIGHT Then
				Return CType(s.Deserialize(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("SLGridMVVMBindableClumns.EmployeesWithPhoto.xml")), List(Of Employee))
#Else
				Return CType(s.Deserialize(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("WPFGridMVVMBindableColumns.EmployeesWithPhoto.xml")), List(Of Employee))
#End If
			End Get
		End Property
	End Class


	Public Class Employee
		Private privateId As Integer
		Public Property Id() As Integer
			Get
				Return privateId
			End Get
			Set(ByVal value As Integer)
				privateId = value
			End Set
		End Property
		Private privateParentId As Integer
		Public Property ParentId() As Integer
			Get
				Return privateParentId
			End Get
			Set(ByVal value As Integer)
				privateParentId = value
			End Set
		End Property
		Private privateFirstName As String
		Public Property FirstName() As String
			Get
				Return privateFirstName
			End Get
			Set(ByVal value As String)
				privateFirstName = value
			End Set
		End Property
		Private privateMiddleName As String
		Public Property MiddleName() As String
			Get
				Return privateMiddleName
			End Get
			Set(ByVal value As String)
				privateMiddleName = value
			End Set
		End Property
		Private privateLastName As String
		Public Property LastName() As String
			Get
				Return privateLastName
			End Get
			Set(ByVal value As String)
				privateLastName = value
			End Set
		End Property
		Private privateJobTitle As String
		Public Property JobTitle() As String
			Get
				Return privateJobTitle
			End Get
			Set(ByVal value As String)
				privateJobTitle = value
			End Set
		End Property
		Private privatePhone As String
		Public Property Phone() As String
			Get
				Return privatePhone
			End Get
			Set(ByVal value As String)
				privatePhone = value
			End Set
		End Property
		Private privateEmailAddress As String
		Public Property EmailAddress() As String
			Get
				Return privateEmailAddress
			End Get
			Set(ByVal value As String)
				privateEmailAddress = value
			End Set
		End Property
		Private privateAddressLine1 As String
		Public Property AddressLine1() As String
			Get
				Return privateAddressLine1
			End Get
			Set(ByVal value As String)
				privateAddressLine1 = value
			End Set
		End Property
		Private privateCity As String
		Public Property City() As String
			Get
				Return privateCity
			End Get
			Set(ByVal value As String)
				privateCity = value
			End Set
		End Property
		Private privateStateProvinceName As String
		Public Property StateProvinceName() As String
			Get
				Return privateStateProvinceName
			End Get
			Set(ByVal value As String)
				privateStateProvinceName = value
			End Set
		End Property
		Private privatePostalCode As String
		Public Property PostalCode() As String
			Get
				Return privatePostalCode
			End Get
			Set(ByVal value As String)
				privatePostalCode = value
			End Set
		End Property
		Private privateCountryRegionName As String
		Public Property CountryRegionName() As String
			Get
				Return privateCountryRegionName
			End Get
			Set(ByVal value As String)
				privateCountryRegionName = value
			End Set
		End Property
		Private privateGroupName As String
		Public Property GroupName() As String
			Get
				Return privateGroupName
			End Get
			Set(ByVal value As String)
				privateGroupName = value
			End Set
		End Property
		Private privateBirthDate As DateTime
		Public Property BirthDate() As DateTime
			Get
				Return privateBirthDate
			End Get
			Set(ByVal value As DateTime)
				privateBirthDate = value
			End Set
		End Property
		Private privateHireDate As DateTime
		Public Property HireDate() As DateTime
			Get
				Return privateHireDate
			End Get
			Set(ByVal value As DateTime)
				privateHireDate = value
			End Set
		End Property
		Private privateGender As String
		Public Property Gender() As String
			Get
				Return privateGender
			End Get
			Set(ByVal value As String)
				privateGender = value
			End Set
		End Property
		Private privateMaritalStatus As String
		Public Property MaritalStatus() As String
			Get
				Return privateMaritalStatus
			End Get
			Set(ByVal value As String)
				privateMaritalStatus = value
			End Set
		End Property
		Private privateTitle As String
		Public Property Title() As String
			Get
				Return privateTitle
			End Get
			Set(ByVal value As String)
				privateTitle = value
			End Set
		End Property
		Private privateImageData As Byte()
		Public Property ImageData() As Byte()
			Get
				Return privateImageData
			End Get
			Set(ByVal value As Byte())
				privateImageData = value
			End Set
		End Property
	End Class
End Namespace
