Imports System
Imports System.Windows.Forms
Imports Codando.DataBase
Imports Codando.Config

Public Class formConfigurarConexao


    Private _configCodando As ConfigCodando
    Private _configSelecionada As ConfigCodandoSolucao = Nothing

    Public Sub Inicial()

        _configCodando = New Configuracao().GetConfigCodando()
        CarregarComboSolucoes()
        If cmbSolucao.Items.Count > 0 Then
            cmbSolucao.SelectedIndex = 0
            _configSelecionada = cmbSolucao.SelectedItem
        End If

    End Sub

    Private Sub btn_testar_Click(sender As Object, e As System.EventArgs) Handles btn_testar.Click

        If _configSelecionada Is Nothing Then Return

        Dim arquivoXML As New ConexaoSolucao
        arquivoXML.Carregar(_configSelecionada)
        MessageBox.Show(arquivoXML.TestarConexao.Mensagem)
    End Sub

    Private Sub btn_salvar_Click(sender As Object, e As System.EventArgs) Handles btn_salvar.Click

        PreencherConfigSelecionada()

        Dim config As New Configuracao
        config.AtualizarConfigCodando(_configCodando)

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
        txt_host.Text = _configSelecionada.Host
        txt_instancia.Text = _configSelecionada.Instancia
        txt_nomeBanco.Text = _configSelecionada.NomeBancoDados
        txt_usuario.Text = _configSelecionada.Usuario
        txt_senha.Text = _configSelecionada.Senha
        txt_namespace.Text = _configSelecionada.NamespacePrincipal
        txt_pastaGeracaoSolucao.Text = _configSelecionada.PastaGeracaoSolucao
    End Sub

    Private Sub PreencherConfigSelecionada()

        If _configSelecionada Is Nothing Then Return

        _configSelecionada.NomeSolucao = txt_nomeSolucao.Text
        _configSelecionada.Host = txt_host.Text
        _configSelecionada.Instancia = txt_instancia.Text
        _configSelecionada.NomeBancoDados = txt_nomeBanco.Text
        _configSelecionada.Usuario = txt_usuario.Text
        _configSelecionada.Senha = txt_senha.Text
        _configSelecionada.NamespacePrincipal = txt_namespace.Text
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
        MessageBox.Show("Solução removida com sucesso!")
        Inicial()

    End Sub

    Private Sub CarregarComboSolucoes()
        cmbSolucao.Items.Clear()
        For Each solucao As ConfigCodandoSolucao In _configCodando.Solucoes
            cmbSolucao.Items.Add(solucao)
        Next
    End Sub

    Private Sub AddNovaSolucao()
        Dim config As New ConfigCodandoSolucao()
        config.NomeSolucao = "Nova Solução"
        _configCodando.Solucoes.Add(config)
    End Sub

    Private Sub AtivarCampos(ativar As Boolean)
        txt_nomeSolucao.Enabled = ativar
        txt_host.Enabled = ativar
        txt_instancia.Enabled = ativar
        txt_nomeBanco.Enabled = ativar
        txt_usuario.Enabled = ativar
        txt_senha.Enabled = ativar
        txt_namespace.Enabled = ativar
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