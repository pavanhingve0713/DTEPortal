using DTEPortal.Entities.Modals;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DTEPortal.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<MstState> MstState { get; set; }
    public virtual DbSet<MstDivision> MstDivision { get; set; }

   
    // Connection string configuration will be handled in Program.cs now
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
