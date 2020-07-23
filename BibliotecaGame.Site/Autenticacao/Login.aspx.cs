using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaGame.BLL.Autenticacao;
using BibliotecaGame.BLL.Exceptions;

namespace BibliotecaGame.Site.Autenticacao
{
    public partial class Login : System.Web.UI.Page
    {
        private LoginBo _loginBo;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            _loginBo = new LoginBo();

            var nomeUsuario = txtUsuario.Text;
            var senha = txtSenha.Text;

            try
            {
                var usuario = _loginBo.ObterUsuarioParaLogar(nomeUsuario, senha);
                FormsAuthentication.RedirectFromLoginPage(nomeUsuario, false);
                Session["Perfil"] = usuario.Perfil; 
            }
            catch (UsuarioNaoCadastradoException)
            {
                lblStatus.Text = "Usuário não cadastrado.";
            }
            catch (Exception)
            {
                lblStatus.Text = "Ocorreu um erro inesperado, consulte o administrador.";
            }
        }
    }
}