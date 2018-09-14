using Microsoft.EntityFrameworkCore;

namespace hotelsweb.Models
{
  public class HotelsContext : DbContext
  {
    public HotelsContext(DbContextOptions<HotelsContext> options) : base(options)
    {
    }

    public DbSet<Hotel> Hotels { get; set; }
  }
}