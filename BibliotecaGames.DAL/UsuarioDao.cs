using BibliotecaGame.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.DAL
{
    public class UsuarioDao
    {
        public Usuario ObterUsuarioPeloUsuarioeSenha(string nomeUsuario, string senha)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = conexao.connection;
                command.CommandText = "SELECT * FROM USUARIO WHERE USUARIO = @USUARIO AND SENHA = @SENHA";

                command.Parameters.AddWithValue("@USUARIO", nomeUsuario);
                command.Parameters.AddWithValue("@SENHA", senha);

                conexao.conectar();

                var reader = command.ExecuteReader();

                Usuario usuario = null;

                while (reader.Read())
                {
                    usuario = new Usuario();

                    usuario.Id = Convert.ToInt32(reader["id"]);
                    usuario.NomeUsuario = reader["usuario"].ToString();
                    usuario.Senha = reader["senha"].ToString();
                    usuario.Perfil = Convert.ToChar(reader["perfil"]);
                }

                return usuario;
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
