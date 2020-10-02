Imports Library3

Public Class WorkForm2
    Dim SQL As String
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            GetLotList_ContractStation(DG_Lot)
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

        Dim SearchSNList As New ArrayList
        Dim SNArray As New ArrayList
        Private Sub TB_ScanSN_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_ScanSN.KeyDown
            If e.KeyCode = Keys.Enter Then
                SearchSNList = SerchSN(TB_ScanSN.Text)
                If SearchSNList.Count <> 0 Then
                    SerchBoxForPrint(SearchSNList(1), SearchSNList(3))
                    SNArray = GetSNFromGrid()
                    If SNArray.Count = 13 Then
                    PrintGroupLabel(SNArray, NumBoxCapacity.Text)
                    LabelPallet(SNArray(12))
                Else
                        PrintLabel(Controllabel, "Корбка еще не закрыта!", 12, 142, Color.Red)
                    End If
                    TB_ScanSN.Clear()
                Else
                    TB_ScanSN.Clear()
                    PrintLabel(Controllabel, "Номер не найден в базе!", Color.Red)
                    Exit Sub
                End If
            End If
        End Sub

        Private Sub NumBox_KeyDown(sender As Object, e As KeyEventArgs) Handles NumBox.KeyDown
            If e.KeyCode = Keys.Enter And Lot <> 0 Then
            'System.Threading.Thread.Sleep(1000)
            SerchBoxForPrint(Lot, NumBox.Value)
                SNArray = GetSNFromGrid()
                If SNArray.Count = 13 Then
                PrintGroupLabel(SNArray, NumBoxCapacity.Text)
                LabelPallet(SNArray(12))
            Else
                    PrintLabel(Controllabel, "Корбка еще не закрыта!", 12, 142, Color.Red)
                End If
                NumBox.Value += 1
            End If
        End Sub

        Private Function SerchSN(Sn As String)
            SQL = "use fas
                SELECT  l.Content,p.[LOTID],Lit.LiterName ,[BoxNum]
                FROM [FAS].[dbo].[Ct_PackingTable] as P
                left join [SMDCOMPONETS].[dbo].[LazerBase] as L On l.IDLaser = PCBID
                left join dbo.Ct_FASSN_reg as F On F.ID =P.SNID
                left join dbo.FAS_Liter as Lit On Lit.ID = P.LiterID
                where l.Content = '" & Sn & "'"
            Return SelectListString(SQL) 'IB365MC001409
        End Function

        Private Sub SerchBoxForPrint(LotID As Integer, BoxNum As Integer) 'LitName As String,
            SQL = "use fas
                SELECT  [UnitNum] as '№',l.Content AS 'Серийный номер платы',Lit.LiterName as 'Литера' ,[BoxNum]as 'Номер коробки' 
                FROM [FAS].[dbo].[Ct_PackingTable] as P
                left join [SMDCOMPONETS].[dbo].[LazerBase] as L On l.IDLaser = PCBID
                left join dbo.Ct_FASSN_reg as F On F.ID =P.SNID
                left join dbo.FAS_Liter as Lit On Lit.ID = P.LiterID
                where p.lotid =" & LotID & " and BoxNum = " & BoxNum & "
                order by UnitNum desc" 'and LiterName= '" & LitName & "'
            LoadGridFromDB(DG_SelectedBox, SQL)
        End Sub

        Private Function GetSNFromGrid()
            Dim SNArrayTemp As New ArrayList
            If DG_SelectedBox.Rows.Count > 0 Then
                For i = 0 To DG_SelectedBox.Rows.Count - 1
                SNArrayTemp.Add(Mid(DG_SelectedBox.Item(1, i).Value, 1, 5) & ">5" & Mid(DG_SelectedBox.Item(1, i).Value, 6))
            Next
                SNArrayTemp.Add(DG_SelectedBox.Item(3, 0).Value)
            Else
                PrintLabel(Controllabel, "Корбка еще не закрыта!", 12, 142, Color.Red)
            End If
            Return SNArrayTemp
        End Function


    Public Function LabelPallet(Box As Integer)
        PrintSerialPort.Open()
        PrintSerialPort.Write(KWH310_Pallet_Label(Box)) 'ответ в COM порт
        PrintSerialPort.Close()
    End Function

    Private Sub PrintGroupLabel(sn As ArrayList, BoxCapacity As Integer)
        For i = 0 To BoxCapacity - 1
            PrintSerialPort.Open()
            PrintSerialPort.Write(KWH310_SN_Label(sn(i))) 'ответ в COM порт
            PrintSerialPort.Close()
            System.Threading.Thread.Sleep(500)
        Next
    End Sub

    Private Sub CB_SN_or_Box_CheckedChanged(sender As Object, e As EventArgs) Handles CB_SN_or_Box.CheckedChanged
        If CB_SN_or_Box.Checked = True Then
            NumBox.Visible = False
            TB_ScanSN.Visible = True
            CB_SN_or_Box.Text = "Отсканируйте серийный номер"
            GB_Lot.Visible = False
            DG_SelectedBox.Visible = True
            Controllabel.Text = ""
            TB_ScanSN.Focus()
        Else
            NumBox.Location = New Point(12, 43)
            TB_ScanSN.Visible = False
            CB_SN_or_Box.Text = "Введите номер коробки"
            GB_Lot.Visible = True
            GB_Lot.Location = New Point(17, 236)
            DG_SelectedBox.Visible = False
            PrintLabel(Controllabel, "Выберите ЛОТ для печати!", 12, 142, Color.Red)

        End If
    End Sub
    'Опредеяем номер выбранной строки в таблице лотов
    Public selRowNum, LOTID As Integer
        Dim Lot As Integer
        Private Sub DG_LOTListPresent_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Lot.CellClick
            selRowNum = DG_Lot.CurrentCell.RowIndex
            If MsgBox("ЛОТ выбран?", vbYesNo) = vbYes Then
                GB_Lot.Visible = False
                DG_SelectedBox.Visible = True
                NumBox.Visible = True
                Controllabel.Text = ""
                NumBox.Focus()
            End If
            Lot = DG_Lot.Item(3, selRowNum).Value
        End Sub





End Class
