
Partial Class WS_Cadastro
    Inherits System.Web.UI.Page
    Private ws As New BDUtils

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ws.cadastracontasadm("12", "123")

    End Sub
End Class
