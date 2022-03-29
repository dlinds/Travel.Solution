using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
#pragma warning disable CS1591
  public class Review
  {
    public int ReviewId { get; set; }
    public int DestinationId { get; set; }
    public string ReviewText { get; set; }
    public int Rating { get; set; }
    [Required]
    public string UserName { get; set; }

  }
#pragma warning restore CS1591
}
