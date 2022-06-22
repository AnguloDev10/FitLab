using Fitlab.Entities;
using FitLab.DataAccess;
using FitLab.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Services
{
    public class SessionService : ISessionService
    {
        private readonly FitLabDbContext _context;

        public SessionService(FitLabDbContext context)
        {
            _context = context;
        }

        public Task<SessionResponce> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SessionResponce> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Session>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Session>> ListByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<SessionResponce> SaveAsync(Session session)
        {
            throw new NotImplementedException();
        }

        public Task<SessionResponce> UpdateAsync(int id, Session session)
        {
            throw new NotImplementedException();
        }
    }
}
