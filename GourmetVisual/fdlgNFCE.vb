Public Class fdlgNFCE
    Private Sub fdlgNFCE_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'Instancia o Objeto responsável pela interação com servidores da SEFAZ
        Dim NFCe '= New NFCeX.spdNFCeX
        'Instancia o Objeto responsável pela geração do DataSet
        Dim NFCeDataSet '= New NFCeDataSetX.spdNFCeDataSetX

        'Utiliza Método do Componente para Listar Certificados instalado no SO
        Dim i As Integer
        Dim vetor
        'NFCe.ConfigurarSoftwareHouse("18928448000135", "")
        vetor = Split(NFCe.ListarCertificados(""), "", -1)
        'vetor = 1
        cbCertificado.Controls.Clear()

        For i = LBound(vetor) To UBound(vetor)
            cbCertificado.Items.Add(vetor(i))
        Next

        'Arquivo INI a ser manipulado com parametrizações
        'ArqIni = Application.StartupPath + "\nfceConfig.ini"

        cbCertificado.Text = CertificadoNFCE
        tbEstado.Text = EstadoNFCE
        tbCNPJ.Text = CnpjNFCE

        tbNome.Text = NomeNFCE
        tbFantasia.Text = FantasiaNFCE
        tbEndereco.Text = EnderecoNFCE
        tbNumero.Text = NumeroNFCE
        tbComplemento.Text = ComplementoNFCE
        tbNumeroCidade.Text = NumeroMunicipioNFCE
        tbCidade.Text = MunicipioNFCE
        tbCepNFCE.Text = CepNFCE
        tbNumeroPais.Text = NumeroPaisNFCE
        tbPais.Text = PaisNFCE
        tbInscricaoEstadual.Text = InscricaoEstadualNFCE
        tbBairroNFCE.Text = BairroNFCE
        tbVersao.Text = VersaoNFCE

    End Sub

    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnGrava_Click(sender As Object, e As EventArgs) Handles btnGrava.Click
        EscreveINI("NFCE", "NomeCertificado", cbCertificado.Text, nome_arquivo_ini_NFCE)
        EscreveINI("NFCE", "UF", UCase(tbEstado.Text), nome_arquivo_ini_NFCE)
        EscreveINI("NFCE", "CNPJ", tbCNPJ.Text, nome_arquivo_ini_NFCE)

        EscreveINI("NFCE", "Nome", UCase(tbNome.Text), nome_arquivo_ini_NFCE)
        EscreveINI("NFCE", "Fantasia", UCase(tbFantasia.Text), nome_arquivo_ini_NFCE)
        EscreveINI("NFCE", "Endereco", UCase(tbEndereco.Text), nome_arquivo_ini_NFCE)
        EscreveINI("NFCE", "Numero", UCase(tbNumero.Text), nome_arquivo_ini_NFCE)
        EscreveINI("NFCE", "Complemento", UCase(tbComplemento.Text), nome_arquivo_ini_NFCE)
        EscreveINI("NFCE", "NumeroMunicipio", UCase(tbNumeroCidade.Text), nome_arquivo_ini_NFCE)
        EscreveINI("NFCE", "Cidade", UCase(tbCidade.Text), nome_arquivo_ini_NFCE)
        EscreveINI("NFCE", "CEP", UCase(tbCepNFCE.Text), nome_arquivo_ini_NFCE)
        EscreveINI("NFCE", "NumeroPais", UCase(tbNumeroPais.Text), nome_arquivo_ini_NFCE)
        EscreveINI("NFCE", "Pais", UCase(tbPais.Text), nome_arquivo_ini_NFCE)
        EscreveINI("NFCE", "InscricaoEstadual", UCase(tbInscricaoEstadual.Text), nome_arquivo_ini_NFCE)
        EscreveINI("NFCE", "Bairro", UCase(tbBairroNFCE.Text), nome_arquivo_ini_NFCE)
        EscreveINI("NFCE", "Versao", UCase(tbVersao.Text), nome_arquivo_ini_NFCE)

        Me.Dispose()
        Me.Close()
    End Sub
End Class