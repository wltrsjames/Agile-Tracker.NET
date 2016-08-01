'---------------------------------------------------------------------------------
' Filename:      DataAccessLayer.vb
' Creation Date: 2016-07-15
'---------------------------------------------------------------------------------
' History        Author              Modification(s)               
'
'---------------------------------------------------------------------------------

Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Web.HttpContext
Imports System.Attribute
Imports Microsoft.SqlServer.Types

Namespace DatabaseLayer.TabUsers

	Public Class DataAccessLayer
	' All code within the DAL Region is automatically generated.
	' Any changes to this code will be lost if the Business Object Tool is run again.
#Region "Private Varibles"

		Private _conString As String = WebConfigurationManager.ConnectionStrings("APIDB").ConnectionString
		Private con As SqlConnection
		Private dtr as SqlDataReader

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

		Private Function CreateConnection() As Boolean
			Try
				con = New SqlConnection(_conString)
			Catch
				Return False
				Exit Function
			End Try

			Return True
		End Function

		Public Function CloseConnection() As Boolean
			Try
				If dtr IsNot Nothing Then
					dtr.Close
					dtr = Nothing
				End If

				' close the connection
				con.Close()

				' garbage collect
				GC.Collect()
			Catch
				Return False
			End Try

			Return True
		End Function

		Public Function CreateTable() As Boolean
			CreateConnection()
			Dim createString as String ="CREATE TABLE Users (pkUserId bigint Identity(1,1) not null , Firstname nvarchar(50) not null , Lastname nvarchar(50) not null , Email nvarchar(128) not null , Password nvarchar(30) not null , Userlevel int not null , CreationDate datetime not null DEFAULT GetDate(), PRIMARY KEY (pkUserId))"
			Dim cmd As New SqlCommand(createString, con)

			Try
				con.Open()
				cmd.ExecuteNonQuery()
			Catch ex As Exception
				' catch exception here
				Return False
			Finally
				CloseConnection()
			End Try

			Return True
		End Function

		Public Function InsertUsers(ByVal Firstname As String, ByVal Lastname As String, ByVal Email As String, ByVal Password As String, ByVal Userlevel As Integer) As Long
			CreateConnection()
			dtr = Nothing
			Dim createString as String ="INSERT INTO Users (Firstname, Lastname, Email, Password, Userlevel) values (@Firstname, @Lastname, @Email, @Password, @Userlevel)"
			Dim cmd As New SqlCommand(createString, con)
			cmd.Parameters.AddWithValue("@Firstname", Firstname)
			cmd.Parameters.AddWithValue("@Lastname", Lastname)
			cmd.Parameters.AddWithValue("@Email", Email)
			cmd.Parameters.AddWithValue("@Password", Password)
			cmd.Parameters.AddWithValue("@Userlevel", Userlevel)

			' Check all string parameters for hidden SQL
			If IsBadParameter(Firstname) = True Then Return -1
			If IsBadParameter(Lastname) = True Then Return -1
			If IsBadParameter(Email) = True Then Return -1
			If IsBadParameter(Password) = True Then Return -1

			Try
				con.Open()
				cmd.ExecuteNonQuery()

                Dim findString As String = "SELECT TOP 1 * FROM Users WHERE Firstname='" + Firstname.ToString + "' AND Lastname='" + Lastname.ToString + "' AND Email='" + Email.ToString + "' AND Password='" + Password.ToString + "' AND Userlevel=" + Userlevel.ToString + "" + " ORDER BY pkUserId DESC "
                Dim cmd2 As New SqlCommand(findString, con)

				Try
					dtr = cmd2.ExecuteReader(CommandBehavior.CloseConnection)

					While dtr.Read
						Return CType(dtr("pkUserId"),Long)
					End While
				Catch ex As Exception
					' catch exception here
				End Try


			Catch ex As Exception
				' catch exception here
				Return -1
			Finally
				CloseConnection()
			End Try

			Return -1
		End Function

		Public Function UpdateUsers(ByVal pkUserId As Long, ByVal Firstname As String, ByVal Lastname As String, ByVal Email As String, ByVal Password As String, ByVal Userlevel As Integer) As Boolean
			CreateConnection()
			Dim createString as String ="UPDATE Users SET Firstname=@Firstname, Lastname=@Lastname, Email=@Email, Password=@Password, Userlevel=@Userlevel WHERE pkUserId=@pkUserId"
			Dim cmd As New SqlCommand(createString, con)

			cmd.Parameters.AddWithValue("@pkUserId", pkUserId)
			cmd.Parameters.AddWithValue("@Firstname", Firstname)
			cmd.Parameters.AddWithValue("@Lastname", Lastname)
			cmd.Parameters.AddWithValue("@Email", Email)
			cmd.Parameters.AddWithValue("@Password", Password)
			cmd.Parameters.AddWithValue("@Userlevel", Userlevel)

			' Check all string parameters for hidden SQL
			If IsBadParameter(Firstname) = True Then Return False
			If IsBadParameter(Lastname) = True Then Return False
			If IsBadParameter(Email) = True Then Return False
			If IsBadParameter(Password) = True Then Return False

			Try
				con.Open()
				cmd.ExecuteNonQuery()
			Catch ex As Exception
				' catch exception here
				Return False
			Finally
				CloseConnection()
			End Try

			Return True
		End Function

		Public Function DeleteUsers(ByVal pkUserId As Long) As Boolean
			CreateConnection()
			Dim createString as String ="DELETE Users WHERE pkUserId=@pkUserId"
			Dim cmd As New SqlCommand(createString, con)
			cmd.Parameters.AddWithValue("@pkUserId", pkUserId)

			Try
				con.Open()
				cmd.ExecuteNonQuery()
			Catch ex As Exception
				' catch exception here
				Return False
			Finally
				CloseConnection()
			End Try

			Return True
		End Function

		Public Function GetUserByUserId(pkUserId As Long) As SqlDataReader
			CreateConnection()
			Dim createString as String ="SELECT * FROM Users WHERE pkUserId=" + pkUserId.ToString + ""
			Dim cmd As New SqlCommand(createString, con)
			dtr = Nothing

			Try
				con.Open()
				dtr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
			Catch ex As Exception
				' catch exception here
			End Try

			Return dtr
		End Function

		Public Function GetUserByEmail(Email As String, Password As String) As SqlDataReader
			CreateConnection()
			Dim createString as String ="SELECT * FROM Users WHERE Email=" +  Chr(39) + Email.ToString +  Chr(39) + " AND Password=" +  Chr(39) + Password.ToString +  Chr(39) + ""
			Dim cmd As New SqlCommand(createString, con)
			dtr = Nothing

			' Check all string parameters for hidden SQL
			If IsBadParameter(Email) = True Then Return Nothing
			If IsBadParameter(Password) = True Then Return Nothing
			Try
				con.Open()
				dtr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
			Catch ex As Exception
				' catch exception here
			End Try

			Return dtr
		End Function

		Public Function GetUsersPrimaryKeySearch(pkUserId As Long) As SqlDataReader
			CreateConnection()
			Dim createString as String ="SELECT * FROM Users WHERE pkUserId=" + pkUserId.ToString + ""
			Dim cmd As New SqlCommand(createString, con)
			dtr = Nothing

			Try
				con.Open()
				dtr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
			Catch ex As Exception
				' catch exception here
			End Try

			Return dtr
		End Function

		Public Function GetAllUsers() As SqlDataReader
			CreateConnection()
			Dim createString as String ="SELECT * FROM Users"
			Dim cmd As New SqlCommand(createString, con)
			dtr = Nothing

			Try
				con.Open()
				dtr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
			Catch ex As Exception
				' catch exception here
			End Try

			Return dtr
		End Function

#End Region

	' All code within the Custom DAL Region will be maintained as is by the Business Objects Automation System
	' Any code outside of the custom regions will be lost
#Region "Custom Functions"

#End Region

	End Class

End Namespace
