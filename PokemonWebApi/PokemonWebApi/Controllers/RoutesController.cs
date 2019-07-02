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
    public class RoutesController : ControllerBase
    {
        private readonly PokemonContext _context;

        public RoutesController(PokemonContext context)
        {
            _context = context;
        }

        // GET: api/Routes
        [HttpGet]
        public IEnumerable<Route> GetRoutes()
        {
            return _context.Route.Include(r => r.Region);
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoute([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var route = await _context.Route
                .Include(r => r.Region)
                .FirstOrDefaultAsync(r => r.ID == id);

            if (route == null)
            {
                return NotFound();
            }

            return Ok(route);
        }

        /**********CUSTOM FILTERS**********/

        //GET: api/Routes/ByRegion
        [HttpGet("ByRegion/{id}")]
        public IEnumerable<Route> GetRoutesByRegion(int id)
        {
            return _context.Route.Include(r => r.Region)
                .Where(r => r.RegionID == id);
        }

        //GET: api/Routes/ByName
        [HttpGet("ByName/{route}")]
        public IEnumerable<Route> GetRoutesByName(string route)
        {
            return _context.Route
                .Include(r => r.Region)
                .Where(r => string.Equals(r.RouteName, route, StringComparison.OrdinalIgnoreCase));
        }

        //GET: api/Routes/RegionIs/k
        [HttpGet("RegionIs/{region}")]
        public IEnumerable<Route> GetRoutesRegionContains(string region)
        {
            return _context.Route
                .Include(r => r.Region)
                .Where(r => r.Region.RegionName.Contains(region));
        }

        // PUT: api/Routes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoute([FromRoute] int id, [FromBody] Route route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != route.ID)
            {
                return BadRequest();
            }

            _context.Entry(route).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(route);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteExists(id))
                {
                    ModelState.AddModelError("", "Concurrency Error: Route has been removed.");
                    return BadRequest(ModelState);
                }
                else
                {
                    ModelState.AddModelError("", "Concurrency Error: Route has been updated by another user. Cancel and trying editing the record again.");
                    return BadRequest(ModelState);
                }
            }
            catch (DbUpdateException dex)
            {
                if (dex.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError("", "Unable to save changes: Duplicate Route Name.");
                    return BadRequest(ModelState);
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes to the database. Try refreshing and trying again.");
                    return BadRequest(ModelState);
                }
            }
        }

        // POST: api/Routes
        [HttpPost]
        public async Task<IActionResult> PostRoute([FromBody] Route route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Route.Add(route);
            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetRoute", new { id = route.ID }, route);
            }
            catch (DbUpdateException dex)
            {
                if (dex.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError("", "Unable to save: Duplicate Route name.");
                    return BadRequest(ModelState);
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes to database. Try refreshing and trying again.");
                    return BadRequest(ModelState);
                }
            }
        }

        // DELETE: api/Routes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoute([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var routes = await _context.Route.FindAsync(id);
            if (routes == null)
            {
                return BadRequest("Delete Error: Route has already been deleted.");
            }
            try
            {
                _context.Route.Remove(routes);
                await _context.SaveChangesAsync();
                return Ok(routes);
            }
            catch (DbUpdateException dex)
            {
                if (dex.InnerException.Message.Contains("FK_"))
                {
                    return BadRequest("Unable to delete: Pokemon need homes.");
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

        private bool RouteExists(int id)
        {
            return _context.Route.Any(e => e.ID == id);
        }
    }
}
