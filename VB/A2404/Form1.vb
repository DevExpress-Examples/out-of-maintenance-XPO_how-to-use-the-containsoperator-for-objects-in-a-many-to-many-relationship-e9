Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DXSample

Namespace A2404
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			InitData()
		End Sub

		#Region "Data initialization"
		Private Sub InitData()
			If Nothing IsNot XpoDefault.Session.FindObject(Of Role)(New BinaryOperator("RoleName", "Manager")) Then
				Return
			End If
			Dim firstName() As String = { "John", "Ben", "Mark", "William" }
			Dim lastName() As String = { "Adams", "Clayborn", "Smith", "Watson" }
			Dim rnd As New Random()
			For i As Integer = 0 To 9
				Dim user As New User()
				user.Name = String.Format("{0} {1}", firstName(rnd.Next(0, 4)), lastName(rnd.Next(0, 4)))
				user.Save()
			Next i
			Dim manager As New Role()
			manager.RoleName = "Manager"
			manager.Save()
			Dim programmer As New Role()
			programmer.RoleName = "Programmer"
			programmer.Save()
			Dim users As XPCollection(Of User) = New XPCollection(Of User)()
			Dim roles As XPCollection(Of Role) = New XPCollection(Of Role)()
			For Each user As User In users
				If user.Oid Mod 4 = 0 Then
					user.Roles.Add(roles(0))
				Else
					user.Roles.Add(roles(1))
				End If
			Next user
			XpoDefault.Session.Save(users)
			XpoDefault.Session.Save(roles)
		End Sub
		#End Region

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			dataGridView1.DataSource = New XPCollection(GetType(User))
		End Sub

		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
			Dim manager As Role = XpoDefault.Session.FindObject(Of Role)(New BinaryOperator("RoleName", "Manager"))
			dataGridView1.DataSource = New XPCollection(GetType(User), New ContainsOperator("Roles", New BinaryOperator("This", manager)))
		End Sub

		Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
			dataGridView1.DataSource = New XPCollection(GetType(User), New ContainsOperator("Roles", New BinaryOperator("RoleName", "Programmer")))
		End Sub

		Private Sub button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button4.Click
			dataGridView1.DataSource = New XPCollection(GetType(User), New GroupOperator(GroupOperatorType.And, New CriteriaOperator() { New ContainsOperator("Roles", New BinaryOperator("RoleName", "Programmer")), New BinaryOperator("Name", "%Smith%", BinaryOperatorType.Like) }))
		End Sub
	End Class
End Namespace