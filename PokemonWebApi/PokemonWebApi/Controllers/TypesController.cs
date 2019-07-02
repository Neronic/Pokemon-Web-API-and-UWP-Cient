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
    public class TypesController : ControllerBase
    {
        private readonly PokemonContext _context;

        public TypesController(PokemonContext context)
        {
            _context = context;
        }

        // GET: api/Types
        [HttpGet]
        public IEnumerable<Types> GetTypess()
        {
            return _context.Types;
        }

        // GET: api/Types/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var types = await _context.Types.FindAsync(id);

            if (types == null)
            {
                return NotFound();
            }

            return Ok(types);
        }

        /**********CUSTOM FILTER**********/
        //GET: api/Types/ByName
        [HttpGet("ByName/{types}")]
        public IEnumerable<Types> GetTypesByName(string types)
        {
            return _context.Types
                .Where(t => string.Equals(t.TypeName, types, StringComparison.OrdinalIgnoreCase));
        }

        //GET: api/Types/ByOne/fire
        [HttpGet("ByOne/{types}")]
        public IEnumerable<Types> GetTypesByOne(string types)
        {
            return _context.Types
                .Where(t => string.Equals(t.TypeOne, types, StringComparison.OrdinalIgnoreCase));
        }

        //GET: api/Types/Contains/fire
        [HttpGet("Contains/{types}")]
        public IEnumerable<Types> GetTypesContains(string types)
        {
            return _context.Types
                .Where(t => t.TypeName.Contains(types));
        }

        // PUT: api/Types/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypes([FromRoute] int id, [FromBody] Types types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != types.ID)
            {
                return BadRequest();
            }

            _context.Entry(types).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(types);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypesExists(id))
                {
                    ModelState.AddModelError("", "Concurrency Error: Type has been removed.");
                    return BadRequest(ModelState);
                }
                else
                {
                    ModelState.AddModelError("", "Concurrency Error: Type has been updated by another user. Cancel and trying editing the record again.");
                    return BadRequest(ModelState);
                }
            }
            catch (DbUpdateException dex)
            {
                if (dex.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError("", "Unable to save changes: Duplicate Type Name.");
                    return BadRequest(ModelState);
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes to the database. Try refreshing and trying again.");
                    return BadRequest(ModelState);
                }
            }
        }

        // POST: api/Types
        [HttpPost]
        public async Task<IActionResult> PostTypes([FromBody] Types types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Types.Add(types);
            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetTypes", new { id = types.ID }, types);
            }
            catch (DbUpdateException dex)
            {
                if (dex.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError("", "Unable to save: Duplicate TypeName.");
                    return BadRequest(ModelState);
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes to database. Try refreshing and trying again.");
                    return BadRequest(ModelState);
                }
            }
        }

        // DELETE: api/Types/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var types = await _context.Types.FindAsync(id);
            if (types == null)
            {
                return BadRequest("Delete Error: Type has already been deleted.");
            }
            try
            {
                _context.Types.Remove(types);
                await _context.SaveChangesAsync();
                return Ok(types);
            }
            catch (DbUpdateException dex)
            {
                if (dex.InnerException.Message.Contains("FK_"))
                {
                    return BadRequest("Unable to delete: Pokemon cannot be Typeless.");
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

        private bool TypesExists(int id)
        {
            return _context.Types.Any(e => e.ID == id);
        }
    }
}
