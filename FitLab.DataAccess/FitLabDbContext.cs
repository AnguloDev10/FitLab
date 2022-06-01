using Fitlab.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitLab.DataAccess
{
    public class FitLabDbContext:DbContext
    {
        public FitLabDbContext()
        {

        }
        public FitLabDbContext(DbContextOptions<FitLabDbContext> options):base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Complaint> Complaints { get; set; }


    }
}