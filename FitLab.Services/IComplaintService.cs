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
    public interface IComplaintService
    {
        Task<IEnumerable<Complaint>> ListAsync();
        Task<ComplaintResponse> SaveAsync(Complaint complaint);

        Task<ComplaintResponse> UpdateAsync(int id, ComplaintDTO complaint);

       Task<ComplaintResponse> DeleteAsync(int id);
    }
}
