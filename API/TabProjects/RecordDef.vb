'---------------------------------------------------------------------------------
' Filename:      RecordDef.vb
' Creation Date: 2016-04-02
'---------------------------------------------------------------------------------
' History        Author              Modification(s)               
'
'---------------------------------------------------------------------------------
Imports System.ComponentModel

Namespace DatabaseLayer.TabProjects

	Public Class RecordDef
		Private _ProjectId As Long
		<DataObjectField(True, True, False)> _
		Public Property ProjectId() As Long
			Get
				Return _ProjectId
			End Get
			Set(ByVal value As Long)
				_ProjectId = value
			End Set
		End Property

		Private _ProjectName As String
		<DataObjectField(False, False, True)> _
		Public Property ProjectName() As String
			Get
				Return _ProjectName
			End Get
			Set(ByVal value As String)
				_ProjectName = value
			End Set
		End Property

		Private _Definition As String
		<DataObjectField(False, False, True)> _
		Public Property Definition() As String
			Get
				Return _Definition
			End Get
			Set(ByVal value As String)
				_Definition = value
			End Set
		End Property

		Private _Outline As String
		<DataObjectField(False, False, True)> _
		Public Property Outline() As String
			Get
				Return _Outline
			End Get
			Set(ByVal value As String)
				_Outline = value
			End Set
		End Property

		Private _CustomerId As Long
		<DataObjectField(False, False, True)> _
		Public Property CustomerId() As Long
			Get
				Return _CustomerId
			End Get
			Set(ByVal value As Long)
				_CustomerId = value
			End Set
		End Property

		Private _ProjectOwnerId As Long
		<DataObjectField(False, False, True)> _
		Public Property ProjectOwnerId() As Long
			Get
				Return _ProjectOwnerId
			End Get
			Set(ByVal value As Long)
				_ProjectOwnerId = value
			End Set
		End Property

		Private _CreatedDate As Date
		<DataObjectField(False, False, True)> _
		Public Property CreatedDate() As Date
			Get
				Return _CreatedDate
			End Get
			Set(ByVal value As Date)
				_CreatedDate = value
			End Set
		End Property

	End Class
End Namespace
