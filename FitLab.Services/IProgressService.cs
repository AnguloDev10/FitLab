using Fitlab.Entities;
using FitLab.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Services
{
    public interface IProgressService
    {
        Task<IEnumerable<Progress>> ListAsync();
        Task<IEnumerable<Progress>> ListBySessionIdAsync(int sessionId);

        Task<ProgressResponse> GetByIdAsync(int id);
        Task<ProgressResponse> SaveAsync(Progress progress);
        Task<ProgressResponse> UpdateAsync(int id, Progress progress);

        Task<ProgressResponse> DeleteAsync(int id);
    }
}
