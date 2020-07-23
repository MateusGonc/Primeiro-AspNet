using BibliotecaGame.Entities;
using BibliotecaGames.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGame.BLL
{
    public class EditorBo
    {
        private EditorDao _editorDao;

        public List<Editor> ObterTodosEditores()
        {
            _editorDao = new EditorDao();
            return _editorDao.ObterTodosEditores();
        }
    }
}
