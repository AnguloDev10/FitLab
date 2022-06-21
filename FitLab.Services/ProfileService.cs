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
    public class ProfileService : IProfileService
    {
        private readonly FitLabDbContext _context;

        public ProfileService(FitLabDbContext context)
        {
            _context = context;
        }

        public async Task Create(Profile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var existingProfile = _context.Profiles.FirstOrDefault(c => c.Id == id);
            if (existingProfile == null)
                throw new Exception("No se encontro");
            try
            {
                _context.Profiles.Remove(existingProfile);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error");
            }
        }

        public async Task<Profile> GetAsync(int id)
        {
            return await _context.Profiles.Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Profile>> ListAsync()
        {
            return await _context.Profiles.ToListAsync();
        }

        public async Task Update( Profile profile)
        {
            _context.Entry(profile).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
