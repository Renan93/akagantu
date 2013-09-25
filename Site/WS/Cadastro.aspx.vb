
Partial Class Cadastro
    Inherits System.Web.UI.Page
    Dim ws As New BDUtils
    Dim idEscola As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If cmbEscola.Items.Count > 1 Then
            '  cmbEscola.Items.Clear()
        End If
        For Each escola In ws.listaEscola
            cmbEscola.Items.Add(escola)
        Next
    End Sub

    Protected Sub btnCadastrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCadastrar.Click
        Dim sexo As Boolean
        ' Dim idEscola As Integer
        If rdbSexo.SelectedValue.ToString = "Masculino" Then
            sexo = True
        Else
            sexo = False
        End If
        idEscola = ws.getEscolaID(cmbEscola.SelectedValue.ToString)
        If txtNome.Text <> "" And txtEmail.Text <> "" And txtIdade.Text <> "" And txtLogin.Text <> "" And txtSenha.Text <> "" And txtSerie.Text <> "" And cmbEscola.SelectedItem.ToString <> "" And rdbSexo.SelectedValue.ToString <> "" Then

            If ws.cadastraAluno(txtNome.Text, txtLogin.Text, txtSenha.Text, txtEmail.Text, txtIdade.Text, sexo, txtSerie.Text, idEscola) Then
                Response.Redirect("CadastroOk.aspx")

            End If
        End If
    End Sub

    Protected Sub cmbEscola_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEscola.SelectedIndexChanged
        '  idEscola = ws.getEscolaID(cmbEscola.SelectedValue.ToString)
        ' MsgBox(cmbEscola.Text)
    End Sub
End Class
