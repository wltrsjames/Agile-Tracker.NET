'---------------------------------------------------------------------------------
' Filename:      RecordDef.vb
' Creation Date: 2016-07-15
'---------------------------------------------------------------------------------
' History        Author              Modification(s)               
'
'---------------------------------------------------------------------------------
Imports System.ComponentModel

Namespace DatabaseLayer.TabCustomers

	Public Class RecordDef
		Private _CustomerId As Long
		<DataObjectField(True, True, False)> _
		Public Property CustomerId() As Long
			Get
				Return _CustomerId
			End Get
			Set(ByVal value As Long)
				_CustomerId = value
			End Set
		End Property

		Private _CustomerName As String
		<DataObjectField(False, False, True)> _
		Public Property CustomerName() As String
			Get
				Return _CustomerName
			End Get
			Set(ByVal value As String)
				_CustomerName = value
			End Set
		End Property

		Private _CompanyName As String
		<DataObjectField(False, False, True)> _
		Public Property CompanyName() As String
			Get
				Return _CompanyName
			End Get
			Set(ByVal value As String)
				_CompanyName = value
			End Set
		End Property

		Private _CompanyAddress As String
		<DataObjectField(False, False, True)> _
		Public Property CompanyAddress() As String
			Get
				Return _CompanyAddress
			End Get
			Set(ByVal value As String)
				_CompanyAddress = value
			End Set
		End Property

		Private _CompanyPostcode As String
		<DataObjectField(False, False, True)> _
		Public Property CompanyPostcode() As String
			Get
				Return _CompanyPostcode
			End Get
			Set(ByVal value As String)
				_CompanyPostcode = value
			End Set
		End Property

		Private _CompanyPhone As String
		<DataObjectField(False, False, True)> _
		Public Property CompanyPhone() As String
			Get
				Return _CompanyPhone
			End Get
			Set(ByVal value As String)
				_CompanyPhone = value
			End Set
		End Property

		Private _Mobile As String
		<DataObjectField(False, False, True)> _
		Public Property Mobile() As String
			Get
				Return _Mobile
			End Get
			Set(ByVal value As String)
				_Mobile = value
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

		Private _DateCreated As Date
		<DataObjectField(False, False, True)> _
		Public Property DateCreated() As Date
			Get
				Return _DateCreated
			End Get
			Set(ByVal value As Date)
				_DateCreated = value
			End Set
		End Property

	End Class
End Namespace
