Module CPF_CNPJ


    Public ChaveOK

    Public Function FU_ValidaCPF(CPF As String) As Boolean
        Dim soma As Integer
        Dim Resto As Integer
        Dim i As Integer
        'Valida argumento
        If Len(CPF) <> 11 Then
            ValidaCPF_CNPJ = False
            Exit Function
        End If
        soma = 0
        For i = 1 To 9
            soma = soma + Val(Mid$(CPF, i, 1)) * (11 - i)
        Next i
        Resto = 11 - (soma - (Int(soma / 11) * 11))

        If Resto = 10 Or Resto = 11 Then Resto = 0

        If Resto <> Val(Mid$(CPF, 10, 1)) Then
            ValidaCPF_CNPJ = False
            Exit Function
        End If
        soma = 0
        For i = 1 To 10
            soma = soma + Val(Mid$(CPF, i, 1)) * (12 - i)
        Next i
        Resto = 11 - (soma - (Int(soma / 11) * 11))

        If Resto = 10 Or Resto = 11 Then Resto = 0

        If Resto <> Val(Mid$(CPF, 11, 1)) Then
            ValidaCPF_CNPJ = False
        Else
            ValidaCPF_CNPJ = True
        End If

        Dim OK
        OK = 0
        For i = 1 To 10
            If Mid$(CPF, i, 1) <> Left([CPF], 1) Then OK = 1
        Next i
        If OK = 0 Then
            ValidaCPF_CNPJ = False
        End If



    End Function
    Public Function FU_ValidaCNPJ(CNPJ As String) As Boolean
        Dim retorno, a, j, i, d1, d2
        If Len(CNPJ) = 8 And Val(CNPJ) > 0 Then
            a = 0
            j = 0
            d1 = 0
            For i = 1 To 7
                a = Val(Mid(CNPJ, i, 1))
                If (i Mod 2) <> 0 Then
                    a = a * 2
                End If
                If a > 9 Then
                    j = j + Int(a / 10) + (a Mod 10)
                Else
                    j = j + a
                End If
            Next i
            d1 = IIf((j Mod 10) <> 0, 10 - (j Mod 10), 0)
            If d1 = Val(Mid(CNPJ, 9, 1)) Then
                ValidaCPF_CNPJ = True
            Else
                ValidaCPF_CNPJ = False
            End If
        Else
            If Len(CNPJ) = 14 And Val(CNPJ) > 0 Then
                a = 0
                i = 0
                d1 = 0
                d2 = 0
                j = 5
                For i = 1 To 12 Step 1
                    a = a + (Val(Mid(CNPJ, i, 1)) * j)
                    j = IIf(j > 2, j - 1, 9)
                Next i
                a = a Mod 11
                d1 = IIf(a > 1, 11 - a, 0)
                a = 0
                i = 0
                j = 6
                For i = 1 To 13 Step 1
                    a = a + (Val(Mid(CNPJ, i, 1)) * j)
                    j = IIf(j > 2, j - 1, 9)
                Next i
                a = a Mod 11
                d2 = IIf(a > 1, 11 - a, 0)
                If (d1 = Val(Mid(CNPJ, 13, 1)) And d2 = Val(Mid(CNPJ, 14, 1))) Then
                    ValidaCPF_CNPJ = True
                Else
                    ValidaCPF_CNPJ = False
                End If
            Else
                ValidaCPF_CNPJ = False
            End If
        End If

    End Function



End Module
