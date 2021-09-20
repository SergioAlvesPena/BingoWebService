using BingoWS.Data;
using BingoWS.Entities;
using BingoWS.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BingoWS.Repositories
{
    public class CartelaRepository : ICartelaRepository
    {
        #region Private Fields

        private readonly DataContext _context;

        #endregion Private Fields

        #region Public Constructors

        public CartelaRepository(DataContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task Create(Cartela cartela)
        {
            await _context.Cartelas.AddAsync(cartela);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cartela>> GetAll()
        {
            return await _context.Cartelas.AsNoTracking().ToListAsync();
        }

        public async Task<Cartela> GetById(Guid id)
        {
            return await _context.Cartelas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Cartela cartela)
        {
            _context.Entry(cartela).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        #endregion Public Methods
    }
}