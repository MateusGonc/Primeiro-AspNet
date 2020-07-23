using BibliotecaGame.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.DAL
{
    public class EditorDao
    {
        public List<Editor> ObterTodosEditores()
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = conexao.connection;
                command.CommandText = "SELECT * FROM EDITOR ORDER BY NOME";

                conexao.conectar();

                var reader = command.ExecuteReader();

                var editores = new List<Editor>();

                while (reader.Read())
                {
                    var editor = new Editor();

                    editor.Id = Convert.ToInt32(reader["id"]);
                    editor.Nome = reader["nome"].ToString();

                    editores.Add(editor);
                }

                return editores;
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                conexao.desconectar();
            }
        }
    }
}
