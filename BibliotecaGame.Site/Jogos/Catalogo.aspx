<%@ Page Title="" Language="C#" MasterPageFile="~/Jogos/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="BibliotecaGame.Site.Jogos.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/Jogos/catalogo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 style="text-align:center; margin-top:30px;">Catalogo de Jogos</h2>
    <hr />

    <asp:Repeater ID="RepeaterJogos" runat="server">
        <ItemTemplate>
            <div class="jogo" onclick="RedirecionarParaPaginaJogo('<%= Session["Perfil"].ToString() %>', <%# DataBinder.Eval(Container.DataItem, "Id") %>)">
                <div class="capa-jogo" style="margin: 0px 0px 0px 30px">
                    <img class="capa-jogo-img" src="../Content/Imagens/<%# DataBinder.Eval(Container.DataItem, "Imagem") %>" alt="<%# DataBinder.Eval(Container.DataItem, "Titulo") %>" />
                </div>
                <div class="nome-jogo">
                    <%# DataBinder.Eval(Container.DataItem, "Titulo") %>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    
    <script>
        function RedirecionarParaPaginaJogo(perfil, id) {
            if (perfil === "A") {
                top.location.href = "CadastroEdicaoJogo.aspx?id=" + id;
            } else {
                top.location.href = "DetalheJogo.aspx?id=" + id;
            }
        }
    </script>

</asp:Content>
