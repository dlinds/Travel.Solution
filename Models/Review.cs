using System.ComponentModel.DataAnnotations;
using System;

namespace Travel.Models
{
#pragma warning disable CS1591
  public class Review
  {
    public int ReviewId { get; set; }
    public int DestinationId { get; set; }
    public string ReviewText { get; set; }
    public string ReviewTitle { get; set; }
    public DateTime ReviewDate { get; set; }
    public int Rating { get; set; }
    [Required]
    public string UserName { get; set; }

  }
#pragma warning restore CS1591
}
