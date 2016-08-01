'---------------------------------------------------------------------------------
' Filename:      DataAccessLayer.vb
' Creation Date: 2016-04-02
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

Namespace DatabaseLayer.TabProjects

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
			Dim createString as String ="CREATE TABLE Projects (ProjectId bigint Identity(1,1) not null , ProjectName nvarchar(50) not null , Definition nvarchar(255) not null , Outline nvarchar(1000) not null , CustomerId bigint not null , ProjectOwnerId bigint not null , CreatedDate datetime not null DEFAULT GetDate(), PRIMARY KEY (ProjectId))"
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

		Public Function InsertProjects(ByVal ProjectName As String, ByVal Definition As String, ByVal Outline As String, ByVal CustomerId As Long, ByVal ProjectOwnerId As Long) As Long
			CreateConnection()
			dtr = Nothing
			Dim createString as String ="INSERT INTO Projects (ProjectName, Definition, Outline, CustomerId, ProjectOwnerId) values (@ProjectName, @Definition, @Outline, @CustomerId, @ProjectOwnerId)"
			Dim cmd As New SqlCommand(createString, con)
			cmd.Parameters.AddWithValue("@ProjectName", ProjectName)
			cmd.Parameters.AddWithValue("@Definition", Definition)
			cmd.Parameters.AddWithValue("@Outline", Outline)
			cmd.Parameters.AddWithValue("@CustomerId", CustomerId)
			cmd.Parameters.AddWithValue("@ProjectOwnerId", ProjectOwnerId)

			' Check all string parameters for hidden SQL
			If IsBadParameter(ProjectName) = True Then Return -1
			If IsBadParameter(Definition) = True Then Return -1
			If IsBadParameter(Outline) = True Then Return -1

			Try
				con.Open()
				cmd.ExecuteNonQuery()

                Dim findString As String = "SELECT TOP 1 * FROM Projects WHERE ProjectName='" + ProjectName.ToString + "' AND Definition='" + Definition.ToString + "' AND Outline='" + Outline.ToString + "' AND CustomerId=" + CustomerId.ToString + " AND ProjectOwnerId=" + ProjectOwnerId.ToString + "" + " ORDER BY ProjectId DESC "
                Dim cmd2 As New SqlCommand(findString, con)

				Try
					dtr = cmd2.ExecuteReader(CommandBehavior.CloseConnection)

					While dtr.Read
						Return CType(dtr("ProjectId"),Long)
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

		Public Function UpdateProjects(ByVal ProjectId As Long, ByVal ProjectName As String, ByVal Definition As String, ByVal Outline As String, ByVal CustomerId As Long, ByVal ProjectOwnerId As Long) As Boolean
			CreateConnection()
			Dim createString as String ="UPDATE Projects SET ProjectName=@ProjectName, Definition=@Definition, Outline=@Outline, CustomerId=@CustomerId, ProjectOwnerId=@ProjectOwnerId WHERE ProjectId=@ProjectId"
			Dim cmd As New SqlCommand(createString, con)

			cmd.Parameters.AddWithValue("@ProjectId", ProjectId)
			cmd.Parameters.AddWithValue("@ProjectName", ProjectName)
			cmd.Parameters.AddWithValue("@Definition", Definition)
			cmd.Parameters.AddWithValue("@Outline", Outline)
			cmd.Parameters.AddWithValue("@CustomerId", CustomerId)
			cmd.Parameters.AddWithValue("@ProjectOwnerId", ProjectOwnerId)

			' Check all string parameters for hidden SQL
			If IsBadParameter(ProjectName) = True Then Return False
			If IsBadParameter(Definition) = True Then Return False
			If IsBadParameter(Outline) = True Then Return False

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

		Public Function DeleteProjects(ByVal ProjectId As Long) As Boolean
			CreateConnection()
			Dim createString as String ="DELETE Projects WHERE ProjectId=@ProjectId"
			Dim cmd As New SqlCommand(createString, con)
			cmd.Parameters.AddWithValue("@ProjectId", ProjectId)

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

		Public Function GetAllProjects() As SqlDataReader
			CreateConnection()
			Dim createString as String ="SELECT * FROM Projects"
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

		Public Function GetProjectById(ProjectId As Long) As SqlDataReader
			CreateConnection()
			Dim createString as String ="SELECT * FROM Projects WHERE ProjectId=" + ProjectId.ToString + ""
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

		Public Function GetProjectsPrimaryKeySearch(ProjectId As Long) As SqlDataReader
			CreateConnection()
			Dim createString as String ="SELECT * FROM Projects WHERE ProjectId=" + ProjectId.ToString + ""
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
