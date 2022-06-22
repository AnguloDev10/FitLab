using Fitlab.Entities;
using FitLab.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Services
{
    public interface ISessionService
    {
        Task<IEnumerable<Session>> ListAsync();
        Task<IEnumerable<Session>> ListByUserIdAsync(int userId);

        Task<SessionResponce> GetByIdAsync(int id);
        Task<SessionResponce> SaveAsync(Session session);
        Task<SessionResponce> UpdateAsync(int id, Session session);
        Task<SessionResponce> DeleteAsync(int id);
    }
}
