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
  public class DestinationsController : ControllerBase
  {
    private readonly TravelContext _db;
    public DestinationsController(TravelContext db)
    {
      _db = db;
    }

    //Get api/Destinations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Destination>>> Get(string sortMethod)
    {
      var query = _db.Destinations.AsQueryable();

      if (sortMethod == "numOfReviews")
      {
        query = _db.Destinations.OrderBy(destination => destination.NumOfReviews);
      }
      if (sortMethod == "averageRating")
      {
        query = _db.Destinations.OrderBy(destination => destination.AverageRating);
      }
      return await query.ToListAsync();
    }

    //Post api/Destinations
    [HttpPost]
    public async Task<ActionResult<Destination>> Post(Destination destination)
    {
      _db.Destinations.Add(destination);
      await _db.SaveChangesAsync();
      return CreatedAtAction("Post", new { id = destination.DestinationId }, destination);
    }

    //Get api/Destinations/3
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

    //Get api/Destinations/x
    [HttpGet("isRandom")]
    public async Task<ActionResult<Destination>> GetRandomDestination()
    {
      var query = _db.Destinations.AsQueryable();
      // if (isRandom == "random")
      // {


      int count = _db.Destinations.Count();
      Random rand = new Random();
      int num = rand.Next(0, count);

      query = _db.Destinations.Where(d => d.DestinationId == num);

      return await query.FirstOrDefaultAsync();

    }

    //Put api/Destination/4
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

    private bool DestinationExists(int id)
    {
      return _db.Destinations.Any(e => e.DestinationId == id);
    }
  }

}
