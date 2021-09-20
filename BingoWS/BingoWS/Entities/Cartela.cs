using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BingoWS.Entities
{
    public class Cartela
    {
        public int Id { get; set; }
        public List<List<int>> CartelaDeNumeros { get; set; }
        public bool Jogando { get; set; }

    }
}
