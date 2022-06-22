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
    public class SessionService : ISessionService
    {
        private readonly FitLabDbContext _context;
        public SessionService(FitLabDbContext context)
        {
            _context = context;
        }

        public async Task<Session> Create(SessionDTO session)
        {
            Session session2 = new Session { StartAt=session.StartAt,EndAt=session.EndAt,ProfileId=session.UserId,Link=session.Link};
            try
            {
                await _context.Sessions.AddAsync(session2);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
            return session2;
            
        }

        public async Task Delete(int id)
        {
            var existingSession = _context.Sessions.FirstOrDefault(c => c.Id == id);
            if (existingSession == null)
                throw new Exception("No se encontro");
            try
            {
                _context.Sessions.Remove(existingSession);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error");
            }
        }

        public async Task<Session> GetByIdAsync(int id)
        {
            return await _context.Sessions.Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Session>> ListAsync()
        {
            return await _context.Sessions.ToListAsync();
        }

        public async Task<Session> ListByUserIdAsync(int userId)
        {
            var session1 = await _context.Sessions.Where(g => g.ProfileId == userId).FirstOrDefaultAsync();
            return session1;
        }

        public async Task Update(int id, SessionDTO session)
        {
            var session1 = _context.Sessions.FirstOrDefault(c => c.Id == id);
            if (session1 == null)
                throw new Exception("No se encontro");
            session1.StartAt = session.StartAt;
            session1.EndAt = session.EndAt;
            session1.Link = session.Link;
            _context.Entry(session1).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
