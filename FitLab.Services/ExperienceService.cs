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
    public class ExperienceService : IExperienceService
    {
        private readonly FitLabDbContext _context;

        public ExperienceService(FitLabDbContext context)
        {
            _context = context;
        }

        public async Task<Experience> Create(ExperienceDTO experience)
        {
            Experience experience1 = new Experience { Name = experience.Name, Description = experience.Description, ProfileId = experience.UserId };
            try
            {
                await _context.Experiences.AddAsync(experience1);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
            return experience1;
        }

        public async Task Delete(int id)
        {
            var existingExperience = _context.Experiences.FirstOrDefault(c => c.Id == id);
            if (existingExperience == null)
                throw new Exception("No se encontro");
            try
            {
                _context.Experiences.Remove(existingExperience);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error");
            }
        }

        public async Task<Experience> GetByIdAsync(int id)
        {
            return await _context.Experiences.Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Experience>> ListAsync()
        {
            return await _context.Experiences.ToListAsync();
        }

        public async Task Update(int id, ExperienceDTO experience)
        {
            var experience2 = _context.Experiences.FirstOrDefault(c => c.Id == id);
            if (experience2 == null)
                throw new Exception("No se encontro");
            experience2.Name = experience.Name;
            experience2.Description = experience.Description;
            _context.Entry(experience2).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
