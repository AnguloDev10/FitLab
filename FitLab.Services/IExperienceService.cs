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
    public interface IExperienceService
    {
        Task<List<Experience>> ListAsync();

        Task<Experience> GetByIdAsync(int id);
        Task<Experience> Create(ExperienceDTO complaint);

        Task Update(int id, ExperienceDTO experience);

        Task Delete(int id);
    }
}
