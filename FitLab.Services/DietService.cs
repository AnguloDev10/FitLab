using Fitlab.Entities;
using FitLab.DataAccess;
using FitLab.Dto.Response;
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


        public async Task<DietResponse> DeleteAsync(int id)
        {
            var existingDiet = await _context.Diets.FindAsync(id);

            if (existingDiet == null)
                return new DietResponse("Diet not found");

            try
            {
                _context.Diets.Remove(existingDiet);
                await _context.SaveChangesAsync();

                return new DietResponse(existingDiet);
            }
            catch (Exception ex)
            {
                return new DietResponse($"An error ocurred while deleting diet: {ex.Message}");
            }
        }

        public async Task<DietResponse> GetByIdAsync(int id)
        {
            var existingDiet = await _context.Diets.FindAsync(id);
            if (existingDiet == null)
                return new DietResponse("Diet not found");
            return new DietResponse(existingDiet);

        }

        public async Task<IEnumerable<Diet>> ListAsync()
        {
            return await _context.Diets.Include(p => p.Session).ToListAsync();
        }

        public async Task<IEnumerable<Diet>> ListBySessionIdAsync(int sessionId)
        {
            return await _context.Diets.Where(p => p.SessionId == sessionId).Include(p => p.Session).ToListAsync();
        }

        public async Task<DietResponse> SaveAsync(Diet diet)
        {
            try 
            { 
               await _context.Diets.AddAsync(diet);
               await _context.SaveChangesAsync();
                return new DietResponse(diet);
            }
            catch (Exception ex)
            {
                return new DietResponse($"An error ocurred while saving diet: {ex.Message}");
            }

        }

        public async Task<DietResponse> UpdateAsync(int id, Diet diet)
        {
            var existingDiet = await _context.Diets.FindAsync(id);
            if (existingDiet == null)
                return new DietResponse("Diet not found");

            existingDiet.Description = diet.Description;

            try
            {
                _context.Diets.Update(diet);
                await _context.SaveChangesAsync();

                return new DietResponse(existingDiet);
            }
            catch (Exception ex)
            {
                return new DietResponse($"An error ocurred while updating Diet: {ex.Message}");
            }
        }
    }
}
