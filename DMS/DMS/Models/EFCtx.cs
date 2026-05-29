using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMS.Models
{
    public class EFCtx : DbContext
    {
        public EFCtx(DbContextOptions<EFCtx> options) : base(options)
        {
        }

        public DbSet<MainOffice> MainOffices { get; set; }
        public DbSet<Directorate> Directorates { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Branch> Branches { get; set; }


    }
}
