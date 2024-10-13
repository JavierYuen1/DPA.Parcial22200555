using DPA.Parcial.DOMAIN.Core.Entities;
using DPA.Parcial.DOMAIN.Infrastructure.Data;
using DPA.Parcial.DOMAIN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Parcial.DOMAIN.Core.Interfaces
{
    public class MechanicRepository : IMechanicRepository
    {
        private readonly Parcial22200555Context _dbContext;

        public MechanicRepository(Parcial22200555Context dbContext)
        {
            _dbContext = dbContext;
        }

        //Sincrona
        public IEnumerable<Mechanic> GetMechanicSync()
        {
            var mechanic = _dbContext.Mechanic.ToList();
            return mechanic;
        }

        //Asincrona
        public async Task<IEnumerable<Mechanic>> GetMechanies()
        {
            var mechanic = await _dbContext.Mechanic.ToListAsync();
            return mechanic;
        }

        public async Task<Mechanic> GetMechanicById(int id)
        {
            var mechanic = await _dbContext.Mechanic.Where(c => c.Id == id).FirstOrDefaultAsync();
            return mechanic;
        }

        public async Task<int> Insert(Mechanic mechanic)
        {
            await _dbContext.Mechanic.AddAsync(mechanic);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0 ? mechanic.Id : -1;
        }

        public async Task<bool> Update(Mechanic mechanic)
        {
            _dbContext.Mechanic.Update(mechanic);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {

            var category = await GetMechanicById(id);
            if (category == null) return false;
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
