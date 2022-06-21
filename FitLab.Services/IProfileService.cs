using Fitlab.Entities;
using FitLab.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Services
{
    public interface IProfileService
    {
        Task<List<Profile>> ListAsync();

        Task<Profile> GetAsync(int id);
        Task Create(Profile profile);
        Task Update( Profile profile);
        Task Delete(int id);
    }
}
