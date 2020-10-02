<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AquaSN
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
        Me.Controllabel = New System.Windows.Forms.Label()
        Me.TB_ScanSN = New System.Windows.Forms.TextBox()
        Me.PrintSerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.CurrrentDateLabel = New System.Windows.Forms.Label()
        Me.CurrrentTimeLabel = New System.Windows.Forms.Label()
        Me.CurrentTimeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.CB_SN_or_Box = New System.Windows.Forms.CheckBox()
        Me.Label_WorkDate = New System.Windows.Forms.Label()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Controllabel
        '
        Me.Controllabel.AutoSize = True
        Me.Controllabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Controllabel.Location = New System.Drawing.Point(12, 145)
        Me.Controllabel.Name = "Controllabel"
        Me.Controllabel.Size = New System.Drawing.Size(139, 25)
        Me.Controllabel.TabIndex = 56
        Me.Controllabel.Text = "Controllabel"
        '
        'TB_ScanSN
        '
        Me.TB_ScanSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TB_ScanSN.Location = New System.Drawing.Point(12, 46)
        Me.TB_ScanSN.Name = "TB_ScanSN"
        Me.TB_ScanSN.Size = New System.Drawing.Size(366, 26)
        Me.TB_ScanSN.TabIndex = 55
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox5.Controls.Add(Me.CurrrentDateLabel)
        Me.GroupBox5.Controls.Add(Me.CurrrentTimeLabel)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox5.Location = New System.Drawing.Point(456, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(316, 128)
        Me.GroupBox5.TabIndex = 58
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Дата и Время"
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
        'CurrentTimeTimer
        '
        Me.CurrentTimeTimer.Interval = 1000
        '
        'CB_SN_or_Box
        '
        Me.CB_SN_or_Box.AutoSize = True
        Me.CB_SN_or_Box.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CB_SN_or_Box.Location = New System.Drawing.Point(12, 12)
        Me.CB_SN_or_Box.Name = "CB_SN_or_Box"
        Me.CB_SN_or_Box.Size = New System.Drawing.Size(290, 24)
        Me.CB_SN_or_Box.TabIndex = 60
        Me.CB_SN_or_Box.Text = "Отсканируйте серийный номер"
        Me.CB_SN_or_Box.UseVisualStyleBackColor = True
        '
        'Label_WorkDate
        '
        Me.Label_WorkDate.AutoSize = True
        Me.Label_WorkDate.BackColor = System.Drawing.SystemColors.Control
        Me.Label_WorkDate.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label_WorkDate.Location = New System.Drawing.Point(800, 21)
        Me.Label_WorkDate.Name = "Label_WorkDate"
        Me.Label_WorkDate.Size = New System.Drawing.Size(203, 41)
        Me.Label_WorkDate.TabIndex = 61
        Me.Label_WorkDate.Text = "Work DATE"
        Me.Label_WorkDate.Visible = False
        '
        'AquaSN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 409)
        Me.Controls.Add(Me.Label_WorkDate)
        Me.Controls.Add(Me.Controllabel)
        Me.Controls.Add(Me.TB_ScanSN)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.CB_SN_or_Box)
        Me.Name = "AquaSN"
        Me.Text = "AquaSN"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Controllabel As Label
    Friend WithEvents TB_ScanSN As TextBox
    Friend WithEvents PrintSerialPort As IO.Ports.SerialPort
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents CurrrentDateLabel As Label
    Friend WithEvents CurrrentTimeLabel As Label
    Friend WithEvents CurrentTimeTimer As Timer
    Friend WithEvents CB_SN_or_Box As CheckBox
    Friend WithEvents Label_WorkDate As Label
End Class
