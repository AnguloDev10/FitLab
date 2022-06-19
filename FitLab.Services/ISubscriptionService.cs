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
    public interface ISubscriptionService
    {
        Task<List<Subscription>> ListAsync();
        Task<Subscription> ListByUserIdAsync(int userId);

        Task<Subscription> GetByIdAsync(int id);
        Task<Subscription> Create(SubscriptionDTO subscription);
        Task Update(int id, SubscriptionDTO subscription);
        Task Delete(int id);
    }
}
