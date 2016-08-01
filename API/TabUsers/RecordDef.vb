'---------------------------------------------------------------------------------
' Filename:      RecordDef.vb
' Creation Date: 2016-07-15
'---------------------------------------------------------------------------------
' History        Author              Modification(s)               
'
'---------------------------------------------------------------------------------
Imports System.ComponentModel

Namespace DatabaseLayer.TabUsers

	Public Class RecordDef
		Private _pkUserId As Long
		<DataObjectField(True, True, False)> _
		Public Property pkUserId() As Long
			Get
				Return _pkUserId
			End Get
			Set(ByVal value As Long)
				_pkUserId = value
			End Set
		End Property

		Private _Firstname As String
		<DataObjectField(False, False, True)> _
		Public Property Firstname() As String
			Get
				Return _Firstname
			End Get
			Set(ByVal value As String)
				_Firstname = value
			End Set
		End Property

		Private _Lastname As String
		<DataObjectField(False, False, True)> _
		Public Property Lastname() As String
			Get
				Return _Lastname
			End Get
			Set(ByVal value As String)
				_Lastname = value
			End Set
		End Property

		Private _Email As String
		<DataObjectField(False, False, True)> _
		Public Property Email() As String
			Get
				Return _Email
			End Get
			Set(ByVal value As String)
				_Email = value
			End Set
		End Property

		Private _Password As String
		<DataObjectField(False, False, True)> _
		Public Property Password() As String
			Get
				Return _Password
			End Get
			Set(ByVal value As String)
				_Password = value
			End Set
		End Property

		Private _Userlevel As Integer
		<DataObjectField(False, False, True)> _
		Public Property Userlevel() As Integer
			Get
				Return _Userlevel
			End Get
			Set(ByVal value As Integer)
				_Userlevel = value
			End Set
		End Property

		Private _CreationDate As Date
		<DataObjectField(False, False, True)> _
		Public Property CreationDate() As Date
			Get
				Return _CreationDate
			End Get
			Set(ByVal value As Date)
				_CreationDate = value
			End Set
		End Property

	End Class
End Namespace
