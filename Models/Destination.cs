using System.Collections.Generic;
using System;
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
      string output = (newTotalSum / (newNumOfReviews)).ToString("0.00");


      this.NumOfReviews = newNumOfReviews;
      this.AverageRating = float.Parse(output);

      /*
      newRating = 10
      AverageRating = 7.5
      numOfReviews = 2

      numOfReviews * AverageRating = priorTotalSum; 7.5*2 = 15
      priorTotalSum + newRating = newTotalSum 15+10 = 25
      newTotalSum/newNumOfReviews = output 25 / 3 = 8.33


      */
    }

    public void ReCalculateAverage(int newRating)
    {

      float CurrentMultipledTotal = this.NumOfReviews * this.AverageRating; //200
      float NewTotal = CurrentMultipledTotal - this.AverageRating;
      float NewNewTotal = NewTotal + newRating;
      float FinishedAverageRating = NewNewTotal / this.NumOfReviews;
      this.AverageRating = float.Parse(FinishedAverageRating.ToString("0.00"));

      /*
      newRating = 10
      oldRating = 8
      AverageRatingCurrent = 5
      numOfReviews = 40

      numOfReviews * AverageCurrentRating = CurrentMultipledTotal (40 * 5 = 200)  *****
      NewTotal = CurrentMultipledTotal - oldRating (200 - 8 = 192)                *****
      newnewTotal = NewTotal + NewRating (192 + 10 = 202)
      FinishedAverageRating = newnewTotal / numOfReview (202 / 40 = 5.05)

      */
    }
    public void DeCalculateAverage(int oldRating)
    {
      float currentTotalScore = this.AverageRating * this.NumOfReviews;
      float newTotalScore = currentTotalScore - oldRating;
      int newNumOfReviews = this.NumOfReviews - 1;
      float result = newTotalScore / newNumOfReviews;

      this.AverageRating = float.Parse(result.ToString("0.00"));
      this.NumOfReviews = newNumOfReviews;
      //averageRating * numOfReviews = currentTotalScore
      //currentTotalScore - oldRating = newTotalScore
      //newTotalScore / newNumOfReviews = result   newNumOfReviews = NumOfReviews-1
    }
  }
#pragma warning restore CS1591
}
