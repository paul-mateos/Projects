Imports System.Configuration
Imports System.Reflection
Imports System.Xml

Namespace AAngelov.Utilities.Configuration
	''' <summary>
	''' Contains static methods for settings file modification
	''' </summary>
	Public NotInheritable Class ConfigModificator
		Private Sub New()
		End Sub
		''' <summary>
		''' Writes the setting.
		''' </summary>
		''' <param name="key">The key.</param>
		''' <param name="value">The value.</param>
		''' <param name="configWriterSettings">The configuration writer settings.</param>
		''' <exception cref="System.InvalidOperationException">appSettings section not found in config file.</exception>
		Public Shared Sub WriteSetting(key As String, value As String, configWriterSettings As ConfigModificatorSettings)
			Dim doc As XmlDocument = ConfigModificator.LoadConfigDocument(configWriterSettings.ConfigPath)
			' retrieve appSettings node
			Dim rootNode As XmlNode = doc.SelectSingleNode(configWriterSettings.RootNode)

			If rootNode Is Nothing Then
				Throw New InvalidOperationException("appSettings section not found in config file.")
			End If

			Try
				' select the 'note for edit' element that contains your key
				Dim elem As XmlElement = DirectCast(rootNode.SelectSingleNode(String.Format(configWriterSettings.NodeForEdit, key)), XmlElement)
				elem.FirstChild.InnerText = value
				doc.Save(configWriterSettings.ConfigPath)
			Catch
				Throw
			End Try
		End Sub

		''' <summary>
		''' Changes the value by key.
		''' </summary>
		''' <param name="key">The key.</param>
		''' <param name="value">The value.</param>
		''' <param name="attributeForChange">The attribute for change.</param>
		''' <param name="configWriterSettings">The configuration writer settings.</param>
		''' <exception cref="System.InvalidOperationException">appSettings section not found in config file.</exception>
		Public Shared Sub ChangeValueByKey(key As String, value As String, attributeForChange As String, configWriterSettings As ConfigModificatorSettings)
			Dim doc As XmlDocument = ConfigModificator.LoadConfigDocument(configWriterSettings.ConfigPath)
			' retrieve the root node
			Dim rootNode As XmlNode = doc.SelectSingleNode(configWriterSettings.RootNode)

			If rootNode Is Nothing Then
				Throw New InvalidOperationException("the root node section not found in config file.")
			End If

			Try
				' select the element that contains the key
				Dim elem As XmlElement = DirectCast(rootNode.SelectSingleNode(String.Format(configWriterSettings.NodeForEdit, key)), XmlElement)
				elem.SetAttribute(attributeForChange, value)
				doc.Save(configWriterSettings.ConfigPath)
			Catch ex As Exception
				Throw ex
			End Try
		End Sub

		''' <summary>
		''' Loads the configuration document.
		''' </summary>
		''' <param name="configFilePath">The configuration file path.</param>
		''' <returns></returns>
		''' <exception cref="System.Exception">No configuration file found.</exception>
		Private Shared Function LoadConfigDocument(configFilePath As String) As XmlDocument
			Dim doc As XmlDocument = Nothing
			Try
				doc = New XmlDocument()
				doc.Load(configFilePath)
				Return doc
			Catch e As System.IO.FileNotFoundException
				Throw New Exception("No configuration file found.", e)
			End Try
		End Function

		''' <summary>
		''' Refreshes the application settings.
		''' </summary>
		Public Shared Sub RefreshAppSettings()
			ConfigurationManager.RefreshSection("appSettings")
		End Sub
	End Class
End Namespace