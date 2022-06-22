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
    public class ExperienceService : IExperienceService
    {
        private readonly FitLabDbContext _context;

        public ExperienceService(FitLabDbContext context)
        {
            _context = context;
        }

        public async Task<ExperienceResponse> DeleteAsync(int id)
        {
            var existingExperience = await _context.Experiences.FindAsync(id);

            if (existingExperience == null)
                return new ExperienceResponse("Experience not found");

            try
            {
                _context.Experiences.Remove(existingExperience);
                await _context.SaveChangesAsync();

                return new ExperienceResponse(existingExperience);
            }
            catch (Exception ex)
            {
                return new ExperienceResponse($"An error ocurred while deleting experience:{ex.Message}");
            }

        }

        public async Task<IEnumerable<Experience>> ListAsync()
        {
            return await _context.Experiences.Include(p => p.Profile).ToListAsync();
        }

        public async Task<ExperienceResponse> SaveAsync(Experience experience)
        {
            try
            {
                await _context.Experiences.AddAsync(experience);
                await _context.SaveChangesAsync();

                return new ExperienceResponse(experience);
            }
            catch (Exception ex)
            {
                return new ExperienceResponse($"An error ocurred while saving experience:{ex.Message}");
            }
        }

        public async Task<ExperienceResponse> UpdateAsync(int id, Experience experience)
        {
            var existingExperience =  await _context.Experiences.FindAsync(id);
            if (existingExperience == null)
                return new ExperienceResponse("Complaint not found");

            existingExperience.Description = experience.Description;

            try
            {
                _context.Experiences.Update(experience);
                await _context.SaveChangesAsync();

                return new ExperienceResponse(existingExperience);
            }
            catch (Exception ex)
            {
                return new ExperienceResponse($"An error ocurred while updating experience: {ex.Message}");
            }

        }
    }
}
