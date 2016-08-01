'---------------------------------------------------------------------------------
' Filename:      BusinessLogicLayer.vb
' Creation Date: 2016-07-15
'---------------------------------------------------------------------------------
' History        Author              Modification(s)               
'
'---------------------------------------------------------------------------------

Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.ComponentModel
Imports Microsoft.SqlServer.Types

Namespace DatabaseLayer.TabUsers

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
		Public Function Delete(ByVal pkUserId As Long) As Boolean
			Dim dal as TabUsers.DataAccessLayer = New TabUsers.DataAccessLayer
			Return dal.DeleteUsers(pkUserId)
		End Function

		' update record function
		<DataObjectMethod(DataObjectMethodType.Update)> _
		Public Function Update(ByVal pkUserId As Long, ByVal Firstname As String, ByVal Lastname As String, ByVal Email As String, ByVal Password As String, ByVal Userlevel As Integer) As Boolean
			Dim dal As TabUsers.DataAccessLayer = New TabUsers.DataAccessLayer
			Dim rec As New TabUsers.RecordDef

			' Check all string parameters for hidden SQL
			If IsBadParameter(Firstname) = True Then Return False
			If IsBadParameter(Lastname) = True Then Return False
			If IsBadParameter(Email) = True Then Return False
			If IsBadParameter(Password) = True Then Return False

			' populate the record object for validation to take place
			rec.pkUserId = pkUserId
			rec.Firstname = Firstname
			rec.Lastname = Lastname
			rec.Email = Email
			rec.Password = Password
			rec.Userlevel = Userlevel

			If ValidateData(rec) = True Then
				Return dal.UpdateUsers(pkUserId, Firstname, Lastname, Email, Password, Userlevel)
			End If

			' if we get here then there is a problem so return false
			Return False
		End Function

		' update record function
		<DataObjectMethod(DataObjectMethodType.Update)> _
		Public Function Update(rec As TabUsers.RecordDef) As Boolean
			Dim dal As TabUsers.DataAccessLayer = New TabUsers.DataAccessLayer

			' Check all string parameters for hidden SQL
			If IsBadParameter(rec.Firstname) = True Then Return False
			If IsBadParameter(rec.Lastname) = True Then Return False
			If IsBadParameter(rec.Email) = True Then Return False
			If IsBadParameter(rec.Password) = True Then Return False

			If ValidateData(rec) = True Then
				Return dal.UpdateUsers(rec.pkUserId, rec.Firstname, rec.Lastname, rec.Email, rec.Password, rec.Userlevel)
			End If

			' if we get here then there is a problem so return false
			Return False
		End Function

		' insert record function
		<DataObjectMethod(DataObjectMethodType.Insert)> _
		Public Function Insert(ByVal Firstname As String, ByVal Lastname As String, ByVal Email As String, ByVal Password As String, ByVal Userlevel As Integer) As Long
			Dim dal As TabUsers.DataAccessLayer = New TabUsers.DataAccessLayer
			Dim rec As New TabUsers.RecordDef

			' Check all string parameters for hidden SQL
			If IsBadParameter(Firstname) = True Then Return -1
			If IsBadParameter(Lastname) = True Then Return -1
			If IsBadParameter(Email) = True Then Return -1
			If IsBadParameter(Password) = True Then Return -1

            ' populate the record object for validation to take place
            'rec.pkUserId = pkUserId
            rec.Firstname = Firstname
            rec.Lastname = Lastname
            rec.Email = Email
            rec.Password = Password
            rec.Userlevel = Userlevel

            If ValidateData(rec) = True Then
                Return dal.InsertUsers(Firstname, Lastname, Email, Password, Userlevel)
            End If

            ' if we get here then there is a problem so return -1 meaning no record
            Return -1
        End Function

        ' get record function
        <DataObjectMethod(DataObjectMethodType.Select)>
        Public Function GetUserByUserId(ByVal pkUserId As Long) As List(Of TabUsers.RecordDef)
            Dim reader As SqlDataReader = Nothing
            Dim dal As TabUsers.DataAccessLayer = New TabUsers.DataAccessLayer
            Dim resultlist As New List(Of TabUsers.RecordDef)

            If IsNumeric(pkUserId) = False Then Return Nothing

            reader = dal.GetUserByUserId(pkUserId)

            ' add all rows in the datareader to the list
            If reader IsNot Nothing Then
                While reader.Read
                    Dim newlist As New TabUsers.RecordDef
                    If Not Convert.IsDBNull(reader("pkUserId")) Then
                        newlist.pkUserId = CType(reader("pkUserId"), Long)
                    End If
                    If Not Convert.IsDBNull(reader("Firstname")) Then
                        newlist.Firstname = CType(reader("Firstname"), String)
                    End If
                    If Not Convert.IsDBNull(reader("Lastname")) Then
                        newlist.Lastname = CType(reader("Lastname"), String)
                    End If
                    If Not Convert.IsDBNull(reader("Email")) Then
                        newlist.Email = CType(reader("Email"), String)
                    End If
                    If Not Convert.IsDBNull(reader("Password")) Then
                        newlist.Password = CType(reader("Password"), String)
                    End If
                    If Not Convert.IsDBNull(reader("Userlevel")) Then
                        newlist.Userlevel = CType(reader("Userlevel"), Integer)
                    End If
                    If Not Convert.IsDBNull(reader("CreationDate")) Then
                        newlist.CreationDate = CType(reader("CreationDate"), Date)
                    End If
                    resultlist.Add(newlist)
                End While

                reader.Close()
                reader = Nothing

            End If

            dal.CloseConnection()

            Return resultlist
        End Function

        ' get record function
        <DataObjectMethod(DataObjectMethodType.Select)>
        Public Function GetUserByEmail(ByVal Email As String, ByVal Password As String) As List(Of TabUsers.RecordDef)
            Dim reader As SqlDataReader = Nothing
            Dim dal As TabUsers.DataAccessLayer = New TabUsers.DataAccessLayer
            Dim resultlist As New List(Of TabUsers.RecordDef)

            If Email Is Nothing Then Return Nothing
            If Password Is Nothing Then Return Nothing

            ' Check all string parameters for hidden SQL
            If IsBadParameter(Email) = True Then Return Nothing
            If IsBadParameter(Password) = True Then Return Nothing
            reader = dal.GetUserByEmail(Email, Password)

            ' add all rows in the datareader to the list
            If reader IsNot Nothing Then
                While reader.Read
                    Dim newlist As New TabUsers.RecordDef
                    If Not Convert.IsDBNull(reader("pkUserId")) Then
                        newlist.pkUserId = CType(reader("pkUserId"), Long)
                    End If
                    If Not Convert.IsDBNull(reader("Firstname")) Then
                        newlist.Firstname = CType(reader("Firstname"), String)
                    End If
                    If Not Convert.IsDBNull(reader("Lastname")) Then
                        newlist.Lastname = CType(reader("Lastname"), String)
                    End If
                    If Not Convert.IsDBNull(reader("Email")) Then
                        newlist.Email = CType(reader("Email"), String)
                    End If
                    If Not Convert.IsDBNull(reader("Password")) Then
                        newlist.Password = CType(reader("Password"), String)
                    End If
                    If Not Convert.IsDBNull(reader("Userlevel")) Then
                        newlist.Userlevel = CType(reader("Userlevel"), Integer)
                    End If
                    If Not Convert.IsDBNull(reader("CreationDate")) Then
                        newlist.CreationDate = CType(reader("CreationDate"), Date)
                    End If
                    resultlist.Add(newlist)
                End While

                reader.Close()
                reader = Nothing

            End If

            dal.CloseConnection()

            Return resultlist
        End Function

        ' get record function
        <DataObjectMethod(DataObjectMethodType.Select)>
        Public Function GetUsersPrimaryKeySearch(ByVal pkUserId As Long) As List(Of TabUsers.RecordDef)
            Dim reader As SqlDataReader = Nothing
            Dim dal As TabUsers.DataAccessLayer = New TabUsers.DataAccessLayer
            Dim resultlist As New List(Of TabUsers.RecordDef)

            If IsNumeric(pkUserId) = False Then Return Nothing

            reader = dal.GetUsersPrimaryKeySearch(pkUserId)

            ' add all rows in the datareader to the list
            If reader IsNot Nothing Then
                While reader.Read
                    Dim newlist As New TabUsers.RecordDef
                    If Not Convert.IsDBNull(reader("pkUserId")) Then
                        newlist.pkUserId = CType(reader("pkUserId"), Long)
                    End If
                    If Not Convert.IsDBNull(reader("Firstname")) Then
                        newlist.Firstname = CType(reader("Firstname"), String)
                    End If
                    If Not Convert.IsDBNull(reader("Lastname")) Then
                        newlist.Lastname = CType(reader("Lastname"), String)
                    End If
                    If Not Convert.IsDBNull(reader("Email")) Then
                        newlist.Email = CType(reader("Email"), String)
                    End If
                    If Not Convert.IsDBNull(reader("Password")) Then
                        newlist.Password = CType(reader("Password"), String)
                    End If
                    If Not Convert.IsDBNull(reader("Userlevel")) Then
                        newlist.Userlevel = CType(reader("Userlevel"), Integer)
                    End If
                    If Not Convert.IsDBNull(reader("CreationDate")) Then
                        newlist.CreationDate = CType(reader("CreationDate"), Date)
                    End If
                    resultlist.Add(newlist)
                End While

                reader.Close()
                reader = Nothing

            End If

            dal.CloseConnection()

            Return resultlist
        End Function

        ' get record function
        <DataObjectMethod(DataObjectMethodType.Select)>
        Public Function GetAllUsers() As List(Of TabUsers.RecordDef)
            Dim reader As SqlDataReader = Nothing
            Dim dal As TabUsers.DataAccessLayer = New TabUsers.DataAccessLayer
            Dim resultlist As New List(Of TabUsers.RecordDef)


            reader = dal.GetAllUsers()

            ' add all rows in the datareader to the list
            If reader IsNot Nothing Then
                While reader.Read
                    Dim newlist As New TabUsers.RecordDef
                    If Not Convert.IsDBNull(reader("pkUserId")) Then
                        newlist.pkUserId = CType(reader("pkUserId"), Long)
                    End If
                    If Not Convert.IsDBNull(reader("Firstname")) Then
                        newlist.Firstname = CType(reader("Firstname"), String)
                    End If
                    If Not Convert.IsDBNull(reader("Lastname")) Then
                        newlist.Lastname = CType(reader("Lastname"), String)
                    End If
                    If Not Convert.IsDBNull(reader("Email")) Then
                        newlist.Email = CType(reader("Email"), String)
                    End If
                    If Not Convert.IsDBNull(reader("Password")) Then
                        newlist.Password = CType(reader("Password"), String)
                    End If
                    If Not Convert.IsDBNull(reader("Userlevel")) Then
                        newlist.Userlevel = CType(reader("Userlevel"), Integer)
                    End If
                    If Not Convert.IsDBNull(reader("CreationDate")) Then
                        newlist.CreationDate = CType(reader("CreationDate"), Date)
                    End If
                    resultlist.Add(newlist)
                End While

                reader.Close()
                reader = Nothing

            End If

            dal.CloseConnection()

            Return resultlist
        End Function

        ' get primary key function for field Firstname
        Public Function GetUsersPrimaryKeyFirstname(pkUserId As Long) As String
			' Only hit the database if the primary key is valid
			If pkUserId < 1 Then
				Return ""
			End If

			Dim UsersList As New List(Of TabUsers.RecordDef)
			UsersList = GetUsersPrimaryKeySearch(pkUserId)
			If UsersList.Count = 1 Then
				Return UsersList(0).Firstname
			Else
				Return ""
			End If
		End Function

		' get primary key function for field Lastname
		Public Function GetUsersPrimaryKeyLastname(pkUserId As Long) As String
			' Only hit the database if the primary key is valid
			If pkUserId < 1 Then
				Return ""
			End If

			Dim UsersList As New List(Of TabUsers.RecordDef)
			UsersList = GetUsersPrimaryKeySearch(pkUserId)
			If UsersList.Count = 1 Then
				Return UsersList(0).Lastname
			Else
				Return ""
			End If
		End Function

		' get primary key function for field Email
		Public Function GetUsersPrimaryKeyEmail(pkUserId As Long) As String
			' Only hit the database if the primary key is valid
			If pkUserId < 1 Then
				Return ""
			End If

			Dim UsersList As New List(Of TabUsers.RecordDef)
			UsersList = GetUsersPrimaryKeySearch(pkUserId)
			If UsersList.Count = 1 Then
				Return UsersList(0).Email
			Else
				Return ""
			End If
		End Function

		' get primary key function for field Password
		Public Function GetUsersPrimaryKeyPassword(pkUserId As Long) As String
			' Only hit the database if the primary key is valid
			If pkUserId < 1 Then
				Return ""
			End If

			Dim UsersList As New List(Of TabUsers.RecordDef)
			UsersList = GetUsersPrimaryKeySearch(pkUserId)
			If UsersList.Count = 1 Then
				Return UsersList(0).Password
			Else
				Return ""
			End If
		End Function

		' get primary key function for field Userlevel
		Public Function GetUsersPrimaryKeyUserlevel(pkUserId As Long) As Integer
			' Only hit the database if the primary key is valid
			If pkUserId < 1 Then
				Return 0
			End If

			Dim UsersList As New List(Of TabUsers.RecordDef)
			UsersList = GetUsersPrimaryKeySearch(pkUserId)
			If UsersList.Count = 1 Then
				Return UsersList(0).Userlevel
			Else
				Return 0
			End If
		End Function

		' get primary key function for field CreationDate
		Public Function GetUsersPrimaryKeyCreationDate(pkUserId As Long) As Date
			' Only hit the database if the primary key is valid
			If pkUserId < 1 Then
				Return Nothing
			End If

			Dim UsersList As New List(Of TabUsers.RecordDef)
			UsersList = GetUsersPrimaryKeySearch(pkUserId)
			If UsersList.Count = 1 Then
				Return UsersList(0).CreationDate
			Else
				Return Nothing
			End If
		End Function

		' get primary key record function
		Public Function GetUsersPrimaryKeyFullRecord(pkUserId As Long) As TabUsers.RecordDef
			' Only hit the database if the primary key is valid
			If pkUserId < 1 Then
				Return Nothing
			End If

			Dim UsersList As New List(Of TabUsers.RecordDef)
			UsersList = GetUsersPrimaryKeySearch(pkUserId)
			If UsersList.Count = 1 Then
				Return UsersList(0)
			Else
				Return Nothing
			End If
		End Function

#End Region
	' All code within the Custom BLL Region will be maintained as is by the Business Objects Automation System
	' Any code outside of the custom regions will be lost
#Region "Custom UsersBLL Functions"

        ' here you add your custom validation code based on your business logic
        ' this code is maintained if the Business Objects program is rerun
        Public Function ValidateData(ByVal rec As TabUsers.RecordDef) As Boolean
            ' make sure identity fields are not validated as these are usually
            ' autogenerated by the database system.

            ' Check string for length


            '  return true if data is ok false if not.
            Return True
        End Function

#End Region

	End Class

End Namespace

