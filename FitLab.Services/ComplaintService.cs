using Fitlab.Entities;
using FitLab.DataAccess;
using FitLab.Dto.Request;
using FitLab.Dto.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Services
{
    public class ComplaintService : IComplaintService
    {
        private readonly FitLabDbContext _context;

        public ComplaintService(FitLabDbContext context)
        {
            _context = context;

        }

        public Task<ComplaintResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Complaint>> ListAsync()
        {
            return await _context.Complaints.Include(p => p.Profile).ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<ComplaintResponse> SaveAsync(Complaint complaint)
        {
            try
            {
                await _context.Complaints.AddAsync(complaint);
                await _context.SaveChangesAsync();
                return new ComplaintResponse(complaint);
            }
            catch(Exception ex)
            {
                return new ComplaintResponse($"An error ocurred while saving complaint: {ex.Message}");
            }
        }

        public async Task<ComplaintResponse> UpdateAsync(int id, ComplaintDTO complaint)
        {
            var existingComplaint = await _context.Complaints.FindAsync(id);
            if (existingComplaint != null)
                return new ComplaintResponse("Complaint not found");

            existingComplaint.Description = complaint.Description;
            existingComplaint.Name = complaint.Name;
            try
            {
                _context.Complaints.Update(existingComplaint);
                await _context.SaveChangesAsync();

                return new ComplaintResponse(existingComplaint);
            }
            catch (Exception ex)
            {
                return new ComplaintResponse($"An error ocurred while deleting complaint:{ex.Message}");
            }
        }


    }
}
