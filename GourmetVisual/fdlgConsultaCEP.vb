Imports System.Xml

Public Class fdlgConsultaCEP
    Public Sub CadastraRuaWeb(Estado As String, Cidade As String, Logra As String)
        Dim IDRua As Integer = 0
        Dim IDCep As Integer
        Dim url As String
        Dim Bairro As String = ""
        Dim Logradouro As String = ""
        Dim CEP As String = ""
        Dim QtdConsulta As Integer = 10

        Label2.Visible = False
        lbTotalCEP.Visible = False

        ' lstRuas.Items.Clear()

        Cidade = VerificaTexto(UCase(Cidade))
        Logra = VerificaTexto(UCase(Logra))

VoltaConsulta:

        url = "https://viacep.com.br/ws/" & Estado & "/" & Cidade & "/" & Logra & "/xml/"


        Dim leCEP As Integer = 0
        Dim leLog As Integer = 0
        Dim leBai As Integer = 0
        Dim leGui As Integer = 0

        Dim reader As XmlTextReader = New XmlTextReader(url)
        Dim elementos As ArrayList = New ArrayList

        Try


            Do While (reader.Read())
                Select Case reader.NodeType
                    Case XmlNodeType.Element
                        If reader.Name = "logradouro" Then
                            leLog = 1
                        End If
                        If reader.Name = "bairro" Then
                            leBai = 1
                        End If
                        If reader.Name = "cep" Then
                            leCEP = 1
                        End If
                        If reader.Name = "gia" Then
                            leGui = 1
                        End If

                    Case XmlNodeType.Text
                        If leCEP = 1 Then
                            CEP = reader.Value
                            leCEP = 0
                        End If
                        If leLog = 1 Then
                            Logradouro = reader.Value
                            Logradouro = VerificaTexto(UCase(Logradouro))

                            leLog = 0
                            If UCase(Logradouro) = UCase(Logra) Then
                                If IDRua = 0 Then
                                    strSql = "Select IDRua, Logradouro From tblRuas WHERE (Logradouro = '" & UCase(Logradouro) & "')"
                                    IDRua = NuloInteger(PegaValorCampo("IDRua", strSql, strCon))
                                    If IDRua = 0 Then
                                        strSql = "INSERT tblRuas "
                                        strSql += "(Logradouro, Bairro, Cidade, Estado, Area) VALUES ('','','','','')"
                                        ExecutaStr(strSql)
                                        IDRua = NuloInteger(PegaValorCampo("ID", "Select MAX(IDRua) As ID From tblRuas WITH (TABLOCKX)", strCon))
                                    End If
                                End If

                                strSql = "Select IDRua, CEP From tblRuasCEP WHERE (CEP = '" & NuloString(Replace(CEP, "-", "")) & "')"
                                IDCep = NuloInteger(PegaValorCampo("IDRua", strSql, strCon))
                                If IDCep = 0 Then
                                    strSql = "INSERT tblRuasCep "
                                    strSql += "(IDRua,CEP) VALUES ("
                                    strSql += to_sql(NuloInteger(IDRua)) & ","
                                    strSql += to_sql(NuloString(Replace(CEP, "-", ""))) & ")"
                                    ExecutaStr(strSql)
                                End If
                            End If
                        End If
                        If leBai = 1 Then
                            Bairro = reader.Value
                            leBai = 0
                        End If

                        If leGui = 1 Then
                            strSql = "UPDATE tblRuas SET "
                            strSql &= "Logradouro='" & VerificaTexto(UCase(NuloString(Logradouro))) & "',"
                            strSql &= "Atualiza=1,"
                            strSql &= "Bairro='" & VerificaTexto(UCase(NuloString(Bairro))) & "',"
                            strSql &= "Cidade='" & UCase(NuloString(tbCidade.Text)) & "',"
                            strSql &= "Estado='" & UCase(NuloString(tbEstado.Text)) & "' "
                            strSql &= "WHERE (IDRua=" & IDRua & ")"
                            ExecutaStr(strSql)
                            leGui = 0
                            IDRua = 0
                        End If
                End Select
            Loop
            Me.Dispose()
            Me.Close()

        Catch ex As Exception
            If QtdConsulta > 0 Then
                System.Threading.Thread.Sleep(1000)
                QtdConsulta -= 1
                GoTo VoltaConsulta
            Else
                MessageBox.Show(ex.Message, "Erro")
            End If
        End Try
    End Sub
    Private Sub BuscaCEP()

        Dim totalCEP As Integer = 0
        Dim IDLog As Integer = 0
        Dim itemRua As ListViewItem
        Dim RuaAtu As String = ""
        Dim url As String

        Dim Bairro As String = ""
        Dim Logradouro As String = ""
        Dim Complemento As String = ""
        Dim CEP As String = ""
        Dim QtdConsulta As Integer = 10

        Label2.Visible = False
        lbTotalCEP.Visible = False

        tbEstado.Text = VerificaTexto(UCase(tbEstado.Text))
        tbCidade.Text = VerificaTexto(UCase(tbCidade.Text))
        tbLogradouro.Text = VerificaTexto(UCase(tbLogradouro.Text))

VoltaConsulta:

        lstRuas.Items.Clear()
        url = "https://viacep.com.br/ws/" & tbEstado.Text & "/" & tbCidade.Text & "/" & tbLogradouro.Text & "/xml/"




        Try
            Dim leCEP As Integer = 0
            Dim leLog As Integer = 0
            Dim leBai As Integer = 0
            Dim leCom As Integer = 0
            Dim leGui As Integer = 0
            Dim reader As XmlTextReader = New XmlTextReader(url)
            Dim elementos As ArrayList = New ArrayList
            Do While (reader.Read())

                Select Case reader.NodeType

                    Case XmlNodeType.Element
                        If reader.Name = "endereco" Then
                            IDLog += 1
                        End If
                        If reader.Name = "logradouro" Then
                            leLog = 1
                        End If
                        If reader.Name = "bairro" Then
                            leBai = 1
                        End If
                        If reader.Name = "complemento" Then
                            leCom = 1
                        End If
                        If reader.Name = "cep" Then
                            leCEP = 1
                        End If
                        If reader.Name = "gia" Then
                            leGui = 1
                        End If

                    Case XmlNodeType.Text
                        If leCEP = 1 Then
                            CEP = reader.Value
                            totalCEP += 1
                            leCEP = 0
                        End If
                        If leCom = 1 Then
                            If leCom = 1 And leBai = 1 Then
                                Complemento = ""
                            Else
                                Complemento = reader.Value
                            End If
                            leCom = 0
                        End If
                        If leLog = 1 Then
                            Logradouro = reader.Value
                            leLog = 0
                        End If
                        If leBai = 1 Then
                            Bairro = reader.Value
                            leBai = 0
                        End If

                        If leGui = 1 Then
                            itemRua = lstRuas.Items.Add(IDLog)
                            itemRua.SubItems.Add(VerificaTexto(UCase(Logradouro)))
                            itemRua.SubItems.Add(VerificaTexto(UCase(Complemento)))
                            itemRua.SubItems.Add(Bairro)
                            itemRua.SubItems.Add(CEP)
                            leGui = 0
                        End If
                End Select
            Loop

            Label2.Visible = True
            lbTotalCEP.Visible = True
            lbTotalCEP.Text = "Total  " & totalCEP

            'MsgBox(QtdConsulta)

        Catch ex As Exception
            'If QtdConsulta > 0 Then
            'System.Threading.Thread.Sleep(1000)
            'QtdConsulta -= 1
            'GoTo VoltaConsulta
            'Else
            MessageBox.Show(ex.Message, "Erro")
            'End If
        End Try
    End Sub
    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub fdlgConsultaCEP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbCidade.Text = CidadeLoja
        tbEstado.Text = EstadoLoja
        Label2.Visible = False
        tbLogradouro.Focus()
        If NuloString(tbLogradouro.Text) <> "" Then
            BuscaCEP()
        End If

    End Sub

    Private Sub btnConsulta_Click(sender As Object, e As EventArgs) Handles btnConsulta.Click
        BuscaCEP()
    End Sub

    Private Sub btnCadastrar_Click(sender As Object, e As EventArgs) Handles btnCadastrar.Click


        CadastraRuaWeb(tbEstado.Text, tbCidade.Text, tbLogradouro.Text)


    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub lstRuas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRuas.SelectedIndexChanged

    End Sub

    Private Sub lstRuas_Click(sender As Object, e As EventArgs) Handles lstRuas.Click
        If lstRuas.SelectedItems.Count > 0 Then
            tbLogradouro.Text = lstRuas.SelectedItems(0).SubItems(1).Text
            tbBairro.Text = lstRuas.SelectedItems(0).SubItems(3).Text
        End If
    End Sub

    Private Sub BtnAtualiza_Click(sender As Object, e As EventArgs) Handles btnAtualiza.Click

        If lstRuas.SelectedItems.Count > 0 Then
            fdlgAtualizaCadastroRua.ShowDialog()
        Else
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário setecionar um logradouro"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        End If

    End Sub
End Class