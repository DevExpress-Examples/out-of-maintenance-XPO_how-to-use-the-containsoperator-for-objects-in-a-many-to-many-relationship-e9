Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports System.Windows.Forms
Imports A2404

Namespace DXSample
	Public Class Program
		<STAThread> _
		Shared Sub Main()
			XpoDefault.ConnectionString = AccessConnectionProvider.GetConnectionString("..\..\data.mdb")
			Application.EnableVisualStyles()
			Application.Run(New Form1())
		End Sub
	End Class
End Namespace