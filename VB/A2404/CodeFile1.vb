Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Namespace DXSample
	Public Class User
		Inherits XPObject
		Private name_Renamed As String
		Public Sub New()
			MyBase.New()
		End Sub
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Public Property Name() As String
			Get
				Return name_Renamed
			End Get
			Set(ByVal value As String)
				name_Renamed = value
			End Set
		End Property
		<Association("User-Role", GetType(Role))> _
		Public ReadOnly Property Roles() As XPCollection
			Get
				Return GetCollection("Roles")
			End Get
		End Property
	End Class

	Public Class Role
		Inherits XPObject
		Public Sub New()
			MyBase.New()
		End Sub
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private roleName_Renamed As String
		Public Property RoleName() As String
			Get
				Return roleName_Renamed
			End Get
			Set(ByVal value As String)
				roleName_Renamed = value
			End Set
		End Property

		<Association("User-Role", GetType(User))> _
		Public ReadOnly Property Users() As XPCollection
			Get
				Return GetCollection("Users")
			End Get
		End Property
	End Class
End Namespace