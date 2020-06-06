Imports Codando.Config
Imports Codando.Config.geracao
Imports Codando.Gerador.Domain.Base

Public Class FrmSolucoes


    Private _configCodando As ConfigCodando
    Private _configSelecionada As SolucaoCodando = Nothing

    Public Sub Inicial()

        _configCodando = New Configuracao().GetConfigCodando()
        CarregarComboSolucoes()
        If cmbSolucao.Items.Count > 0 Then
            cmbSolucao.SelectedIndex = 0
            _configSelecionada = cmbSolucao.SelectedItem
        End If

    End Sub

    Private Sub btn_salvar_Click(sender As Object, e As System.EventArgs) Handles btn_salvar.Click

        PreencherConfigSelecionada()

        Dim config As New Configuracao
        config.AtualizarConfigCodando(_configCodando)

        Dim configGeracao As New ConfiguracaoGeracao(_configSelecionada)
        Dim solucaoGerada = configGeracao.GetConfig()
        solucaoGerada.SolucaoCodando = _configSelecionada

        If String.IsNullOrEmpty(solucaoGerada.NomeGeracao) Then
            solucaoGerada.NomeGeracao = _configSelecionada.NomeSolucao
        End If

        configGeracao.SetConfig(solucaoGerada)

        pnl_listagem.Enabled = True
        AtivarCampos(False)

        MessageBox.Show("Informações atualizadas com sucesso")
        Inicial()

    End Sub

    Private Sub cmbSolucao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSolucao.SelectedIndexChanged
        PreencherConfigSelecionada()
        _configSelecionada = cmbSolucao.SelectedItem
        PreencherTela()
    End Sub

    Private Sub PreencherTela()
        txt_nomeSolucao.Text = _configSelecionada.NomeSolucao
        txt_pastaGeracaoSolucao.Text = _configSelecionada.PastaGeracaoSolucao
    End Sub

    Private Sub PreencherConfigSelecionada()

        If _configSelecionada Is Nothing Then Return

        _configSelecionada.NomeSolucao = txt_nomeSolucao.Text
        _configSelecionada.PastaGeracaoSolucao = txt_pastaGeracaoSolucao.Text

    End Sub

    Private Sub btn_novaSolucao_Click(sender As Object, e As EventArgs) Handles btn_novaSolucao.Click

        pnl_listagem.Enabled = False

        AddNovaSolucao()
        CarregarComboSolucoes()
        cmbSolucao.SelectedIndex = cmbSolucao.Items.Count - 1
        AtivarCampos(True)

    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click

        If _configSelecionada Is Nothing Then Return

        pnl_listagem.Enabled = False
        AtivarCampos(True)

    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click

        If _configSelecionada Is Nothing Then Return

        _configCodando.Solucoes.Remove(_configSelecionada)

        Dim config As New Configuracao
        config.AtualizarConfigCodando(_configCodando)

        _configSelecionada = Nothing
        txt_nomeSolucao.Text = ""
        txt_pastaGeracaoSolucao.Text = ""

        MessageBox.Show("Solução removida com sucesso!")
        Inicial()

    End Sub

    Private Sub CarregarComboSolucoes()
        cmbSolucao.Items.Clear()
        For Each solucao As SolucaoCodando In _configCodando.Solucoes
            cmbSolucao.Items.Add(solucao)
        Next
    End Sub

    Private Sub AddNovaSolucao()
        Dim config As New SolucaoCodando()
        config.NomeSolucao = "Nova Solução"
        _configCodando.Solucoes.Add(config)
    End Sub

    Private Sub AtivarCampos(ativar As Boolean)
        txt_nomeSolucao.Enabled = ativar
        txt_pastaGeracaoSolucao.Enabled = ativar
        btn_selecionarPasta.Enabled = ativar
        btn_salvar.Enabled = ativar
        btn_cancelar.Enabled = ativar
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        pnl_listagem.Enabled = True
        CarregarComboSolucoes()
        If cmbSolucao.Items.Count > 0 Then
            cmbSolucao.SelectedIndex = 0
            _configSelecionada = cmbSolucao.SelectedItem
        End If
        AtivarCampos(False)
    End Sub

    Private Sub btn_selecionarPasta_Click(sender As Object, e As EventArgs) Handles btn_selecionarPasta.Click
        If folder_pasta.ShowDialog = DialogResult.OK Then
            txt_pastaGeracaoSolucao.Text = folder_pasta.SelectedPath
        End If
    End Sub

End Class