Imports System.Data.SqlClient
Imports System.IO

Public Class fdlgPendencias_LanctoInclusao
    Public Sub CriaPendenciaRecibo(Tipo As String, TipoPagto As String, Cliente As String, FormaPagto As String, Telefone As String, Valor As Decimal, Caixa As String)

        Dim lngFile As Integer = FreeFile()
        Dim texto As String


        Try
            FileClose(lngFile)
            FileOpen(lngFile, Application.StartupPath & "\Impressao\recibo.txt", OpenMode.Output)

1:
            PrintLine(lngFile, "                RECIBO PENDENCIA")
            PrintLine(lngFile, "=================================================")
            PrintLine(lngFile, "Tipo      :  " & Tipo)
            If TipoPagto = "V" Then
                PrintLine(lngFile, "Vinculado :  " & Caixa)
            Else
                PrintLine(lngFile, "Data      :  " & Now)
            End If
            PrintLine(lngFile, " ")
            PrintLine(lngFile, "Cliente   :  " & Cliente)
            If Telefone <> "" Then
                PrintLine(lngFile, "Telefone  :  " & Telefone)
            End If
            PrintLine(lngFile, "Pagamento :  " & FormaPagto)
            PrintLine(lngFile, "Valor     :  " & Valor.ToString("#0.00"))
            PrintLine(lngFile, "==================================================")

            If GuilhotinaImpCaixa = False Then
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
            End If
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")

            FileClose(lngFile)


        Catch ex As Exception
            If InStr(1, ex.Message, "localizar") > 0 Then
                Dim fs As FileStream = File.Create(Application.StartupPath & "\Impressao\recibo.txt")
                fs.Close()
                GoTo 1
            Else
                MsgBox(ex.Message)
            End If

        End Try


    End Sub
    Private Sub PreencheFormaPagto()

        strSql = "Select IDFormaPagto, Descricao "
        strSql += "From tblFormaPagtos_Local "
        strSql += "Order By Descricao"

        cbFormaPagto.Items.Clear()

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            cbFormaPagto.Items.Add("")
            While (dr.Read)
                cbFormaPagto.Items.Add(dr.Item("Descricao") & Space(150) & dr.Item("IDFormaPagto"))
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()
    End Sub
    Private Sub PreencheMovto()

        strSql = "Select IDFechamento, IDFuncionario, Caixa, DiaMovimento, DataAbertura, DataFechamento, Turno, Confirmado, FundoCaixa, SaldoCaixa, Transferido "
        strSql += "From tblFechamentos_Local "
        strSql += "Where (Confirmado = 0) "
        strSql += "Order By IDFechamento, Turno"

        cbMovto.Items.Clear()

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            cbMovto.Items.Add("")
            While (dr.Read)
                cbMovto.Items.Add(dr.Item("Turno") & " (" & dr.Item("DiaMovimento") & ") - " & Strings.Left(dr.Item("Caixa"), 20) & Space(100) & dr.Item("IDFechamento"))
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()
    End Sub
    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        tbValor.Text &= "1"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        tbValor.Text &= "2"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        tbValor.Text &= "3"
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        tbValor.Text &= "4"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        tbValor.Text &= "5"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        tbValor.Text &= "6"
    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        tbValor.Text &= "7"
    End Sub

    Private Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click
        tbValor.Text &= "8"
    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        tbValor.Text &= "9"
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        tbValor.Text &= "0"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tbValor.Text &= ","
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tbValor.Text = ""
    End Sub

    Private Sub FdlgPendencias_LanctoInclusao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreencheFormaPagto()
        PreencheMovto()
        cbTipo.Items.Add("")
        cbTipo.Items.Add("(+) INCLUI CRÉDITO")
        cbTipo.Items.Add("(+) PAGAMENTO")
        cbTipo.Items.Add("(-) INCLUI DÉBITO")
        dtData.Value = Now
        chkMovtoCaixa.Checked = True
    End Sub

    Private Sub BtnRelatorios_Click(sender As Object, e As EventArgs) Handles btnRelatorios.Click

        If chkMovtoCaixa.Checked = True Then
            If cbMovto.Text = "" Then
                Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                frm1.lbMensagem.Text = "É necessário selecionar um movimento"
                frm1.btnNao.Visible = False
                frm1.btnSim.Visible = False
                frm1.btnOK.Visible = True
                frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm1.ShowDialog()
                Exit Sub
            End If
        End If

        If cbFormaPagto.Text = "" Then
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "É necessário selecionar uma forma de pagamento"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm1.ShowDialog()
            Exit Sub
        End If

        If cbTipo.Text = "" Then
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "É necessário selecionar um tipo de lançamento"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm1.ShowDialog()
            Exit Sub
        End If

        If NuloDecimal(tbValor.Text) = 0 Then
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "Valor inválido"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm1.ShowDialog()
            Exit Sub
        End If


        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        frm.lbMensagem.Text = "Confirma a inclusão deste lançamento"
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm.ShowDialog()
        If RetornoMsg = False Then Exit Sub

        Dim IDfec As Integer = NuloInteger(Trim(Strings.Right(cbMovto.Text, 10)))
        Dim IDpagto As Integer = NuloInteger(Trim(Strings.Right(cbFormaPagto.Text, 10)))
        Dim IDpen As Integer
        Dim IDvdaPagto As Integer = 0
        Dim Descricao As String = ""
        Dim Saldo As Decimal = SaldoPendencia(NuloInteger(frmPendencias.tbIDCliente.Text))
        Dim vlrLanc As Decimal = NuloDecimal(tbValor.Text)
        Dim Vinculado As Boolean = False

        Dim Tipo As String, TipoPagto As String, Movto As String

        '"(+) INCLUI CRÉDITO"
        '"(+) PAGAMENTO"
        '"(-) INCLUI DÉBITO"
        If cbTipo.Text = "(+) INCLUI CRÉDITO" Then
            Tipo = "INCLUSAO DE CREDITO"
            If chkMovtoCaixa.Checked = False Then
                Descricao = "CREDITO NAO VINCULADO"
                Vinculado = False
                TipoPagto = "N"
                Movto = ""
            Else
                Descricao = "CREDITO VINCULADO "
                Vinculado = True
                TipoPagto = "V"
                Movto = cbMovto.Text
            End If
        End If
        If cbTipo.Text = "(+) PAGAMENTO" Then
            Tipo = "PAGAMENTO"
            If chkMovtoCaixa.Checked = False Then
                Descricao = "PAGTO NAO VINCULADO"
                Vinculado = False
                TipoPagto = "N"
                Movto = ""
            Else
                Descricao = "PAGTO VINCULADO "
                Vinculado = True
                TipoPagto = "V"
                Movto = cbMovto.Text
            End If
        End If
        If cbTipo.Text = "(-) INCLUI DÉBITO" Then
            Tipo = "INCLUSAO DE DEBITO"
            Descricao = "DEBITO NAO VINCULADO"
            vlrLanc = vlrLanc * -1
            Vinculado = False
            TipoPagto = "N"
            Movto = ""
        End If
        Saldo += vlrLanc

        strSql = "INSERT tblPendenciasLoja "
        strSql += "(IDLoja, IDFechamento, IDCliente, IDVendaRet, IDFormaPagto, Data, Descricao, Valor, Saldo, Lancado) VALUES ("
        strSql += to_sql(IDLoja) & ","
        strSql += to_sql(IDfec) & ","
        strSql += to_sql(NuloInteger(frmPendencias.tbIDCliente.Text)) & ","
        If Vinculado = False Then
            strSql += "0,"
        Else
            strSql += to_sql(NuloInteger(frmPendencias.tbIDVendaRet.Text)) & ","
        End If
        strSql += to_sql(IDpagto) & ","
        strSql += to_sqlDATA(dtData.Value, "data", "L") & ", "
        strSql += "'" & Descricao & "',"
        strSql += Replace(vlrLanc.ToString, ",", ".") & ","
        strSql += Replace(Saldo.ToString, ",", ".") & ","
        strSql += "0)"
        ExecutaStr(strSql)
        IDpen = NuloInteger(PegaID("IDPendencia", "tblPendenciasLoja", "L"))

        If RegistraLog = True Then
            strSql = "Select IDFormaPagto, Descricao "
            strSql += "From tblFormaPagtos_Local "
            strSql += "WHERE (IDFormaPagto=" & IDpagto & ")"
            IncluirLog(NomeTerminal, Operador, "PENDENCIA", "LANÇTO: " & NuloString(PegaValorCampo("Descricao", strSql, strCon)) & " - " & Descricao & " (" & NuloDecimal(vlrLanc) & ")")
        End If

        strSql = "UPDATE tblClientes SET "
        strSql += "SaldoCredito=" & NuloDecimal(Replace(NuloString(Saldo), ",", ".")) & " "
        strSql += "WHERE (IDCliente=" & NuloInteger(frmPendencias.tbIDCliente.Text) & ")"
        ExecutaStr(strSql)

        If Vinculado = True Then
            'strSql = "Select IDVenda, StatusVenda "
            'strSql += "From tblVendas "
            'strSql += "WHERE (IDFechamento=" & IDfec & ") And (StatusVenda='P')"
            'Dim IDvda As Integer = NuloInteger(PegaValorCampo("IDVenda", strSql, strCon))
            'If IDvda = 0 Then
            Dim IDvda As Integer

            strSql = "INSERT tblVendas "
            strSql &= "(IDFechamento, NumVenda,  NumMesa, DataVenda, PercDesconto, PercServico, QtdPessoas, FlagFechada, HoraAbertura, StatusVenda, Caixa, Atendente, Enviado, Excluido, IDFuncionarioAtendente, IDLoja, TotalProdutos, TotalVenda, Desconto, Servico, Caixinha, HoraFechamento) VALUES ("
            strSql &= to_sql(IDfec) & ","
            strSql &= "0,"
            strSql &= "0,"
            strSql += "'" & Date.Now & "',"
            strSql &= "0,"
            strSql &= "0,"
            strSql &= "0,"
            strSql &= "1,"
            strSql += "'" & Date.Now & "',"
            strSql &= "'P',"
            strSql &= to_sql(Caixa) & ","
            strSql &= to_sql(Operador) & ","
            strSql &= "0,"
            strSql &= "0,"
            strSql &= IDOperador & ","
            strSql &= IDLoja & ","
            strSql &= "0,"
            strSql &= "0,"
            strSql &= "0,"
            strSql &= "0,"
            strSql &= "0,"
            strSql += "'" & Date.Now & "')"
            ExecutaStr(strSql)
            IDvda = NuloInteger(PegaID("IDVenda", "tblVendas", "L"))

            'End If

            EnviaPagto(IDpagto, IDvda)
            IDvdaPagto = NuloInteger(PegaID("IDVendaPagto", "tblVendasPagto", "L"))

            strSql = "UPDATE tblPendenciasLoja SET "
            strSql += "IDVendaRet=" & IDvda & ", "
            strSql += "IDVendaRetPagto=" & IDvdaPagto & " "
            strSql += "WHERE (IDPendencia=" & IDpen & ")"
            ExecutaStr(strSql)

            If ImpRecibo = True Then
                CriaPendenciaRecibo(Tipo, TipoPagto, NuloString(frmPendencias.tbCliente.Text), NuloString(Trim(Strings.Left(cbFormaPagto.Text, 50))), NuloString(frmPendencias.tbTel1.Text), Math.Abs(NuloDecimal(tbValor.Text)), NuloString(Trim(Strings.Left(Movto, 50))))
                ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\recibo.txt")
                If GuilhotinaImpCaixa = True Then
                    ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
                End If
            End If

        End If

        Me.Dispose()
        Me.Close()

    End Sub
    Private Sub EnviaPagto(IDpag As Integer, IDvda As Integer)

        Dim con As New SqlConnection()
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        strSql = "Select IDFormaPagto, CodigoFormaPagto, CodigoFiscal, TrocoPadrao, AcionaGaveta, Descricao, IDFormaPagto, Tipo "
        strSql += "From tblFormaPagtos_Local "
        strSql += "WHERE IDFormaPagto=" & IDpag
        cmd.CommandText = strSql

        con.Open()
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            dr.Read()

            strSql = "INSERT tblVendasPagto "
            strSql += "(IDVenda,IDFormaPagto,Descricao,ValorPago,ECartao,TaxaCartao,Tipo,Cupom) VALUES ("
            strSql += to_sql(IDvda) & ","
            strSql += to_sql(dr.Item("IDFormaPagto")) & ","
            strSql += to_sql(dr.Item("Descricao")) & ","
            strSql += to_sql(Replace(Math.Abs(NuloDecimal(tbValor.Text)), ",", ".")) & ","
            strSql += "0,"
            strSql += "0,"
            If NuloString(dr.Item("Tipo")) = "V" Then
                strSql += "'D',"
            Else
                strSql += "'C',"
            End If
            strSql += "0)"
            ExecutaStr(strSql)
        End If
        dr.Close()
        cmd.Dispose()
        con.Close()


    End Sub

    Private Sub ChkMovtoCaixa_CheckedChanged(sender As Object, e As EventArgs) Handles chkMovtoCaixa.CheckedChanged
        If chkMovtoCaixa.Checked = False Then
            cbMovto.Text = ""
        End If
    End Sub
End Class