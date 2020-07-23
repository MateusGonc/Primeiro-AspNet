using BibliotecaGame.BLL;
using BibliotecaGame.BLL.Autenticacao;
using BibliotecaGame.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaGame.Site.Content.Jogos
{
    public partial class CadastroEdicaoJogo : System.Web.UI.Page
    {
        private GeneroBo _generoBo;
        private EditorBo _editorBo;
        private JogosBo _jogoBo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarEditoresCombo();
                CarregarGenerosCombo();

                if (ModoEdicao())
                {
                    CarregarDadosEdicao();
                }
            }
        }
        protected void btnGravar_Click(object sender, EventArgs e)
        {
            _jogoBo = new JogosBo();

            var jogo = ObterModeloPreenchido();

            try
            {
                jogo.Imagem = GravarImagemDisco();
            }
            catch
            {
                lblMensagem.Text = "Ocorreu um erro ao Salvar a Imagem.";
            }

            try
            {
                var MensagemSucesso = "";

                if (ModoEdicao())
                {
                    jogo.Id = ObterIdJogo();
                    _jogoBo.AlterarJogo(jogo);
                    MensagemSucesso = "Jogo Alterado com Sucesso.";
                }
                else
                {
                    _jogoBo.InserirNovoJogo(jogo);
                    MensagemSucesso = "Jogo Cadastrado com Sucesso.";
                }
                lblMensagem.ForeColor = System.Drawing.Color.Green;
                lblMensagem.Text = MensagemSucesso;
                btnGravar.Enabled = false;
            }
            catch(Exception ex)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Ocorreu um erro ao Gravar o Jogo.";
            }
            
        }
        private string GravarImagemDisco()
        {
            if (FileUploadImage.HasFile)
            {
                try
                {
                    var caminho = $"{AppDomain.CurrentDomain.BaseDirectory}Content\\Imagens\\";
                    var fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}{FileUploadImage.FileName}";
                    FileUploadImage.SaveAs($"{caminho}{fileName}");
                    return fileName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return null;
            }
        }
        private void CarregarEditoresCombo()
        {
            _editorBo = new EditorBo();
            var editores = _editorBo.ObterTodosEditores();

            DdlEditor.DataSource = editores;
            DdlEditor.DataBind();
        }
        private void CarregarGenerosCombo()
        {
            _generoBo = new GeneroBo();
            var generos = _generoBo.ObterTodosGeneros();

            DdlGenero.DataSource = generos;
            DdlGenero.DataBind();

        }
        public void CarregarDadosEdicao()
        {
            _jogoBo = new JogosBo();

            var id = ObterIdJogo();

            var jogo = _jogoBo.ObterJogo(id);

            txtTitulo.Text = jogo.Titulo;
            txtValorPago.Text = jogo.ValorPago.ToString();
            txtDataCompra.Text = jogo.DataCompra.HasValue ? jogo.DataCompra.Value.ToString("yyyy-MM-dd") : string.Empty;
            DdlEditor.SelectedValue = jogo.idEditor.ToString();
            DdlGenero.SelectedValue = jogo.idGenero.ToString();



        }
        public int ObterIdJogo()
        {
            var id = 0;
            var idQueryString = Request.QueryString["id"];
            if (int.TryParse(idQueryString, out id))
            {
                if (id <= 0)
                {
                    throw new Exception("ID inválido!");
                }
                return id;
            }
            else
            {
                throw new Exception("ID inválido!");
            }
        }
        public bool ModoEdicao()
        {
            return Request.QueryString.AllKeys.Contains("id");

        }
        public Jogo ObterModeloPreenchido()
        {
            var jogo = new Jogo();

            jogo.Titulo = txtTitulo.Text;
            jogo.ValorPago = string.IsNullOrWhiteSpace(txtValorPago.Text) ? (double?)null : Convert.ToDouble(txtValorPago.Text);
            jogo.DataCompra = string.IsNullOrWhiteSpace(txtDataCompra.Text) ? (DateTime?)null : Convert.ToDateTime(txtDataCompra.Text);

            jogo.idEditor = Convert.ToInt32(DdlEditor.SelectedValue);
            jogo.idGenero = Convert.ToInt32(DdlGenero.SelectedValue);

            return jogo;
        }

    }
}