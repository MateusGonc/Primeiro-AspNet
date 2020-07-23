using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaGame.Entities;
using BibliotecaGame.BLL.Autenticacao;
using System.Web.Security;

namespace BibliotecaGame.Site.Jogos
    
{
    public partial class Catalogo : System.Web.UI.Page
    {
        private JogosBo _jogosBo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarJogosRepeater();
                Deslogar();
            }

        }

        private void CarregarJogosRepeater()
        {
            _jogosBo = new JogosBo();
            RepeaterJogos.DataSource = _jogosBo.ObterTodosJogos();
            RepeaterJogos.DataBind();
        }

        private void Deslogar()
        {
            if (!string.IsNullOrEmpty(Page.Request.QueryString["logout"]))
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                Response.Redirect("/Autenticacao/Login.aspx"); 
            }
        }
    }
}