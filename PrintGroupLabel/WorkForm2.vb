Imports Library3

Public Class WorkForm2

    Dim ExitToSet As Boolean
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
                    PrintGroupLabel(SNArray)
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
                PrintGroupLabel(SNArray)
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

        Dim Content As String = "
^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^JUS^LRN^CI0^XZ
~DG000.GRF,03072,048,
,:::::::::::::::::::::::::H0FE003F80,:H0HFH07F80,:::H0F780F780,H0F780F7800FF03FHFE03F801E3F003E03E07C07C00FF007C0F00FF001FHF80H03FHFE03FHFE007F81FIF01FE,H0F780F7801FFC3FHFE0FFE01EFFC03E07E07C07C03FFC07C3F01FFC03FHF80H03FHFE03FHFE00FFE1FIF03FF80,H0F380E7803FFE3FHFE1FHF01FHFE03E07E07C07C07FFE07C3F03FFE07FHF80H03FHFE03FHFE01FHF1FIF07FFC0,H0F3C1E7807FHF3FHFE3FHF81FIF03E0FE07C07C0FIF07C7807FHF0FC0F80H03FHFE03FHFE03FHF9FIF0FHFE0,H0F3C1E780F83F00F807E0FC1FC1F83E1FE07C07C1F83F07C780F83F0F80F80H03E03E03E03E07C1F807C01F07E0,H0F1C1C780F81F00F807C07C1F80F83E1FE07C07C1F01F87C780F81F0F80F80H03E03E03E03E07C0F807C01F03E0,H0F1E3C780301F00F80F803E1F80FC3E3FE07C07C3F00E07CF00301F0F80F80H03E03E03E03E0180F807C00603E0,H0F1E3C780H01F00F80F803E1F007C3E3FE07FHFC3E0I07DF0I01F0F80F80H03E03E03E03E0I0F807C0I03E0,H0F1E3C780H07F00F80FIFE1F007C3E7BE07FHFC3E0I07FE0I07F0FC0F80H03E03E03E03E0H03F807C0I0FE0,H0F0E387800FHFH0F80FIFE1F007C3E7BE07FHFC3E0I07FC0H0IF07FHF80H03E03E03E03E007FF807C001FFE0,H0F0F787807FHFH0F80FIFE1F007C3EF3E07FHFC3E0I07FF007FHF03FHF80H03E03E03E03E03FHF807C00FHFE0,H0F0F78780FF9F00F80F80H01F007C3EF3E07C07C3E0I07CF80FF9F00FHF80H03E03E03E03E07FCF807C01FF3E0,H0F0770780F81F00F80F80H01F007C3FE3E07C07C3E00E07CF80F81F01F8F80H03E03E03E03E07C0F807C01F03E0,H0F07F0781F01F00F80FC0H01F80FC3FE3E07C07C3F00F87C7C1F01F03F0F80H03E03E03E03E0F80F807C03E03E0,H0F07F0781F03F00F807C0381F80F83FC3E07C07C1F01F87C7C1F03F03E0F80H03E03E03E03E0F81F807C03E07E0,H0F03E0781F87F00F807F07E1FE1F83FC3E07C07C1FC3F07C3E1F87F07E0F80H03E03E03E03E0FC3F807C03F0FE0,H0F03E0781FIFH0F803FHFC1FIF03F83E07C07C0FIF07C3E1FIF0FC0F80H03E03E3FE03E0FIF807C03FHFE0,H0F03E0780FFEF00F801FHF81FHFE03F03E07C07C07FFE07C3F0FFEF0F80F80H03E03E3FC03E07FF7807C01FFDE0,H0F01C07807FCF00F800FHF01F7FC03F03E07C07C03FFC07C1F07FCF1F80F80H03E03E3FC03E03FE7807C00FF9E0,H0F01C07803F0F80F8003FC01F1F803E03E07C07C00FE007C1F83F0FBF00F80H03E03E3F803E01F87C07C007E1F0,gJ01F,:::::::,::~DG001.GRF,06144,064,
,::::::::::::::::::::::::::::::::::::::jH070380gN03C0,J03E003E0iQ070380gL07FFC0,J03E003E0iQ03870gL01FHF80,J03E003E0iQ03FF0gL07FHF80,J03E003E0iQ01FE0gL0JF,J03E003E0iR0FC0gL0FC,J03E003E0k01F0,J03E003E0k01E0,J03E003E003F800FC007E007F003C7E0J0IF8F1F807C01F1FIF03FHFE003F800FHFE0H0FE003E03E0I0F81E00FE003C7E0H03F801E3F801F03C3E03E0J03E003E00FFE00FC007E01FFC03DFF80I0IF8F7FE07C01F1FIF03FHFE00FFE00FIF803FF803E07E0I0F87E03FF803DFF800FFE03CFFE01F0FC3E07E0J03E003E03FHF80FE00FE03FFE03FHFC0I0IF8FIF03E03E1FIF03FHFE03FHF80FIF80FHFE03E07E0I0F87E0FHFE03FHFC03FHF83DFHF01F0FC3E07E0J03E003E07FHFC0FE00FE07FHF03FHFE0I0IF8FIF83E03E1FIF03FHFE07FHFC0F80FC1FIF03E0FE0I0F8F01FIF03FHFE07FHFC3FIF81F1E03E0FE0J03FIFE07E0FC0FE00FE0FC1F83F83F0I0F800FE0FC3E03E1F01F03E03E07E0FC0F807C1F83F03E1FE0I0F8F01F83F03F83F07E0FC3FC1F81F1E03E1FE0J03FIFE0FC07E0FF01FE0F80F83F01F0I0F800FC07C1E03C1F01F03E03E0FC07E0F807C3F01F83E1FE0I0F8F03F01F83F01F0FC07E3F80FC1F1E03E1FE0J03FIFE0F803E0FF01FE1F007C3F01F80H0F800FC07E1F07C1F01F03E03E0F803E0F807C3E00F83E3FE0I0F9E03E00F83F01F8F803E3F007C1F3C03E3FE0J03FIFE1F001F0FF83FE1F007C3E00F80H0F800F803E1F07C1F01F03E03E1F001F0F80F87C007C3E3FE0I0FBE07C007C3E00F9F001F3E003E1F7C03E3FE0J03E003E1F001F0F783DE1FIFC3E00F80H0F800F803E0F0781F01F03E03E1F001F0FIF07C007C3E7BE0I0HFC07C007C3E00F9F001F3E003E1FF803E7BE0J03E003E1F001F0F7C7DE1FIFC3E00F80H0F800F803E0F8F81F01F03E03E1F001F0FHFE07C007C3E7BE0I0HF807C007C3E00F9F001F3E003E1FF003E7BE0J03E003E1F001F0F3C79E1FIFC3E00F80H0F800F803E078F81F01F03E03E1F001F0FIF87C007C3EF3E0I0HFE07C007C3E00F9F001F3E003E1FFC03EF3E0J03E003E1F001F0F3C79E1F0I03E00F80H0F800F803E078F01F01F03E03E1F001F0F80FC7C007C3EF3E0I0F9F07C007C3E00F9F001F3E003E1F3E03EF3E0J03E003E1F001F0F3EF9E1F0I03E00F80H0F800F803E07DF01F01F03E03E1F001F0F803E7C007C3FE3E0I0F9F07C007C3E00F9F001F3E003E1F3E03FE3E0J03E003E0F803E0F1EF1E1F80H03F01F80H0F800FC07E03DE01F01F03E03E0F803E0F803E3E00F83FE3E0I0F8F83E00F83F01F8F803E1F007C1F1F03FE3E0J03E003E0FC07E0F1FF1E0F80703F01F0I0F800FC07C03DE01F01F03E03E0FC07E0F803E3F01F83FC3E0I0F8F83F01F83F01F0FC07E1F80FC1F1F03FC3E0J03E003E0FE0FC0F0FE1E0FE0FC3FC3F0I0F800FF0FC03FE01F01F03E03E0FE0FC0F803E3F83F03FC3E0I0F87C3F83F03FC3F0FE0FC0FC1F81F0F83FC3E0J03E003E07FHFC0F0FE1E07FHF83FHFE0I0F800FIF801FC01F01F03E03E07FHFC0F807E1FIF03F83E0I0F87C1FIF03FHFE07FHFC0FIF81F0F83F83E0J03E003E03FHF80F07C1E03FHF03FHFC0I0F800FIFH01FC01F01F03E03E03FHF80FIFC0FHFE03F03E0I0F87E0FHFE03FHFC03FHF807FHF01F0FC3F03E0J03E003E00FFE00F07C1E01FFE03EFF80I0F800FBFE001FC01F01F03E03E00FFE00FIF803FF803F03E0I0F83E03FF803EFF800FFE001FFC01F07C3F03E0J03E003E003F800F07C1E007F803E3F0J0F800F8FC0H0F801F01F03E03E003F800FIFI0FE003E03E0I0F83F00FE003E3F0H03F80H07F001F07E3E03E0gO03E0P0F80J0F80hN03E,gO03E0P0F80I01F80hN03E,gO03E0P0F80I01F0hO03E,gO03E0P0F80I03F0hO03E,gO03E0P0F80H03FE0hO03E,:gO03E0P0F80H03FC0hO03E,gO03E0P0F80H03F0hP03E,,::::::::::::::::::::^XA
^MMT
^PW650
^LL0201
^LS0
^FT64,64^XG000.GRF,1,1^FS
^FT64,128^XG001.GRF,1,1^FS
^FT447,54^A0N,38,38^FH\^FDKWH310^FS
^FT278,160^A0N,50,50^FB96,1,0,C^FH\^FD" & Box & "^FS
^PQ1,0,1,Y^XZ
^XA^ID000.GRF^FS^XZ
^XA^ID001.GRF^FS^XZ"
        PrintSerialPort.Open()
        PrintSerialPort.Write(Content) 'ответ в COM порт
        PrintSerialPort.Close()
    End Function

    Private Sub PrintGroupLabel(sn As ArrayList)
        For i = 0 To 11
            Dim Content As String = "
        ^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,00^JMA^MD5^JUS^LRN^CI0^XZ
        ^XA
        ^MMT
        ^PW650
        ^LL0201
        ^LS0
        ^BY4,3,80^FT55,121^BCN,,Y,N
        ^FD>:" & sn(i) & "^FS
        ^PQ1,0,1,Y^XZ
        "
            PrintSerialPort.Open()
            PrintSerialPort.Write(Content) 'ответ в COM порт
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
