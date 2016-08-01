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

Namespace DatabaseLayer.TabUserStories

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
		Public Function Delete(ByVal UserStoryId As Long) As Boolean
			Dim dal as TabUserStories.DataAccessLayer = New TabUserStories.DataAccessLayer
			Return dal.DeleteUserStories(UserStoryId)
		End Function

		' update record function
		<DataObjectMethod(DataObjectMethodType.Update)> _
		Public Function Update(ByVal UserStoryId As Long, ByVal ProjectId As Long, ByVal UserRole As String, ByVal Request As String, ByVal Purpose As String, ByVal AcceptanceCriteria As String, ByVal MVP As Integer) As Boolean
			Dim dal As TabUserStories.DataAccessLayer = New TabUserStories.DataAccessLayer
			Dim rec As New TabUserStories.RecordDef

			' Check all string parameters for hidden SQL
			If IsBadParameter(UserRole) = True Then Return False
			If IsBadParameter(Request) = True Then Return False
			If IsBadParameter(Purpose) = True Then Return False
			If IsBadParameter(AcceptanceCriteria) = True Then Return False

			' populate the record object for validation to take place
			rec.UserStoryId = UserStoryId
			rec.ProjectId = ProjectId
			rec.UserRole = UserRole
			rec.Request = Request
			rec.Purpose = Purpose
			rec.AcceptanceCriteria = AcceptanceCriteria
			rec.MVP = MVP

			If ValidateData(rec) = True Then
				Return dal.UpdateUserStories(UserStoryId, ProjectId, UserRole, Request, Purpose, AcceptanceCriteria, MVP)
			End If

			' if we get here then there is a problem so return false
			Return False
		End Function

		' update record function
		<DataObjectMethod(DataObjectMethodType.Update)> _
		Public Function Update(rec As TabUserStories.RecordDef) As Boolean
			Dim dal As TabUserStories.DataAccessLayer = New TabUserStories.DataAccessLayer

			' Check all string parameters for hidden SQL
			If IsBadParameter(rec.UserRole) = True Then Return False
			If IsBadParameter(rec.Request) = True Then Return False
			If IsBadParameter(rec.Purpose) = True Then Return False
			If IsBadParameter(rec.AcceptanceCriteria) = True Then Return False

			If ValidateData(rec) = True Then
				Return dal.UpdateUserStories(rec.UserStoryId, rec.ProjectId, rec.UserRole, rec.Request, rec.Purpose, rec.AcceptanceCriteria, rec.MVP)
			End If

			' if we get here then there is a problem so return false
			Return False
		End Function

		' insert record function
		<DataObjectMethod(DataObjectMethodType.Insert)> _
		Public Function Insert(ByVal ProjectId As Long, ByVal UserRole As String, ByVal Request As String, ByVal Purpose As String, ByVal AcceptanceCriteria As String, ByVal MVP As Integer) As Long
			Dim dal As TabUserStories.DataAccessLayer = New TabUserStories.DataAccessLayer
			Dim rec As New TabUserStories.RecordDef

			' Check all string parameters for hidden SQL
			If IsBadParameter(UserRole) = True Then Return -1
			If IsBadParameter(Request) = True Then Return -1
			If IsBadParameter(Purpose) = True Then Return -1
			If IsBadParameter(AcceptanceCriteria) = True Then Return -1

            ' populate the record object for validation to take place
            'rec.UserStoryId = UserStoryId
            rec.ProjectId = ProjectId
			rec.UserRole = UserRole
			rec.Request = Request
			rec.Purpose = Purpose
			rec.AcceptanceCriteria = AcceptanceCriteria
			rec.MVP = MVP

			If ValidateData(rec) = True Then
				Return dal.InsertUserStories(ProjectId, UserRole, Request, Purpose, AcceptanceCriteria, MVP)
			End If

			' if we get here then there is a problem so return -1 meaning no record
			Return -1
		End Function

		' get record function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Function GetUserStoryByProjectId(ByVal ProjectId As Long) As List(Of TabUserStories.RecordDef)
			Dim reader As SqlDataReader = Nothing
			Dim dal As TabUserStories.DataAccessLayer = New TabUserStories.DataAccessLayer
			Dim resultlist As New List(Of TabUserStories.RecordDef)

			If IsNumeric(ProjectId) = False Then Return Nothing

			reader = dal.GetUserStoryByProjectId(ProjectId)

			' add all rows in the datareader to the list
			If reader IsNot Nothing Then
				While reader.Read
					Dim newlist As New TabUserStories.RecordDef
					If Not Convert.IsDBNull(reader("UserStoryId")) Then 
					newlist.UserStoryId = CType(reader("UserStoryId"), Long)
					End if
					If Not Convert.IsDBNull(reader("ProjectId")) Then 
					newlist.ProjectId = CType(reader("ProjectId"), Long)
					End if
					If Not Convert.IsDBNull(reader("UserRole")) Then 
					newlist.UserRole = CType(reader("UserRole"), String)
					End if
					If Not Convert.IsDBNull(reader("Request")) Then 
					newlist.Request = CType(reader("Request"), String)
					End if
					If Not Convert.IsDBNull(reader("Purpose")) Then 
					newlist.Purpose = CType(reader("Purpose"), String)
					End if
					If Not Convert.IsDBNull(reader("AcceptanceCriteria")) Then 
					newlist.AcceptanceCriteria = CType(reader("AcceptanceCriteria"), String)
					End if
					If Not Convert.IsDBNull(reader("MVP")) Then 
					newlist.MVP = CType(reader("MVP"), Integer)
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
		Public Function GetUserStoriesPrimaryKeySearch(ByVal UserStoryId As Long) As List(Of TabUserStories.RecordDef)
			Dim reader As SqlDataReader = Nothing
			Dim dal As TabUserStories.DataAccessLayer = New TabUserStories.DataAccessLayer
			Dim resultlist As New List(Of TabUserStories.RecordDef)

			If IsNumeric(UserStoryId) = False Then Return Nothing

			reader = dal.GetUserStoriesPrimaryKeySearch(UserStoryId)

			' add all rows in the datareader to the list
			If reader IsNot Nothing Then
				While reader.Read
					Dim newlist As New TabUserStories.RecordDef
					If Not Convert.IsDBNull(reader("UserStoryId")) Then 
					newlist.UserStoryId = CType(reader("UserStoryId"), Long)
					End if
					If Not Convert.IsDBNull(reader("ProjectId")) Then 
					newlist.ProjectId = CType(reader("ProjectId"), Long)
					End if
					If Not Convert.IsDBNull(reader("UserRole")) Then 
					newlist.UserRole = CType(reader("UserRole"), String)
					End if
					If Not Convert.IsDBNull(reader("Request")) Then 
					newlist.Request = CType(reader("Request"), String)
					End if
					If Not Convert.IsDBNull(reader("Purpose")) Then 
					newlist.Purpose = CType(reader("Purpose"), String)
					End if
					If Not Convert.IsDBNull(reader("AcceptanceCriteria")) Then 
					newlist.AcceptanceCriteria = CType(reader("AcceptanceCriteria"), String)
					End if
					If Not Convert.IsDBNull(reader("MVP")) Then 
					newlist.MVP = CType(reader("MVP"), Integer)
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
		Public Function GetAll() As List(Of TabUserStories.RecordDef)
			Dim reader As SqlDataReader = Nothing
			Dim dal As TabUserStories.DataAccessLayer = New TabUserStories.DataAccessLayer
			Dim resultlist As New List(Of TabUserStories.RecordDef)


			reader = dal.GetAll()

			' add all rows in the datareader to the list
			If reader IsNot Nothing Then
				While reader.Read
					Dim newlist As New TabUserStories.RecordDef
					If Not Convert.IsDBNull(reader("UserStoryId")) Then 
					newlist.UserStoryId = CType(reader("UserStoryId"), Long)
					End if
					If Not Convert.IsDBNull(reader("ProjectId")) Then 
					newlist.ProjectId = CType(reader("ProjectId"), Long)
					End if
					If Not Convert.IsDBNull(reader("UserRole")) Then 
					newlist.UserRole = CType(reader("UserRole"), String)
					End if
					If Not Convert.IsDBNull(reader("Request")) Then 
					newlist.Request = CType(reader("Request"), String)
					End if
					If Not Convert.IsDBNull(reader("Purpose")) Then 
					newlist.Purpose = CType(reader("Purpose"), String)
					End if
					If Not Convert.IsDBNull(reader("AcceptanceCriteria")) Then 
					newlist.AcceptanceCriteria = CType(reader("AcceptanceCriteria"), String)
					End if
					If Not Convert.IsDBNull(reader("MVP")) Then 
					newlist.MVP = CType(reader("MVP"), Integer)
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
		Public Function GetUserStoryById(ByVal UserStoryId As Long) As List(Of TabUserStories.RecordDef)
			Dim reader As SqlDataReader = Nothing
			Dim dal As TabUserStories.DataAccessLayer = New TabUserStories.DataAccessLayer
			Dim resultlist As New List(Of TabUserStories.RecordDef)

			If IsNumeric(UserStoryId) = False Then Return Nothing

			reader = dal.GetUserStoryById(UserStoryId)

			' add all rows in the datareader to the list
			If reader IsNot Nothing Then
				While reader.Read
					Dim newlist As New TabUserStories.RecordDef
					If Not Convert.IsDBNull(reader("UserStoryId")) Then 
					newlist.UserStoryId = CType(reader("UserStoryId"), Long)
					End if
					If Not Convert.IsDBNull(reader("ProjectId")) Then 
					newlist.ProjectId = CType(reader("ProjectId"), Long)
					End if
					If Not Convert.IsDBNull(reader("UserRole")) Then 
					newlist.UserRole = CType(reader("UserRole"), String)
					End if
					If Not Convert.IsDBNull(reader("Request")) Then 
					newlist.Request = CType(reader("Request"), String)
					End if
					If Not Convert.IsDBNull(reader("Purpose")) Then 
					newlist.Purpose = CType(reader("Purpose"), String)
					End if
					If Not Convert.IsDBNull(reader("AcceptanceCriteria")) Then 
					newlist.AcceptanceCriteria = CType(reader("AcceptanceCriteria"), String)
					End if
					If Not Convert.IsDBNull(reader("MVP")) Then 
					newlist.MVP = CType(reader("MVP"), Integer)
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
		Public Function GetUserStoriesPrimaryKeyProjectId(UserStoryId As Long) As Long
			' Only hit the database if the primary key is valid
			If UserStoryId < 1 Then
				Return 0
			End If

			Dim UserStoriesList As New List(Of TabUserStories.RecordDef)
			UserStoriesList = GetUserStoriesPrimaryKeySearch(UserStoryId)
			If UserStoriesList.Count = 1 Then
				Return UserStoriesList(0).ProjectId
			Else
				Return 0
			End If
		End Function

		' get primary key function for field UserRole
		Public Function GetUserStoriesPrimaryKeyUserRole(UserStoryId As Long) As String
			' Only hit the database if the primary key is valid
			If UserStoryId < 1 Then
				Return ""
			End If

			Dim UserStoriesList As New List(Of TabUserStories.RecordDef)
			UserStoriesList = GetUserStoriesPrimaryKeySearch(UserStoryId)
			If UserStoriesList.Count = 1 Then
				Return UserStoriesList(0).UserRole
			Else
				Return ""
			End If
		End Function

		' get primary key function for field Request
		Public Function GetUserStoriesPrimaryKeyRequest(UserStoryId As Long) As String
			' Only hit the database if the primary key is valid
			If UserStoryId < 1 Then
				Return ""
			End If

			Dim UserStoriesList As New List(Of TabUserStories.RecordDef)
			UserStoriesList = GetUserStoriesPrimaryKeySearch(UserStoryId)
			If UserStoriesList.Count = 1 Then
				Return UserStoriesList(0).Request
			Else
				Return ""
			End If
		End Function

		' get primary key function for field Purpose
		Public Function GetUserStoriesPrimaryKeyPurpose(UserStoryId As Long) As String
			' Only hit the database if the primary key is valid
			If UserStoryId < 1 Then
				Return ""
			End If

			Dim UserStoriesList As New List(Of TabUserStories.RecordDef)
			UserStoriesList = GetUserStoriesPrimaryKeySearch(UserStoryId)
			If UserStoriesList.Count = 1 Then
				Return UserStoriesList(0).Purpose
			Else
				Return ""
			End If
		End Function

		' get primary key function for field AcceptanceCriteria
		Public Function GetUserStoriesPrimaryKeyAcceptanceCriteria(UserStoryId As Long) As String
			' Only hit the database if the primary key is valid
			If UserStoryId < 1 Then
				Return ""
			End If

			Dim UserStoriesList As New List(Of TabUserStories.RecordDef)
			UserStoriesList = GetUserStoriesPrimaryKeySearch(UserStoryId)
			If UserStoriesList.Count = 1 Then
				Return UserStoriesList(0).AcceptanceCriteria
			Else
				Return ""
			End If
		End Function

		' get primary key function for field MVP
		Public Function GetUserStoriesPrimaryKeyMVP(UserStoryId As Long) As Integer
			' Only hit the database if the primary key is valid
			If UserStoryId < 1 Then
				Return 0
			End If

			Dim UserStoriesList As New List(Of TabUserStories.RecordDef)
			UserStoriesList = GetUserStoriesPrimaryKeySearch(UserStoryId)
			If UserStoriesList.Count = 1 Then
				Return UserStoriesList(0).MVP
			Else
				Return 0
			End If
		End Function

		' get primary key record function
		Public Function GetUserStoriesPrimaryKeyFullRecord(UserStoryId As Long) As TabUserStories.RecordDef
			' Only hit the database if the primary key is valid
			If UserStoryId < 1 Then
				Return Nothing
			End If

			Dim UserStoriesList As New List(Of TabUserStories.RecordDef)
			UserStoriesList = GetUserStoriesPrimaryKeySearch(UserStoryId)
			If UserStoriesList.Count = 1 Then
				Return UserStoriesList(0)
			Else
				Return Nothing
			End If
		End Function

#End Region
	' All code within the Custom BLL Region will be maintained as is by the Business Objects Automation System
	' Any code outside of the custom regions will be lost
#Region "Custom UserStoriesBLL Functions"

		' here you add your custom validation code based on your business logic
		' this code is maintained if the Business Objects program is rerun
		Public Function ValidateData(ByVal rec As TabUserStories.RecordDef) As Boolean
			' make sure identity fields are not validated as these are usually
			' autogenerated by the database system.

			' Check string for length
			If rec.UserRole.Length > 30 Then Return False
			If rec.UserRole.Length = 0 Then Return False
			If rec.Request.Length > 255 Then Return False
			If rec.Request.Length = 0 Then Return False
			If rec.Purpose.Length > 255 Then Return False
			If rec.Purpose.Length = 0 Then Return False
			If rec.AcceptanceCriteria.Length > 255 Then Return False
			If rec.AcceptanceCriteria.Length = 0 Then Return False

			'  return true if data is ok false if not.
			Return True
		End Function

#End Region

	End Class

End Namespace

