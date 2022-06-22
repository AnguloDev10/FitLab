using Fitlab.Entities;
using FitLab.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Services
{
    public interface IScheduleService
    {
        Task<IEnumerable<Schedule>> ListAsync();

        Task<IEnumerable<Schedule>> ListByUserIdAsync(int userId);

        Task<ScheduleResponse> GetByIdAsync(int id);
        Task<ScheduleResponse> SaveAsync(Schedule schedule);
        Task<ScheduleResponse> UpdateAsync(int id, Schedule schedule);
    }
}
