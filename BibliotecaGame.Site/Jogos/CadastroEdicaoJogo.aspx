<%@ Page Title="" Language="C#" MasterPageFile="~/Jogos/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="CadastroEdicaoJogo.aspx.cs" Inherits="BibliotecaGame.Site.Content.Jogos.CadastroEdicaoJogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 pt-5">
        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="inputTitulo">Titulo</label>
                <asp:TextBox runat="server" ID="txtTitulo" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="txtTitulo" ErrorMessage="É Necessário preencher o Título." Text="*"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group col-md-6">
                <label for="inputValor">Valor Pago</label>
                <asp:TextBox runat="server" ID="txtValorPago" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="inputGenero">Genêro</label>
                <asp:DropDownList ID="DdlGenero" runat="server" DataValueField="id" DataTextField="Descricao" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvGenero" runat="server" ControlToValidate="DdlGenero" ErrorMessage="É Necessário preencher o Gênero." Text="*"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group col-md-6">
                <label for="inputEditor">Editor</label>
                <asp:DropDownList ID="DdlEditor" runat="server" DataValueField="id" DataTextField="Nome" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvEditor" runat="server" ControlToValidate="DdlEditor" ErrorMessage="É Necessário preencher o Editor." Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="inputData">Data Compra</label>
                <asp:TextBox runat="server" ID="txtDataCompra" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-6">
                <label for="inputImagem">Imagem</label>
                <asp:FileUpload ID="FileUploadImage" runat="server" CssClass="form-control" />
            </div>
        </div>

        <asp:ValidationSummary ID="valSum"
            DisplayMode="BulletList"
            EnableClientScript="true"
            ForeColor="Red"
            HeaderText="Você precisa preencher o(s) seguinte(s) campo(s)."
            runat="server" />
        <br />

        <asp:Label runat="server" ID="lblMensagem"></asp:Label>

        <asp:Button runat="server" Text="Gravar" CssClass="btn btn-primary mt-3" ID="btnGravar" OnClick="btnGravar_Click" />

        <a href="Catalogo.aspx">Voltar ao catálogo</a>



    </div>
</asp:Content>
