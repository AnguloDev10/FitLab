using Fitlab.Entities;
using FitLab.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Services
{
    public interface IExperienceService
    {
        Task<IEnumerable<Experience>> ListAsync();
        Task<ExperienceResponse> SaveAsync(Experience experience);

        Task<ExperienceResponse> UpdateAsync(int id, Experience experience);

        Task<ExperienceResponse> DeleteAsync(int id);
    }
}
