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
    public class ScheduleService : IScheduleService
    {
        private readonly FitLabDbContext _context;
        public ScheduleService(FitLabDbContext context)
        {
            _context = context;
        }

        public async Task<ScheduleResponse> GetByIdAsync(int id)
        {
            var existingSchedule = await _context.Schedules.FindAsync(id);
            if (existingSchedule == null)
                return new ScheduleResponse("Schedule not found");
            return new ScheduleResponse(existingSchedule);
        }

        public async Task<IEnumerable<Schedule>> ListAsync()
        {
            return await _context.Schedules.Include(p => p.Profile).ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> ListByUserIdAsync(int userId)
        {
            return await _context.Schedules
                .Where(p => p.ProfileId == userId)
                .Include(p => p.Profile)
                .ToListAsync();
        }

        public async Task<ScheduleResponse> SaveAsync(Schedule schedule)
        {
            try
            {
                await _context.Schedules.AddAsync(schedule);
                await _context.SaveChangesAsync();

                return new ScheduleResponse(schedule);
            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error ocurred while saving schedule: {ex.Message}");
            }
        }

        public async Task<ScheduleResponse> UpdateAsync(int id, Schedule schedule)
        {
            var existingSchedule = await _context.Schedules.FindAsync(id); ;
            if (existingSchedule == null)
                return new ScheduleResponse("Schedule not found");

            existingSchedule.State = schedule.State;

            try
            {
                _context.Schedules.Update(existingSchedule);
                await _context.SaveChangesAsync();

                return new ScheduleResponse(existingSchedule);
            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error ocurred while updating schedule: {ex.Message}");
            }
        }
    }
}
