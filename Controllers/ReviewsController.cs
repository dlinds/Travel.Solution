using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Models;
using System;

namespace Travel.Controllers
{
#pragma warning disable CS1591
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private readonly TravelContext _db;
    public ReviewsController(TravelContext db)
    {
      _db = db;
    }
#pragma warning restore CS1591
    //Get api/Reviews
    //Get api/Destinations
    /// <summary>
    /// Gets list of reviews based on search criteria
    /// </summary>
    /// <remarks>
    /// Get all reviews:
    ///
    ///     GET /Reviews
    ///     {
    ///     }
    ///
    /// Sort by Country:
    ///
    ///     GET /Reviews?country={insert country name}
    ///     {
    ///     }
    ///
    /// Sort by City:
    ///
    ///     GET /Destinations?city={insert city name}
    ///     {
    ///     }
    ///
    ///
    /// </remarks>
    ///
    /// <param name="country">Either blank or name of country</param>
    /// <param name="city">Either blank or name of city</param>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Review>>> Get(string country, string city)
    {
      var query = _db.Reviews.AsQueryable();
      // var dQuery = _db.Destinations.AsQueryable();

      // var innerJoinQuery = _db.Reviews.AsQueryable();
      if (country != null && city != null)
      {
        var countryJoinQuery = from destination in _db.Destinations
                               where destination.Country == country
                               where destination.City == city
                               join review in _db.Reviews on destination.DestinationId equals review.DestinationId
                               select review;
        return await countryJoinQuery.ToListAsync();
      }
      if (country != null)
      {
        var countryJoinQuery = from destination in _db.Destinations
                               where destination.Country == country
                               join review in _db.Reviews on destination.DestinationId equals review.DestinationId
                               select review;
        return await countryJoinQuery.ToListAsync();
      }
      if (city != null)
      {
        var cityJoinQuery = from destination in _db.Destinations
                            where destination.City == city
                            join review in _db.Reviews on destination.DestinationId equals review.DestinationId
                            select review;
        return await cityJoinQuery.ToListAsync();
      }
      return await query.ToListAsync();

    }

    //Post api/Reviews
    /// <summary>
    /// Creates new review
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Post /Reviews
    ///     {
    ///       "DestinationId": integer id of country,
    ///       "ReviewText": "text of review",
    ///       "Rating": integer rating,
    ///       "UserName": "a name"
    ///     }
    ///
    ///
    /// </remarks>
    ///
    /// <param name="review">A review</param>
    /// <response code="201">Returns a newly created review</response>
    [HttpPost]
    public async Task<ActionResult<Review>> Post(Review review)
    {

      Destination destination = _db.Destinations.FirstOrDefault(a => a.DestinationId == review.DestinationId);
      destination.CalculateAverage(review.Rating);
      _db.Entry(destination).State = EntityState.Modified;
      _db.Reviews.Add(review);
      await _db.SaveChangesAsync();
      return CreatedAtAction("Post", new { id = review.ReviewId }, review);
    }

    //Get api/Reviews/3
    /// <summary>
    /// Retrieve review based on Id
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Get /Reviews/4
    ///     {
    ///     }
    ///
    /// </remarks>
    ///
    /// <param name="id">Review Id</param>
    /// <response code="404">No review with that Id exists</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReview(int id)
    {
      var review = await _db.Reviews.FindAsync(id);
      if (review == null)
      {
        return NotFound();
      }
      return review;
    }

    //Put api/Review/4
    /// <summary>
    /// Edits a review
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Put /Reviews/id
    ///     {
    ///       "reviewId": id,
    ///       "destinationId": id,
    ///       "review Text": "Updated Review Text",
    ///       "rating": Updated Review Rating,
    ///       "userName": "Updated Destination Name",
    ///     }
    ///
    ///
    /// </remarks>
    ///
    /// <param name="id">Id of the review being updated</param>
    /// <param name="review"></param>
    /// <param name="userName">Username of person who originally submitted review</param>
    /// <response code="204">Review updated successfully</response>
    /// <response code="400">Review ID doesn't match ID that is passed.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Review review, string userName)
    {
      if (id != review.ReviewId || review.UserName != userName)
      {
        return BadRequest();
      }
      var thisReview = _db.Reviews.FirstOrDefault(r => r.ReviewId == id);
      _db.Entry(thisReview).State = EntityState.Detached;
      if (thisReview.UserName != userName)
      {
        return BadRequest("Please use accurate user name!");
      }
      _db.Entry(review).State = EntityState.Modified;
      // thisReview = null;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ReviewExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }

      }
      return NoContent();

    }
    /// <summary>
    /// Removes a review
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Delete /reviews/id
    ///     {
    ///     }
    ///
    ///
    /// </remarks>
    ///
    /// <param name="id"></param>
    /// <response code="204">Deletes Review</response>
    /// <response code="404">Review ID doesn't exist.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
      var review = await _db.Reviews.FindAsync(id);
      if (review == null)
      {
        return NotFound();
      }

      _db.Reviews.Remove(review);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool ReviewExists(int id)
    {
      return _db.Reviews.Any(r => r.ReviewId == id);
    }
  }

}
