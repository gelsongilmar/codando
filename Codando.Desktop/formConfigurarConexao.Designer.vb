<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formConfigurarConexao
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
        Me.btn_testar = New System.Windows.Forms.Button()
        Me.btn_salvar = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.txt_namespace = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Host"
        '
        'txt_host
        '
        Me.txt_host.Location = New System.Drawing.Point(16, 30)
        Me.txt_host.Name = "txt_host"
        Me.txt_host.Size = New System.Drawing.Size(147, 20)
        Me.txt_host.TabIndex = 1
        '
        'txt_instancia
        '
        Me.txt_instancia.Location = New System.Drawing.Point(169, 30)
        Me.txt_instancia.Name = "txt_instancia"
        Me.txt_instancia.Size = New System.Drawing.Size(143, 20)
        Me.txt_instancia.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(166, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Instância"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Usuário"
        '
        'txt_usuario
        '
        Me.txt_usuario.Location = New System.Drawing.Point(16, 114)
        Me.txt_usuario.Name = "txt_usuario"
        Me.txt_usuario.Size = New System.Drawing.Size(170, 20)
        Me.txt_usuario.TabIndex = 4
        '
        'txt_senha
        '
        Me.txt_senha.Location = New System.Drawing.Point(192, 114)
        Me.txt_senha.Name = "txt_senha"
        Me.txt_senha.Size = New System.Drawing.Size(120, 20)
        Me.txt_senha.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(189, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Senha"
        '
        'txt_nomeBanco
        '
        Me.txt_nomeBanco.Location = New System.Drawing.Point(16, 75)
        Me.txt_nomeBanco.Name = "txt_nomeBanco"
        Me.txt_nomeBanco.Size = New System.Drawing.Size(296, 20)
        Me.txt_nomeBanco.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Banco de dados"
        '
        'btn_testar
        '
        Me.btn_testar.Location = New System.Drawing.Point(17, 215)
        Me.btn_testar.Name = "btn_testar"
        Me.btn_testar.Size = New System.Drawing.Size(75, 23)
        Me.btn_testar.TabIndex = 6
        Me.btn_testar.Text = "Testar"
        Me.btn_testar.UseVisualStyleBackColor = True
        '
        'btn_salvar
        '
        Me.btn_salvar.Location = New System.Drawing.Point(170, 215)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(75, 23)
        Me.btn_salvar.TabIndex = 7
        Me.btn_salvar.Text = "Salvar"
        Me.btn_salvar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_cancelar.Location = New System.Drawing.Point(251, 215)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 8
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'txt_namespace
        '
        Me.txt_namespace.Location = New System.Drawing.Point(16, 154)
        Me.txt_namespace.Name = "txt_namespace"
        Me.txt_namespace.Size = New System.Drawing.Size(296, 20)
        Me.txt_namespace.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Namespace"
        '
        'formConfigurarConexao
        '
        Me.AcceptButton = Me.btn_salvar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn_cancelar
        Me.ClientSize = New System.Drawing.Size(348, 263)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_namespace)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_salvar)
        Me.Controls.Add(Me.btn_testar)
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
    Friend WithEvents btn_testar As System.Windows.Forms.Button
    Friend WithEvents btn_salvar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents txt_namespace As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
