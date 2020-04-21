<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formGeracao
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formGeracao))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ConfiguraçãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurarConexaoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_pastaOutPut = New System.Windows.Forms.Label()
        Me.cmbSolucao = New System.Windows.Forms.ComboBox()
        Me.lbl_configuracao = New System.Windows.Forms.Label()
        Me.chkBox_tabelas = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_abrirPasta = New System.Windows.Forms.Button()
        Me.btn_gerarCodigo = New System.Windows.Forms.Button()
        Me.btn_marcarTodas = New System.Windows.Forms.Button()
        Me.btn_desmarcarTodas = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_gerarClasseDAL = New System.Windows.Forms.CheckBox()
        Me.chkBox_gerarProcedures = New System.Windows.Forms.CheckBox()
        Me.chkBox_gerarTabelas = New System.Windows.Forms.CheckBox()
        Me.chkBox_isLocalizarIdentidade = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdBtn_vbNet = New System.Windows.Forms.RadioButton()
        Me.rdBtn_cSharp = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdBtn_aspNetStandard = New System.Windows.Forms.RadioButton()
        Me.rdBtn_aspNetCore = New System.Windows.Forms.RadioButton()
        Me.btn_gerarSolucao = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraçãoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(769, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "Menu"
        '
        'ConfiguraçãoToolStripMenuItem
        '
        Me.ConfiguraçãoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurarConexaoToolStripMenuItem})
        Me.ConfiguraçãoToolStripMenuItem.Name = "ConfiguraçãoToolStripMenuItem"
        Me.ConfiguraçãoToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ConfiguraçãoToolStripMenuItem.Text = "Arquivo"
        '
        'ConfigurarConexaoToolStripMenuItem
        '
        Me.ConfigurarConexaoToolStripMenuItem.Name = "ConfigurarConexaoToolStripMenuItem"
        Me.ConfigurarConexaoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ConfigurarConexaoToolStripMenuItem.Text = "Configurar Conexão"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.lbl_pastaOutPut)
        Me.Panel1.Controls.Add(Me.cmbSolucao)
        Me.Panel1.Controls.Add(Me.lbl_configuracao)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(769, 51)
        Me.Panel1.TabIndex = 1
        '
        'lbl_pastaOutPut
        '
        Me.lbl_pastaOutPut.AutoSize = True
        Me.lbl_pastaOutPut.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pastaOutPut.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl_pastaOutPut.Location = New System.Drawing.Point(7, 27)
        Me.lbl_pastaOutPut.Name = "lbl_pastaOutPut"
        Me.lbl_pastaOutPut.Size = New System.Drawing.Size(123, 16)
        Me.lbl_pastaOutPut.TabIndex = 15
        Me.lbl_pastaOutPut.Text = "Pasta de Geração"
        '
        'cmbSolucao
        '
        Me.cmbSolucao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSolucao.FormattingEnabled = True
        Me.cmbSolucao.Location = New System.Drawing.Point(492, 16)
        Me.cmbSolucao.Name = "cmbSolucao"
        Me.cmbSolucao.Size = New System.Drawing.Size(261, 21)
        Me.cmbSolucao.TabIndex = 14
        '
        'lbl_configuracao
        '
        Me.lbl_configuracao.AutoSize = True
        Me.lbl_configuracao.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_configuracao.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl_configuracao.Location = New System.Drawing.Point(7, 8)
        Me.lbl_configuracao.Name = "lbl_configuracao"
        Me.lbl_configuracao.Size = New System.Drawing.Size(146, 16)
        Me.lbl_configuracao.TabIndex = 1
        Me.lbl_configuracao.Text = "Conexão Configurada"
        '
        'chkBox_tabelas
        '
        Me.chkBox_tabelas.CheckOnClick = True
        Me.chkBox_tabelas.FormattingEnabled = True
        Me.chkBox_tabelas.Location = New System.Drawing.Point(12, 107)
        Me.chkBox_tabelas.Name = "chkBox_tabelas"
        Me.chkBox_tabelas.Size = New System.Drawing.Size(390, 274)
        Me.chkBox_tabelas.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tabelas"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel2.Controls.Add(Me.btn_gerarSolucao)
        Me.Panel2.Controls.Add(Me.btn_abrirPasta)
        Me.Panel2.Controls.Add(Me.btn_gerarCodigo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 398)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(769, 51)
        Me.Panel2.TabIndex = 4
        '
        'btn_abrirPasta
        '
        Me.btn_abrirPasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_abrirPasta.Location = New System.Drawing.Point(10, 8)
        Me.btn_abrirPasta.Name = "btn_abrirPasta"
        Me.btn_abrirPasta.Size = New System.Drawing.Size(177, 34)
        Me.btn_abrirPasta.TabIndex = 2
        Me.btn_abrirPasta.Text = "Abrir Pasta Geração"
        Me.btn_abrirPasta.UseVisualStyleBackColor = True
        '
        'btn_gerarCodigo
        '
        Me.btn_gerarCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gerarCodigo.Location = New System.Drawing.Point(427, 8)
        Me.btn_gerarCodigo.Name = "btn_gerarCodigo"
        Me.btn_gerarCodigo.Size = New System.Drawing.Size(151, 34)
        Me.btn_gerarCodigo.TabIndex = 0
        Me.btn_gerarCodigo.Text = "Gerar Código"
        Me.btn_gerarCodigo.UseVisualStyleBackColor = True
        '
        'btn_marcarTodas
        '
        Me.btn_marcarTodas.Location = New System.Drawing.Point(409, 107)
        Me.btn_marcarTodas.Name = "btn_marcarTodas"
        Me.btn_marcarTodas.Size = New System.Drawing.Size(96, 23)
        Me.btn_marcarTodas.TabIndex = 5
        Me.btn_marcarTodas.Text = "Marcar Todas"
        Me.btn_marcarTodas.UseVisualStyleBackColor = True
        '
        'btn_desmarcarTodas
        '
        Me.btn_desmarcarTodas.Location = New System.Drawing.Point(511, 107)
        Me.btn_desmarcarTodas.Name = "btn_desmarcarTodas"
        Me.btn_desmarcarTodas.Size = New System.Drawing.Size(109, 23)
        Me.btn_desmarcarTodas.TabIndex = 6
        Me.btn_desmarcarTodas.Text = "Desmarcar Todas"
        Me.btn_desmarcarTodas.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_gerarClasseDAL)
        Me.GroupBox1.Controls.Add(Me.chkBox_gerarProcedures)
        Me.GroupBox1.Controls.Add(Me.chkBox_gerarTabelas)
        Me.GroupBox1.Controls.Add(Me.chkBox_isLocalizarIdentidade)
        Me.GroupBox1.Location = New System.Drawing.Point(409, 153)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(344, 133)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuração da Geração"
        '
        'chk_gerarClasseDAL
        '
        Me.chk_gerarClasseDAL.AutoSize = True
        Me.chk_gerarClasseDAL.Checked = True
        Me.chk_gerarClasseDAL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_gerarClasseDAL.Location = New System.Drawing.Point(15, 99)
        Me.chk_gerarClasseDAL.Name = "chk_gerarClasseDAL"
        Me.chk_gerarClasseDAL.Size = New System.Drawing.Size(110, 17)
        Me.chk_gerarClasseDAL.TabIndex = 4
        Me.chk_gerarClasseDAL.Text = "Gerar Classe DAL"
        Me.chk_gerarClasseDAL.UseVisualStyleBackColor = True
        '
        'chkBox_gerarProcedures
        '
        Me.chkBox_gerarProcedures.AutoSize = True
        Me.chkBox_gerarProcedures.Checked = True
        Me.chkBox_gerarProcedures.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBox_gerarProcedures.Location = New System.Drawing.Point(15, 76)
        Me.chkBox_gerarProcedures.Name = "chkBox_gerarProcedures"
        Me.chkBox_gerarProcedures.Size = New System.Drawing.Size(154, 17)
        Me.chkBox_gerarProcedures.TabIndex = 3
        Me.chkBox_gerarProcedures.Text = "Gerar Script de Procedures"
        Me.chkBox_gerarProcedures.UseVisualStyleBackColor = True
        '
        'chkBox_gerarTabelas
        '
        Me.chkBox_gerarTabelas.AutoSize = True
        Me.chkBox_gerarTabelas.Checked = True
        Me.chkBox_gerarTabelas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBox_gerarTabelas.Location = New System.Drawing.Point(15, 53)
        Me.chkBox_gerarTabelas.Name = "chkBox_gerarTabelas"
        Me.chkBox_gerarTabelas.Size = New System.Drawing.Size(118, 17)
        Me.chkBox_gerarTabelas.TabIndex = 2
        Me.chkBox_gerarTabelas.Text = "Gerar Script Tabela"
        Me.chkBox_gerarTabelas.UseVisualStyleBackColor = True
        '
        'chkBox_isLocalizarIdentidade
        '
        Me.chkBox_isLocalizarIdentidade.AutoSize = True
        Me.chkBox_isLocalizarIdentidade.Checked = True
        Me.chkBox_isLocalizarIdentidade.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBox_isLocalizarIdentidade.Location = New System.Drawing.Point(15, 30)
        Me.chkBox_isLocalizarIdentidade.Name = "chkBox_isLocalizarIdentidade"
        Me.chkBox_isLocalizarIdentidade.Size = New System.Drawing.Size(195, 17)
        Me.chkBox_isLocalizarIdentidade.TabIndex = 0
        Me.chkBox_isLocalizarIdentidade.Text = "Localizar o Registro pela Identidade"
        Me.chkBox_isLocalizarIdentidade.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdBtn_vbNet)
        Me.GroupBox2.Controls.Add(Me.rdBtn_cSharp)
        Me.GroupBox2.Location = New System.Drawing.Point(409, 293)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(133, 88)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Linguagem"
        '
        'rdBtn_vbNet
        '
        Me.rdBtn_vbNet.AutoSize = True
        Me.rdBtn_vbNet.Checked = True
        Me.rdBtn_vbNet.Location = New System.Drawing.Point(15, 42)
        Me.rdBtn_vbNet.Name = "rdBtn_vbNet"
        Me.rdBtn_vbNet.Size = New System.Drawing.Size(64, 17)
        Me.rdBtn_vbNet.TabIndex = 1
        Me.rdBtn_vbNet.TabStop = True
        Me.rdBtn_vbNet.Text = "VB.NET"
        Me.rdBtn_vbNet.UseVisualStyleBackColor = True
        '
        'rdBtn_cSharp
        '
        Me.rdBtn_cSharp.AutoSize = True
        Me.rdBtn_cSharp.Location = New System.Drawing.Point(15, 19)
        Me.rdBtn_cSharp.Name = "rdBtn_cSharp"
        Me.rdBtn_cSharp.Size = New System.Drawing.Size(39, 17)
        Me.rdBtn_cSharp.TabIndex = 0
        Me.rdBtn_cSharp.Text = "C#"
        Me.rdBtn_cSharp.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdBtn_aspNetStandard)
        Me.GroupBox3.Controls.Add(Me.rdBtn_aspNetCore)
        Me.GroupBox3.Location = New System.Drawing.Point(549, 293)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 88)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Template de Dev"
        '
        'rdBtn_aspNetStandard
        '
        Me.rdBtn_aspNetStandard.AutoSize = True
        Me.rdBtn_aspNetStandard.Checked = True
        Me.rdBtn_aspNetStandard.Location = New System.Drawing.Point(6, 42)
        Me.rdBtn_aspNetStandard.Name = "rdBtn_aspNetStandard"
        Me.rdBtn_aspNetStandard.Size = New System.Drawing.Size(134, 17)
        Me.rdBtn_aspNetStandard.TabIndex = 2
        Me.rdBtn_aspNetStandard.TabStop = True
        Me.rdBtn_aspNetStandard.Text = "ASP.NET STANDARD"
        Me.rdBtn_aspNetStandard.UseVisualStyleBackColor = True
        '
        'rdBtn_aspNetCore
        '
        Me.rdBtn_aspNetCore.AutoSize = True
        Me.rdBtn_aspNetCore.Location = New System.Drawing.Point(6, 19)
        Me.rdBtn_aspNetCore.Name = "rdBtn_aspNetCore"
        Me.rdBtn_aspNetCore.Size = New System.Drawing.Size(104, 17)
        Me.rdBtn_aspNetCore.TabIndex = 1
        Me.rdBtn_aspNetCore.Text = "ASP.NET CORE"
        Me.rdBtn_aspNetCore.UseVisualStyleBackColor = True
        '
        'btn_gerarSolucao
        '
        Me.btn_gerarSolucao.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gerarSolucao.Location = New System.Drawing.Point(602, 8)
        Me.btn_gerarSolucao.Name = "btn_gerarSolucao"
        Me.btn_gerarSolucao.Size = New System.Drawing.Size(151, 34)
        Me.btn_gerarSolucao.TabIndex = 3
        Me.btn_gerarSolucao.Text = "Gerar Solução"
        Me.btn_gerarSolucao.UseVisualStyleBackColor = True
        '
        'formGeracao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 449)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_desmarcarTodas)
        Me.Controls.Add(Me.btn_marcarTodas)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkBox_tabelas)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formGeracao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Codando V1.1 - Geração de Códigos"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ConfiguraçãoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigurarConexaoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_configuracao As System.Windows.Forms.Label
    Friend WithEvents chkBox_tabelas As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btn_gerarCodigo As System.Windows.Forms.Button
    Friend WithEvents btn_abrirPasta As System.Windows.Forms.Button
    Friend WithEvents btn_marcarTodas As System.Windows.Forms.Button
    Friend WithEvents btn_desmarcarTodas As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkBox_isLocalizarIdentidade As System.Windows.Forms.CheckBox
    Friend WithEvents chkBox_gerarProcedures As System.Windows.Forms.CheckBox
    Friend WithEvents chkBox_gerarTabelas As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdBtn_vbNet As System.Windows.Forms.RadioButton
    Friend WithEvents rdBtn_cSharp As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdBtn_aspNetStandard As System.Windows.Forms.RadioButton
    Friend WithEvents rdBtn_aspNetCore As System.Windows.Forms.RadioButton
    Friend WithEvents cmbSolucao As ComboBox
    Friend WithEvents lbl_pastaOutPut As Label
    Friend WithEvents chk_gerarClasseDAL As CheckBox
    Friend WithEvents btn_gerarSolucao As Button
End Class
