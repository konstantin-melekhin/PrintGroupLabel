Imports Library3

Public Class AquaSN
    Dim SQL As String

    Private Sub AquaSN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrrentDateLabel.Text = Date.Today
        CB_SN_or_Box.Checked = True
        Controllabel.Text = ""
        'Устанавливаем дефолты при загоузке формы 
        'Настройка COM порта
        PrintSerialPort.PortName = "com3"
        PrintSerialPort.BaudRate = 115200
        'Требуется печать или нет
        Try
            PrintSerialPort.Open()
            PrintSerialPort.Close()
        Catch ex As Exception
            PrintLabel(Controllabel, "Проверьте подключение ком порта!", 12, 142, Color.Red) ' если не настроен ком порт для печати
            CB_SN_or_Box.Enabled = False
            TB_ScanSN.Enabled = False
        End Try
        'Переносим константы из формы настроек в рабочую форму. Данные получаем из таблицы M_Lots
        'Запуск программы
        '___________________________________________________________
        GetTimeSec()

    End Sub
    'запуск таймера
    Private Sub CurrentTimeTimer_Tick(sender As Object, e As EventArgs) Handles CurrentTimeTimer.Tick
        GetTimeSec()
    End Sub
    Dim CurentTimeSec As Integer
    Private Sub GetTimeSec()
        CurrentTimeTimer.Start()
        CurrrentTimeLabel.Text = TimeString
        CurentTimeSec = CurrrentTimeLabel.Text.Substring(0, 2) * 3600 + CurrrentTimeLabel.Text.Substring(3, 2) * 60 + CurrrentTimeLabel.Text.Substring(6, 2)
    End Sub

    Dim SNArray As New ArrayList

    Private Sub TB_ScanSN_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_ScanSN.KeyDown
        If e.KeyCode = Keys.Enter Then
            SNArray = SerchSN(TB_ScanSN.Text)
            If SNArray.Count <> 0 Then
                GroupAquaSN(SNArray)
                PrintLabel(Controllabel, "Серийный номер " & SNArray(1) & vbCrLf &
                            "MAC WiFi " & SNArray(4) & vbCrLf &
                            "IMEI " & SNArray(2) & vbCrLf &
                            "MAC BT " & SNArray(3), 12, 142, Color.Green)
                RunCommand("Update [FAS].[dbo].[CT_Aquarius] set IsPrinted = 1, PrintDate = CURRENT_TIMESTAMP where id = " & SNArray(0))
                TB_ScanSN.Clear()
            Else
                TB_ScanSN.Clear()
                PrintLabel(Controllabel, "Номер не найден в базе!", 12, 142, Color.Red)
                Exit Sub
            End If
        End If
    End Sub
    Private Function SerchSN(Sn As String)
        SQL = "use fas
        SELECT [ID],[SN],[IMEI],[MAC_BT],[MAC_WF],[IsPrinted],[PrintByID],[PrintDate]
        ,[IsRePrinted],[RePrintByID],[RePrintDate],[RePrintCount]
        FROM [FAS].[dbo].[CT_Aquarius] where [LOTID] = 20063 and [SN] = '" & Sn & "'"
        Return SelectListString(SQL) 'INS220020101
    End Function


    Public Function GroupAquaSN(SN As ArrayList)
        'INS2> 520020330
        '35639911074697>67
        '0058>63F>5048752
        '0058>63F048D51
        Dim Content As String = "
^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,15^JMA^JUS^LRN^CI0^XZ
^XA
^MMT
^PW685
^LL0354
^LS0
^FT183,64^A0N,42,40^FH\^FDSN^FS
^FT154,215^A0N,42,40^FH\^FDIMEI^FS
^FT95,139^A0N,42,40^FH\^FDBT Addr^FS
^FT62,290^A0N,42,40^FH\^FDWiFi Addr^FS

^BY2,3,47^FT255,62^BCN,,Y,N
^FD>:" & Mid(SN(1), 1, 4) & ">5" & Mid(SN(1), 5) & "^FS
^BY2,3,47^FT255,213^BCN,,Y,N
^FD>;" & Mid(SN(2), 1, 14) & ">6" & Mid(SN(2), 15) & "^FS
^BY2,3,47^FT255,137^BCN,,Y,N
^FD>;" & Mid(SN(3), 1, 4) & ">6" & Mid(SN(3), 5) & "^FS
^FO44,234^GB597,78,3^FS
^FO44,158^GB597,78,3^FS
^FO44,82^GB597,78,3^FS
^FO44,7^GB597,78,3^FS
^BY2,3,47^FT255,288^BCN,,Y,N
^FD>;" & Mid(SN(4), 1, 4) & ">6" & Mid(SN(4), 5) & "^FS
^PQ1,0,1,Y^XZ
"
        PrintSerialPort.Open()
        PrintSerialPort.Write(Content) 'ответ в COM порт
        PrintSerialPort.Close()
    End Function


End Class
