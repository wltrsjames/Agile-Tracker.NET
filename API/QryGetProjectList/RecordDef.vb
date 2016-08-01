'---------------------------------------------------------------------------------
' Filename:      RecordDef.vb
' Creation Date: 2016-07-15
'---------------------------------------------------------------------------------
Imports System.ComponentModel
Imports Microsoft.SqlServer.Types

Namespace DatabaseLayer.QryGetProjectList

	Public Class RecordDef
		Private _Projects_ProjectId As Long
		<DataObjectField(True, True, False)> _
		Public Property Projects_ProjectId() As Long
			Get
				Return _Projects_ProjectId
			End Get
			Set(ByVal value As Long)
				_Projects_ProjectId = value
			End Set
		End Property

		Private _Projects_ProjectName As String
		<DataObjectField(False, False, True)> _
		Public Property Projects_ProjectName() As String
			Get
				Return _Projects_ProjectName
			End Get
			Set(ByVal value As String)
				_Projects_ProjectName = value
			End Set
		End Property

		Private _Projects_Definition As String
		<DataObjectField(False, False, True)> _
		Public Property Projects_Definition() As String
			Get
				Return _Projects_Definition
			End Get
			Set(ByVal value As String)
				_Projects_Definition = value
			End Set
		End Property

		Private _Projects_Outline As String
		<DataObjectField(False, False, True)> _
		Public Property Projects_Outline() As String
			Get
				Return _Projects_Outline
			End Get
			Set(ByVal value As String)
				_Projects_Outline = value
			End Set
		End Property

		Private _Customers_CustomerName As String
		<DataObjectField(False, False, True)> _
		Public Property Customers_CustomerName() As String
			Get
				Return _Customers_CustomerName
			End Get
			Set(ByVal value As String)
				_Customers_CustomerName = value
			End Set
		End Property

		Private _Users_Firstname As String
		<DataObjectField(False, False, True)> _
		Public Property Users_Firstname() As String
			Get
				Return _Users_Firstname
			End Get
			Set(ByVal value As String)
				_Users_Firstname = value
			End Set
		End Property

		Private _Users_Lastname As String
		<DataObjectField(False, False, True)> _
		Public Property Users_Lastname() As String
			Get
				Return _Users_Lastname
			End Get
			Set(ByVal value As String)
				_Users_Lastname = value
			End Set
		End Property

		Private _Projects_CreatedDate As Date
		<DataObjectField(False, False, True)> _
		Public Property Projects_CreatedDate() As Date
			Get
				Return _Projects_CreatedDate
			End Get
			Set(ByVal value As Date)
				_Projects_CreatedDate = value
			End Set
		End Property

	End Class
End Namespace
