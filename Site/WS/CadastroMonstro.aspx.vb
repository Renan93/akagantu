
Partial Class CadastroMonstro
    Inherits System.Web.UI.Page
    Dim ws As New BDUtils
    Dim idMonstro As String

    Protected Sub btnDireito_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDireito.Click
        imgPet.ImageUrl = "images/reset.gif"
    End Sub

    Protected Sub btnEsquerdo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEsquerdo.Click
        imgPet.ImageUrl = "images/pato.png"
    End Sub

    Protected Sub btnCadPet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCadPet.Click
        Dim sexo As Boolean

        If rdbSexo0.SelectedValue.ToString = "Masculino" Then
            sexo = True
        Else
            sexo = False
        End If

        If txtNomePet.Text <> "" And rdbSexo0.SelectedValue.ToString <> "" And imgPet.ImageUrl.ToString <> "" Then

            If ws.cadastraMonstro(txtNomePet.Text, 0, 0, sexo, codImage(imgPet.ImageUrl.ToString)) Then
                MsgBox(ws.getMonstroID(txtNomePet.Text))
                If ws.cadastraCarteira(10, ws.getMonstroID(txtNomePet.Text)) Then
                    Response.Redirect("CadastroOk.aspx")
                End If

            End If
        End If
    End Sub
    Public Function codImage(ByVal img As String) As Integer
        Dim cod As Integer
        If img.Contains("pato.png") Then
            cod = 1
        End If
        If img.Contains("reset.gif") Then
            cod = 2
        End If
        Return cod
    End Function


    
End Class