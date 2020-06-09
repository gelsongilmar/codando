Imports Codando.Config
Imports Codando.Config.geracao
Imports Codando.Gerador
Imports Codando.Gerador.Domain.Base
Imports Codando.Gerador.FactoryDomain
Imports Codando.[Shared]

Public Class FrmGerar

    Private _configCodando As ConfigCodando
    Private _configSelecionada As SolucaoCodando = Nothing
    Private _configGeracaoSelecionada As SolucaoGerada = Nothing
    Private _entidadeSelecionada As EntidadeGerada = Nothing
    Private _atributoSelecionado As AtributoGerado = Nothing

    Private Sub FrmGerar_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Not Me.DesignMode Then
            CarregarConfiguracoes()
            CarregarInformacoes()
        End If
    End Sub

    Private Sub SoluçõesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SoluçõesToolStripMenuItem.Click
        Dim f As New FrmSolucoes
        f.Inicial()
        f.ShowDialog()
        Me.CarregarConfiguracoes()
    End Sub

    Private Sub CarregarConfiguracoes()
        _configCodando = New Configuracao().GetConfigCodando()
        CarregarComboSolucoes()
        If cmbSolucao.Items.Count > 0 Then
            cmbSolucao.SelectedIndex = 0
            _configSelecionada = cmbSolucao.SelectedItem
            Me.PreencherConfgGeracaoSelecionada()
        End If
    End Sub

    Private Sub CarregarInformacoes()

        If _configSelecionada Is Nothing Then
            ExibirConexaoNaoConfigurada()
            Return
        End If

        lbl_pastaOutPut.ForeColor = System.Drawing.Color.Blue
        lbl_pastaOutPut.Text = "Pasta Geração: " + _configSelecionada.PastaGeracaoSolucao

        Dim i = ltbEntidades.SelectedIndex
        ltbEntidades.Items.Clear()
        For Each item As EntidadeGerada In _configGeracaoSelecionada.Entidades
            ltbEntidades.Items.Add(item)
        Next

        If ltbEntidades.Items.Count > 0 Then

            If i < 0 Then
                i = 0
            End If

            ltbEntidades.SelectedIndex = i
            pnlPropriedadesEntidade.Visible = True
            pnlAtributos.Visible = True

        Else
            pnlPropriedadeAtributos.Visible = False
            pnlAtributos.Visible = False
            pnlPropriedadesEntidade.Visible = False
        End If

    End Sub

    Private Sub ExibirConexaoNaoConfigurada()
        lbl_pastaOutPut.Text = "Solução não configurada"
        lbl_pastaOutPut.ForeColor = System.Drawing.Color.Red
    End Sub

    Private Sub CarregarComboSolucoes()
        cmbSolucao.Items.Clear()
        For Each solucao As SolucaoCodando In _configCodando.Solucoes
            cmbSolucao.Items.Add(solucao)
        Next
    End Sub

    Private Sub cmbSolucao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSolucao.SelectedIndexChanged
        _configSelecionada = cmbSolucao.SelectedItem
        Me.PreencherConfgGeracaoSelecionada()
        Me.CarregarInformacoes()
    End Sub

    Private Sub btnGerar_Click(sender As Object, e As EventArgs) Handles btnGerar.Click

        If _configSelecionada Is Nothing Then Return
        If _configGeracaoSelecionada Is Nothing Then Return

        Dim validacao As New Codando.Config.geracao.ValidaGeracao(_configGeracaoSelecionada)
        If Not validacao.IsValid() Then
            ViewNotification.Show(validacao)
            Return
        End If

        Dim _factory As New FactoryGeracao()

        Dim _solucao As Solucao = _factory.GetSolucao(Me.GetParametrosGeracao())

        Dim motor As New Gerador.Motor.Gerador(_solucao)
        motor.Gerar(AddressOf ShowProgresso)

    End Sub

    Private Function GetParametrosGeracao() As ParametrosGeracao
        Dim retorno As New ParametrosGeracao

        retorno.ConfigSolucao = _configGeracaoSelecionada
        retorno.LinguagemGeracao = LinguagemGeracao.VisualBasic

        Return retorno
    End Function

    Private Sub PreencherConfgGeracaoSelecionada()
        Dim configGeracao As New ConfiguracaoGeracao(_configSelecionada)
        _configGeracaoSelecionada = configGeracao.GetConfig()
    End Sub

    Sub ShowProgresso(msg As String)
        txtOutPut.AppendText(vbCrLf & Now.ToString() & ": " & msg)
    End Sub

    Private Sub btnAddNovaEntidade_Click(sender As Object, e As EventArgs) Handles btnAddNovaEntidade.Click
        AddNovaEntidade()
    End Sub

    Private Sub AddNovaEntidade()
        If txtNomeEntidade.Text.Trim = "" Then Return

        For Each item As EntidadeGerada In _configGeracaoSelecionada.Entidades
            If item.Nome = txtNomeEntidade.Text.Trim Then Return
        Next

        _configGeracaoSelecionada.Entidades.Add(New EntidadeGerada(txtNomeEntidade.Text.Trim))
        Dim configGeracao As New ConfiguracaoGeracao(_configSelecionada)
        configGeracao.SetConfig(_configGeracaoSelecionada)

        Me.PreencherConfgGeracaoSelecionada()
        Me.CarregarInformacoes()

        txtNomeEntidade.Text = ""

    End Sub

    Private Sub txtNomeEntidade_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNomeEntidade.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddNovaEntidade()
        End If
    End Sub

    Private Sub ltbEntidades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ltbEntidades.SelectedIndexChanged
        Me.PreencherDadosTabelaSelecionada()
    End Sub

    Private Sub PreencherDadosTabelaSelecionada()
        _entidadeSelecionada = ltbEntidades.SelectedItem

        If Not _entidadeSelecionada Is Nothing Then


            txtPropNomeEntidade.Text = _entidadeSelecionada.Nome

            Dim i = ltbAtributos.SelectedIndex

            ltbAtributos.Items.Clear()
            For Each item As AtributoGerado In _entidadeSelecionada.Atributos
                ltbAtributos.Items.Add(item)
            Next

            If ltbAtributos.Items.Count > 0 Then

                If i < 0 Then
                    i = 0
                End If

                If i > ltbAtributos.Items.Count - 1 Then
                    i = ltbAtributos.Items.Count - 1
                End If

                ltbAtributos.SelectedIndex = i
                pnlPropriedadeAtributos.Visible = True

            Else
                pnlPropriedadeAtributos.Visible = False
            End If

        End If

    End Sub

    Private Sub btnAddNovoAtributo_Click(sender As Object, e As EventArgs) Handles btnAddNovoAtributo.Click
        AddNovoAtributo()
    End Sub

    Private Sub AddNovoAtributo()
        If txtNomeAtributo.Text.Trim = "" Then Return

        For Each item As AtributoGerado In _entidadeSelecionada.Atributos
            If item.Nome = txtNomeAtributo.Text.Trim Then Return
        Next

        _entidadeSelecionada.Atributos.Add(New AtributoGerado(txtNomeAtributo.Text.Trim))
        Dim configGeracao As New ConfiguracaoGeracao(_configSelecionada)
        configGeracao.SetConfig(_configGeracaoSelecionada)

        Me.PreencherConfgGeracaoSelecionada()
        Me.CarregarInformacoes()

        txtNomeAtributo.Text = ""
    End Sub

    Private Sub txtNomeAtributo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNomeAtributo.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddNovoAtributo()
        End If
    End Sub

    Private Sub ltbAtributos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ltbAtributos.SelectedIndexChanged
        Me.PreencherDadosAtributoSelecionado()
    End Sub

    Private Sub PreencherDadosAtributoSelecionado()
        _atributoSelecionado = ltbAtributos.SelectedItem

        If Not _atributoSelecionado Is Nothing Then


            txtPropNomeAtributo.Text = _atributoSelecionado.Nome
            cmbPropTipoAtributo.SelectedIndex = _atributoSelecionado.Tipo?.Tipo

            txtPropTamanhoAtributo.Text = ""
            If Not txtPropTamanhoAtributo.ReadOnly Then
                txtPropTamanhoAtributo.Text = _atributoSelecionado.Tamanho
            End If

            txtPropPrecisaoAtributo.Text = ""
            If Not txtPropPrecisaoAtributo.ReadOnly Then
                txtPropPrecisaoAtributo.Text = _atributoSelecionado.Precisao
            End If

            If _atributoSelecionado.IsNulo Then
                cmbPropAtributoIsNulo.SelectedIndex = 0
            Else
                cmbPropAtributoIsNulo.SelectedIndex = 1
            End If

            If _atributoSelecionado.IsAutoIncremento Then
                cmbPropAtributoAutoInremento.SelectedIndex = 0
            Else
                cmbPropAtributoAutoInremento.SelectedIndex = 1
            End If

            If _atributoSelecionado.IsPK Then
                cmbPropAtributoPK.SelectedIndex = 0
            Else
                cmbPropAtributoPK.SelectedIndex = 1
            End If

        End If

    End Sub

    Private Sub cmbPropTipoAtributo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPropTipoAtributo.SelectedIndexChanged
        txtPropTamanhoAtributo.ReadOnly = cmbPropTipoAtributo.SelectedIndex <> 0 And cmbPropTipoAtributo.SelectedIndex <> 3
        txtPropPrecisaoAtributo.ReadOnly = cmbPropTipoAtributo.SelectedIndex <> 3

        If txtPropTamanhoAtributo.ReadOnly Then
            txtPropTamanhoAtributo.Text = ""
        End If

        If txtPropPrecisaoAtributo.ReadOnly Then
            txtPropPrecisaoAtributo.Text = ""
        End If

    End Sub

    Private Sub SalvarPropriedadesAtributo()

        _atributoSelecionado.Tipo.Tipo = cmbPropTipoAtributo.SelectedIndex

        Dim tamanho As Integer = -1
        If Integer.TryParse(txtPropTamanhoAtributo.Text, tamanho) Then
            _atributoSelecionado.Tamanho = tamanho
        Else
            _atributoSelecionado.Tamanho = -1
        End If

        Dim precisao As Integer = -1
        If Integer.TryParse(txtPropPrecisaoAtributo.Text, precisao) Then
            _atributoSelecionado.Precisao = precisao
        Else
            _atributoSelecionado.Precisao = -1
        End If

        _atributoSelecionado.IsNulo = cmbPropAtributoIsNulo.SelectedIndex = 0
        _atributoSelecionado.IsPK = cmbPropAtributoPK.SelectedIndex = 0
        _atributoSelecionado.IsAutoIncremento = cmbPropAtributoAutoInremento.SelectedIndex = 0

        Dim configGeracao As New ConfiguracaoGeracao(_configSelecionada)
        configGeracao.SetConfig(_configGeracaoSelecionada)

        Me.PreencherConfgGeracaoSelecionada()
        Me.CarregarInformacoes()

    End Sub

    Private Sub btnSalvarPropriedadesAtributos_Click(sender As Object, e As EventArgs) Handles btnSalvarPropriedadesAtributos.Click
        Me.SalvarPropriedadesAtributo()
    End Sub

    Private Sub btnExcluirAtributo_Click(sender As Object, e As EventArgs) Handles btnExcluirAtributo.Click

        _entidadeSelecionada.Atributos.Remove(_atributoSelecionado)

        Dim configGeracao As New ConfiguracaoGeracao(_configSelecionada)
        configGeracao.SetConfig(_configGeracaoSelecionada)

        Me.PreencherConfgGeracaoSelecionada()
        Me.CarregarInformacoes()

    End Sub

    Private Sub FrmGerar_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

End Class