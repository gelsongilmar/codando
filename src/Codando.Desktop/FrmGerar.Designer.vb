<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmGerar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGerar))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.menuGeral = New System.Windows.Forms.MenuStrip()
        Me.ArquivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SoluçõesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_pastaOutPut = New System.Windows.Forms.Label()
        Me.cmbSolucao = New System.Windows.Forms.ComboBox()
        Me.txtOutPut = New System.Windows.Forms.TextBox()
        Me.btnGerar = New System.Windows.Forms.Button()
        Me.menuGeral.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(12, 73)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(350, 372)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ Solução ] "
        '
        'menuGeral
        '
        Me.menuGeral.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArquivoToolStripMenuItem})
        Me.menuGeral.Location = New System.Drawing.Point(10, 10)
        Me.menuGeral.Name = "menuGeral"
        Me.menuGeral.Size = New System.Drawing.Size(780, 24)
        Me.menuGeral.TabIndex = 1
        Me.menuGeral.Text = "MenuStrip1"
        '
        'ArquivoToolStripMenuItem
        '
        Me.ArquivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SoluçõesToolStripMenuItem})
        Me.ArquivoToolStripMenuItem.Name = "ArquivoToolStripMenuItem"
        Me.ArquivoToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ArquivoToolStripMenuItem.Text = "Arquivo"
        '
        'SoluçõesToolStripMenuItem
        '
        Me.SoluçõesToolStripMenuItem.Name = "SoluçõesToolStripMenuItem"
        Me.SoluçõesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SoluçõesToolStripMenuItem.Text = "Soluções"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.btnGerar)
        Me.Panel1.Controls.Add(Me.lbl_pastaOutPut)
        Me.Panel1.Controls.Add(Me.cmbSolucao)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(10, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(780, 31)
        Me.Panel1.TabIndex = 2
        '
        'lbl_pastaOutPut
        '
        Me.lbl_pastaOutPut.AutoSize = True
        Me.lbl_pastaOutPut.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pastaOutPut.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl_pastaOutPut.Location = New System.Drawing.Point(279, 7)
        Me.lbl_pastaOutPut.Name = "lbl_pastaOutPut"
        Me.lbl_pastaOutPut.Size = New System.Drawing.Size(123, 16)
        Me.lbl_pastaOutPut.TabIndex = 15
        Me.lbl_pastaOutPut.Text = "Pasta de Geração"
        '
        'cmbSolucao
        '
        Me.cmbSolucao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSolucao.FormattingEnabled = True
        Me.cmbSolucao.Location = New System.Drawing.Point(12, 5)
        Me.cmbSolucao.Name = "cmbSolucao"
        Me.cmbSolucao.Size = New System.Drawing.Size(261, 21)
        Me.cmbSolucao.TabIndex = 14
        '
        'txtOutPut
        '
        Me.txtOutPut.BackColor = System.Drawing.SystemColors.Info
        Me.txtOutPut.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtOutPut.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOutPut.Location = New System.Drawing.Point(10, 451)
        Me.txtOutPut.Multiline = True
        Me.txtOutPut.Name = "txtOutPut"
        Me.txtOutPut.Size = New System.Drawing.Size(780, 100)
        Me.txtOutPut.TabIndex = 3
        '
        'btnGerar
        '
        Me.btnGerar.BackColor = System.Drawing.Color.Maroon
        Me.btnGerar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGerar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnGerar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGerar.ForeColor = System.Drawing.Color.White
        Me.btnGerar.Location = New System.Drawing.Point(680, 0)
        Me.btnGerar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnGerar.Name = "btnGerar"
        Me.btnGerar.Size = New System.Drawing.Size(100, 31)
        Me.btnGerar.TabIndex = 16
        Me.btnGerar.Text = "Gerar"
        Me.btnGerar.UseVisualStyleBackColor = False
        '
        'FrmGerar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 561)
        Me.Controls.Add(Me.txtOutPut)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.menuGeral)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuGeral
        Me.Name = "FrmGerar"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Codando"
        Me.menuGeral.ResumeLayout(False)
        Me.menuGeral.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents menuGeral As MenuStrip
    Friend WithEvents ArquivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SoluçõesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbl_pastaOutPut As Label
    Friend WithEvents cmbSolucao As ComboBox
    Friend WithEvents txtOutPut As TextBox
    Friend WithEvents btnGerar As Button
End Class
