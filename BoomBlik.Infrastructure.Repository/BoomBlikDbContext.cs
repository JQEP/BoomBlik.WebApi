using Microsoft.EntityFrameworkCore;
using BoomBlik.Core.Infrastructure.Entities;

namespace BoomBlik.Infrastructure.Repository;

public class BoomBlikDbContext : DbContext
{
    public BoomBlikDbContext(DbContextOptions<BoomBlikDbContext> options) : base(options)
    {
    }

    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<CustomerAddressEntity> CustomerAddresses { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<TreeEntity> Trees { get; set; }
    public DbSet<TreeReportEntity> TreeReports { get; set; }
    public DbSet<TreeReportPdfEntity> TreeReportPdfs { get; set; }
    public DbSet<TreeReportPictureEntity> TreeReportPictures { get; set; }
}