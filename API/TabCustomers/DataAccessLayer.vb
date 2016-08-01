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

Namespace DatabaseLayer.TabCustomers

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
			Dim createString as String ="CREATE TABLE Customers (CustomerId bigint Identity(1,1) not null , CustomerName nvarchar(50) not null , CompanyName nvarchar(50) not null , CompanyAddress nvarchar(128) not null , CompanyPostcode nvarchar(10) not null , CompanyPhone nvarchar(15) not null , Mobile nvarchar(15) not null , Email nvarchar(128) not null , DateCreated datetime not null DEFAULT GetDate(), PRIMARY KEY (CustomerId))"
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

		Public Function InsertCustomers(ByVal CustomerName As String, ByVal CompanyName As String, ByVal CompanyAddress As String, ByVal CompanyPostcode As String, ByVal CompanyPhone As String, ByVal Mobile As String, ByVal Email As String) As Long
			CreateConnection()
			dtr = Nothing
			Dim createString as String ="INSERT INTO Customers (CustomerName, CompanyName, CompanyAddress, CompanyPostcode, CompanyPhone, Mobile, Email) values (@CustomerName, @CompanyName, @CompanyAddress, @CompanyPostcode, @CompanyPhone, @Mobile, @Email)"
			Dim cmd As New SqlCommand(createString, con)
			cmd.Parameters.AddWithValue("@CustomerName", CustomerName)
			cmd.Parameters.AddWithValue("@CompanyName", CompanyName)
			cmd.Parameters.AddWithValue("@CompanyAddress", CompanyAddress)
			cmd.Parameters.AddWithValue("@CompanyPostcode", CompanyPostcode)
			cmd.Parameters.AddWithValue("@CompanyPhone", CompanyPhone)
			cmd.Parameters.AddWithValue("@Mobile", Mobile)
			cmd.Parameters.AddWithValue("@Email", Email)

			' Check all string parameters for hidden SQL
			If IsBadParameter(CustomerName) = True Then Return -1
			If IsBadParameter(CompanyName) = True Then Return -1
			If IsBadParameter(CompanyAddress) = True Then Return -1
			If IsBadParameter(CompanyPostcode) = True Then Return -1
			If IsBadParameter(CompanyPhone) = True Then Return -1
			If IsBadParameter(Mobile) = True Then Return -1
			If IsBadParameter(Email) = True Then Return -1

			Try
				con.Open()
				cmd.ExecuteNonQuery()

                Dim findString As String = "SELECT TOP 1 * FROM Customers WHERE CustomerName='" + CustomerName.ToString + "' AND CompanyName='" + CompanyName.ToString + "' AND CompanyAddress='" + CompanyAddress.ToString + "' AND CompanyPostcode='" + CompanyPostcode.ToString + "' AND CompanyPhone='" + CompanyPhone.ToString + "' AND Mobile='" + Mobile.ToString + "' AND Email='" + Email.ToString + "'" + " ORDER BY CustomerId DESC "
                Dim cmd2 As New SqlCommand(findString, con)

				Try
					dtr = cmd2.ExecuteReader(CommandBehavior.CloseConnection)

					While dtr.Read
						Return CType(dtr("CustomerId"),Long)
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

		Public Function UpdateCustomers(ByVal CustomerId As Long, ByVal CustomerName As String, ByVal CompanyName As String, ByVal CompanyAddress As String, ByVal CompanyPostcode As String, ByVal CompanyPhone As String, ByVal Mobile As String, ByVal Email As String) As Boolean
			CreateConnection()
			Dim createString as String ="UPDATE Customers SET CustomerName=@CustomerName, CompanyName=@CompanyName, CompanyAddress=@CompanyAddress, CompanyPostcode=@CompanyPostcode, CompanyPhone=@CompanyPhone, Mobile=@Mobile, Email=@Email WHERE CustomerId=@CustomerId"
			Dim cmd As New SqlCommand(createString, con)

			cmd.Parameters.AddWithValue("@CustomerId", CustomerId)
			cmd.Parameters.AddWithValue("@CustomerName", CustomerName)
			cmd.Parameters.AddWithValue("@CompanyName", CompanyName)
			cmd.Parameters.AddWithValue("@CompanyAddress", CompanyAddress)
			cmd.Parameters.AddWithValue("@CompanyPostcode", CompanyPostcode)
			cmd.Parameters.AddWithValue("@CompanyPhone", CompanyPhone)
			cmd.Parameters.AddWithValue("@Mobile", Mobile)
			cmd.Parameters.AddWithValue("@Email", Email)

			' Check all string parameters for hidden SQL
			If IsBadParameter(CustomerName) = True Then Return False
			If IsBadParameter(CompanyName) = True Then Return False
			If IsBadParameter(CompanyAddress) = True Then Return False
			If IsBadParameter(CompanyPostcode) = True Then Return False
			If IsBadParameter(CompanyPhone) = True Then Return False
			If IsBadParameter(Mobile) = True Then Return False
			If IsBadParameter(Email) = True Then Return False

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

		Public Function DeleteCustomers(ByVal CustomerId As Long) As Boolean
			CreateConnection()
			Dim createString as String ="DELETE Customers WHERE CustomerId=@CustomerId"
			Dim cmd As New SqlCommand(createString, con)
			cmd.Parameters.AddWithValue("@CustomerId", CustomerId)

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

		Public Function GetAll() As SqlDataReader
			CreateConnection()
			Dim createString as String ="SELECT * FROM Customers"
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

		Public Function GetCustomerById(CustomerId As Long) As SqlDataReader
			CreateConnection()
			Dim createString as String ="SELECT * FROM Customers WHERE CustomerId=" + CustomerId.ToString + ""
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

		Public Function GetCustomersPrimaryKeySearch(CustomerId As Long) As SqlDataReader
			CreateConnection()
			Dim createString as String ="SELECT * FROM Customers WHERE CustomerId=" + CustomerId.ToString + ""
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
