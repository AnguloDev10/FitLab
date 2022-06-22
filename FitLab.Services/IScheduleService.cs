using Fitlab.Entities;
using FitLab.Dto.Request;
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
        Task<List<Schedule>> ListAsync();

        Task<Schedule>ListByUserIdAsync(int userId);

        Task<Schedule> GetByIdAsync(int id);
        Task<Schedule> Create(ScheduleDTO schedule);
        Task Update(int id, ScheduleDTO schedule);
        Task Delete(int id);
    }
}
