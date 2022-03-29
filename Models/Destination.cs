using System.Collections.Generic;

namespace Travel.Models
{
#pragma warning disable CS1591
  public class Destination
  {
    // public Destination()
    // {
    //   this.Reviews = new HashSet<Review>();
    // }
    public int DestinationId { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Name { get; set; }
    public float AverageRating { get; set; }
    public int NumOfReviews { get; set; }
    // public virtual ICollection<Review> Reviews { get; set; }
  }
#pragma warning restore CS1591
}
