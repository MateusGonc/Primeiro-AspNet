using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGame.Entities
{
    public class Jogo:IntId
    {
        public string Titulo { get; set; }
        public double? ValorPago{ get; set; }
        public string Imagem { get; set; }
        public DateTime? DataCompra { get; set; }
        public Genero genero { get; set; }
        public int idGenero { get; set; }
        public Editor editor { get; set; }
        public int idEditor { get; set; }
    }
}
