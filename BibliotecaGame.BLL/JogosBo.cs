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
    public class JogosBo
    {
        private JogoDao _jogoDao;

        public List<Jogo> ObterTodosJogos()
        {
            _jogoDao = new JogoDao();
            return _jogoDao.ObterTodosJogos();
        }
        public void InserirNovoJogo(Jogo jogo)
        {
            _jogoDao = new JogoDao();

            ValidarJogo(jogo);

            var linhasAfetadas = _jogoDao.InserirJogo(jogo);

            if(linhasAfetadas == 0)
            {
                throw new JogoNaoCadastradoException();
            }
        }
        public void ValidarJogo(Jogo jogo)
        {
            if (string.IsNullOrWhiteSpace(jogo.Titulo) || jogo.idEditor == 0 || jogo.idGenero == 0)
            {
                throw new JogoInvalidoException();
            }
        }

        public Jogo ObterJogo(int id)
        {
            _jogoDao = new JogoDao();
            var jogo = _jogoDao.ObterJogo(id);

            if(jogo == null)
            {
                throw new JogoNaoCadastradoException();
            }
                return jogo;
        }
        public void AlterarJogo(Jogo jogo)
        {
            _jogoDao = new JogoDao();

            ValidarJogo(jogo);

            var linhasAfetadas = _jogoDao.AlterarJogo(jogo);

            if (linhasAfetadas == 0)
            {
                throw new JogoNaoAlteradoException();
            }
        }
    }
}
