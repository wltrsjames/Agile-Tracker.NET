'---------------------------------------------------------------------------------
' Filename:      BusinessLogicLayer.vb
' Creation Date: 2016-07-16
'---------------------------------------------------------------------------------
' History        Author              Modification(s)               
'
'---------------------------------------------------------------------------------

Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.ComponentModel
Imports Microsoft.SqlServer.Types

Namespace DatabaseLayer.TabProjectMilestones

	<DataObject(True)> _
	Public Class BusinessLogicLayer
	' All code within the BLL Region is automatically generated.
	' Any changes to this code will be lost if the Business Object Tool is run again.

#Region "Private Variables"

#End Region

#Region "Generated Code"

		Private Function IsBadParameter(ByVal text As String) As Boolean
			Dim word As String
			Dim reservedword As String
			Dim SQLReservedWords As new List(Of String)

			SQLReservedWords.Add("ALTER")
			SQLReservedWords.Add("UNION")
			SQLReservedWords.Add("UPDATE")
			SQLReservedWords.Add("SELECT")
			SQLReservedWords.Add("EXEC")
			SQLReservedWords.Add("DROP")
			SQLReservedWords.Add("INSERT")

			For Each word In text.Split(" ")
				For Each reservedword In SQLReservedWords
					If word.ToLower = reservedword.ToLower Then
						Return True
					End If
				Next
			Next

			Return False
		End Function

		' delete record function
		<DataObjectMethod(DataObjectMethodType.Delete)> _
		Public Function Delete(ByVal ProjectMilestoneId As Long) As Boolean
			Dim dal as TabProjectMilestones.DataAccessLayer = New TabProjectMilestones.DataAccessLayer
			Return dal.DeleteProjectMilestones(ProjectMilestoneId)
		End Function

		' update record function
		<DataObjectMethod(DataObjectMethodType.Update)> _
		Public Function Update(ByVal ProjectMilestoneId As Long, ByVal ProjectId As Long, ByVal MilestoneDescription As String, ByVal EstimatedHours As Single, ByVal EstimatedCost As Single, ByVal Status As Integer, ByVal HoursSpent As Single) As Boolean
			Dim dal As TabProjectMilestones.DataAccessLayer = New TabProjectMilestones.DataAccessLayer
			Dim rec As New TabProjectMilestones.RecordDef

			' Check all string parameters for hidden SQL
			If IsBadParameter(MilestoneDescription) = True Then Return False

			' populate the record object for validation to take place
			rec.ProjectMilestoneId = ProjectMilestoneId
			rec.ProjectId = ProjectId
			rec.MilestoneDescription = MilestoneDescription
			rec.EstimatedHours = EstimatedHours
			rec.EstimatedCost = EstimatedCost
			rec.Status = Status
			rec.HoursSpent = HoursSpent

			If ValidateData(rec) = True Then
				Return dal.UpdateProjectMilestones(ProjectMilestoneId, ProjectId, MilestoneDescription, EstimatedHours, EstimatedCost, Status, HoursSpent)
			End If

			' if we get here then there is a problem so return false
			Return False
		End Function

		' update record function
		<DataObjectMethod(DataObjectMethodType.Update)> _
		Public Function Update(rec As TabProjectMilestones.RecordDef) As Boolean
			Dim dal As TabProjectMilestones.DataAccessLayer = New TabProjectMilestones.DataAccessLayer

			' Check all string parameters for hidden SQL
			If IsBadParameter(rec.MilestoneDescription) = True Then Return False

			If ValidateData(rec) = True Then
				Return dal.UpdateProjectMilestones(rec.ProjectMilestoneId, rec.ProjectId, rec.MilestoneDescription, rec.EstimatedHours, rec.EstimatedCost, rec.Status, rec.HoursSpent)
			End If

			' if we get here then there is a problem so return false
			Return False
		End Function

		' insert record function
		<DataObjectMethod(DataObjectMethodType.Insert)> _
		Public Function Insert(ByVal ProjectId As Long, ByVal MilestoneDescription As String, ByVal EstimatedHours As Single, ByVal EstimatedCost As Single, ByVal Status As Integer, ByVal HoursSpent As Single) As Long
			Dim dal As TabProjectMilestones.DataAccessLayer = New TabProjectMilestones.DataAccessLayer
			Dim rec As New TabProjectMilestones.RecordDef

			' Check all string parameters for hidden SQL
			If IsBadParameter(MilestoneDescription) = True Then Return -1

            ' populate the record object for validation to take place
            'rec.ProjectMilestoneId = ProjectMilestoneId
            rec.ProjectId = ProjectId
			rec.MilestoneDescription = MilestoneDescription
			rec.EstimatedHours = EstimatedHours
			rec.EstimatedCost = EstimatedCost
			rec.Status = Status
			rec.HoursSpent = HoursSpent

			If ValidateData(rec) = True Then
				Return dal.InsertProjectMilestones(ProjectId, MilestoneDescription, EstimatedHours, EstimatedCost, Status, HoursSpent)
			End If

			' if we get here then there is a problem so return -1 meaning no record
			Return -1
		End Function

		' get record function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Function GetMilestonesByProject(ByVal ProjectId As Long) As List(Of TabProjectMilestones.RecordDef)
			Dim reader As SqlDataReader = Nothing
			Dim dal As TabProjectMilestones.DataAccessLayer = New TabProjectMilestones.DataAccessLayer
			Dim resultlist As New List(Of TabProjectMilestones.RecordDef)

			If IsNumeric(ProjectId) = False Then Return Nothing

			reader = dal.GetMilestonesByProject(ProjectId)

			' add all rows in the datareader to the list
			If reader IsNot Nothing Then
				While reader.Read
					Dim newlist As New TabProjectMilestones.RecordDef
					If Not Convert.IsDBNull(reader("ProjectMilestoneId")) Then 
					newlist.ProjectMilestoneId = CType(reader("ProjectMilestoneId"), Long)
					End if
					If Not Convert.IsDBNull(reader("ProjectId")) Then 
					newlist.ProjectId = CType(reader("ProjectId"), Long)
					End if
					If Not Convert.IsDBNull(reader("MilestoneDescription")) Then 
					newlist.MilestoneDescription = CType(reader("MilestoneDescription"), String)
					End if
					If Not Convert.IsDBNull(reader("EstimatedHours")) Then 
					newlist.EstimatedHours = CType(reader("EstimatedHours"), Single)
					End if
					If Not Convert.IsDBNull(reader("EstimatedCost")) Then 
					newlist.EstimatedCost = CType(reader("EstimatedCost"), Single)
					End if
					If Not Convert.IsDBNull(reader("Status")) Then 
					newlist.Status = CType(reader("Status"), Integer)
					End if
					If Not Convert.IsDBNull(reader("HoursSpent")) Then 
					newlist.HoursSpent = CType(reader("HoursSpent"), Single)
					End if
					If Not Convert.IsDBNull(reader("DateCreated")) Then 
					newlist.DateCreated = CType(reader("DateCreated"), Date)
					End if
					resultlist.Add(newlist)
				End While

				reader.Close()
				reader = Nothing

			End If

			dal.CloseConnection()

			Return resultlist
		End Function

		' get record function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Function GetProjectMilestonesPrimaryKeySearch(ByVal ProjectMilestoneId As Long) As List(Of TabProjectMilestones.RecordDef)
			Dim reader As SqlDataReader = Nothing
			Dim dal As TabProjectMilestones.DataAccessLayer = New TabProjectMilestones.DataAccessLayer
			Dim resultlist As New List(Of TabProjectMilestones.RecordDef)

			If IsNumeric(ProjectMilestoneId) = False Then Return Nothing

			reader = dal.GetProjectMilestonesPrimaryKeySearch(ProjectMilestoneId)

			' add all rows in the datareader to the list
			If reader IsNot Nothing Then
				While reader.Read
					Dim newlist As New TabProjectMilestones.RecordDef
					If Not Convert.IsDBNull(reader("ProjectMilestoneId")) Then 
					newlist.ProjectMilestoneId = CType(reader("ProjectMilestoneId"), Long)
					End if
					If Not Convert.IsDBNull(reader("ProjectId")) Then 
					newlist.ProjectId = CType(reader("ProjectId"), Long)
					End if
					If Not Convert.IsDBNull(reader("MilestoneDescription")) Then 
					newlist.MilestoneDescription = CType(reader("MilestoneDescription"), String)
					End if
					If Not Convert.IsDBNull(reader("EstimatedHours")) Then 
					newlist.EstimatedHours = CType(reader("EstimatedHours"), Single)
					End if
					If Not Convert.IsDBNull(reader("EstimatedCost")) Then 
					newlist.EstimatedCost = CType(reader("EstimatedCost"), Single)
					End if
					If Not Convert.IsDBNull(reader("Status")) Then 
					newlist.Status = CType(reader("Status"), Integer)
					End if
					If Not Convert.IsDBNull(reader("HoursSpent")) Then 
					newlist.HoursSpent = CType(reader("HoursSpent"), Single)
					End if
					If Not Convert.IsDBNull(reader("DateCreated")) Then 
					newlist.DateCreated = CType(reader("DateCreated"), Date)
					End if
					resultlist.Add(newlist)
				End While

				reader.Close()
				reader = Nothing

			End If

			dal.CloseConnection()

			Return resultlist
		End Function

		' get record function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Function GetAll() As List(Of TabProjectMilestones.RecordDef)
			Dim reader As SqlDataReader = Nothing
			Dim dal As TabProjectMilestones.DataAccessLayer = New TabProjectMilestones.DataAccessLayer
			Dim resultlist As New List(Of TabProjectMilestones.RecordDef)


			reader = dal.GetAll()

			' add all rows in the datareader to the list
			If reader IsNot Nothing Then
				While reader.Read
					Dim newlist As New TabProjectMilestones.RecordDef
					If Not Convert.IsDBNull(reader("ProjectMilestoneId")) Then 
					newlist.ProjectMilestoneId = CType(reader("ProjectMilestoneId"), Long)
					End if
					If Not Convert.IsDBNull(reader("ProjectId")) Then 
					newlist.ProjectId = CType(reader("ProjectId"), Long)
					End if
					If Not Convert.IsDBNull(reader("MilestoneDescription")) Then 
					newlist.MilestoneDescription = CType(reader("MilestoneDescription"), String)
					End if
					If Not Convert.IsDBNull(reader("EstimatedHours")) Then 
					newlist.EstimatedHours = CType(reader("EstimatedHours"), Single)
					End if
					If Not Convert.IsDBNull(reader("EstimatedCost")) Then 
					newlist.EstimatedCost = CType(reader("EstimatedCost"), Single)
					End if
					If Not Convert.IsDBNull(reader("Status")) Then 
					newlist.Status = CType(reader("Status"), Integer)
					End if
					If Not Convert.IsDBNull(reader("HoursSpent")) Then 
					newlist.HoursSpent = CType(reader("HoursSpent"), Single)
					End if
					If Not Convert.IsDBNull(reader("DateCreated")) Then 
					newlist.DateCreated = CType(reader("DateCreated"), Date)
					End if
					resultlist.Add(newlist)
				End While

				reader.Close()
				reader = Nothing

			End If

			dal.CloseConnection()

			Return resultlist
		End Function

		' get record function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Function GetMilestoneById(ByVal ProjectMilestoneId As Long) As List(Of TabProjectMilestones.RecordDef)
			Dim reader As SqlDataReader = Nothing
			Dim dal As TabProjectMilestones.DataAccessLayer = New TabProjectMilestones.DataAccessLayer
			Dim resultlist As New List(Of TabProjectMilestones.RecordDef)

			If IsNumeric(ProjectMilestoneId) = False Then Return Nothing

			reader = dal.GetMilestoneById(ProjectMilestoneId)

			' add all rows in the datareader to the list
			If reader IsNot Nothing Then
				While reader.Read
					Dim newlist As New TabProjectMilestones.RecordDef
					If Not Convert.IsDBNull(reader("ProjectMilestoneId")) Then 
					newlist.ProjectMilestoneId = CType(reader("ProjectMilestoneId"), Long)
					End if
					If Not Convert.IsDBNull(reader("ProjectId")) Then 
					newlist.ProjectId = CType(reader("ProjectId"), Long)
					End if
					If Not Convert.IsDBNull(reader("MilestoneDescription")) Then 
					newlist.MilestoneDescription = CType(reader("MilestoneDescription"), String)
					End if
					If Not Convert.IsDBNull(reader("EstimatedHours")) Then 
					newlist.EstimatedHours = CType(reader("EstimatedHours"), Single)
					End if
					If Not Convert.IsDBNull(reader("EstimatedCost")) Then 
					newlist.EstimatedCost = CType(reader("EstimatedCost"), Single)
					End if
					If Not Convert.IsDBNull(reader("Status")) Then 
					newlist.Status = CType(reader("Status"), Integer)
					End if
					If Not Convert.IsDBNull(reader("HoursSpent")) Then 
					newlist.HoursSpent = CType(reader("HoursSpent"), Single)
					End if
					If Not Convert.IsDBNull(reader("DateCreated")) Then 
					newlist.DateCreated = CType(reader("DateCreated"), Date)
					End if
					resultlist.Add(newlist)
				End While

				reader.Close()
				reader = Nothing

			End If

			dal.CloseConnection()

			Return resultlist
		End Function

		' get primary key function for field ProjectId
		Public Function GetProjectMilestonesPrimaryKeyProjectId(ProjectMilestoneId As Long) As Long
			' Only hit the database if the primary key is valid
			If ProjectMilestoneId < 1 Then
				Return 0
			End If

			Dim ProjectMilestonesList As New List(Of TabProjectMilestones.RecordDef)
			ProjectMilestonesList = GetProjectMilestonesPrimaryKeySearch(ProjectMilestoneId)
			If ProjectMilestonesList.Count = 1 Then
				Return ProjectMilestonesList(0).ProjectId
			Else
				Return 0
			End If
		End Function

		' get primary key function for field MilestoneDescription
		Public Function GetProjectMilestonesPrimaryKeyMilestoneDescription(ProjectMilestoneId As Long) As String
			' Only hit the database if the primary key is valid
			If ProjectMilestoneId < 1 Then
				Return ""
			End If

			Dim ProjectMilestonesList As New List(Of TabProjectMilestones.RecordDef)
			ProjectMilestonesList = GetProjectMilestonesPrimaryKeySearch(ProjectMilestoneId)
			If ProjectMilestonesList.Count = 1 Then
				Return ProjectMilestonesList(0).MilestoneDescription
			Else
				Return ""
			End If
		End Function

		' get primary key function for field EstimatedHours
		Public Function GetProjectMilestonesPrimaryKeyEstimatedHours(ProjectMilestoneId As Long) As Single
			' Only hit the database if the primary key is valid
			If ProjectMilestoneId < 1 Then
				Return 0.0
			End If

			Dim ProjectMilestonesList As New List(Of TabProjectMilestones.RecordDef)
			ProjectMilestonesList = GetProjectMilestonesPrimaryKeySearch(ProjectMilestoneId)
			If ProjectMilestonesList.Count = 1 Then
				Return ProjectMilestonesList(0).EstimatedHours
			Else
				Return 0.0
			End If
		End Function

		' get primary key function for field EstimatedCost
		Public Function GetProjectMilestonesPrimaryKeyEstimatedCost(ProjectMilestoneId As Long) As Single
			' Only hit the database if the primary key is valid
			If ProjectMilestoneId < 1 Then
				Return 0.0
			End If

			Dim ProjectMilestonesList As New List(Of TabProjectMilestones.RecordDef)
			ProjectMilestonesList = GetProjectMilestonesPrimaryKeySearch(ProjectMilestoneId)
			If ProjectMilestonesList.Count = 1 Then
				Return ProjectMilestonesList(0).EstimatedCost
			Else
				Return 0.0
			End If
		End Function

		' get primary key function for field Status
		Public Function GetProjectMilestonesPrimaryKeyStatus(ProjectMilestoneId As Long) As Integer
			' Only hit the database if the primary key is valid
			If ProjectMilestoneId < 1 Then
				Return 0
			End If

			Dim ProjectMilestonesList As New List(Of TabProjectMilestones.RecordDef)
			ProjectMilestonesList = GetProjectMilestonesPrimaryKeySearch(ProjectMilestoneId)
			If ProjectMilestonesList.Count = 1 Then
				Return ProjectMilestonesList(0).Status
			Else
				Return 0
			End If
		End Function

		' get primary key function for field HoursSpent
		Public Function GetProjectMilestonesPrimaryKeyHoursSpent(ProjectMilestoneId As Long) As Single
			' Only hit the database if the primary key is valid
			If ProjectMilestoneId < 1 Then
				Return 0.0
			End If

			Dim ProjectMilestonesList As New List(Of TabProjectMilestones.RecordDef)
			ProjectMilestonesList = GetProjectMilestonesPrimaryKeySearch(ProjectMilestoneId)
			If ProjectMilestonesList.Count = 1 Then
				Return ProjectMilestonesList(0).HoursSpent
			Else
				Return 0.0
			End If
		End Function

		' get primary key function for field DateCreated
		Public Function GetProjectMilestonesPrimaryKeyDateCreated(ProjectMilestoneId As Long) As Date
			' Only hit the database if the primary key is valid
			If ProjectMilestoneId < 1 Then
				Return Nothing
			End If

			Dim ProjectMilestonesList As New List(Of TabProjectMilestones.RecordDef)
			ProjectMilestonesList = GetProjectMilestonesPrimaryKeySearch(ProjectMilestoneId)
			If ProjectMilestonesList.Count = 1 Then
				Return ProjectMilestonesList(0).DateCreated
			Else
				Return Nothing
			End If
		End Function

		' get primary key record function
		Public Function GetProjectMilestonesPrimaryKeyFullRecord(ProjectMilestoneId As Long) As TabProjectMilestones.RecordDef
			' Only hit the database if the primary key is valid
			If ProjectMilestoneId < 1 Then
				Return Nothing
			End If

			Dim ProjectMilestonesList As New List(Of TabProjectMilestones.RecordDef)
			ProjectMilestonesList = GetProjectMilestonesPrimaryKeySearch(ProjectMilestoneId)
			If ProjectMilestonesList.Count = 1 Then
				Return ProjectMilestonesList(0)
			Else
				Return Nothing
			End If
		End Function

#End Region
	' All code within the Custom BLL Region will be maintained as is by the Business Objects Automation System
	' Any code outside of the custom regions will be lost
#Region "Custom ProjectMilestonesBLL Functions"

		' here you add your custom validation code based on your business logic
		' this code is maintained if the Business Objects program is rerun
		Public Function ValidateData(ByVal rec As TabProjectMilestones.RecordDef) As Boolean
			' make sure identity fields are not validated as these are usually
			' autogenerated by the database system.

			' Check string for length
			If rec.MilestoneDescription.Length > 1000 Then Return False
			If rec.MilestoneDescription.Length = 0 Then Return False

			'  return true if data is ok false if not.
			Return True
		End Function

#End Region

	End Class

End Namespace

