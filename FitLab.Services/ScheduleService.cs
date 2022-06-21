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
    public class ScheduleService : IScheduleService
    {
        private readonly FitLabDbContext _context;
        public ScheduleService(FitLabDbContext context)
        {
            _context = context;
        }

        public async Task<Schedule> Create(ScheduleDTO schedule)
        {
            Schedule schedule1 = new Schedule { StartAt = schedule.StartAt, EndAt = schedule.EndAt,State = schedule.State, ProfileId = schedule.UserId};
            try
            {
                await _context.Schedules.AddAsync(schedule1);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
            return schedule1;

        }

        public async Task Delete(int id)
        {
            var existingSchedule = _context.Schedules.FirstOrDefault(c => c.Id == id);
            if (existingSchedule == null)
                throw new Exception("No se encontro");
            try
            {
                _context.Schedules.Remove(existingSchedule);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error");
            }
        }

        public async Task<Schedule> GetByIdAsync(int id)
        {
            return await _context.Schedules.Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Schedule>> ListAsync()
        {
            return await _context.Schedules.ToListAsync();
        }

        public async Task<Schedule> ListByUserIdAsync(int userId)
        {
            var schedule3 = await _context.Schedules.Where(g => g.ProfileId == userId).FirstOrDefaultAsync();
            return schedule3;
        }

        public async Task Update(int id, ScheduleDTO schedule)
        {
            var schedule4 = _context.Schedules.FirstOrDefault(c => c.Id == id);
            if (schedule4 == null)
                throw new Exception("No se encontro");
            schedule4.StartAt = schedule.StartAt;
            schedule4.EndAt = schedule.EndAt;
            schedule4.State = schedule.State;
            _context.Entry(schedule4).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
