using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Models;
using System;

namespace Travel.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private readonly TravelContext _db;
    public ReviewsController(TravelContext db)
    {
      _db = db;
    }

    //Get api/Reviews
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Review>>> Get(int id, string country, string city)
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
    [HttpPost]
    public async Task<ActionResult<Review>> Post(Review review)
    {
      _db.Reviews.Add(review);
      await _db.SaveChangesAsync();
      return CreatedAtAction("Post", new { id = review.ReviewId }, review);
    }

    //Get api/Reviews/3
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
