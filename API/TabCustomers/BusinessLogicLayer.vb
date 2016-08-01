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

Namespace DatabaseLayer.TabCustomers

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
		Public Function Delete(ByVal CustomerId As Long) As Boolean
			Dim dal as TabCustomers.DataAccessLayer = New TabCustomers.DataAccessLayer
			Return dal.DeleteCustomers(CustomerId)
		End Function

		' update record function
		<DataObjectMethod(DataObjectMethodType.Update)> _
		Public Function Update(ByVal CustomerId As Long, ByVal CustomerName As String, ByVal CompanyName As String, ByVal CompanyAddress As String, ByVal CompanyPostcode As String, ByVal CompanyPhone As String, ByVal Mobile As String, ByVal Email As String) As Boolean
			Dim dal As TabCustomers.DataAccessLayer = New TabCustomers.DataAccessLayer
			Dim rec As New TabCustomers.RecordDef

			' Check all string parameters for hidden SQL
			If IsBadParameter(CustomerName) = True Then Return False
			If IsBadParameter(CompanyName) = True Then Return False
			If IsBadParameter(CompanyAddress) = True Then Return False
			If IsBadParameter(CompanyPostcode) = True Then Return False
			If IsBadParameter(CompanyPhone) = True Then Return False
			If IsBadParameter(Mobile) = True Then Return False
			If IsBadParameter(Email) = True Then Return False

			' populate the record object for validation to take place
			rec.CustomerId = CustomerId
			rec.CustomerName = CustomerName
			rec.CompanyName = CompanyName
			rec.CompanyAddress = CompanyAddress
			rec.CompanyPostcode = CompanyPostcode
			rec.CompanyPhone = CompanyPhone
			rec.Mobile = Mobile
			rec.Email = Email

			If ValidateData(rec) = True Then
				Return dal.UpdateCustomers(CustomerId, CustomerName, CompanyName, CompanyAddress, CompanyPostcode, CompanyPhone, Mobile, Email)
			End If

			' if we get here then there is a problem so return false
			Return False
		End Function

		' update record function
		<DataObjectMethod(DataObjectMethodType.Update)> _
		Public Function Update(rec As TabCustomers.RecordDef) As Boolean
			Dim dal As TabCustomers.DataAccessLayer = New TabCustomers.DataAccessLayer

			' Check all string parameters for hidden SQL
			If IsBadParameter(rec.CustomerName) = True Then Return False
			If IsBadParameter(rec.CompanyName) = True Then Return False
			If IsBadParameter(rec.CompanyAddress) = True Then Return False
			If IsBadParameter(rec.CompanyPostcode) = True Then Return False
			If IsBadParameter(rec.CompanyPhone) = True Then Return False
			If IsBadParameter(rec.Mobile) = True Then Return False
			If IsBadParameter(rec.Email) = True Then Return False

			If ValidateData(rec) = True Then
				Return dal.UpdateCustomers(rec.CustomerId, rec.CustomerName, rec.CompanyName, rec.CompanyAddress, rec.CompanyPostcode, rec.CompanyPhone, rec.Mobile, rec.Email)
			End If

			' if we get here then there is a problem so return false
			Return False
		End Function

		' insert record function
		<DataObjectMethod(DataObjectMethodType.Insert)> _
		Public Function Insert(ByVal CustomerName As String, ByVal CompanyName As String, ByVal CompanyAddress As String, ByVal CompanyPostcode As String, ByVal CompanyPhone As String, ByVal Mobile As String, ByVal Email As String) As Long
			Dim dal As TabCustomers.DataAccessLayer = New TabCustomers.DataAccessLayer
			Dim rec As New TabCustomers.RecordDef

			' Check all string parameters for hidden SQL
			If IsBadParameter(CustomerName) = True Then Return -1
			If IsBadParameter(CompanyName) = True Then Return -1
			If IsBadParameter(CompanyAddress) = True Then Return -1
			If IsBadParameter(CompanyPostcode) = True Then Return -1
			If IsBadParameter(CompanyPhone) = True Then Return -1
			If IsBadParameter(Mobile) = True Then Return -1
			If IsBadParameter(Email) = True Then Return -1

            ' populate the record object for validation to take place
            'rec.CustomerId = CustomerId
            rec.CustomerName = CustomerName
			rec.CompanyName = CompanyName
			rec.CompanyAddress = CompanyAddress
			rec.CompanyPostcode = CompanyPostcode
			rec.CompanyPhone = CompanyPhone
			rec.Mobile = Mobile
			rec.Email = Email

			If ValidateData(rec) = True Then
				Return dal.InsertCustomers(CustomerName, CompanyName, CompanyAddress, CompanyPostcode, CompanyPhone, Mobile, Email)
			End If

			' if we get here then there is a problem so return -1 meaning no record
			Return -1
		End Function

		' get record function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Function GetAll() As List(Of TabCustomers.RecordDef)
			Dim reader As SqlDataReader = Nothing
			Dim dal As TabCustomers.DataAccessLayer = New TabCustomers.DataAccessLayer
			Dim resultlist As New List(Of TabCustomers.RecordDef)


			reader = dal.GetAll()

			' add all rows in the datareader to the list
			If reader IsNot Nothing Then
				While reader.Read
					Dim newlist As New TabCustomers.RecordDef
					If Not Convert.IsDBNull(reader("CustomerId")) Then 
					newlist.CustomerId = CType(reader("CustomerId"), Long)
					End if
					If Not Convert.IsDBNull(reader("CustomerName")) Then 
					newlist.CustomerName = CType(reader("CustomerName"), String)
					End if
					If Not Convert.IsDBNull(reader("CompanyName")) Then 
					newlist.CompanyName = CType(reader("CompanyName"), String)
					End if
					If Not Convert.IsDBNull(reader("CompanyAddress")) Then 
					newlist.CompanyAddress = CType(reader("CompanyAddress"), String)
					End if
					If Not Convert.IsDBNull(reader("CompanyPostcode")) Then 
					newlist.CompanyPostcode = CType(reader("CompanyPostcode"), String)
					End if
					If Not Convert.IsDBNull(reader("CompanyPhone")) Then 
					newlist.CompanyPhone = CType(reader("CompanyPhone"), String)
					End if
					If Not Convert.IsDBNull(reader("Mobile")) Then 
					newlist.Mobile = CType(reader("Mobile"), String)
					End if
					If Not Convert.IsDBNull(reader("Email")) Then 
					newlist.Email = CType(reader("Email"), String)
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
		Public Function GetCustomerById(ByVal CustomerId As Long) As List(Of TabCustomers.RecordDef)
			Dim reader As SqlDataReader = Nothing
			Dim dal As TabCustomers.DataAccessLayer = New TabCustomers.DataAccessLayer
			Dim resultlist As New List(Of TabCustomers.RecordDef)

			If IsNumeric(CustomerId) = False Then Return Nothing

			reader = dal.GetCustomerById(CustomerId)

			' add all rows in the datareader to the list
			If reader IsNot Nothing Then
				While reader.Read
					Dim newlist As New TabCustomers.RecordDef
					If Not Convert.IsDBNull(reader("CustomerId")) Then 
					newlist.CustomerId = CType(reader("CustomerId"), Long)
					End if
					If Not Convert.IsDBNull(reader("CustomerName")) Then 
					newlist.CustomerName = CType(reader("CustomerName"), String)
					End if
					If Not Convert.IsDBNull(reader("CompanyName")) Then 
					newlist.CompanyName = CType(reader("CompanyName"), String)
					End if
					If Not Convert.IsDBNull(reader("CompanyAddress")) Then 
					newlist.CompanyAddress = CType(reader("CompanyAddress"), String)
					End if
					If Not Convert.IsDBNull(reader("CompanyPostcode")) Then 
					newlist.CompanyPostcode = CType(reader("CompanyPostcode"), String)
					End if
					If Not Convert.IsDBNull(reader("CompanyPhone")) Then 
					newlist.CompanyPhone = CType(reader("CompanyPhone"), String)
					End if
					If Not Convert.IsDBNull(reader("Mobile")) Then 
					newlist.Mobile = CType(reader("Mobile"), String)
					End if
					If Not Convert.IsDBNull(reader("Email")) Then 
					newlist.Email = CType(reader("Email"), String)
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
		Public Function GetCustomersPrimaryKeySearch(ByVal CustomerId As Long) As List(Of TabCustomers.RecordDef)
			Dim reader As SqlDataReader = Nothing
			Dim dal As TabCustomers.DataAccessLayer = New TabCustomers.DataAccessLayer
			Dim resultlist As New List(Of TabCustomers.RecordDef)

			If IsNumeric(CustomerId) = False Then Return Nothing

			reader = dal.GetCustomersPrimaryKeySearch(CustomerId)

			' add all rows in the datareader to the list
			If reader IsNot Nothing Then
				While reader.Read
					Dim newlist As New TabCustomers.RecordDef
					If Not Convert.IsDBNull(reader("CustomerId")) Then 
					newlist.CustomerId = CType(reader("CustomerId"), Long)
					End if
					If Not Convert.IsDBNull(reader("CustomerName")) Then 
					newlist.CustomerName = CType(reader("CustomerName"), String)
					End if
					If Not Convert.IsDBNull(reader("CompanyName")) Then 
					newlist.CompanyName = CType(reader("CompanyName"), String)
					End if
					If Not Convert.IsDBNull(reader("CompanyAddress")) Then 
					newlist.CompanyAddress = CType(reader("CompanyAddress"), String)
					End if
					If Not Convert.IsDBNull(reader("CompanyPostcode")) Then 
					newlist.CompanyPostcode = CType(reader("CompanyPostcode"), String)
					End if
					If Not Convert.IsDBNull(reader("CompanyPhone")) Then 
					newlist.CompanyPhone = CType(reader("CompanyPhone"), String)
					End if
					If Not Convert.IsDBNull(reader("Mobile")) Then 
					newlist.Mobile = CType(reader("Mobile"), String)
					End if
					If Not Convert.IsDBNull(reader("Email")) Then 
					newlist.Email = CType(reader("Email"), String)
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

		' get primary key function for field CustomerName
		Public Function GetCustomersPrimaryKeyCustomerName(CustomerId As Long) As String
			' Only hit the database if the primary key is valid
			If CustomerId < 1 Then
				Return ""
			End If

			Dim CustomersList As New List(Of TabCustomers.RecordDef)
			CustomersList = GetCustomersPrimaryKeySearch(CustomerId)
			If CustomersList.Count = 1 Then
				Return CustomersList(0).CustomerName
			Else
				Return ""
			End If
		End Function

		' get primary key function for field CompanyName
		Public Function GetCustomersPrimaryKeyCompanyName(CustomerId As Long) As String
			' Only hit the database if the primary key is valid
			If CustomerId < 1 Then
				Return ""
			End If

			Dim CustomersList As New List(Of TabCustomers.RecordDef)
			CustomersList = GetCustomersPrimaryKeySearch(CustomerId)
			If CustomersList.Count = 1 Then
				Return CustomersList(0).CompanyName
			Else
				Return ""
			End If
		End Function

		' get primary key function for field CompanyAddress
		Public Function GetCustomersPrimaryKeyCompanyAddress(CustomerId As Long) As String
			' Only hit the database if the primary key is valid
			If CustomerId < 1 Then
				Return ""
			End If

			Dim CustomersList As New List(Of TabCustomers.RecordDef)
			CustomersList = GetCustomersPrimaryKeySearch(CustomerId)
			If CustomersList.Count = 1 Then
				Return CustomersList(0).CompanyAddress
			Else
				Return ""
			End If
		End Function

		' get primary key function for field CompanyPostcode
		Public Function GetCustomersPrimaryKeyCompanyPostcode(CustomerId As Long) As String
			' Only hit the database if the primary key is valid
			If CustomerId < 1 Then
				Return ""
			End If

			Dim CustomersList As New List(Of TabCustomers.RecordDef)
			CustomersList = GetCustomersPrimaryKeySearch(CustomerId)
			If CustomersList.Count = 1 Then
				Return CustomersList(0).CompanyPostcode
			Else
				Return ""
			End If
		End Function

		' get primary key function for field CompanyPhone
		Public Function GetCustomersPrimaryKeyCompanyPhone(CustomerId As Long) As String
			' Only hit the database if the primary key is valid
			If CustomerId < 1 Then
				Return ""
			End If

			Dim CustomersList As New List(Of TabCustomers.RecordDef)
			CustomersList = GetCustomersPrimaryKeySearch(CustomerId)
			If CustomersList.Count = 1 Then
				Return CustomersList(0).CompanyPhone
			Else
				Return ""
			End If
		End Function

		' get primary key function for field Mobile
		Public Function GetCustomersPrimaryKeyMobile(CustomerId As Long) As String
			' Only hit the database if the primary key is valid
			If CustomerId < 1 Then
				Return ""
			End If

			Dim CustomersList As New List(Of TabCustomers.RecordDef)
			CustomersList = GetCustomersPrimaryKeySearch(CustomerId)
			If CustomersList.Count = 1 Then
				Return CustomersList(0).Mobile
			Else
				Return ""
			End If
		End Function

		' get primary key function for field Email
		Public Function GetCustomersPrimaryKeyEmail(CustomerId As Long) As String
			' Only hit the database if the primary key is valid
			If CustomerId < 1 Then
				Return ""
			End If

			Dim CustomersList As New List(Of TabCustomers.RecordDef)
			CustomersList = GetCustomersPrimaryKeySearch(CustomerId)
			If CustomersList.Count = 1 Then
				Return CustomersList(0).Email
			Else
				Return ""
			End If
		End Function

		' get primary key function for field DateCreated
		Public Function GetCustomersPrimaryKeyDateCreated(CustomerId As Long) As Date
			' Only hit the database if the primary key is valid
			If CustomerId < 1 Then
				Return Nothing
			End If

			Dim CustomersList As New List(Of TabCustomers.RecordDef)
			CustomersList = GetCustomersPrimaryKeySearch(CustomerId)
			If CustomersList.Count = 1 Then
				Return CustomersList(0).DateCreated
			Else
				Return Nothing
			End If
		End Function

		' get primary key record function
		Public Function GetCustomersPrimaryKeyFullRecord(CustomerId As Long) As TabCustomers.RecordDef
			' Only hit the database if the primary key is valid
			If CustomerId < 1 Then
				Return Nothing
			End If

			Dim CustomersList As New List(Of TabCustomers.RecordDef)
			CustomersList = GetCustomersPrimaryKeySearch(CustomerId)
			If CustomersList.Count = 1 Then
				Return CustomersList(0)
			Else
				Return Nothing
			End If
		End Function

#End Region
	' All code within the Custom BLL Region will be maintained as is by the Business Objects Automation System
	' Any code outside of the custom regions will be lost
#Region "Custom CustomersBLL Functions"

		' here you add your custom validation code based on your business logic
		' this code is maintained if the Business Objects program is rerun
		Public Function ValidateData(ByVal rec As TabCustomers.RecordDef) As Boolean
			' make sure identity fields are not validated as these are usually
			' autogenerated by the database system.

			' Check string for length
			If rec.CustomerName.Length > 50 Then Return False
			If rec.CustomerName.Length = 0 Then Return False
			If rec.CompanyName.Length > 50 Then Return False
			If rec.CompanyName.Length = 0 Then Return False
			If rec.CompanyAddress.Length > 128 Then Return False
			If rec.CompanyAddress.Length = 0 Then Return False
			If rec.CompanyPostcode.Length > 10 Then Return False
			If rec.CompanyPostcode.Length = 0 Then Return False
			If rec.CompanyPhone.Length > 15 Then Return False
			If rec.CompanyPhone.Length = 0 Then Return False
			If rec.Mobile.Length > 15 Then Return False
			If rec.Mobile.Length = 0 Then Return False
			If rec.Email.Length > 128 Then Return False
			If rec.Email.Length = 0 Then Return False

			'  return true if data is ok false if not.
			Return True
		End Function

#End Region

	End Class

End Namespace

