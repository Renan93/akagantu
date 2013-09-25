Imports Microsoft.VisualBasic
Imports System.Data.OleDb

Public Class BDUtils
    Dim myConn As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Rodrigo\Desktop\Children_Place\Banco.mdb")
    Public Function cadastraAluno(ByVal nome As String, ByVal login As String, ByVal senha As String, ByVal email As String, ByVal idade As Integer, ByVal sexo As Boolean, ByVal serie As String, ByVal escola As Integer) As Boolean
        If verificarBanco(login, email) Then
            Dim MySQL As String = "Insert into Aluno (nome, login, senha, email, idade, sexo,tipoconta, idescola,serie) values (@nome, @login, @senha, @email, @idade, @sexo,@tipoconta, @idescola, @serie)"

            Dim Cmd As New OleDbCommand(MySQL, myConn)

            Cmd.Parameters.Add(New OleDbParameter("@nome", nome))
            Cmd.Parameters.Add(New OleDbParameter("@login", login))
            Cmd.Parameters.Add(New OleDbParameter("@senha", senha))
            Cmd.Parameters.Add(New OleDbParameter("@email", email))
            Cmd.Parameters.Add(New OleDbParameter("@idade", idade))
            Cmd.Parameters.Add(New OleDbParameter("@sexo", sexo))
            Cmd.Parameters.Add(New OleDbParameter("@tipoconta", 1))
            Cmd.Parameters.Add(New OleDbParameter("@idescola", escola))
            Cmd.Parameters.Add(New OleDbParameter("@serie", serie))

            myConn.Open()

            Cmd.ExecuteNonQuery()

            myConn.Close()
            Return True
        Else
            Return False
        End If
    End Function
    Public Function cadastraEscola(ByVal nomefantasia As String, ByVal login As String, ByVal senha As String, ByVal email As String, ByVal cnpj As String, ByVal endereco As String, ByVal nomecontato As String, ByVal nomeempresa As String, ByVal tipoconta As Integer, ByVal telefone As String, ByVal tipoescola As Boolean) As Boolean
        If verificarCNPJ(cnpj) Then
            Dim MySQL As String = "Insert into Escola (nomefantasia, login, senha, email, cnpj, endereco, tipoconta, nomecontato, nomeempresa, telefone, tipoescola) values (@nomefantasia, @login, @senha, @email, @cnpj, @endereco, @tipoconta, @nomecontato, @nomeempresa, @telefone, @tipoescola)"

            Dim Cmd As New OleDbCommand(MySQL, myConn)

            Cmd.Parameters.Add(New OleDbParameter("@nomefantasia", nomefantasia))
            Cmd.Parameters.Add(New OleDbParameter("@login", login))
            Cmd.Parameters.Add(New OleDbParameter("@senha", senha))
            Cmd.Parameters.Add(New OleDbParameter("@email", email))
            Cmd.Parameters.Add(New OleDbParameter("@cnpj", cnpj))
            Cmd.Parameters.Add(New OleDbParameter("@endereco", endereco))
            Cmd.Parameters.Add(New OleDbParameter("@tipoconta", 2))
            Cmd.Parameters.Add(New OleDbParameter("@nomecontato", nomecontato))
            Cmd.Parameters.Add(New OleDbParameter("@nomeempresa", nomeempresa))
            Cmd.Parameters.Add(New OleDbParameter("@telefone", telefone))
            Cmd.Parameters.Add(New OleDbParameter("@tipoescola", tipoescola))
            myConn.Open()

            Cmd.ExecuteNonQuery()

            myConn.Close()
            Return True
        Else
            Return False
        End If
    End Function
    Public Function verificarBanco(ByVal login As String, ByVal email As String) As Boolean
        Dim MySQL As String = "Select COUNT(*) from Aluno Where login='" & login & "' AND email='" & email & "'"
        Dim numLinhas As Integer
        Dim Cmd As New OleDbCommand(MySQL, myConn)
        myConn.Open()
        numLinhas = Cmd.ExecuteScalar
        If numLinhas <= 0 Then

            myConn.Close()
            Return True
        Else
            myConn.Close()
            Return False
        End If
    End Function
    Public Function cadastraMonstro(ByVal nomemonstro As String, ByVal Aluno As Integer, ByVal Escola As Integer, ByVal Sexo As Boolean, ByVal IdFigura As Integer) As Boolean
        If verificarnomemonstro(nomemonstro) Then
            Dim MySQL As String = "Insert into Monstro (nomemonstro, idaluno, idescola, sexo, nivel, experiencia, IdFigura) values (@nomemonstro, @idaluno, @idescola, @sexo, @nivel, @experiencia, @IdFigura)"

            Dim Cmd As New OleDbCommand(MySQL, myConn)

            Cmd.Parameters.Add(New OleDbParameter("@nomemonstro", nomemonstro))
            Cmd.Parameters.Add(New OleDbParameter("@idaluno", Aluno))
            Cmd.Parameters.Add(New OleDbParameter("@idescola", Escola))
            Cmd.Parameters.Add(New OleDbParameter("@sexo", Sexo))
            Cmd.Parameters.Add(New OleDbParameter("@nivel", 0))
            Cmd.Parameters.Add(New OleDbParameter("@experiencia", 0))
            Cmd.Parameters.Add(New OleDbParameter("@IdFigura", IdFigura))

            myConn.Open()

            Cmd.ExecuteNonQuery()

            myConn.Close()
            Return True
        Else
            Return False
        End If
    End Function
    Public Function cadastraCarteira(ByVal idaluno As Integer, ByVal Monstro As Integer) As Boolean
        If verificarcarteira(idaluno) Then
            Dim MySQL As String = "Insert into Carteira ( idaluno, idmonstro, pontos) values (@idaluno, @idmonstro, @pontos)"

            Dim Cmd As New OleDbCommand(MySQL, myConn)


            Cmd.Parameters.Add(New OleDbParameter("@idaluno", idaluno))
            Cmd.Parameters.Add(New OleDbParameter("@idmonstro", Monstro))
            Cmd.Parameters.Add(New OleDbParameter("@pontos", 0))



            myConn.Open()

            Cmd.ExecuteNonQuery()

            myConn.Close()
            Return True
        Else
            Return False
        End If
    End Function
    Public Function cadastracontasadm(ByVal login As String, ByVal senha As String) As Boolean
        If verificarlogin(login) Then
            Dim MySQL As String = "Insert into ContasADM ( login, senha) values (@login, @senha)"

            Dim Cmd As New OleDbCommand(MySQL, myConn)


            Cmd.Parameters.Add(New OleDbParameter("@login", login))
            Cmd.Parameters.Add(New OleDbParameter("@senha", senha))

            myConn.Open()

            Cmd.ExecuteNonQuery()

            myConn.Close()
            Return True
        Else
            Return False
        End If
    End Function
    Public Function verificarcarteira(ByVal idaluno As String) As Boolean
        Dim MySQL As String = "Select COUNT(*) from Carteira Where idaluno=" & idaluno & ""
        Dim numLinhas As Integer
        Dim Cmd As New OleDbCommand(MySQL, myConn)
        myConn.Open()
        numLinhas = Cmd.ExecuteScalar
        If numLinhas <= 0 Then

            myConn.Close()
            Return True
        Else
            myConn.Close()
            Return False
        End If
    End Function
    Public Function verificarnomemonstro(ByVal nomemonstro As String) As Boolean
        Dim MySQL As String = "Select COUNT(*) from Monstro Where nomemonstro='" & nomemonstro & "'"
        Dim numLinhas As Integer
        Dim Cmd As New OleDbCommand(MySQL, myConn)
        myConn.Open()
        numLinhas = Cmd.ExecuteScalar
        If numLinhas <= 0 Then

            myConn.Close()
            Return True
        Else
            myConn.Close()
            Return False
        End If
    End Function
    Public Function verificarCnpj(ByVal cnpj As String) As Boolean
        Dim MySQL As String = "Select COUNT(*) from cnpj Where cnpj='" & cnpj & "'"
        Dim numLinhas As Integer
        Dim Cmd As New OleDbCommand(MySQL, myConn)
        myConn.Open()
        numLinhas = Cmd.ExecuteScalar
        If numLinhas <= 0 Then

            myConn.Close()
            Return True
        Else
            myConn.Close()
            Return False
        End If
    End Function

    Public Function verificarlogin(ByVal login As String) As Boolean
        Dim MySQL As String = "Select COUNT(*) from ContasADM Where login='" & login & "'"
        Dim numLinhas As Integer
        Dim Cmd As New OleDbCommand(MySQL, myConn)
        myConn.Open()
        numLinhas = Cmd.ExecuteScalar
        If numLinhas <= 0 Then

            myConn.Close()
            Return True
        Else
            myConn.Close()
            Return False
        End If
    End Function
    Public Function listaEscola() As List(Of String)
        Dim escola As New List(Of String)
        Dim MySQL As String = "Select NomeFantasia from Escola"
        Dim Cmd As New OleDbCommand(MySQL, myConn)
        myConn.Open()
        Dim reader As OleDbDataReader
        reader = Cmd.ExecuteReader
        While reader.Read()
            escola.Add(reader.GetValue(0))
        End While
        reader.Close()
        myConn.Close()
        Return escola
    End Function
    Public Function getEscolaID(ByVal escola As String) As Integer
        Dim id As Integer
        Dim MySQL As String = "Select ID from Escola where NomeFantasia='" & escola & "'"
        Dim Cmd As New OleDbCommand(MySQL, myConn)
        myConn.Open()
        Dim reader As OleDbDataReader
        reader = Cmd.ExecuteReader
        While reader.Read()

            id = reader.GetValue(0)
        End While
        reader.Close()
        myConn.Close()
        Return id
    End Function

    Public Function getMonstroID(ByVal monstro As String) As Integer
        Dim id As Integer
        Dim MySQL As String = "Select ID from Monstro where NomeMonstro='" & monstro & "'"
        Dim Cmd As New OleDbCommand(MySQL, myConn)
        myConn.Open()
        Dim reader As OleDbDataReader
        reader = Cmd.ExecuteReader
        While reader.Read()
            id = reader.GetValue(0)
        End While
        reader.Close()
        myConn.Close()
        Return id
    End Function

End Class

