Imports Library3


Public Class ICL_Print
    Dim SQL As String

    Private Sub ICL_Print_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                PrintLabel(Controllabel, "PCB_SN " & SNArray(1) & vbCrLf &
                            "SN " & SNArray(2) & vbCrLf &
                            "MAC " & SNArray(3), 12, 142, Color.Green)
                RunCommand("Use FAS Update [FAS].[dbo].[CT_ICL_SN] set IsPrinted = 1, PrintDate = CURRENT_TIMESTAMP where id = " & SNArray(0))
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
        SELECT [ID],[PCBSN],[SN],[MAC],[LOTID],[IsPrinted],[PrintByID],[PrintDate],[IsRePrinted]
        ,[RePrintByID],[RePrintDate],[RePrintCount]
        FROM [FAS].[dbo].[CT_ICL_SN] where [LOTID] = 20067 and [PCBSN] = '" & Sn & "'"
        Return SelectListString(SQL) 'INS220020101
        End Function


        Public Function GroupAquaSN(SN As ArrayList)
        'INS2> 520020330
        '35639911074697>67
        '0058>63F>5048752
        '0058>63F048D51
        Dim Content As String = "

^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^JUS^LRN^CI0^XZ
^XA
^MMT
^PW685
^LL0201
^LS0
^BY3,3,62^FT79,168^BCN,,Y,N
^FD>:" & Mid(SN(3), 1, 3) & ">5" & Mid(SN(3), 4, 4) & ">6" & Mid(SN(3), 8) & "^FS
^BY3,3,50^FT111,71^BCN,,Y,N
^FD>:" & Mid(SN(2), 1, 6) & ">5" & Mid(SN(2), 7) & "^FS
^PQ1,0,1,Y^XZ
"
        PrintSerialPort.Open()
        PrintSerialPort.Write(Content) 'ответ в COM порт
        PrintSerialPort.Close()
    End Function


    End Class

