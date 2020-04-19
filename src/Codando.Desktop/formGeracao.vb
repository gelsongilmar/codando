Imports Codando.Config
Imports Codando.DataBase
Imports Codando.Gerador
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class formGeracao

    Private _configCodando As ConfigCodando
    Private _configSelecionada As ConfigCodandoSolucao = Nothing

    Private Sub formGeracao_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Not Me.DesignMode Then
            CarregarConfiguracoes()
            CarregarInformacoes()
        End If
    End Sub

    Private Sub CarregarConfiguracoes()
        _configCodando = New Configuracao().GetConfigCodando()
        CarregarComboSolucoes()
        If cmbSolucao.Items.Count > 0 Then
            cmbSolucao.SelectedIndex = 0
            _configSelecionada = cmbSolucao.SelectedItem
        End If
    End Sub

    Private Sub CarregarInformacoes()

        If _configSelecionada Is Nothing Then
            ExibirConexaoNaoConfigurada()
            Return
        End If

        Dim arquivoXML As New ConexaoSolucao
        arquivoXML.Carregar(_configSelecionada)
        If arquivoXML.Host <> "" Then

            lbl_configuracao.Text = "Conexão Configurada: " + arquivoXML.Host + "\" + arquivoXML.Instancia + " BD: " + arquivoXML.NomeBancoDados
            lbl_configuracao.ForeColor = System.Drawing.Color.Blue

            lbl_pastaOutPut.Text = "Pasta Geração: " + _configSelecionada.PastaGeracaoSolucao

            If arquivoXML.TestarConexao.IsSucesso Then
                CarregarTabelas(arquivoXML.MontarStringConexao)
            End If

        Else
            ExibirConexaoNaoConfigurada()
        End If
    End Sub

    Private Sub ExibirConexaoNaoConfigurada()
        lbl_configuracao.Text = "Conexão não configurada"
        lbl_configuracao.ForeColor = System.Drawing.Color.Red
    End Sub

    Private Sub CarregarTabelas(p_strConexao As String)
        chkBox_tabelas.DataSource = New SchemaBD(p_strConexao).ListarTabelas()
        chkBox_tabelas.DisplayMember = "NomeTabela"
        chkBox_tabelas.ValueMember = "IdTabela"
        chkBox_tabelas.Refresh()
    End Sub

    Private Sub ConfigurarConexaoToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles ConfigurarConexaoToolStripMenuItem.Click
        Dim frmConexao As New formConfigurarConexao
        frmConexao.Inicial()
        frmConexao.ShowDialog()
        Me.CarregarConfiguracoes()
    End Sub

    Private Sub btn_gerarCodigo_Click(sender As Object, e As System.EventArgs) Handles btn_gerarCodigo.Click

        If _configSelecionada Is Nothing Then Return

        Dim validacao As New ValidaConfiguracao(_configSelecionada)
        If Not validacao.IsValid() Then
            ViewNotification.Show(validacao)
            Return
        End If

        Dim _arquivoXML As New ConexaoSolucao
        _arquivoXML.Carregar(_configSelecionada)

        Dim diretorios As New DiretoriosGeracao(_configSelecionada)

        Me.CriarDiretorios(diretorios)

        For index = 0 To chkBox_tabelas.CheckedItems.Count - 1

            Dim dr As DataRowView = chkBox_tabelas.CheckedItems(index)

            Dim idTabela As String = dr.Item("IdTabela").ToString
            Dim nomeTabela As String = dr.Item("NomeTabela").ToString

            '// Gerar Classe de Acesso a Dados
            If chk_gerarClasseDAL.Checked Then

                'TODO:  CRIAR O PROJETO DAL, vide essa classe DiretoriosGeracao
                ' AS DAL serão partial class e se ainda não existir vamos criar a class vazia onde o dev pode mexer, as partial não é para ser mexida

                Dim _strClasse As String = Me.ObterStrClass(idTabela, nomeTabela, _arquivoXML.MontarStringConexao, _configSelecionada.NamespacePrincipal)

                Dim nomeArquivo As String = nomeTabela
                If rdBtn_cSharp.Checked Then
                    nomeArquivo += ".cs"
                Else
                    nomeArquivo += ".vb"
                End If
                Dim sw As New IO.StreamWriter(diretorios.GetDiretorioGeracaoDAL & "/" & nomeArquivo, False)
                sw.WriteLine(_strClasse)
                sw.Close()
            End If

            '// Gerar Banco de dados
            If Me.IsGerarBancoDados Then

                'TODO:  CRIAR O PROJETO DE BANCO DE DADOS, vide essa classe DiretoriosGeracao

                Dim _strTabelaProcedure As String = Me.ObterStrTabelaProcedures(idTabela, nomeTabela, _arquivoXML.MontarStringConexao)
                Dim sw As New IO.StreamWriter(diretorios.GetDiretorioProjetoBD & "/" & nomeTabela + ".SQL", False)
                sw.WriteLine(_strTabelaProcedure)
                sw.Close()
            End If
        Next

        MessageBox.Show("Geração realizada com sucesso", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        System.Diagnostics.Process.Start((_configSelecionada.PastaGeracaoSolucao).Replace("\", "/"))

    End Sub

    Private Function IsGerarBancoDados() As Boolean
        Return chkBox_gerarTabelas.Checked OrElse chkBox_gerarProcedures.Checked
    End Function

    Private Sub CriarDiretorios(ditretorios As DiretoriosGeracao)
        If Not IO.Directory.Exists(ditretorios.GetDiretorioProjetoDAL) Then
            IO.Directory.CreateDirectory(ditretorios.GetDiretorioProjetoDAL)
        End If
        If Not IO.Directory.Exists(ditretorios.GetDiretorioGeracaoDAL) Then
            IO.Directory.CreateDirectory(ditretorios.GetDiretorioGeracaoDAL)
        End If
        If Not IO.Directory.Exists(ditretorios.GetDiretorioProjetoWEB) Then
            IO.Directory.CreateDirectory(ditretorios.GetDiretorioProjetoWEB)
        End If
        If Me.IsGerarBancoDados Then
            If Not IO.Directory.Exists(ditretorios.GetDiretorioProjetoBD) Then
                IO.Directory.CreateDirectory(ditretorios.GetDiretorioProjetoBD)
            End If
            If Not IO.Directory.Exists(ditretorios.GetDiretorioGeracaoProcedures) Then
                IO.Directory.CreateDirectory(ditretorios.GetDiretorioGeracaoProcedures)
            End If
        End If
    End Sub

    Private Function ObterStrClass(idTabela As String, nomeTabela As String, strConexao As String, p_namespace As String) As String
        Dim _geradorCodigo As New GeracaoCodigo(strConexao)
        _geradorCodigo.IsBuscarIdentidade = Me.chkBox_isLocalizarIdentidade.Checked
        Return _geradorCodigo.GerarStrClasse(idTabela, nomeTabela, rdBtn_cSharp.Checked, rdBtn_aspNetCore.Checked, p_namespace)
    End Function

    Private Function ObterStrTabelaProcedures(idTabela As String, nomeTabela As String, strConexao As String) As String
        Dim _geradorCodigo As New GeracaoCodigo(strConexao)

        _geradorCodigo.IsBuscarIdentidade = Me.chkBox_isLocalizarIdentidade.Checked
        _geradorCodigo.IsGerarTabelas = Me.chkBox_gerarTabelas.Checked
        _geradorCodigo.IsGerarProcedures = Me.chkBox_gerarProcedures.Checked

        Return _geradorCodigo.GerarStrTabelasStoredProcedures(idTabela, nomeTabela)
    End Function

    Private Sub btn_abrirPasta_Click(sender As Object, e As EventArgs) Handles btn_abrirPasta.Click
        If _configSelecionada Is Nothing Then Return
        Dim _dirSolucao As String = _configSelecionada.PastaGeracaoSolucao
        System.Diagnostics.Process.Start((_dirSolucao).Replace("\", "/"))
    End Sub

    Private Sub btn_marcarTodas_Click(sender As Object, e As EventArgs) Handles btn_marcarTodas.Click
        For i As Integer = 0 To (chkBox_tabelas.Items.Count - 1)
            chkBox_tabelas.SetItemCheckState(i, CheckState.Checked)
        Next
    End Sub

    Private Sub btn_desmarcarTodas_Click(sender As Object, e As EventArgs) Handles btn_desmarcarTodas.Click
        For i As Integer = 0 To (chkBox_tabelas.Items.Count - 1)
            chkBox_tabelas.SetItemCheckState(i, CheckState.Unchecked)
        Next
    End Sub

    Private Sub CarregarComboSolucoes()
        cmbSolucao.Items.Clear()
        For Each solucao As ConfigCodandoSolucao In _configCodando.Solucoes
            cmbSolucao.Items.Add(solucao)
        Next
    End Sub

    Private Sub cmbSolucao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSolucao.SelectedIndexChanged
        _configSelecionada = cmbSolucao.SelectedItem
        Me.CarregarInformacoes()
    End Sub

End Class