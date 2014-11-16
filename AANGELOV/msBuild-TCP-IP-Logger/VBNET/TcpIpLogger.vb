Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Microsoft.Build.Utilities
Imports Microsoft.Build.Framework
Imports System.Net.Sockets
Imports System.Net
Imports System.Configuration
Imports System.Threading
 
Public Class TcpIpLogger
    Inherits Logger
    #Region "Private Fields"
    Private paramaterBag As IDictionary(Of String, String)
    Private Shared networkStream As NetworkStream
    Private clientSocketWriter As TcpClient
    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    #End Region
 
    #Region "ILogger Members"
    Public Overrides Sub Initialize(eventSource As IEventSource)
        Try
            Me.InitializeParameters()
 
            Me.SubscribeToEvents(eventSource)
 
            log.Info("Initialize MS Build Logger!")
 
            Dim ipStr As String = GetParameterValue("ip")
            Dim ipServer As IPAddress = IPAddress.Parse(ipStr)
            Dim port As Integer = Integer.Parse(GetParameterValue("port"))
            log.InfoFormat("MS Build Logger port to write {0}", port)
 
            clientSocketWriter = New System.Net.Sockets.TcpClient()
            clientSocketWriter.Connect(ipServer, port)
            networkStream = clientSocketWriter.GetStream()
            Thread.Sleep(1000)
        Catch ex As Exception
            log.[Error]("Exception in MS Build logger", ex)
        End Try
    End Sub
 
    Public Overrides Sub Shutdown()
        clientSocketWriter.GetStream().Close()
        clientSocketWriter.Close()
    End Sub
    #End Region
 
    Protected Overridable Sub InitializeParameters()
        Try
            Me.paramaterBag = New Dictionary(Of String, String)()
            log.Info("Initialize Logger params")
            If Not String.IsNullOrEmpty(Parameters) Then
                For Each paramString As String In Me.Parameters.Split(";".ToCharArray())
                    Dim keyValue As String() = paramString.Split("=".ToCharArray())
                    If keyValue Is Nothing OrElse keyValue.Length < 2 Then
                        Continue For
                    End If
                    Me.ProcessParam(keyValue(0).ToLower(), keyValue(1))
                Next
            End If
        Catch e As Exception
            Throw New LoggerException("Unable to initialize parameters; message=" + e.Message, e)
        End Try
    End Sub
    ''' <summary>
    ''' Method that will process the parameter value. If either <code>name</code> or
    ''' <code>value</code> is empty then this parameter will not be processed.
    ''' </summary>
    ''' <param name="name">name of the parameter</param>
    ''' <param name="value">value of the parameter</param>
    Protected Overridable Sub ProcessParam(name As String, value As String)
        Try
            If Not String.IsNullOrEmpty(name) AndAlso Not String.IsNullOrEmpty(value) Then
                'add to param bag so subclasses have easy method to fetch other parameter values
                log.Info("Process Logger params")
                AddToParameters(name, value)
            End If
        Catch generatedExceptionName As LoggerException
            Throw
        End Try
        'catch (Exception e)
        '{
        '    string message = String.Concat("Unable to process parameters;[name=", name, ",value=", value, " message=", e.Message)
        '    //throw new LoggerException(message, e);
        '}
    End Sub
 
    ''' <summary>
    ''' Adds the given name & value to the <code>_parameterBag</code>.
    ''' If the bag already contains the name as a key, this value will replace the previous value.
    ''' </summary>
    ''' <param name="name">name of the parameter</param>
    ''' <param name="value">value for the parameter</param>
    Protected Overridable Sub AddToParameters(name As String, value As String)
        log.Info("Add new item to Logger params")
        If name Is Nothing Then
            Throw New ArgumentNullException("name")
        End If
        If value Is Nothing Then
            Throw New ArgumentException("value")
        End If
 
        Dim paramKey As String = name.ToUpper()
        Try
            If paramaterBag.ContainsKey(paramKey) Then
                paramaterBag.Remove(paramKey)
            End If
 
            paramaterBag.Add(paramKey, value)
        Catch e As Exception
            Throw New LoggerException("Unable to add to parameters bag", e)
        End Try
    End Sub
    ''' <summary>
    ''' This can be used to get the values of parameter that this class is not aware of.
    ''' If the value is not present then string.Empty is returned.
    ''' </summary>
    ''' <param name="name">name of the parameter to fetch</param>
    ''' <returns></returns>
    Protected Overridable Function GetParameterValue(name As String) As String
        log.Info("Get parameter value from logger params")
        If name Is Nothing Then
            Throw New ArgumentNullException("name")
        End If
 
        Dim paramName As String = name.ToUpper()
 
        Dim value As String = Nothing
        If paramaterBag.ContainsKey(paramName) Then
            value = paramaterBag(paramName)
        End If
 
        Return value
    End Function
    ''' <summary>
    ''' Will return a collection of parameters that have been defined.
    ''' </summary>
    Protected Overridable ReadOnly Property DefiniedParameters() As ICollection(Of String)
        Get
            Dim value As ICollection(Of String) = Nothing
            If paramaterBag IsNot Nothing Then
                value = paramaterBag.Keys
            End If
 
            Return value
        End Get
    End Property
 
    Private Sub SubscribeToEvents(eventSource As IEventSource)
        eventSource.BuildStarted += New BuildStartedEventHandler(AddressOf Me.BuildStarted)
        eventSource.BuildFinished += New BuildFinishedEventHandler(AddressOf Me.BuildFinished)
        eventSource.ProjectStarted += New ProjectStartedEventHandler(AddressOf Me.ProjectStarted)
        eventSource.ProjectFinished += New ProjectFinishedEventHandler(AddressOf Me.ProjectFinished)
        eventSource.TargetStarted += New TargetStartedEventHandler(AddressOf Me.TargetStarted)
        eventSource.TargetFinished += New TargetFinishedEventHandler(AddressOf Me.TargetFinished)
        eventSource.TaskStarted += New TaskStartedEventHandler(AddressOf Me.TaskStarted)
        eventSource.TaskFinished += New TaskFinishedEventHandler(AddressOf Me.TaskFinished)
        eventSource.ErrorRaised += New BuildErrorEventHandler(AddressOf Me.BuildError)
        eventSource.WarningRaised += New BuildWarningEventHandler(AddressOf Me.BuildWarning)
        eventSource.MessageRaised += New BuildMessageEventHandler(AddressOf Me.BuildMessage)
    End Sub
 
    #Region "Logging handlers"
    Private Sub BuildStarted(sender As Object, e As BuildStartedEventArgs)
        SendMessage(FormatMessage(e))
    End Sub
 
    Private Sub BuildFinished(sender As Object, e As BuildFinishedEventArgs)
        SendMessage(FormatMessage(e))
        SendMessage("END$$")
    End Sub
 
    Private Sub ProjectStarted(sender As Object, e As ProjectStartedEventArgs)
        SendMessage(FormatMessage(e))
    End Sub
 
    Private Sub ProjectFinished(sender As Object, e As ProjectFinishedEventArgs)
        SendMessage(FormatMessage(e))
        SendMessage("END$$")
    End Sub
 
    Private Sub TargetStarted(sender As Object, e As TargetStartedEventArgs)
        SendMessage(FormatMessage(e))
    End Sub
 
    Private Sub TargetFinished(sender As Object, e As TargetFinishedEventArgs)
        SendMessage(FormatMessage(e))
    End Sub
 
    Private Sub TaskStarted(sender As Object, e As TaskStartedEventArgs)
        SendMessage(FormatMessage(e))
    End Sub
 
    Private Sub TaskFinished(sender As Object, e As TaskFinishedEventArgs)
        SendMessage(FormatMessage(e))
    End Sub
 
    Private Sub BuildError(sender As Object, e As BuildErrorEventArgs)
        SendMessage(FormatMessage(e))
    End Sub
 
    Private Sub BuildWarning(sender As Object, e As BuildWarningEventArgs)
        SendMessage(FormatMessage(e))
    End Sub
 
    Private Sub BuildMessage(sender As Object, e As BuildMessageEventArgs)
        SendMessage(FormatMessage(e))
    End Sub
    #End Region
 
    Private Sub SendMessage(line As String)
        Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes(line)
        networkStream.Write(sendBytes, 0, sendBytes.Length)
        networkStream.Flush()
        log.InfoFormat("MS Build logger send to server the message {0}", line)
    End Sub
 
    Private Shared Function FormatMessage(e As BuildStatusEventArgs) As String
        Return String.Format("{0}:{1}$$", e.HelpKeyword, e.Message)
    End Function
 
    Private Shared Function FormatMessage(e As LazyFormattedBuildEventArgs) As String
        Return String.Format("{0}:{1}$$", e.HelpKeyword, e.Message)
    End Function
End Class