using BibliotecaGame.Entities;
using BibliotecaGames.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGame.BLL
{
    public class GeneroBo
    {        
            private GeneroDao _generoDao;

            public List<Genero> ObterTodosGeneros()
            {
                _generoDao = new GeneroDao();
                return _generoDao.ObterTodosGeneros();
            }
    }
}
