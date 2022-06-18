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
    public class SubscriptionService : ISubscriptionService
    {
        private readonly FitLabDbContext _context;

        SubscriptionService(FitLabDbContext context)
        {
            _context = context;
        }

        public async Task<SubscriptionResponse> DeleteAsync(int id)
        {
            var existingSubscription = await _context.Subscriptions.FindAsync(id);

            if (existingSubscription == null)
                return new SubscriptionResponse("Subscription not found");

            try
            {
                _context.Subscriptions.Remove(existingSubscription);
                await _context.SaveChangesAsync();

                return new SubscriptionResponse(existingSubscription);
            }
            catch (Exception ex)
            {
                return new SubscriptionResponse($"An error ocurred while deleting subscription: {ex.Message}");
            }
        }
    

        public async Task<SubscriptionResponse> GetByIdAsync(int id)
        {
        var existingSubscription = await _context.Subscriptions.FindAsync(id);

            if (existingSubscription == null)
            return new SubscriptionResponse("Subscription not found");
        return new SubscriptionResponse(existingSubscription);
        }

        public async Task<IEnumerable<Subscription>> ListAsync()
        {
            return await _context.Subscriptions.Include(p => p.Profile).ToListAsync();
        }

        public async Task<IEnumerable<Subscription>> ListByUserIdAsync(int userId)
        {
            return await _context.Subscriptions
                 .Where(p => p. ProfileId == userId)
                 .Include(p => p.Profile)
                 .ToListAsync();
        }

        public async Task<SubscriptionResponse> SaveAsync(Subscription subscription)
        {
            try
            {
                await _context.Subscriptions.AddAsync(subscription);
                await _context.SaveChangesAsync();

                return new SubscriptionResponse(subscription);
            }
            catch (Exception ex)
            {
                return new SubscriptionResponse($"An error ocurred while saving subscription: {ex.Message}");
            }
        }

        public async Task<SubscriptionResponse> UpdateAsync(int id, Subscription subscription)
        {
            var existingSubscription = await _context.Subscriptions.FindAsync(id);
            if (existingSubscription == null)
                return new SubscriptionResponse("Subscription not found");

            existingSubscription.MaxSessions = subscription.MaxSessions;

            try
            {
                _context.Subscriptions.Update(existingSubscription);
                await _context.SaveChangesAsync();

                return new SubscriptionResponse(existingSubscription);
            }
            catch (Exception ex)
            {
                return new SubscriptionResponse($"An error ocurred while updating subscription: {ex.Message}");
            }
        }
    }
}
