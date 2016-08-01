'---------------------------------------------------------------------------------
' Filename:      RecordDef.vb
' Creation Date: 2016-07-16
'---------------------------------------------------------------------------------
' History        Author              Modification(s)               
'
'---------------------------------------------------------------------------------
Imports System.ComponentModel

Namespace DatabaseLayer.TabUserStories

	Public Class RecordDef
		Private _UserStoryId As Long
		<DataObjectField(True, True, False)> _
		Public Property UserStoryId() As Long
			Get
				Return _UserStoryId
			End Get
			Set(ByVal value As Long)
				_UserStoryId = value
			End Set
		End Property

		Private _ProjectId As Long
		<DataObjectField(False, False, True)> _
		Public Property ProjectId() As Long
			Get
				Return _ProjectId
			End Get
			Set(ByVal value As Long)
				_ProjectId = value
			End Set
		End Property

		Private _UserRole As String
		<DataObjectField(False, False, True)> _
		Public Property UserRole() As String
			Get
				Return _UserRole
			End Get
			Set(ByVal value As String)
				_UserRole = value
			End Set
		End Property

		Private _Request As String
		<DataObjectField(False, False, True)> _
		Public Property Request() As String
			Get
				Return _Request
			End Get
			Set(ByVal value As String)
				_Request = value
			End Set
		End Property

		Private _Purpose As String
		<DataObjectField(False, False, True)> _
		Public Property Purpose() As String
			Get
				Return _Purpose
			End Get
			Set(ByVal value As String)
				_Purpose = value
			End Set
		End Property

		Private _AcceptanceCriteria As String
		<DataObjectField(False, False, True)> _
		Public Property AcceptanceCriteria() As String
			Get
				Return _AcceptanceCriteria
			End Get
			Set(ByVal value As String)
				_AcceptanceCriteria = value
			End Set
		End Property

		Private _MVP As Integer
		<DataObjectField(False, False, True)> _
		Public Property MVP() As Integer
			Get
				Return _MVP
			End Get
			Set(ByVal value As Integer)
				_MVP = value
			End Set
		End Property

	End Class
End Namespace
