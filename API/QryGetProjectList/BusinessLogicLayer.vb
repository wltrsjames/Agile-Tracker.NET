'---------------------------------------------------------------------------------
' Filename:      BusinessLogicLayer.vb
' Creation Date: 2016-07-15
' Copyright (c): Patchwork Technology Limited
'---------------------------------------------------------------------------------

Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.ComponentModel
Imports Microsoft.SqlServer.Types
Imports Patchwork.Libraries.PWCommon.Win32

Namespace DatabaseLayer.QryGetProjectList

	<DataObject(True)> _
	Public Class BusinessLogicLayer
	' All code within the BLL Region is automatically generated.
	' Any changes to this code will be lost if the Business Object Tool is run again.

#Region "Private Varibles"


#End Region

#Region "Generated Code"

		' get record function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Function GetQryGetProjectList() As List(Of QryGetProjectList.RecordDef)
			Dim reader As SqlDataReader = Nothing
			Dim dal As QryGetProjectList.DataAccessLayer = New QryGetProjectList.DataAccessLayer
			Dim resultlist As New List(Of QryGetProjectList.RecordDef)


			reader = dal.GetQryGetProjectList()

			' add all rows in the datareader to the list
			If reader IsNot Nothing Then
				While reader.Read
					Dim newlist As New QryGetProjectList.RecordDef
					newlist.Projects_ProjectId = CType(reader(0), Long)
					newlist.Projects_ProjectName = CType(reader(1), String)
					newlist.Projects_Definition = CType(reader(2), String)
					newlist.Projects_Outline = CType(reader(3), String)
					Try
						newlist.Customers_CustomerName = CType(reader(4), String)
					Catch
                        newlist.Customers_CustomerName = "Unassigned"
                    End Try
					Try
						newlist.Users_Firstname = CType(reader(5), String)
					Catch
                        newlist.Users_Firstname = "Unassigned"
                    End Try
					Try
						newlist.Users_Lastname = CType(reader(6), String)
					Catch
                        newlist.Users_Lastname = "Unassigned"
                    End Try
					newlist.Projects_CreatedDate = CType(reader(7), Date)
					resultlist.Add(newlist)
				End While

				reader.Close()
				reader = Nothing

			End If

			dal.CloseConnection()

			Return resultlist
		End Function

#End Region
	' All code within the Custom BLL Region will be maintained as is by the Business Objects Automation System
	' Any code outside of the custom regions will be lost
#Region "Custom GetProjectListBLL Functions"

#End Region

	End Class

End Namespace

