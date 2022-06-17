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
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }


    }
}