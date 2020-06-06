Imports Codando.Config
Imports Codando.Config.geracao
Imports Codando.Gerador
Imports Codando.Gerador.Domain.Base
Imports Codando.Gerador.FactoryDomain

Public Class FrmGerar

    Private _configCodando As ConfigCodando
    Private _configSelecionada As SolucaoCodando = Nothing
    Private _configGeracaoSelecionada As SolucaoGerada = Nothing

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

        'Dim validacao As New ValidaConfiguracao(_configSelecionada)
        'If Not validacao.IsValid() Then
        '    ViewNotification.Show(validacao)
        '    Return
        'End If

        Dim _factory As New FactoryGeracao()

        Dim _solucao As Solucao = _factory.GetSolucao(Me.GetParametrosGeracao())

        Dim motor As New Gerador.Motor.Gerador(_solucao)
        motor.Gerar()

        MessageBox.Show("Geração realizada com sucesso", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

End Class