<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolucoes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolucoes))
        Me.btn_selecionarPasta = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_pastaGeracaoSolucao = New System.Windows.Forms.TextBox()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.btn_novaSolucao = New System.Windows.Forms.Button()
        Me.cmbSolucao = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.folder_pasta = New System.Windows.Forms.FolderBrowserDialog()
        Me.pnl_listagem = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_nomeSolucao = New System.Windows.Forms.TextBox()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_salvar = New System.Windows.Forms.Button()
        Me.pnl_listagem.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_selecionarPasta
        '
        Me.btn_selecionarPasta.Enabled = False
        Me.btn_selecionarPasta.Location = New System.Drawing.Point(282, 200)
        Me.btn_selecionarPasta.Name = "btn_selecionarPasta"
        Me.btn_selecionarPasta.Size = New System.Drawing.Size(32, 20)
        Me.btn_selecionarPasta.TabIndex = 42
        Me.btn_selecionarPasta.Text = "..."
        Me.btn_selecionarPasta.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 184)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 13)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Pasta Geração Solução"
        '
        'txt_pastaGeracaoSolucao
        '
        Me.txt_pastaGeracaoSolucao.Enabled = False
        Me.txt_pastaGeracaoSolucao.Location = New System.Drawing.Point(19, 200)
        Me.txt_pastaGeracaoSolucao.Name = "txt_pastaGeracaoSolucao"
        Me.txt_pastaGeracaoSolucao.Size = New System.Drawing.Size(257, 20)
        Me.txt_pastaGeracaoSolucao.TabIndex = 40
        '
        'btn_excluir
        '
        Me.btn_excluir.Location = New System.Drawing.Point(262, 57)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(53, 23)
        Me.btn_excluir.TabIndex = 16
        Me.btn_excluir.Text = "Excluir"
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.Location = New System.Drawing.Point(203, 57)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(53, 23)
        Me.btn_alterar.TabIndex = 15
        Me.btn_alterar.Text = "Alterar"
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'btn_novaSolucao
        '
        Me.btn_novaSolucao.Location = New System.Drawing.Point(144, 57)
        Me.btn_novaSolucao.Name = "btn_novaSolucao"
        Me.btn_novaSolucao.Size = New System.Drawing.Size(53, 23)
        Me.btn_novaSolucao.TabIndex = 14
        Me.btn_novaSolucao.Text = "Nova"
        Me.btn_novaSolucao.UseVisualStyleBackColor = True
        '
        'cmbSolucao
        '
        Me.cmbSolucao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSolucao.FormattingEnabled = True
        Me.cmbSolucao.Location = New System.Drawing.Point(12, 30)
        Me.cmbSolucao.Name = "cmbSolucao"
        Me.cmbSolucao.Size = New System.Drawing.Size(303, 21)
        Me.cmbSolucao.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Solução"
        '
        'folder_pasta
        '
        Me.folder_pasta.Description = "Selecione a pasta onde a solução deve ser gerada"
        Me.folder_pasta.RootFolder = System.Environment.SpecialFolder.MyComputer
        Me.folder_pasta.SelectedPath = "c:\git\"
        '
        'pnl_listagem
        '
        Me.pnl_listagem.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.pnl_listagem.Controls.Add(Me.btn_excluir)
        Me.pnl_listagem.Controls.Add(Me.btn_alterar)
        Me.pnl_listagem.Controls.Add(Me.btn_novaSolucao)
        Me.pnl_listagem.Controls.Add(Me.cmbSolucao)
        Me.pnl_listagem.Controls.Add(Me.Label7)
        Me.pnl_listagem.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_listagem.Location = New System.Drawing.Point(0, 0)
        Me.pnl_listagem.Name = "pnl_listagem"
        Me.pnl_listagem.Size = New System.Drawing.Size(337, 97)
        Me.pnl_listagem.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 134)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Nome Solução"
        '
        'txt_nomeSolucao
        '
        Me.txt_nomeSolucao.Enabled = False
        Me.txt_nomeSolucao.Location = New System.Drawing.Point(19, 150)
        Me.txt_nomeSolucao.Name = "txt_nomeSolucao"
        Me.txt_nomeSolucao.Size = New System.Drawing.Size(296, 20)
        Me.txt_nomeSolucao.TabIndex = 24
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Enabled = False
        Me.btn_cancelar.Location = New System.Drawing.Point(239, 243)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 37
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_salvar
        '
        Me.btn_salvar.Enabled = False
        Me.btn_salvar.Location = New System.Drawing.Point(158, 243)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(75, 23)
        Me.btn_salvar.TabIndex = 36
        Me.btn_salvar.Text = "Salvar"
        Me.btn_salvar.UseVisualStyleBackColor = True
        '
        'FrmSolucoes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 292)
        Me.Controls.Add(Me.btn_selecionarPasta)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_pastaGeracaoSolucao)
        Me.Controls.Add(Me.pnl_listagem)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_nomeSolucao)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_salvar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmSolucoes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Soluções"
        Me.pnl_listagem.ResumeLayout(False)
        Me.pnl_listagem.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_selecionarPasta As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents txt_pastaGeracaoSolucao As TextBox
    Friend WithEvents btn_excluir As Button
    Friend WithEvents btn_alterar As Button
    Friend WithEvents btn_novaSolucao As Button
    Friend WithEvents cmbSolucao As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents folder_pasta As FolderBrowserDialog
    Friend WithEvents pnl_listagem As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_nomeSolucao As TextBox
    Friend WithEvents btn_cancelar As Button
    Friend WithEvents btn_salvar As Button
End Class
