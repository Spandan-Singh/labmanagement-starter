using CapstoneData.Model;
using Microsoft.EntityFrameworkCore;

namespace CapstoneData
{
    public interface ICapstoneDBContext
    {
        int SaveChanges();
        DbSet<CategoryDbo> Categories { get; set; }
        DbSet<LabDbo> Labs { get; set; }
        DbSet<AutherDbo> Authers { get; set; }
    }
}
