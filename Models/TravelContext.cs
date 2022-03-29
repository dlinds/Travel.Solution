using Microsoft.EntityFrameworkCore;

namespace Travel.Models
{
#pragma warning disable CS1591
  public class TravelContext : DbContext
  {
    public TravelContext(DbContextOptions<TravelContext> options)
    : base(options)
    {

    }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Review> Reviews { get; set; }
  }
#pragma warning restore CS1591
}
