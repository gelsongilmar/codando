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
        Me.menuGeral = New System.Windows.Forms.MenuStrip()
        Me.ArquivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SoluçõesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnGerar = New System.Windows.Forms.Button()
        Me.lbl_pastaOutPut = New System.Windows.Forms.Label()
        Me.cmbSolucao = New System.Windows.Forms.ComboBox()
        Me.txtOutPut = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ltbEntidades = New System.Windows.Forms.ListBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAddNovaEntidade = New System.Windows.Forms.Button()
        Me.txtNomeEntidade = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlTopoEntidades = New System.Windows.Forms.Panel()
        Me.lblTituloEntidades = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.txtPropNomeEntidade = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.ltbAtributos = New System.Windows.Forms.ListBox()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAddNovoAtributo = New System.Windows.Forms.Button()
        Me.txtNomeAtributo = New System.Windows.Forms.TextBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.txtPropNomeAtributo = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.menuGeral.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlTopoEntidades.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuGeral
        '
        Me.menuGeral.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArquivoToolStripMenuItem})
        Me.menuGeral.Location = New System.Drawing.Point(0, 0)
        Me.menuGeral.Name = "menuGeral"
        Me.menuGeral.Size = New System.Drawing.Size(1008, 24)
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
        Me.SoluçõesToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.SoluçõesToolStripMenuItem.Text = "Soluções"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.btnGerar)
        Me.Panel1.Controls.Add(Me.lbl_pastaOutPut)
        Me.Panel1.Controls.Add(Me.cmbSolucao)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 31)
        Me.Panel1.TabIndex = 2
        '
        'btnGerar
        '
        Me.btnGerar.BackColor = System.Drawing.Color.Maroon
        Me.btnGerar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGerar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnGerar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGerar.ForeColor = System.Drawing.Color.White
        Me.btnGerar.Location = New System.Drawing.Point(908, 0)
        Me.btnGerar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnGerar.Name = "btnGerar"
        Me.btnGerar.Size = New System.Drawing.Size(100, 31)
        Me.btnGerar.TabIndex = 16
        Me.btnGerar.Text = "Gerar"
        Me.btnGerar.UseVisualStyleBackColor = False
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
        Me.txtOutPut.Location = New System.Drawing.Point(0, 611)
        Me.txtOutPut.Multiline = True
        Me.txtOutPut.Name = "txtOutPut"
        Me.txtOutPut.Size = New System.Drawing.Size(1008, 100)
        Me.txtOutPut.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ltbEntidades)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.pnlTopoEntidades)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 55)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel2.Size = New System.Drawing.Size(250, 556)
        Me.Panel2.TabIndex = 4
        '
        'ltbEntidades
        '
        Me.ltbEntidades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ltbEntidades.FormattingEnabled = True
        Me.ltbEntidades.Location = New System.Drawing.Point(10, 119)
        Me.ltbEntidades.Name = "ltbEntidades"
        Me.ltbEntidades.Size = New System.Drawing.Size(228, 425)
        Me.ltbEntidades.TabIndex = 9
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(10, 109)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(228, 10)
        Me.Panel4.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAddNovaEntidade)
        Me.GroupBox1.Controls.Add(Me.txtNomeEntidade)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(10, 60)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(228, 49)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ Nova Enitdade ] "
        '
        'btnAddNovaEntidade
        '
        Me.btnAddNovaEntidade.Location = New System.Drawing.Point(172, 17)
        Me.btnAddNovaEntidade.Name = "btnAddNovaEntidade"
        Me.btnAddNovaEntidade.Size = New System.Drawing.Size(50, 23)
        Me.btnAddNovaEntidade.TabIndex = 2
        Me.btnAddNovaEntidade.Text = "Add"
        Me.btnAddNovaEntidade.UseVisualStyleBackColor = True
        '
        'txtNomeEntidade
        '
        Me.txtNomeEntidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomeEntidade.Location = New System.Drawing.Point(6, 19)
        Me.txtNomeEntidade.Name = "txtNomeEntidade"
        Me.txtNomeEntidade.Size = New System.Drawing.Size(160, 20)
        Me.txtNomeEntidade.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(10, 50)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(228, 10)
        Me.Panel3.TabIndex = 4
        '
        'pnlTopoEntidades
        '
        Me.pnlTopoEntidades.BackColor = System.Drawing.Color.Gray
        Me.pnlTopoEntidades.Controls.Add(Me.lblTituloEntidades)
        Me.pnlTopoEntidades.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopoEntidades.Location = New System.Drawing.Point(10, 10)
        Me.pnlTopoEntidades.Name = "pnlTopoEntidades"
        Me.pnlTopoEntidades.Size = New System.Drawing.Size(228, 40)
        Me.pnlTopoEntidades.TabIndex = 2
        '
        'lblTituloEntidades
        '
        Me.lblTituloEntidades.AutoSize = True
        Me.lblTituloEntidades.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloEntidades.ForeColor = System.Drawing.Color.White
        Me.lblTituloEntidades.Location = New System.Drawing.Point(75, 12)
        Me.lblTituloEntidades.Name = "lblTituloEntidades"
        Me.lblTituloEntidades.Size = New System.Drawing.Size(78, 16)
        Me.lblTituloEntidades.TabIndex = 18
        Me.lblTituloEntidades.Text = "Entidades"
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Panel15)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(250, 55)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel5.Size = New System.Drawing.Size(250, 556)
        Me.Panel5.TabIndex = 5
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.White
        Me.Panel15.Controls.Add(Me.txtPropNomeEntidade)
        Me.Panel15.Controls.Add(Me.TextBox2)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel15.Location = New System.Drawing.Point(10, 60)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(228, 22)
        Me.Panel15.TabIndex = 5
        '
        'txtPropNomeEntidade
        '
        Me.txtPropNomeEntidade.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtPropNomeEntidade.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPropNomeEntidade.Location = New System.Drawing.Point(100, 0)
        Me.txtPropNomeEntidade.Name = "txtPropNomeEntidade"
        Me.txtPropNomeEntidade.ReadOnly = True
        Me.txtPropNomeEntidade.Size = New System.Drawing.Size(125, 22)
        Me.txtPropNomeEntidade.TabIndex = 8
        '
        'TextBox2
        '
        Me.TextBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.TextBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(0, 0)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(100, 22)
        Me.TextBox2.TabIndex = 7
        Me.TextBox2.Text = "Nome:"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(10, 50)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(228, 10)
        Me.Panel7.TabIndex = 4
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Gray
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(10, 10)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(228, 40)
        Me.Panel8.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Propriedades da Entidade Selecionada"
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.ltbAtributos)
        Me.Panel6.Controls.Add(Me.Panel14)
        Me.Panel6.Controls.Add(Me.GroupBox2)
        Me.Panel6.Controls.Add(Me.Panel9)
        Me.Panel6.Controls.Add(Me.Panel10)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(500, 55)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel6.Size = New System.Drawing.Size(250, 556)
        Me.Panel6.TabIndex = 6
        '
        'ltbAtributos
        '
        Me.ltbAtributos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ltbAtributos.FormattingEnabled = True
        Me.ltbAtributos.Location = New System.Drawing.Point(10, 119)
        Me.ltbAtributos.Name = "ltbAtributos"
        Me.ltbAtributos.Size = New System.Drawing.Size(228, 425)
        Me.ltbAtributos.TabIndex = 10
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.White
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel14.Location = New System.Drawing.Point(10, 109)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(228, 10)
        Me.Panel14.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAddNovoAtributo)
        Me.GroupBox2.Controls.Add(Me.txtNomeAtributo)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(10, 60)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(228, 49)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " [ Novo Atributo ] "
        '
        'btnAddNovoAtributo
        '
        Me.btnAddNovoAtributo.Location = New System.Drawing.Point(172, 17)
        Me.btnAddNovoAtributo.Name = "btnAddNovoAtributo"
        Me.btnAddNovoAtributo.Size = New System.Drawing.Size(50, 23)
        Me.btnAddNovoAtributo.TabIndex = 2
        Me.btnAddNovoAtributo.Text = "Add"
        Me.btnAddNovoAtributo.UseVisualStyleBackColor = True
        '
        'txtNomeAtributo
        '
        Me.txtNomeAtributo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomeAtributo.Location = New System.Drawing.Point(6, 19)
        Me.txtNomeAtributo.Name = "txtNomeAtributo"
        Me.txtNomeAtributo.Size = New System.Drawing.Size(160, 20)
        Me.txtNomeAtributo.TabIndex = 1
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.White
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(10, 50)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(228, 10)
        Me.Panel9.TabIndex = 4
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Gray
        Me.Panel10.Controls.Add(Me.Label2)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(10, 10)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(228, 40)
        Me.Panel10.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(14, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(201, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Atributos da Entidade Selecionada"
        '
        'Panel11
        '
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.Panel16)
        Me.Panel11.Controls.Add(Me.Panel12)
        Me.Panel11.Controls.Add(Me.Panel13)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel11.Location = New System.Drawing.Point(750, 55)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel11.Size = New System.Drawing.Size(250, 556)
        Me.Panel11.TabIndex = 7
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.White
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel12.Location = New System.Drawing.Point(10, 50)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(228, 10)
        Me.Panel12.TabIndex = 4
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.Gray
        Me.Panel13.Controls.Add(Me.Label3)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel13.Location = New System.Drawing.Point(10, 10)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(228, 40)
        Me.Panel13.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(222, 15)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Propriedades do Atributo Selecionado"
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.White
        Me.Panel16.Controls.Add(Me.txtPropNomeAtributo)
        Me.Panel16.Controls.Add(Me.TextBox3)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(10, 60)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(228, 22)
        Me.Panel16.TabIndex = 6
        '
        'txtPropNomeAtributo
        '
        Me.txtPropNomeAtributo.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtPropNomeAtributo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPropNomeAtributo.Location = New System.Drawing.Point(100, 0)
        Me.txtPropNomeAtributo.Name = "txtPropNomeAtributo"
        Me.txtPropNomeAtributo.ReadOnly = True
        Me.txtPropNomeAtributo.Size = New System.Drawing.Size(125, 22)
        Me.txtPropNomeAtributo.TabIndex = 8
        '
        'TextBox3
        '
        Me.TextBox3.Dock = System.Windows.Forms.DockStyle.Left
        Me.TextBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(0, 0)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(100, 22)
        Me.TextBox3.TabIndex = 7
        Me.TextBox3.Text = "Nome:"
        '
        'FrmGerar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1008, 711)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.txtOutPut)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.menuGeral)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuGeral
        Me.Name = "FrmGerar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Codando"
        Me.menuGeral.ResumeLayout(False)
        Me.menuGeral.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlTopoEntidades.ResumeLayout(False)
        Me.pnlTopoEntidades.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menuGeral As MenuStrip
    Friend WithEvents ArquivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SoluçõesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbl_pastaOutPut As Label
    Friend WithEvents cmbSolucao As ComboBox
    Friend WithEvents txtOutPut As TextBox
    Friend WithEvents btnGerar As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAddNovaEntidade As Button
    Friend WithEvents txtNomeEntidade As TextBox
    Friend WithEvents pnlTopoEntidades As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ltbEntidades As ListBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnAddNovoAtributo As Button
    Friend WithEvents txtNomeAtributo As TextBox
    Friend WithEvents ltbAtributos As ListBox
    Friend WithEvents Panel14 As Panel
    Friend WithEvents lblTituloEntidades As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel15 As Panel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents txtPropNomeEntidade As TextBox
    Friend WithEvents Panel16 As Panel
    Friend WithEvents txtPropNomeAtributo As TextBox
    Friend WithEvents TextBox3 As TextBox
End Class
