'---------------------------------------------------------------------------------
' Filename:      DataAccessLayer.vb
' Creation Date: 2016-07-15
' Copyright (c): Patchwork Technology Limited
'---------------------------------------------------------------------------------

Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Web.HttpContext
Imports System.Attribute
Imports Microsoft.SqlServer.Types

Namespace DatabaseLayer.QryGetProjectList

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

		Private Function DateToString(datevalue as Date) As string
			Return datevalue.Month.ToString + "/" + datevalue.Day.ToString + "/" + datevalue.Year.ToString
		End Function

		Public Function GetQryGetProjectList() As SqlDataReader
			CreateConnection()
            Dim createString As String = "SELECT Projects.ProjectId, Projects.ProjectName, Projects.Definition, Projects.Outline, Customers.CustomerName, Users.Firstname, Users.Lastname, Projects.CreatedDate FROM Projects LEFT JOIN Customers ON Projects.CustomerId = Customers.CustomerId LEFT JOIN Users ON Projects.ProjectOwnerId = Users.pkUserId ORDER BY Projects.ProjectId"
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
