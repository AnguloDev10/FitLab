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
    public interface ISessionService
    {
        Task<List<Session>> ListAsync();
        Task<Session> ListByUserIdAsync(int userId);

        Task<Session> GetByIdAsync(int id);
        Task<Session> Create(SessionDTO session);
        Task Update(int id, SessionDTO session);
        Task Delete(int id);
    }
}
