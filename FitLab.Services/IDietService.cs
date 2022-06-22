using Fitlab.Entities;
using FitLab.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Services
{
    public interface IDietService
    {
        Task<IEnumerable<Diet>> ListAsync();
        Task<IEnumerable<Diet>> ListBySessionIdAsync(int sessionId);

        Task<DietResponse> GetByIdAsync(int id);
        Task<DietResponse> SaveAsync(Diet diet);
        Task<DietResponse> UpdateAsync(int id, Diet diet);

        Task<DietResponse> DeleteAsync(int id);
    }
}
