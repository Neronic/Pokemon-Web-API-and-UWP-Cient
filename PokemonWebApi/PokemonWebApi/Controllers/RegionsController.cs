using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonWebApi.Data;
using PokemonWebApi.Models;

namespace PokemonWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly PokemonContext _context;

        public RegionsController(PokemonContext context)
        {
            _context = context;
        }

        // GET: api/Regions
        [HttpGet]
        public IEnumerable<Region> GetRegions()
        {
            return _context.Region;
        }

        // GET: api/Regions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var region = await _context.Region.FindAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }

        /**********CUSTOM FILTER**********/

        //GET: api/Regions/ByName
        [HttpGet("ByName/{region}")]
        public IEnumerable<Region> GetRegionsByName(string region)
        {
            return _context.Region
                .Where(r => string.Equals(r.RegionName, region, StringComparison.OrdinalIgnoreCase));
        }

        //GET: api/Regions/Contains/k
        [HttpGet("Contains/{region}")]
        public IEnumerable<Region> GetRegionsContains(string region)
        {
            return _context.Region
                .Where(r => r.RegionName.Contains(region));
        }

        // PUT: api/Regions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion([FromRoute] int id, [FromBody] Region region)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != region.ID)
            {
                return BadRequest();
            }

            _context.Entry(region).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(region);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(id))
                {
                    ModelState.AddModelError("", "Concurrency Error: Region has been removed.");
                    return BadRequest(ModelState);
                }
                else
                {
                    ModelState.AddModelError("", "Concurrency Error: Region has been updated by another user. Cancel and trying editing the record again.");
                    return BadRequest(ModelState);
                }
            }
            catch (DbUpdateException dex)
            {
                if (dex.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError("", "Unable to save changes: Duplicate Region Name.");
                    return BadRequest(ModelState);
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes to the database. Try refreshing and trying again.");
                    return BadRequest(ModelState);
                }
            }
        }

        // POST: api/Regions
        [HttpPost]
        public async Task<IActionResult> PostRegion([FromBody] Region region)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Region.Add(region);
            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetRegion", new { id = region.ID }, region);
            }
            catch (DbUpdateException dex)
            {
                if (dex.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError("", "Unable to save: Duplicate Region name. Try again.");
                    return BadRequest(ModelState);
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes to database. Try refreshing and trying again.");
                    return BadRequest(ModelState);
                }
            }
        }

        // DELETE: api/Regions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var region = await _context.Region.FindAsync(id);
            if (region == null)
            {
                return BadRequest("Delete Error: Region has already been deleted.");
            }
            try
            {
                _context.Region.Remove(region);
                await _context.SaveChangesAsync();
                return Ok(region);
            }
            catch (DbUpdateException dex)
            {
                if (dex.InnerException.Message.Contains("FK_"))
                {
                    return BadRequest("Unable to delete: Routes can't exist without Regions.");
                }
                else
                {
                    return BadRequest("Unable to save changes to the database. Try again.");
                }
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Try again.");
            }
        }

        private bool RegionExists(int id)
        {
            return _context.Region.Any(e => e.ID == id);
        }
    }
}
