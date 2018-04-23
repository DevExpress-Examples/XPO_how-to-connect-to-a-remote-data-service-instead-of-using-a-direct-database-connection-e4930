Imports DevExpress.Xpo

Imports DevExpress.Xpo.DB
Imports System.ServiceModel

Namespace WcfService1

    Public Class Service1
        Inherits DataStoreService

        Public Shared DataStore As IDataStore

        Shared Sub New()

            Dim connectionString As String = MSSqlConnectionProvider.GetConnectionString("localhost", "ServiceDB")

            DataStore = XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.DatabaseAndSchema)

        End Sub
        Public Sub New()
            MyBase.New(DataStore)
        End Sub

    End Class

End Namespace
