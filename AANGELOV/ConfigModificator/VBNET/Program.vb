Imports AAngelov.Utilities.Configuration
Imports System.Collections.Generic
Imports System.Configuration
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.Text
Imports System.Threading.Tasks

Namespace TestConfigModificator.Console
	Class Program
		Private Shared Sub Main(args As String())
			'Example how to change app.config file associated to your application. 
			'You can use the same approach for web.configs and other type of configurations
			Dim appConfigFilePath As String = String.Concat(Assembly.GetExecutingAssembly().Location, ".config")
			Dim appConfigWriterSettings As New ConfigModificatorSettings("//appSettings", "//add[@key='{0}']", appConfigFilePath)

			Dim value As String = ConfigurationManager.AppSettings("testKey1")
			System.Console.WriteLine("Value before modification: {0}", value)

			ConfigModificator.ChangeValueByKey(key := "testKey1", value := "ChangedValueByModificator", attributeForChange := "value", configWriterSettings := appConfigWriterSettings)

			ConfigModificator.RefreshAppSettings()
			value = ConfigurationManager.AppSettings("testKey1")
			System.Console.WriteLine("Value after modification: {0}", value)

			'Example how to change Custom XML configuration
			Dim carsConfigFilePath As String = "Cars.xml"
			Dim carsConfigWriterSettings As New ConfigModificatorSettings("//cars", "//car[@name='{0}']", carsConfigFilePath)

			ConfigModificator.ChangeValueByKey(key := "BMW", value := "Mazda", attributeForChange := "name", configWriterSettings := carsConfigWriterSettings)
		End Sub
	End Class
End Namespace