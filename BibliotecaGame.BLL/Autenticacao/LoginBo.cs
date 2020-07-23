using BibliotecaGame.BLL.Exceptions;
using BibliotecaGame.Entities;
using BibliotecaGames.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGame.BLL.Autenticacao
{
    public class LoginBo
    {
        private UsuarioDao _usuarioDao;
        public Usuario ObterUsuarioParaLogar(string nomeUsuario, string senha)
        {
            _usuarioDao = new UsuarioDao(); 
            var usuario = _usuarioDao.ObterUsuarioPeloUsuarioeSenha(nomeUsuario, senha);
            if (usuario == null)
            {
                throw new UsuarioNaoCadastradoException();
            }
            else
            {
                return usuario;
            }

        }
    }
}
