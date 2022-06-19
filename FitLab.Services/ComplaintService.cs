using Fitlab.Entities;
using FitLab.DataAccess;
using FitLab.Dto.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Services
{
    public class ComplaintService: IComplaintService
    {
        private readonly FitLabDbContext _context;

        public ComplaintService(FitLabDbContext context)
        {
            _context = context;
        }

        public async Task<Complaint> Create(ComplaintDTO complaint)
        {
            Complaint newComplaint = new Complaint { Name= complaint.Name, Description=complaint.Description,ProfileId=complaint.UserId};

            try
            {
                _context.Complaints.Add(newComplaint);
                await _context.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                throw new Exception("Algo salio mal");
            }
            return newComplaint;
        }

        public async Task Delete(int id)
        {
            var existingComplaint = _context.Complaints.FirstOrDefault(c => c.Id == id);
            if (existingComplaint == null)
                throw new Exception("No se encontro");
            try
            {
                _context.Complaints.Remove(existingComplaint);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new Exception("Hubo un error");
            }
        }

        public async Task<List<Complaint>> ListAsync()
        {
            return await _context.Complaints.ToListAsync();
        }

        public async Task Update(int id, ComplaintDTO complaint)
        {
            var complaint1 = await _context.Complaints.FindAsync(id);
            if (complaint1 == null)
                throw new Exception("No se encontro");
            complaint1.Description = complaint.Description;
            complaint1.Name = complaint.Name;
            _context.Entry(complaint1).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
