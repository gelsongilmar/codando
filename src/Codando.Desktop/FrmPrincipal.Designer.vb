<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrincipal))
        Me.btnGerarSQLServer = New System.Windows.Forms.Button()
        Me.btnGerarCadastrandoEntidades = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnGerarSQLServer
        '
        Me.btnGerarSQLServer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGerarSQLServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGerarSQLServer.Location = New System.Drawing.Point(12, 12)
        Me.btnGerarSQLServer.Name = "btnGerarSQLServer"
        Me.btnGerarSQLServer.Size = New System.Drawing.Size(500, 30)
        Me.btnGerarSQLServer.TabIndex = 0
        Me.btnGerarSQLServer.Text = "Gerar Código a Partir de Uma Base de Dados SQL Server (Leitura do Schema)"
        Me.btnGerarSQLServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGerarSQLServer.UseVisualStyleBackColor = True
        '
        'btnGerarCadastrandoEntidades
        '
        Me.btnGerarCadastrandoEntidades.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGerarCadastrandoEntidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGerarCadastrandoEntidades.Location = New System.Drawing.Point(12, 48)
        Me.btnGerarCadastrandoEntidades.Name = "btnGerarCadastrandoEntidades"
        Me.btnGerarCadastrandoEntidades.Size = New System.Drawing.Size(500, 30)
        Me.btnGerarCadastrandoEntidades.TabIndex = 1
        Me.btnGerarCadastrandoEntidades.Text = "Gerar Código Cadastrando Entidades"
        Me.btnGerarCadastrandoEntidades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGerarCadastrandoEntidades.UseVisualStyleBackColor = True
        '
        'formPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(526, 92)
        Me.Controls.Add(Me.btnGerarCadastrandoEntidades)
        Me.Controls.Add(Me.btnGerarSQLServer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "formPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Codando: Produtividade Absoluta"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnGerarSQLServer As Button
    Friend WithEvents btnGerarCadastrandoEntidades As Button
End Class
