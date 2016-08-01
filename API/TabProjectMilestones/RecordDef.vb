'---------------------------------------------------------------------------------
' Filename:      RecordDef.vb
' Creation Date: 2016-07-16
'---------------------------------------------------------------------------------
' History        Author              Modification(s)               
'
'---------------------------------------------------------------------------------
Imports System.ComponentModel

Namespace DatabaseLayer.TabProjectMilestones

	Public Class RecordDef
		Private _ProjectMilestoneId As Long
		<DataObjectField(True, True, False)> _
		Public Property ProjectMilestoneId() As Long
			Get
				Return _ProjectMilestoneId
			End Get
			Set(ByVal value As Long)
				_ProjectMilestoneId = value
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

		Private _MilestoneDescription As String
		<DataObjectField(False, False, True)> _
		Public Property MilestoneDescription() As String
			Get
				Return _MilestoneDescription
			End Get
			Set(ByVal value As String)
				_MilestoneDescription = value
			End Set
		End Property

		Private _EstimatedHours As Single
		<DataObjectField(False, False, True)> _
		Public Property EstimatedHours() As Single
			Get
				Return _EstimatedHours
			End Get
			Set(ByVal value As Single)
				_EstimatedHours = value
			End Set
		End Property

		Private _EstimatedCost As Single
		<DataObjectField(False, False, True)> _
		Public Property EstimatedCost() As Single
			Get
				Return _EstimatedCost
			End Get
			Set(ByVal value As Single)
				_EstimatedCost = value
			End Set
		End Property

		Private _Status As Integer
		<DataObjectField(False, False, True)> _
		Public Property Status() As Integer
			Get
				Return _Status
			End Get
			Set(ByVal value As Integer)
				_Status = value
			End Set
		End Property

		Private _HoursSpent As Single
		<DataObjectField(False, False, True)> _
		Public Property HoursSpent() As Single
			Get
				Return _HoursSpent
			End Get
			Set(ByVal value As Single)
				_HoursSpent = value
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
