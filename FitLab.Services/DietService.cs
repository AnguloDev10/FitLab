using Fitlab.Entities;
using FitLab.DataAccess;
using FitLab.Dto.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Services
{
    public class DietService : IDietService
    {
        private readonly FitLabDbContext _context;
        public DietService(FitLabDbContext context)
        {
            _context = context;
        }

        public async Task<Diet> Create(DietDTO diet)
        {
            Diet diet1 = new Diet {Description = diet.Description,SessionId=diet.SessionId,Title=diet.Title};
            try
            {
                _context.Diets.Add(diet1);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Algo salio mal");
            }
            return diet1;
        }

        public async Task Delete(int id)
        {
            var existingDiet = _context.Diets.FirstOrDefault(c => c.Id == id);
            if (existingDiet == null)
                throw new Exception("No se encontro");
            try
            {
                _context.Diets.Remove(existingDiet);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error");
            }
        }

        public async Task<Diet> GetByIdAsync(int id)
        {
            return await _context.Diets.Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Diet>> ListAsync()
        {
            return await _context.Diets.ToListAsync();
        }

        public async Task<Diet> ListBySessionIdAsync(int sessionId)
        {
            return await _context.Diets.Where(g => g.SessionId == sessionId).FirstOrDefaultAsync();

        }

        public async Task Update(int id, DietDTO diet)
        {
            var diet1 = await _context.Diets.FindAsync(id);
            if (diet1 == null)
                throw new Exception("No se encontro");
            diet1.Title = diet.Title;
            diet1.Description = diet.Description;
            _context.Entry(diet1).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
