<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LeftUnitComboBox = New System.Windows.Forms.ComboBox()
        Me.LeftTextBox = New System.Windows.Forms.RichTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToggleSideButton = New System.Windows.Forms.Button()
        Me.SelectQuantityComboBox = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.RightUnitComboBox = New System.Windows.Forms.ComboBox()
        Me.RightTextbox = New System.Windows.Forms.RichTextBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(754, 281)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 134.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(748, 134)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LeftUnitComboBox)
        Me.Panel1.Controls.Add(Me.LeftTextBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(300, 128)
        Me.Panel1.TabIndex = 2
        '
        'LeftUnitComboBox
        '
        Me.LeftUnitComboBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LeftUnitComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.LeftUnitComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.LeftUnitComboBox.FormattingEnabled = True
        Me.LeftUnitComboBox.Location = New System.Drawing.Point(8, 58)
        Me.LeftUnitComboBox.Name = "LeftUnitComboBox"
        Me.LeftUnitComboBox.Size = New System.Drawing.Size(112, 21)
        Me.LeftUnitComboBox.TabIndex = 1
        Me.LeftUnitComboBox.Text = "Select Unit"
        '
        'LeftTextBox
        '
        Me.LeftTextBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LeftTextBox.Font = New System.Drawing.Font("Franklin Gothic Medium", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LeftTextBox.Location = New System.Drawing.Point(124, 18)
        Me.LeftTextBox.Multiline = False
        Me.LeftTextBox.Name = "LeftTextBox"
        Me.LeftTextBox.Size = New System.Drawing.Size(173, 96)
        Me.LeftTextBox.TabIndex = 2
        Me.LeftTextBox.Text = ""
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ToggleSideButton)
        Me.Panel2.Controls.Add(Me.SelectQuantityComboBox)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(309, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(128, 128)
        Me.Panel2.TabIndex = 1
        '
        'ToggleSideButton
        '
        Me.ToggleSideButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ToggleSideButton.Location = New System.Drawing.Point(28, 88)
        Me.ToggleSideButton.Name = "ToggleSideButton"
        Me.ToggleSideButton.Size = New System.Drawing.Size(75, 23)
        Me.ToggleSideButton.TabIndex = 3
        Me.ToggleSideButton.Text = "Swap Units"
        Me.ToggleSideButton.UseVisualStyleBackColor = True
        '
        'SelectQuantityComboBox
        '
        Me.SelectQuantityComboBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SelectQuantityComboBox.AutoCompleteCustomSource.AddRange(New String() {"Length", "Mass", "Temperature ", "Speed", "Area", "Volume", "Time"})
        Me.SelectQuantityComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.SelectQuantityComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.SelectQuantityComboBox.FormattingEnabled = True
        Me.SelectQuantityComboBox.Location = New System.Drawing.Point(17, 40)
        Me.SelectQuantityComboBox.Name = "SelectQuantityComboBox"
        Me.SelectQuantityComboBox.Size = New System.Drawing.Size(96, 21)
        Me.SelectQuantityComboBox.TabIndex = 0
        Me.SelectQuantityComboBox.Text = "Select Quantity"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.RightUnitComboBox)
        Me.Panel3.Controls.Add(Me.RightTextbox)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(443, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(302, 128)
        Me.Panel3.TabIndex = 3
        '
        'RightUnitComboBox
        '
        Me.RightUnitComboBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RightUnitComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.RightUnitComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.RightUnitComboBox.FormattingEnabled = True
        Me.RightUnitComboBox.Location = New System.Drawing.Point(192, 53)
        Me.RightUnitComboBox.Name = "RightUnitComboBox"
        Me.RightUnitComboBox.Size = New System.Drawing.Size(104, 21)
        Me.RightUnitComboBox.TabIndex = 2
        Me.RightUnitComboBox.Text = "Select Unit"
        '
        'RightTextbox
        '
        Me.RightTextbox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RightTextbox.Font = New System.Drawing.Font("Franklin Gothic Medium", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RightTextbox.Location = New System.Drawing.Point(5, 16)
        Me.RightTextbox.Name = "RightTextbox"
        Me.RightTextbox.ReadOnly = True
        Me.RightTextbox.Size = New System.Drawing.Size(183, 96)
        Me.RightTextbox.TabIndex = 3
        Me.RightTextbox.Text = ""
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.ClearButton, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 143)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(748, 135)
        Me.TableLayoutPanel3.TabIndex = 4
        '
        'ClearButton
        '
        Me.ClearButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ClearButton.Location = New System.Drawing.Point(336, 56)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(75, 23)
        Me.ClearButton.TabIndex = 0
        Me.ClearButton.Text = "Clear"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(754, 281)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(770, 320)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unit Converter"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LeftTextBox As RichTextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RightTextbox As RichTextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents SelectQuantityComboBox As ComboBox
    Friend WithEvents LeftUnitComboBox As ComboBox
    Friend WithEvents RightUnitComboBox As ComboBox
    Friend WithEvents ToggleSideButton As Button
    Friend WithEvents ClearButton As Button
End Class
