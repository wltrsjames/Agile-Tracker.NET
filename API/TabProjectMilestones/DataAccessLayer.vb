'---------------------------------------------------------------------------------
' Filename:      DataAccessLayer.vb
' Creation Date: 2016-07-16
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

Namespace DatabaseLayer.TabProjectMilestones

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
			Dim createString as String ="CREATE TABLE ProjectMilestones (ProjectMilestoneId bigint Identity(1,1) not null , ProjectId bigint not null , MilestoneDescription nvarchar(1000) not null , EstimatedHours float not null , EstimatedCost money not null , Status int not null , HoursSpent float not null , DateCreated datetime not null DEFAULT GetDate(), PRIMARY KEY (ProjectMilestoneId))"
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

		Public Function InsertProjectMilestones(ByVal ProjectId As Long, ByVal MilestoneDescription As String, ByVal EstimatedHours As Single, ByVal EstimatedCost As Single, ByVal Status As Integer, ByVal HoursSpent As Single) As Long
			CreateConnection()
			dtr = Nothing
			Dim createString as String ="INSERT INTO ProjectMilestones (ProjectId, MilestoneDescription, EstimatedHours, EstimatedCost, Status, HoursSpent) values (@ProjectId, @MilestoneDescription, @EstimatedHours, @EstimatedCost, @Status, @HoursSpent)"
			Dim cmd As New SqlCommand(createString, con)
			cmd.Parameters.AddWithValue("@ProjectId", ProjectId)
			cmd.Parameters.AddWithValue("@MilestoneDescription", MilestoneDescription)
			cmd.Parameters.AddWithValue("@EstimatedHours", EstimatedHours)
			cmd.Parameters.AddWithValue("@EstimatedCost", EstimatedCost)
			cmd.Parameters.AddWithValue("@Status", Status)
			cmd.Parameters.AddWithValue("@HoursSpent", HoursSpent)

			' Check all string parameters for hidden SQL
			If IsBadParameter(MilestoneDescription) = True Then Return -1

			Try
				con.Open()
				cmd.ExecuteNonQuery()

				Dim findString As String = "SELECT TOP 1 * FROM ProjectMilestones WHERE ProjectId=" + ProjectId.ToString + " AND MilestoneDescription=" + MilestoneDescription.ToString + " AND EstimatedCost=" + EstimatedCost.ToString + " AND Status=" + Status.ToString + "" + " ORDER BY ProjectMilestoneId DESC "
				Dim cmd2 As New SqlCommand(findString, con)

				Try
					dtr = cmd2.ExecuteReader(CommandBehavior.CloseConnection)

					While dtr.Read
						Return CType(dtr("ProjectMilestoneId"),Long)
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

		Public Function UpdateProjectMilestones(ByVal ProjectMilestoneId As Long, ByVal ProjectId As Long, ByVal MilestoneDescription As String, ByVal EstimatedHours As Single, ByVal EstimatedCost As Single, ByVal Status As Integer, ByVal HoursSpent As Single) As Boolean
			CreateConnection()
			Dim createString as String ="UPDATE ProjectMilestones SET ProjectId=@ProjectId, MilestoneDescription=@MilestoneDescription, EstimatedHours=@EstimatedHours, EstimatedCost=@EstimatedCost, Status=@Status, HoursSpent=@HoursSpent WHERE ProjectMilestoneId=@ProjectMilestoneId"
			Dim cmd As New SqlCommand(createString, con)

			cmd.Parameters.AddWithValue("@ProjectMilestoneId", ProjectMilestoneId)
			cmd.Parameters.AddWithValue("@ProjectId", ProjectId)
			cmd.Parameters.AddWithValue("@MilestoneDescription", MilestoneDescription)
			cmd.Parameters.AddWithValue("@EstimatedHours", EstimatedHours)
			cmd.Parameters.AddWithValue("@EstimatedCost", EstimatedCost)
			cmd.Parameters.AddWithValue("@Status", Status)
			cmd.Parameters.AddWithValue("@HoursSpent", HoursSpent)

			' Check all string parameters for hidden SQL
			If IsBadParameter(MilestoneDescription) = True Then Return False

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

		Public Function DeleteProjectMilestones(ByVal ProjectMilestoneId As Long) As Boolean
			CreateConnection()
			Dim createString as String ="DELETE ProjectMilestones WHERE ProjectMilestoneId=@ProjectMilestoneId"
			Dim cmd As New SqlCommand(createString, con)
			cmd.Parameters.AddWithValue("@ProjectMilestoneId", ProjectMilestoneId)

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

		Public Function GetMilestonesByProject(ProjectId As Long) As SqlDataReader
			CreateConnection()
			Dim createString as String ="SELECT * FROM ProjectMilestones WHERE ProjectId=" + ProjectId.ToString + ""
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

		Public Function GetProjectMilestonesPrimaryKeySearch(ProjectMilestoneId As Long) As SqlDataReader
			CreateConnection()
			Dim createString as String ="SELECT * FROM ProjectMilestones WHERE ProjectMilestoneId=" + ProjectMilestoneId.ToString + ""
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

		Public Function GetAll() As SqlDataReader
			CreateConnection()
			Dim createString as String ="SELECT * FROM ProjectMilestones"
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

		Public Function GetMilestoneById(ProjectMilestoneId As Long) As SqlDataReader
			CreateConnection()
			Dim createString as String ="SELECT * FROM ProjectMilestones WHERE ProjectMilestoneId=" + ProjectMilestoneId.ToString + ""
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
