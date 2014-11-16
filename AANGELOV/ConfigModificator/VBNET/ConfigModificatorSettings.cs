Namespace AAngelov.Utilities.Configuration
	''' <summary>
	''' Contains Config Writer Setting Properties
	''' </summary>
	Public Class ConfigModificatorSettings
		''' <summary>
		''' Gets or sets the application settings node.
		''' </summary>
		''' <value>
		''' The application settings node.
		''' </value>
		Public Property RootNode() As String
			Get
				Return m_RootNode
			End Get
			Set
				m_RootNode = Value
			End Set
		End Property
		Private m_RootNode As String

		''' <summary>
		''' Gets or sets the node for edit.
		''' </summary>
		''' <value>
		''' The node for edit.
		''' </value>
		Public Property NodeForEdit() As String
			Get
				Return m_NodeForEdit
			End Get
			Set
				m_NodeForEdit = Value
			End Set
		End Property
		Private m_NodeForEdit As String

		''' <summary>
		''' Gets or sets the configuration path.
		''' </summary>
		''' <value>
		''' The configuration path.
		''' </value>
		Public Property ConfigPath() As String
			Get
				Return m_ConfigPath
			End Get
			Set
				m_ConfigPath = Value
			End Set
		End Property
		Private m_ConfigPath As String

		''' <summary>
		''' Initializes a new instance of the <see cref="ConfigModificatorSettings"/> class.
		''' </summary>
		''' <param name="appSettingsNode">The application settings node.</param>
		''' <param name="nodeForEdit">The node for edit.</param>
		''' <param name="configPath">The configuration path.</param>
		Public Sub New(appSettingsNode As [String], nodeForEdit As [String], configPath As String)
			Me.RootNode = appSettingsNode
			Me.NodeForEdit = nodeForEdit
			Me.ConfigPath = configPath
		End Sub

		''' <summary>
		''' Initializes a new instance of the <see cref="ConfigModificatorSettings"/> class.
		''' </summary>
		''' <param name="appSettingsNode">The application settings node.</param>
		''' <param name="configPath">The configuration path.</param>
		Public Sub New(appSettingsNode As [String], configPath As String)
			Me.RootNode = appSettingsNode
			Me.ConfigPath = configPath
		End Sub
	End Class
End Namespace