using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Models;
using System;
using Microsoft.AspNetCore.Cors;


namespace Travel.Controllers
{
#pragma warning disable CS1591
  [Route("api/[controller]")]
  [ApiController]
  public class DestinationsController : ControllerBase
  {
    private readonly TravelContext _db;
    public DestinationsController(TravelContext db)
    {
      _db = db;
    }
#pragma warning restore CS1591
    //Get api/Destinations
    /// <summary>
    /// Gets multiple destinations, can be sorted
    /// </summary>
    /// <remarks>
    /// Get all reviews:
    ///
    ///     GET /Destinations
    ///     {
    ///     }
    ///
    /// Sort by Number of Reviews:
    ///
    ///     GET /Destinations?sortMethod=numOfReviews
    ///     {
    ///     }
    ///
    /// Sort by Average Rating:
    ///
    ///     GET /Destinations?sortMethod=averageRating
    ///     {
    ///     }
    ///
    ///
    /// </remarks>
    ///
    /// <param name="sortMethod">Either blank, numOfReviews, or averageRating</param>
    [DisableCors]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Destination>>> Get(string sortMethod)
    {
      var query = _db.Destinations.AsQueryable();
      if (sortMethod == "numOfReviews")
      {
        query = _db.Destinations.OrderByDescending(destination => destination.NumOfReviews);
      }
      else if (sortMethod == "averageRating")
      {
        query = _db.Destinations.OrderByDescending(destination => destination.AverageRating);
      }
      else
      {
        query = _db.Destinations.OrderBy(destination => destination.Country);
      }
      return await query.ToListAsync();
    }

    //Post api/Destinations
    /// <summary>
    /// Creates new destination
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Post /Destinations
    ///     {
    ///       "Country": "Sample Country",
    ///       "City": "Sample City",
    ///       "Name": "Sample Name",
    ///       "AverageRating": a decimal number,
    ///       "NumOfReviews": an integer
    ///       "ImgLink": "A URL string of destination"
    ///     }
    ///
    ///
    /// </remarks>
    ///
    /// <param name="destination">A destination</param>
    /// <response code="201">Returns a newly created destination</response>
    [HttpPost]
    public async Task<ActionResult<Destination>> Post(Destination destination)
    {
      _db.Destinations.Add(destination);
      await _db.SaveChangesAsync();
      return CreatedAtAction("Post", new { id = destination.DestinationId }, destination);
    }



    //  Get api/Destinations/3
    /// <summary>
    /// Retrieve destination based on Id
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Get /Destinations/4
    ///     {
    ///     }
    ///
    /// </remarks>
    ///
    /// <param name="id">Destination Id</param>
    /// <response code="404">No destination with that Id exists</response>
    [EnableCors("AnotherPolicy")]
    [HttpGet("{id}")]
    public async Task<ActionResult<Destination>> GetDestination(int id)
    {
      var destination = await _db.Destinations.FindAsync(id);
      if (destination == null)
      {
        return NotFound();
      }
      return destination;
    }

    //Put api/Destinations/4
    /// <summary>
    /// Edits a destination
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Put /Destinations/id
    ///     {
    ///       "DestinationId": id,
    ///       "Country": "Updated Country Name",
    ///       "City": "Updated City Name",
    ///       "Name": "Updated Destination Name",
    ///       "AverageRating": updated decimal number,
    ///       "NumOfReviews": updated integer
    ///     }
    ///
    ///
    /// </remarks>
    ///
    /// <param name="id"></param>
    /// <param name="destination"></param>
    /// <response code="204">Updates Destination</response>
    /// <response code="400">Destination ID doesn't match ID that is passed.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Destination destination)
    {
      if (id != destination.DestinationId)
      {
        return BadRequest();
      }
      _db.Entry(destination).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DestinationExists(id))
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
    /// Removes a destination
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Delete /Destinations/id
    ///     {
    ///     }
    ///
    ///
    /// </remarks>
    ///
    /// <param name="id"></param>
    /// <response code="204">Deletes Destination</response>
    /// <response code="404">Destination ID doesn't exist.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDestination(int id)
    {
      var destination = await _db.Destinations.FindAsync(id);
      if (destination == null)
      {
        return NotFound();
      }

      _db.Destinations.Remove(destination);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    //Get api/Destinations/x

    /// <summary>
    /// Gets a random destination
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Get /Destinations/GetRandom
    ///     {
    ///     }
    ///
    ///
    /// </remarks>
    ///
    /// <response code="204">Random value doesn't exist.</response>
    [HttpGet("GetRandom")]
    public async Task<ActionResult<Destination>> GetRandomDestination()
    {
      var query = _db.Destinations.AsQueryable();

      Destination newestDestination = _db.Destinations
                      .OrderByDescending(p => p.DestinationId)
                      .FirstOrDefault();
      int count = newestDestination.DestinationId + 1;
      Random rand = new Random();
      int num = rand.Next(0, count);


      bool isFound = false;

      while (isFound != true)
      {
        isFound = _db.Destinations.Any(d => d.DestinationId == num);

        if (isFound == true)
        {
          query = _db.Destinations.Where(d => d.DestinationId == num);
          break;
        }
        else
        {
          num = rand.Next(0, count);
        }
      }

      return await query.FirstOrDefaultAsync();

    }

    private bool DestinationExists(int id)
    {
      return _db.Destinations.Any(e => e.DestinationId == id);
    }
  }

}
