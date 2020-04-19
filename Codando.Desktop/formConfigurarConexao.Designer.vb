<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formConfigurarConexao
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_host = New System.Windows.Forms.TextBox()
        Me.txt_instancia = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_usuario = New System.Windows.Forms.TextBox()
        Me.txt_senha = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_nomeBanco = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_salvar = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.txt_namespace = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_nomeSolucao = New System.Windows.Forms.TextBox()
        Me.pnl_listagem = New System.Windows.Forms.Panel()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.btn_novaSolucao = New System.Windows.Forms.Button()
        Me.cmbSolucao = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btn_testar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_pastaGeracaoSolucao = New System.Windows.Forms.TextBox()
        Me.folder_pasta = New System.Windows.Forms.FolderBrowserDialog()
        Me.btn_selecionarPasta = New System.Windows.Forms.Button()
        Me.pnl_listagem.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Host"
        '
        'txt_host
        '
        Me.txt_host.Enabled = False
        Me.txt_host.Location = New System.Drawing.Point(18, 173)
        Me.txt_host.Name = "txt_host"
        Me.txt_host.Size = New System.Drawing.Size(147, 20)
        Me.txt_host.TabIndex = 3
        '
        'txt_instancia
        '
        Me.txt_instancia.Enabled = False
        Me.txt_instancia.Location = New System.Drawing.Point(171, 173)
        Me.txt_instancia.Name = "txt_instancia"
        Me.txt_instancia.Size = New System.Drawing.Size(143, 20)
        Me.txt_instancia.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(168, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Instância"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 241)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Usuário"
        '
        'txt_usuario
        '
        Me.txt_usuario.Enabled = False
        Me.txt_usuario.Location = New System.Drawing.Point(18, 257)
        Me.txt_usuario.Name = "txt_usuario"
        Me.txt_usuario.Size = New System.Drawing.Size(170, 20)
        Me.txt_usuario.TabIndex = 6
        '
        'txt_senha
        '
        Me.txt_senha.Enabled = False
        Me.txt_senha.Location = New System.Drawing.Point(194, 257)
        Me.txt_senha.Name = "txt_senha"
        Me.txt_senha.Size = New System.Drawing.Size(120, 20)
        Me.txt_senha.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(191, 241)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Senha"
        '
        'txt_nomeBanco
        '
        Me.txt_nomeBanco.Enabled = False
        Me.txt_nomeBanco.Location = New System.Drawing.Point(18, 218)
        Me.txt_nomeBanco.Name = "txt_nomeBanco"
        Me.txt_nomeBanco.Size = New System.Drawing.Size(296, 20)
        Me.txt_nomeBanco.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Banco de dados"
        '
        'btn_salvar
        '
        Me.btn_salvar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_salvar.Enabled = False
        Me.btn_salvar.Location = New System.Drawing.Point(158, 394)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(75, 23)
        Me.btn_salvar.TabIndex = 10
        Me.btn_salvar.Text = "Salvar"
        Me.btn_salvar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_cancelar.Enabled = False
        Me.btn_cancelar.Location = New System.Drawing.Point(239, 394)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 11
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'txt_namespace
        '
        Me.txt_namespace.Enabled = False
        Me.txt_namespace.Location = New System.Drawing.Point(18, 297)
        Me.txt_namespace.Name = "txt_namespace"
        Me.txt_namespace.Size = New System.Drawing.Size(296, 20)
        Me.txt_namespace.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 281)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Namespace"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Nome Solução"
        '
        'txt_nomeSolucao
        '
        Me.txt_nomeSolucao.Enabled = False
        Me.txt_nomeSolucao.Location = New System.Drawing.Point(19, 133)
        Me.txt_nomeSolucao.Name = "txt_nomeSolucao"
        Me.txt_nomeSolucao.Size = New System.Drawing.Size(296, 20)
        Me.txt_nomeSolucao.TabIndex = 2
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
        Me.pnl_listagem.Size = New System.Drawing.Size(341, 97)
        Me.pnl_listagem.TabIndex = 1
        '
        'btn_excluir
        '
        Me.btn_excluir.DialogResult = System.Windows.Forms.DialogResult.Cancel
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
        Me.btn_novaSolucao.DialogResult = System.Windows.Forms.DialogResult.Cancel
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
        'btn_testar
        '
        Me.btn_testar.Location = New System.Drawing.Point(20, 394)
        Me.btn_testar.Name = "btn_testar"
        Me.btn_testar.Size = New System.Drawing.Size(104, 23)
        Me.btn_testar.TabIndex = 18
        Me.btn_testar.Text = "Testar Conexao"
        Me.btn_testar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 328)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Pasta Geração Solução"
        '
        'txt_pastaGeracaoSolucao
        '
        Me.txt_pastaGeracaoSolucao.Enabled = False
        Me.txt_pastaGeracaoSolucao.Location = New System.Drawing.Point(18, 344)
        Me.txt_pastaGeracaoSolucao.Name = "txt_pastaGeracaoSolucao"
        Me.txt_pastaGeracaoSolucao.Size = New System.Drawing.Size(257, 20)
        Me.txt_pastaGeracaoSolucao.TabIndex = 19
        '
        'folder_pasta
        '
        Me.folder_pasta.Description = "Selecione a pasta onde a solução deve ser gerada"
        Me.folder_pasta.RootFolder = System.Environment.SpecialFolder.MyComputer
        Me.folder_pasta.SelectedPath = "c:\git\"
        '
        'btn_selecionarPasta
        '
        Me.btn_selecionarPasta.Enabled = False
        Me.btn_selecionarPasta.Location = New System.Drawing.Point(281, 344)
        Me.btn_selecionarPasta.Name = "btn_selecionarPasta"
        Me.btn_selecionarPasta.Size = New System.Drawing.Size(32, 20)
        Me.btn_selecionarPasta.TabIndex = 21
        Me.btn_selecionarPasta.Text = "..."
        Me.btn_selecionarPasta.UseVisualStyleBackColor = True
        '
        'formConfigurarConexao
        '
        Me.AcceptButton = Me.btn_salvar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(341, 446)
        Me.Controls.Add(Me.btn_selecionarPasta)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_pastaGeracaoSolucao)
        Me.Controls.Add(Me.btn_testar)
        Me.Controls.Add(Me.pnl_listagem)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_nomeSolucao)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_namespace)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_salvar)
        Me.Controls.Add(Me.txt_nomeBanco)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_senha)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_usuario)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_instancia)
        Me.Controls.Add(Me.txt_host)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formConfigurarConexao"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "formConfigurarConexao"
        Me.pnl_listagem.ResumeLayout(False)
        Me.pnl_listagem.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_host As System.Windows.Forms.TextBox
    Friend WithEvents txt_instancia As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_usuario As System.Windows.Forms.TextBox
    Friend WithEvents txt_senha As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_nomeBanco As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_salvar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents txt_namespace As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_nomeSolucao As TextBox
    Friend WithEvents pnl_listagem As Panel
    Friend WithEvents cmbSolucao As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btn_novaSolucao As Button
    Friend WithEvents btn_alterar As Button
    Friend WithEvents btn_excluir As Button
    Friend WithEvents btn_testar As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents txt_pastaGeracaoSolucao As TextBox
    Friend WithEvents folder_pasta As FolderBrowserDialog
    Friend WithEvents btn_selecionarPasta As Button
End Class
