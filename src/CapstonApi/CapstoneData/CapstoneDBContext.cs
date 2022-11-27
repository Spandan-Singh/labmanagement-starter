using CapstoneData.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CapstoneData
{
    public class CapstoneDBContext : DbContext, ICapstoneDBContext
    {
        private static bool _created = false;
        public CapstoneDBContext(DbContextOptions<CapstoneDBContext> options)
            : base(options)
        {
            //if (!_created)
            //{
            //    _created = true;
            //    Database.EnsureDeleted();
            //    Database.EnsureCreated();
            //}
        }

        public DbSet<CategoryDbo> Categories { get; set; }
        public DbSet<LabDbo> Labs { get; set; }
        public DbSet<AutherDbo> Authers { get; set; }


    }
}