using BibliotecaGame.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.DAL
{
    public class JogoDao
    {
        public List<Jogo> ObterTodosJogos()
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = conexao.connection;
                command.CommandText = "SELECT * FROM JOGO";

                conexao.conectar();

                var reader = command.ExecuteReader();

                var jogos = new List<Jogo>();

                while (reader.Read())
                {
                    var jogo = new Jogo();

                    jogo.Id = Convert.ToInt32(reader["id"]);
                    jogo.Imagem = reader["imagem"].ToString();
                    jogo.DataCompra = reader["dataCompra"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["dataCompra"]);
                    jogo.Titulo = reader["titulo"].ToString();
                    jogo.ValorPago = reader["valorPago"] == DBNull.Value ? (Double?)null : Convert.ToDouble(reader["valorPago"]);

                    jogos.Add(jogo);
                }

                return jogos;
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

        public int InserirJogo(Jogo jogo)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = conexao.connection;
                command.CommandText = "INSERT INTO JOGO (titulo, valorPago, dataCompra, id_editor, id_genero, imagem) values (@titulo, @valorPago, @dataCompra, @id_editor, @id_genero, @imagem)";
                command.Parameters.AddWithValue("@titulo", jogo.Titulo);
                command.Parameters.AddWithValue("@valorPago", jogo.ValorPago);
                command.Parameters.AddWithValue("@dataCompra", jogo.DataCompra);
                command.Parameters.AddWithValue("@id_editor", jogo.idEditor);
                command.Parameters.AddWithValue("@id_genero", jogo.idGenero);
                command.Parameters.AddWithValue("@Imagem", jogo.Imagem);
                conexao.conectar();

                return command.ExecuteNonQuery();
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

        public Jogo ObterJogo(int id)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = conexao.connection;
                command.CommandText = "SELECT * FROM JOGO WHERE id = @id";

                command.Parameters.AddWithValue("@id", id);

                conexao.conectar();

                var reader = command.ExecuteReader();

                Jogo jogo = null;

                while (reader.Read())
                {
                    jogo = new Jogo();

                    jogo.Id = Convert.ToInt32(reader["id"]);
                    jogo.Imagem = reader["imagem"].ToString();
                    jogo.DataCompra = reader["dataCompra"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["dataCompra"]);
                    jogo.Titulo = reader["titulo"].ToString();
                    jogo.ValorPago = reader["valorPago"] == DBNull.Value ? (Double?)null : Convert.ToDouble(reader["valorPago"]);
                    jogo.idEditor = Convert.ToInt32(reader["id_editor"]);
                    jogo.idGenero = Convert.ToInt32(reader["id_genero"]);
                }
                return jogo;
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

        public int AlterarJogo(Jogo jogo)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = conexao.connection;
                command.CommandText = "update jogo set titulo = @titulo, valorPago = @valorPago, dataCompra = @dataCompra, id_editor = @id_editor, id_genero = @id_genero where id = @id;";
                command.Parameters.AddWithValue("@titulo", jogo.Titulo);
                command.Parameters.AddWithValue("@valorPago", jogo.ValorPago);
                command.Parameters.AddWithValue("@dataCompra", jogo.DataCompra);
                command.Parameters.AddWithValue("@id_editor", jogo.idEditor);
                command.Parameters.AddWithValue("@id_genero", jogo.idGenero);
                command.Parameters.AddWithValue("@id", jogo.Id);
                conexao.conectar();

                return command.ExecuteNonQuery();
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
