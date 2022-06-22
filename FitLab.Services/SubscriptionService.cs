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
    public class SubscriptionService:ISubscriptionService
    {
        private readonly FitLabDbContext _context;

        public SubscriptionService(FitLabDbContext context)
        {
            _context = context;
        }

        public async Task<Subscription> Create(SubscriptionDTO subscription)
        {
            Subscription newSubscription = new Subscription { Name = subscription.Name,  Active = subscription.Active,MaxSessions=subscription.MaxSessions,Price = subscription.Price,ProfileId = subscription.UserId, Description=subscription.Description};
            try
            {
                _context.Subscriptions.Add(newSubscription);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Algo salio mal");
            }
            return newSubscription;
        }

        public async Task Delete(int id)
        {
            var existingSubscription = _context.Subscriptions.FirstOrDefault(c => c.Id == id);
            if (existingSubscription == null)
                throw new Exception("No se encontro");
            try
            {
                _context.Subscriptions.Remove(existingSubscription);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error");
            }
        }

        public async Task<Subscription> GetByIdAsync(int id)
        {
            return await _context.Subscriptions.Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Subscription>> ListAsync()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public async Task<Subscription> ListByUserIdAsync(int userId)
        {
            var session1 = await _context.Subscriptions.Where(g => g.ProfileId == userId).FirstOrDefaultAsync();
            return session1;
        }

        public async Task Update(int id, SubscriptionDTO subscription)
        {
            var subscription1 = await _context.Subscriptions.FindAsync(id);
            if (subscription1 == null)
                throw new Exception("No se encontro");
            subscription1.Name = subscription.Name;
            subscription1.Active = subscription.Active;
            subscription1.Price=subscription.Price;
            subscription1.MaxSessions = subscription.MaxSessions;
            subscription1.Description = subscription.Description;
            _context.Entry(subscription1).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
