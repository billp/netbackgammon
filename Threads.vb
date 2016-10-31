' Thulsee Shan © 2008

''' <summary>
''' Delegate for the call back function
''' </summary>
''' <param name="status">status message</param>
''' <remarks>Declare method with signature 'Sub [AnyMethodName](status as String)'</remarks>
Public Delegate Sub CallBackDelegate(ByRef status As Object)

''' <summary>
''' The parameterless Thread function delegate
''' </summary>
''' <remarks></remarks>
Public Delegate Sub ThreadFunctionDelegate()

''' <summary>
''' Class to process any function in a thread
''' </summary>
''' <remarks>
''' This would be typically a function that connects to a Remote and updates a progress back to Form
''' or a function that monitors the disk for any changes in a database
''' or a hardware interupt monitoring
''' ...
''' </remarks>
Public Class CallBackThread
    Implements IDisposable

    Private m_BaseControl As Control                    'The Form/Control that implements the call back function
    Private m_ThreadFunction As ThreadFunctionDelegate  'The pointer to the function that implements the thread logic
    Private m_CallBackFunction As CallBackDelegate      'The pointer to the call back function

    Private m_Thread As Threading.Thread                'internal thread object
    Private m_disposedValue As Boolean = False          'internal falg to detect redundant calls
    Private m_startedValue As Boolean = False           'internal falg to detect redundant calls

    ''' <summary>
    ''' Instanciates the Call back thread
    ''' </summary>
    ''' <param name="caller">The Form/Control that implements the call back function</param>
    ''' <param name="threadMethod">The pointer to the function that implements the thread logic(use AddressOf() to assign)</param>
    ''' <param name="callbackFunction">The pointer to the call back function(use AddressOf() to assign)</param>
    ''' <remarks>Call 'Start' to start thread and use UpdateUI to send status messages to UI</remarks>
    Public Sub New(ByRef caller As Control, _
                    ByRef threadMethod As ThreadFunctionDelegate, _
                    ByRef callbackFunction As CallBackDelegate)
        m_BaseControl = caller
        m_ThreadFunction = threadMethod
        m_CallBackFunction = callbackFunction
        m_Thread = New Threading.Thread(AddressOf ThreadFunction)
        m_Thread.IsBackground = True
    End Sub

    ''' <summary>
    ''' Starts the internal thread
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Start()
        If Not m_startedValue Then
            m_Thread.Start()
            m_startedValue = True
        Else
            Throw New Exception("Thread already started")
        End If
    End Sub

    Private Sub ThreadFunction()
        m_ThreadFunction.Invoke()
        m_startedValue = False
    End Sub


    ''' <summary>
    ''' Sends the status to the Form/Control that implements the Call back method.
    ''' </summary>
    ''' <param name="msg">the message to send</param>
    ''' <remarks></remarks>
    Public Sub UpdateUI(ByVal msg As Object)
        If m_BaseControl IsNot Nothing AndAlso m_CallBackFunction IsNot Nothing Then
            m_BaseControl.Invoke(m_CallBackFunction, New Object() {msg})
        End If
    End Sub

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.m_disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
                If m_Thread.ThreadState <> Threading.ThreadState.Stopped Then
                    m_Thread.Abort()
                End If
            End If

            m_Thread = Nothing
            m_BaseControl = Nothing
            m_CallBackFunction = Nothing

        End If
        Me.m_disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
