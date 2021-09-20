using BingoWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BingoWS.IRepositories
{
    interface ICartelaRepository
    {
        Task Create(Cartela cartela);

        Task Update(Cartela cartela);

        Task<Cartela> GetById(Guid id);

        Task<IEnumerable<Cartela>> GetAll();
    }
}
