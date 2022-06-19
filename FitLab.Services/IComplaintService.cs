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
        Task<List<Complaint>> ListAsync();
        Task<Complaint> Create(ComplaintDTO complaint);

        Task Update(int id, ComplaintDTO complaint);

        Task Delete(int id);
    }
}
