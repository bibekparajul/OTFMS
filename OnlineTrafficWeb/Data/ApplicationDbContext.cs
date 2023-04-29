using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineTrafficWeb.Models;

namespace OnlineTrafficWeb.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<TrafficAdd> TrafficAds { get; set; }
        public DbSet<DriversAdd> DriversAds { get; set; }
        public DbSet<FineModel> FineModels { get; set; }

        public DbSet<PayHeader> PayHeaders { get; set; }
        public DbSet<FineHeader> FineHeaders { get; set; }

        //public DbSet<UserModel> UserModels { get; set; }
        //public DbSet<FinePay> FinePays { get; set; }


    }
}
