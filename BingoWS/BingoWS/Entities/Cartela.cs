using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BingoWS.Entities
{
    public class Cartela
    {
        public Guid Id { get; set; }
        public List<List<int>> CartelaDeNumeros { get; set; }
        public bool Jogando { get; set; }

        public void FullUpdate(Guid id, List<List<int>> cartela, bool jogando) 
        {
            Id = id;
            CartelaDeNumeros = cartela;
            Jogando = jogando;
        }

    }
}
