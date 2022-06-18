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
    public class ProgressService : IProgressService
    {
        private readonly FitLabDbContext _context;

        public ProgressService(FitLabDbContext context)
        {
            _context = context;
        }
        public async Task<ProgressResponse> DeleteAsync(int id)
        {
            var existingProgress = await _context.Progresses.FindAsync(id);

            if (existingProgress == null)
                return new ProgressResponse("Progress not found");

            try
            {
                _context.Progresses.Remove(existingProgress);
                await _context.SaveChangesAsync();

                return new ProgressResponse(existingProgress);
            }
            catch (Exception ex)
            {
                return new ProgressResponse($"An error ocurred while deleting progress: {ex.Message}");
            }
        }

        public async Task<ProgressResponse> GetByIdAsync(int id)
        {
            var existingProgress = await _context.Progresses.FindAsync(id);

            if (existingProgress == null)
                return new ProgressResponse("Progress not found");
            return new ProgressResponse(existingProgress);
        }

        public async Task<IEnumerable<Progress>> ListAsync()
        {
            return await _context.Progresses.Include(p => p.Session).ToListAsync();
        }

        public async Task<IEnumerable<Progress>> ListBySessionIdAsync(int sessionId)
        {
            return await _context.Progresses
              .Where(p => p.SessionId == sessionId)
              .Include(p => p.Session)
              .ToListAsync();
        }

        public async Task<ProgressResponse> SaveAsync(Progress progress)
        {
            try
            {
                await _context.Progresses.AddAsync(progress);
                await _context.SaveChangesAsync();

                return new ProgressResponse(progress);
            }
            catch (Exception ex)
            {
                return new ProgressResponse($"An error ocurred while saving progress: {ex.Message}");
            }
        }

        public async Task<ProgressResponse> UpdateAsync(int id, Progress progress)
        {
            var existingProgress = await _context.Progresses.FindAsync(id);
            if (existingProgress == null)
                return new ProgressResponse("Progress not found");

            existingProgress.Description = progress.Description;

            try
            {
                _context.Progresses.Update(progress);
                await _context.SaveChangesAsync();

                return new ProgressResponse(existingProgress);
            }
            catch (Exception ex)
            {
                return new ProgressResponse($"An error ocurred while updating Progress: {ex.Message}");
            }
        }
    }
}
