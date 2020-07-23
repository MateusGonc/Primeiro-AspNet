<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BibliotecaGame.Site.Autenticacao.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
        
        <div>Usuário:</div>
        <div><asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox></div>
        <br />
        <div>Senha:</div>
        <div><asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox></div>
        <br />
        <asp:Label runat="server" ID="lblStatus"></asp:Label>
        <div><asp:Button ID="btnLogin" Text="Entrar" runat="server" OnClick="btnLogin_Click" /></div>

        </div>
    </form>
</body>
</html>
