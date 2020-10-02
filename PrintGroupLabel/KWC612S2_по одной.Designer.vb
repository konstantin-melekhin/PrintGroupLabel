<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KWC612S2_по_одной
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DG_SelectedBox = New System.Windows.Forms.DataGridView()
        Me.Controllabel = New System.Windows.Forms.Label()
        Me.TB_ScanSN = New System.Windows.Forms.TextBox()
        Me.PrintSerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.CurrrentDateLabel = New System.Windows.Forms.Label()
        Me.CurrrentTimeLabel = New System.Windows.Forms.Label()
        Me.Label_WorkDate = New System.Windows.Forms.Label()
        Me.CurrentTimeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GB_Lot = New System.Windows.Forms.GroupBox()
        Me.DG_Lot = New System.Windows.Forms.DataGridView()
        Me.NumBoxCapacity = New System.Windows.Forms.NumericUpDown()
        Me.NumBox = New System.Windows.Forms.NumericUpDown()
        Me.CB_SN_or_Box = New System.Windows.Forms.CheckBox()
        CType(Me.DG_SelectedBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GB_Lot.SuspendLayout()
        CType(Me.DG_Lot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumBoxCapacity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DG_SelectedBox
        '
        Me.DG_SelectedBox.AllowUserToAddRows = False
        Me.DG_SelectedBox.AllowUserToDeleteRows = False
        Me.DG_SelectedBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG_SelectedBox.Location = New System.Drawing.Point(9, 225)
        Me.DG_SelectedBox.Name = "DG_SelectedBox"
        Me.DG_SelectedBox.ReadOnly = True
        Me.DG_SelectedBox.Size = New System.Drawing.Size(760, 389)
        Me.DG_SelectedBox.TabIndex = 58
        '
        'Controllabel
        '
        Me.Controllabel.AutoSize = True
        Me.Controllabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Controllabel.Location = New System.Drawing.Point(4, 145)
        Me.Controllabel.Name = "Controllabel"
        Me.Controllabel.Size = New System.Drawing.Size(139, 25)
        Me.Controllabel.TabIndex = 57
        Me.Controllabel.Text = "Controllabel"
        '
        'TB_ScanSN
        '
        Me.TB_ScanSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TB_ScanSN.Location = New System.Drawing.Point(4, 46)
        Me.TB_ScanSN.Name = "TB_ScanSN"
        Me.TB_ScanSN.Size = New System.Drawing.Size(366, 26)
        Me.TB_ScanSN.TabIndex = 56
        Me.TB_ScanSN.Text = "K02A00022"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox5.Controls.Add(Me.CurrrentDateLabel)
        Me.GroupBox5.Controls.Add(Me.CurrrentTimeLabel)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox5.Location = New System.Drawing.Point(448, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(316, 128)
        Me.GroupBox5.TabIndex = 59
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Дата и Время на этикетке СН"
        '
        'CurrrentDateLabel
        '
        Me.CurrrentDateLabel.AutoSize = True
        Me.CurrrentDateLabel.BackColor = System.Drawing.SystemColors.Control
        Me.CurrrentDateLabel.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CurrrentDateLabel.Location = New System.Drawing.Point(6, 28)
        Me.CurrrentDateLabel.Name = "CurrrentDateLabel"
        Me.CurrrentDateLabel.Size = New System.Drawing.Size(241, 41)
        Me.CurrrentDateLabel.TabIndex = 6
        Me.CurrrentDateLabel.Text = "Current DATE"
        '
        'CurrrentTimeLabel
        '
        Me.CurrrentTimeLabel.AutoSize = True
        Me.CurrrentTimeLabel.BackColor = System.Drawing.SystemColors.Control
        Me.CurrrentTimeLabel.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CurrrentTimeLabel.Location = New System.Drawing.Point(6, 77)
        Me.CurrrentTimeLabel.Name = "CurrrentTimeLabel"
        Me.CurrrentTimeLabel.Size = New System.Drawing.Size(234, 41)
        Me.CurrrentTimeLabel.TabIndex = 6
        Me.CurrrentTimeLabel.Text = "Current TIME"
        '
        'Label_WorkDate
        '
        Me.Label_WorkDate.AutoSize = True
        Me.Label_WorkDate.BackColor = System.Drawing.SystemColors.Control
        Me.Label_WorkDate.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label_WorkDate.Location = New System.Drawing.Point(770, 21)
        Me.Label_WorkDate.Name = "Label_WorkDate"
        Me.Label_WorkDate.Size = New System.Drawing.Size(203, 41)
        Me.Label_WorkDate.TabIndex = 60
        Me.Label_WorkDate.Text = "Work DATE"
        Me.Label_WorkDate.Visible = False
        '
        'CurrentTimeTimer
        '
        Me.CurrentTimeTimer.Interval = 1000
        '
        'GB_Lot
        '
        Me.GB_Lot.Controls.Add(Me.DG_Lot)
        Me.GB_Lot.Location = New System.Drawing.Point(822, 225)
        Me.GB_Lot.Name = "GB_Lot"
        Me.GB_Lot.Size = New System.Drawing.Size(544, 363)
        Me.GB_Lot.TabIndex = 63
        Me.GB_Lot.TabStop = False
        Me.GB_Lot.Text = "Выберите лот"
        '
        'DG_Lot
        '
        Me.DG_Lot.AllowUserToAddRows = False
        Me.DG_Lot.AllowUserToDeleteRows = False
        Me.DG_Lot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG_Lot.Location = New System.Drawing.Point(6, 19)
        Me.DG_Lot.Name = "DG_Lot"
        Me.DG_Lot.ReadOnly = True
        Me.DG_Lot.Size = New System.Drawing.Size(532, 338)
        Me.DG_Lot.TabIndex = 0
        '
        'NumBoxCapacity
        '
        Me.NumBoxCapacity.Location = New System.Drawing.Point(210, 103)
        Me.NumBoxCapacity.Name = "NumBoxCapacity"
        Me.NumBoxCapacity.Size = New System.Drawing.Size(120, 20)
        Me.NumBoxCapacity.TabIndex = 64
        Me.NumBoxCapacity.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'NumBox
        '
        Me.NumBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.NumBox.Location = New System.Drawing.Point(4, 103)
        Me.NumBox.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumBox.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumBox.Name = "NumBox"
        Me.NumBox.Size = New System.Drawing.Size(183, 26)
        Me.NumBox.TabIndex = 62
        Me.NumBox.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'CB_SN_or_Box
        '
        Me.CB_SN_or_Box.AutoSize = True
        Me.CB_SN_or_Box.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CB_SN_or_Box.Location = New System.Drawing.Point(4, 12)
        Me.CB_SN_or_Box.Name = "CB_SN_or_Box"
        Me.CB_SN_or_Box.Size = New System.Drawing.Size(290, 24)
        Me.CB_SN_or_Box.TabIndex = 61
        Me.CB_SN_or_Box.Text = "Отсканируйте серийный номер"
        Me.CB_SN_or_Box.UseVisualStyleBackColor = True
        '
        'KWC612S2_по_одной
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1298, 695)
        Me.Controls.Add(Me.DG_SelectedBox)
        Me.Controls.Add(Me.Controllabel)
        Me.Controls.Add(Me.TB_ScanSN)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Label_WorkDate)
        Me.Controls.Add(Me.GB_Lot)
        Me.Controls.Add(Me.NumBoxCapacity)
        Me.Controls.Add(Me.NumBox)
        Me.Controls.Add(Me.CB_SN_or_Box)
        Me.Name = "KWC612S2_по_одной"
        Me.Text = "KWC612S2_по_одной"
        CType(Me.DG_SelectedBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GB_Lot.ResumeLayout(False)
        CType(Me.DG_Lot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumBoxCapacity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DG_SelectedBox As DataGridView
    Friend WithEvents Controllabel As Label
    Friend WithEvents TB_ScanSN As TextBox
    Friend WithEvents PrintSerialPort As IO.Ports.SerialPort
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents CurrrentDateLabel As Label
    Friend WithEvents CurrrentTimeLabel As Label
    Friend WithEvents Label_WorkDate As Label
    Friend WithEvents CurrentTimeTimer As Timer
    Friend WithEvents GB_Lot As GroupBox
    Friend WithEvents DG_Lot As DataGridView
    Friend WithEvents NumBoxCapacity As NumericUpDown
    Friend WithEvents NumBox As NumericUpDown
    Friend WithEvents CB_SN_or_Box As CheckBox
End Class
