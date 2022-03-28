using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    public int DestinationId { get; set; }
    public string ReviewText { get; set; }
    public int Rating { get; set; }
    [Required]
    public string UserName { get; set; }
    public virtual Destination destination { get; set; }

  }

}
