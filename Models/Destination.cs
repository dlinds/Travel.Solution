using System.Collections.Generic;

namespace Travel.Models
{
#pragma warning disable CS1591
  public class Destination
  {
    public Destination()
    {
      this.Reviews = new HashSet<Review>();
    }
    public int DestinationId { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Name { get; set; }
    public float AverageRating { get; set; }
    public int NumOfReviews { get; set; }
    public string ImgLink { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }

    public void CalculateAverage(int newRating)
    {
      float priorTotalSum = (float)this.NumOfReviews * this.AverageRating;
      float newTotalSum = priorTotalSum + newRating;
      int newNumOfReviews = this.NumOfReviews + 1;
      float output = newTotalSum / (newNumOfReviews);


      this.NumOfReviews = newNumOfReviews;
      this.AverageRating = output;

      /*
      newRating = 5
      AverageRating = 3.7
      numOfReviews = 40

      numOfReviews * AverageRating = priorTotalSum;
      priorTotalSum + newRating = newTotalSum
      newTotalSum/newNumOfReviews = output


      */
    }
  }
#pragma warning restore CS1591
}
