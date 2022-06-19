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
    public interface IDietService
    {
        Task<List<Diet>> ListAsync();
        Task<Diet> ListBySessionIdAsync(int sessionId);

        Task<Diet> GetByIdAsync(int id);
        Task<Diet> Create(DietDTO diet);
        Task Update(int id, DietDTO diet);

        Task Delete(int id);
    }
}
