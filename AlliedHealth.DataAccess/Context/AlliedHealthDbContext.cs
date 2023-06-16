using AlliedHealth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliedHealth.DataAccess.Context
{
    public class AlliedHealthDbContext : DbContext
    {
        public AlliedHealthDbContext(DbContextOptions<AlliedHealthDbContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Province> Provinces { get; set; }
    }
}
