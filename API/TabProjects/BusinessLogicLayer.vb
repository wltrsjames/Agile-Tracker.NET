'---------------------------------------------------------------------------------
' Filename:      BusinessLogicLayer.vb
' Creation Date: 2016-04-02
'---------------------------------------------------------------------------------
' History        Author              Modification(s)               
'
'---------------------------------------------------------------------------------

Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.ComponentModel
'Imports Microsoft.SqlServer.Types

Namespace DatabaseLayer.TabProjects

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
		Public Function Delete(ByVal ProjectId As Long) As Boolean
			Dim dal as TabProjects.DataAccessLayer = New TabProjects.DataAccessLayer
			Return dal.DeleteProjects(ProjectId)
		End Function

		' update record function
		<DataObjectMethod(DataObjectMethodType.Update)> _
		Public Function Update(ByVal ProjectId As Long, ByVal ProjectName As String, ByVal Definition As String, ByVal Outline As String, ByVal CustomerId As Long, ByVal ProjectOwnerId As Long) As Boolean
			Dim dal As TabProjects.DataAccessLayer = New TabProjects.DataAccessLayer
			Dim rec As New TabProjects.RecordDef

			' Check all string parameters for hidden SQL
			If IsBadParameter(ProjectName) = True Then Return False
			If IsBadParameter(Definition) = True Then Return False
			If IsBadParameter(Outline) = True Then Return False

			' populate the record object for validation to take place
			rec.ProjectId = ProjectId
			rec.ProjectName = ProjectName
			rec.Definition = Definition
			rec.Outline = Outline
			rec.CustomerId = CustomerId
			rec.ProjectOwnerId = ProjectOwnerId

			If ValidateData(rec) = True Then
				Return dal.UpdateProjects(ProjectId, ProjectName, Definition, Outline, CustomerId, ProjectOwnerId)
			End If

			' if we get here then there is a problem so return false
			Return False
		End Function

		' update record function
		<DataObjectMethod(DataObjectMethodType.Update)> _
		Public Function Update(rec As TabProjects.RecordDef) As Boolean
			Dim dal As TabProjects.DataAccessLayer = New TabProjects.DataAccessLayer

			' Check all string parameters for hidden SQL
			If IsBadParameter(rec.ProjectName) = True Then Return False
			If IsBadParameter(rec.Definition) = True Then Return False
			If IsBadParameter(rec.Outline) = True Then Return False

			If ValidateData(rec) = True Then
				Return dal.UpdateProjects(rec.ProjectId, rec.ProjectName, rec.Definition, rec.Outline, rec.CustomerId, rec.ProjectOwnerId)
			End If

			' if we get here then there is a problem so return false
			Return False
		End Function

		' insert record function
		<DataObjectMethod(DataObjectMethodType.Insert)> _
		Public Function Insert(ByVal ProjectName As String, ByVal Definition As String, ByVal Outline As String, ByVal CustomerId As Long, ByVal ProjectOwnerId As Long) As Long
			Dim dal As TabProjects.DataAccessLayer = New TabProjects.DataAccessLayer
			Dim rec As New TabProjects.RecordDef

			' Check all string parameters for hidden SQL
			If IsBadParameter(ProjectName) = True Then Return -1
			If IsBadParameter(Definition) = True Then Return -1
			If IsBadParameter(Outline) = True Then Return -1

			' populate the record object for validation to take place
            'rec.ProjectId = ProjectId
			rec.ProjectName = ProjectName
			rec.Definition = Definition
			rec.Outline = Outline
			rec.CustomerId = CustomerId
			rec.ProjectOwnerId = ProjectOwnerId

			If ValidateData(rec) = True Then
				Return dal.InsertProjects(ProjectName, Definition, Outline, CustomerId, ProjectOwnerId)
			End If

			' if we get here then there is a problem so return -1 meaning no record
			Return -1
		End Function

		' get record function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Function GetAllProjects() As List(Of TabProjects.RecordDef)
			Dim reader As SqlDataReader = Nothing
			Dim dal As TabProjects.DataAccessLayer = New TabProjects.DataAccessLayer
			Dim resultlist As New List(Of TabProjects.RecordDef)


			reader = dal.GetAllProjects()

			' add all rows in the datareader to the list
			If reader IsNot Nothing Then
				While reader.Read
					Dim newlist As New TabProjects.RecordDef
					If Not Convert.IsDBNull(reader("ProjectId")) Then 
					newlist.ProjectId = CType(reader("ProjectId"), Long)
					End if
					If Not Convert.IsDBNull(reader("ProjectName")) Then 
					newlist.ProjectName = CType(reader("ProjectName"), String)
					End if
					If Not Convert.IsDBNull(reader("Definition")) Then 
					newlist.Definition = CType(reader("Definition"), String)
					End if
					If Not Convert.IsDBNull(reader("Outline")) Then 
					newlist.Outline = CType(reader("Outline"), String)
					End if
					If Not Convert.IsDBNull(reader("CustomerId")) Then 
					newlist.CustomerId = CType(reader("CustomerId"), Long)
					End if
					If Not Convert.IsDBNull(reader("ProjectOwnerId")) Then 
					newlist.ProjectOwnerId = CType(reader("ProjectOwnerId"), Long)
					End if
					If Not Convert.IsDBNull(reader("CreatedDate")) Then 
					newlist.CreatedDate = CType(reader("CreatedDate"), Date)
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
		Public Function GetProjectById(ByVal ProjectId As Long) As List(Of TabProjects.RecordDef)
			Dim reader As SqlDataReader = Nothing
			Dim dal As TabProjects.DataAccessLayer = New TabProjects.DataAccessLayer
			Dim resultlist As New List(Of TabProjects.RecordDef)

			If IsNumeric(ProjectId) = False Then Return Nothing

			reader = dal.GetProjectById(ProjectId)

			' add all rows in the datareader to the list
			If reader IsNot Nothing Then
				While reader.Read
					Dim newlist As New TabProjects.RecordDef
					If Not Convert.IsDBNull(reader("ProjectId")) Then 
					newlist.ProjectId = CType(reader("ProjectId"), Long)
					End if
					If Not Convert.IsDBNull(reader("ProjectName")) Then 
					newlist.ProjectName = CType(reader("ProjectName"), String)
					End if
					If Not Convert.IsDBNull(reader("Definition")) Then 
					newlist.Definition = CType(reader("Definition"), String)
					End if
					If Not Convert.IsDBNull(reader("Outline")) Then 
					newlist.Outline = CType(reader("Outline"), String)
					End if
					If Not Convert.IsDBNull(reader("CustomerId")) Then 
					newlist.CustomerId = CType(reader("CustomerId"), Long)
					End if
					If Not Convert.IsDBNull(reader("ProjectOwnerId")) Then 
					newlist.ProjectOwnerId = CType(reader("ProjectOwnerId"), Long)
					End if
					If Not Convert.IsDBNull(reader("CreatedDate")) Then 
					newlist.CreatedDate = CType(reader("CreatedDate"), Date)
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
		Public Function GetProjectsPrimaryKeySearch(ByVal ProjectId As Long) As List(Of TabProjects.RecordDef)
			Dim reader As SqlDataReader = Nothing
			Dim dal As TabProjects.DataAccessLayer = New TabProjects.DataAccessLayer
			Dim resultlist As New List(Of TabProjects.RecordDef)

			If IsNumeric(ProjectId) = False Then Return Nothing

			reader = dal.GetProjectsPrimaryKeySearch(ProjectId)

			' add all rows in the datareader to the list
			If reader IsNot Nothing Then
				While reader.Read
					Dim newlist As New TabProjects.RecordDef
					If Not Convert.IsDBNull(reader("ProjectId")) Then 
					newlist.ProjectId = CType(reader("ProjectId"), Long)
					End if
					If Not Convert.IsDBNull(reader("ProjectName")) Then 
					newlist.ProjectName = CType(reader("ProjectName"), String)
					End if
					If Not Convert.IsDBNull(reader("Definition")) Then 
					newlist.Definition = CType(reader("Definition"), String)
					End if
					If Not Convert.IsDBNull(reader("Outline")) Then 
					newlist.Outline = CType(reader("Outline"), String)
					End if
					If Not Convert.IsDBNull(reader("CustomerId")) Then 
					newlist.CustomerId = CType(reader("CustomerId"), Long)
					End if
					If Not Convert.IsDBNull(reader("ProjectOwnerId")) Then 
					newlist.ProjectOwnerId = CType(reader("ProjectOwnerId"), Long)
					End if
					If Not Convert.IsDBNull(reader("CreatedDate")) Then 
					newlist.CreatedDate = CType(reader("CreatedDate"), Date)
					End if
					resultlist.Add(newlist)
				End While

				reader.Close()
				reader = Nothing

			End If

			dal.CloseConnection()

			Return resultlist
		End Function

		' get primary key function for field ProjectName
		Public Function GetProjectsPrimaryKeyProjectName(ProjectId As Long) As String
			' Only hit the database if the primary key is valid
			If ProjectId < 1 Then
				Return ""
			End If

			Dim ProjectsList As New List(Of TabProjects.RecordDef)
			ProjectsList = GetProjectsPrimaryKeySearch(ProjectId)
			If ProjectsList.Count = 1 Then
				Return ProjectsList(0).ProjectName
			Else
				Return ""
			End If
		End Function

		' get primary key function for field Definition
		Public Function GetProjectsPrimaryKeyDefinition(ProjectId As Long) As String
			' Only hit the database if the primary key is valid
			If ProjectId < 1 Then
				Return ""
			End If

			Dim ProjectsList As New List(Of TabProjects.RecordDef)
			ProjectsList = GetProjectsPrimaryKeySearch(ProjectId)
			If ProjectsList.Count = 1 Then
				Return ProjectsList(0).Definition
			Else
				Return ""
			End If
		End Function

		' get primary key function for field Outline
		Public Function GetProjectsPrimaryKeyOutline(ProjectId As Long) As String
			' Only hit the database if the primary key is valid
			If ProjectId < 1 Then
				Return ""
			End If

			Dim ProjectsList As New List(Of TabProjects.RecordDef)
			ProjectsList = GetProjectsPrimaryKeySearch(ProjectId)
			If ProjectsList.Count = 1 Then
				Return ProjectsList(0).Outline
			Else
				Return ""
			End If
		End Function

		' get primary key function for field CustomerId
		Public Function GetProjectsPrimaryKeyCustomerId(ProjectId As Long) As Long
			' Only hit the database if the primary key is valid
			If ProjectId < 1 Then
				Return 0
			End If

			Dim ProjectsList As New List(Of TabProjects.RecordDef)
			ProjectsList = GetProjectsPrimaryKeySearch(ProjectId)
			If ProjectsList.Count = 1 Then
				Return ProjectsList(0).CustomerId
			Else
				Return 0
			End If
		End Function

		' get primary key function for field ProjectOwnerId
		Public Function GetProjectsPrimaryKeyProjectOwnerId(ProjectId As Long) As Long
			' Only hit the database if the primary key is valid
			If ProjectId < 1 Then
				Return 0
			End If

			Dim ProjectsList As New List(Of TabProjects.RecordDef)
			ProjectsList = GetProjectsPrimaryKeySearch(ProjectId)
			If ProjectsList.Count = 1 Then
				Return ProjectsList(0).ProjectOwnerId
			Else
				Return 0
			End If
		End Function

		' get primary key function for field CreatedDate
		Public Function GetProjectsPrimaryKeyCreatedDate(ProjectId As Long) As Date
			' Only hit the database if the primary key is valid
			If ProjectId < 1 Then
				Return Nothing
			End If

			Dim ProjectsList As New List(Of TabProjects.RecordDef)
			ProjectsList = GetProjectsPrimaryKeySearch(ProjectId)
			If ProjectsList.Count = 1 Then
				Return ProjectsList(0).CreatedDate
			Else
				Return Nothing
			End If
		End Function

		' get primary key record function
		Public Function GetProjectsPrimaryKeyFullRecord(ProjectId As Long) As TabProjects.RecordDef
			' Only hit the database if the primary key is valid
			If ProjectId < 1 Then
				Return Nothing
			End If

			Dim ProjectsList As New List(Of TabProjects.RecordDef)
			ProjectsList = GetProjectsPrimaryKeySearch(ProjectId)
			If ProjectsList.Count = 1 Then
				Return ProjectsList(0)
			Else
				Return Nothing
			End If
		End Function

#End Region
	' All code within the Custom BLL Region will be maintained as is by the Business Objects Automation System
	' Any code outside of the custom regions will be lost
#Region "Custom ProjectsBLL Functions"

		' here you add your custom validation code based on your business logic
		' this code is maintained if the Business Objects program is rerun
		Public Function ValidateData(ByVal rec As TabProjects.RecordDef) As Boolean
			' make sure identity fields are not validated as these are usually
			' autogenerated by the database system.

			' Check string for length
			If rec.ProjectName.Length > 50 Then Return False
			If rec.ProjectName.Length = 0 Then Return False
			If rec.Definition.Length > 255 Then Return False
			If rec.Definition.Length = 0 Then Return False
			If rec.Outline.Length > 1000 Then Return False
			If rec.Outline.Length = 0 Then Return False

			'  return true if data is ok false if not.
			Return True
		End Function

#End Region

	End Class

End Namespace

