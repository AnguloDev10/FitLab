using Fitlab.Entities;
using FitLab.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Services
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<Subscription>> ListAsync();
        Task<IEnumerable<Subscription>> ListByUserIdAsync(int userId);

        Task<SubscriptionResponse> GetByIdAsync(int id);
        Task<SubscriptionResponse> SaveAsync(Subscription subscription);
        Task<SubscriptionResponse> UpdateAsync(int id, Subscription subscription);
        Task<SubscriptionResponse> DeleteAsync(int id);
    }
}
