using Microsoft.EntityFrameworkCore;
using RealEstateManagmentSystem.Models;

namespace RealEstateManagmentSystem.Data
{
    public class RealEstateManagmentContext:DbContext
    {
        public RealEstateManagmentContext(DbContextOptions<RealEstateManagmentContext> options) : base(options) { }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<LeaseAgreement> LeaseAgreements { get; set; }

    }
}
