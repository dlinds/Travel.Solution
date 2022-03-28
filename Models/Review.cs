namespace Travel.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    public int DestinationId { get; set; }
    public string ReviewText { get; set; }
    public int Rating { get; set; }
    public virtual Destination destination { get; set; }

  }

}
