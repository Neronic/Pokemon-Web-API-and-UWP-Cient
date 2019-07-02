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
    public class PokemonsController : ControllerBase
    {
        private readonly PokemonContext _context;

        public PokemonsController(PokemonContext context)
        {
            _context = context;
        }

        // GET: api/Pokemons
        [HttpGet]
        public IEnumerable<Pokemon> GetPokemons()
        {
            return _context.Pokemon.Include(t => t.Types)
                .Include(r => r.Route);
        }

        // GET: api/Pokemons/2
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPokemon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pokemon = await _context.Pokemon
                .Include(t => t.Types)
                .Include(r => r.Route)
                .FirstOrDefaultAsync(p => p.ID == id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon);
        }

        /**********CUSTOM FILTERS**********/

        //GET: api/Pokemons/ByTypes/33
        [HttpGet("ByTypes/{id}")]
        public IEnumerable<Pokemon> GetPokemonsByTypes(int id)
        {
            return _context.Pokemon.Include(t => t.Types)
                .Include(r => r.Route)
                .Where(t => t.TypesID == id);
        }

        //GET: api/Pokemons/ByRoute/60
        [HttpGet("ByRoute/{id}")]
        public IEnumerable<Pokemon> GetPokemonsByRoute(int id)
        {
            return _context.Pokemon.Include(r => r.Route)
                .Include(t => t.Types)
                .Where(r => r.RouteID == id);
        }

        //GET: api/Pokemons/ByName
        [HttpGet("ByName/{pokemon}")]
        public IEnumerable<Pokemon> GetPokemonsByName(string pokemon)
        {
            return _context.Pokemon
                .Include(t => t.Types)
                .Include(r => r.Route)
                .Where(p => string.Equals(p.Name, pokemon, StringComparison.OrdinalIgnoreCase));
        }

        //GET: api/Pokemons/Contains/b
        [HttpGet("Contains/{pokemon}")]
        public IEnumerable<Pokemon> GetPokemonsContains(string pokemon)
        {
            return _context.Pokemon
                .Include(t => t.Types)
                .Include(r => r.Route)
                .Where(p => p.Name.Contains(pokemon));
        }

        //GET: api/Pokemons/TypeIs/Rock
        [HttpGet("TypeIs/{types}")]
        public IEnumerable<Pokemon> GetPokemonsTypeIs(string types)
        {
            return _context.Pokemon
                .Include(t => t.Types)
                .Include(r => r.Route)
                .Where(p => p.Types.TypeName.Contains(types));
        }

        // PUT: api/Pokemons/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPokemon([FromRoute] int id, [FromBody] Pokemon pokemon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pokemon.ID)
            {
                return BadRequest();
            }

            _context.Entry(pokemon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(pokemon);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonExists(id))
                {
                    ModelState.AddModelError("", "Concurrency Error: Pokemon has been removed.");
                    return BadRequest(ModelState);
                }
                else
                {
                    ModelState.AddModelError("", "Concurrency Error: Pokemon has been updated by another user. Cancel and trying editing the record again.");
                    return BadRequest(ModelState);
                }
            }
            catch (DbUpdateException dex)
            {
                if (dex.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError("", "Unable to save changes: Duplicate Number, trying again.");
                    return BadRequest(ModelState);
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes to the database. Try refreshing and trying again.");
                    return BadRequest(ModelState);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                ModelState.AddModelError("", "Unable to save changes, Number is out of range.");
                return BadRequest(ModelState);
            }
        }

        // POST: api/Pokemons
        [HttpPost]
        public async Task<IActionResult> PostPokemon([FromBody] Pokemon pokemon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pokemon.Add(pokemon);
            if(pokemon.Number > 807 || pokemon.Number < 1)
            {
                ModelState.AddModelError("", "Unable to save changes. Number is out of range");
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetPokemon", new { id = pokemon.ID }, pokemon);
                }
                catch (DbUpdateException dex)
                {
                    if (dex.InnerException.Message.Contains("IX_"))
                    {
                        ModelState.AddModelError("", "Unable to save: Duplicate Number.");
                        return BadRequest(ModelState);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes to database. Try refreshing and trying again.");
                        return BadRequest(ModelState);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    ModelState.AddModelError("", "Unable to save changes, Number is out of range.");
                    return BadRequest(ModelState);
                }
            }
            /*try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetPokemon", new { id = pokemon.ID }, pokemon);
            }
            catch (DbUpdateException dex)
            {
                if (dex.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError("", "Unable to save: Duplicate Number.");
                    return BadRequest(ModelState);
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes to database. Try refreshing and trying again.");
                    return BadRequest(ModelState);
                }
            }
            catch (IndexOutOfRangeException)
            {
                ModelState.AddModelError("", "Unable to save changes, Number is out of range.");
                return BadRequest(ModelState);
            }*/
        }

        // DELETE: api/Pokemons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pokemon = await _context.Pokemon.FindAsync(id);
            if (pokemon == null)
            {
                ModelState.AddModelError("", "Delete Error: Pokemon has already been deleted.");
            }
            else
            {
                try
                {
                    _context.Pokemon.Remove(pokemon);
                    await _context.SaveChangesAsync();
                    return Ok(pokemon);
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Delete Error: Unable to delete Pokemon.");
                }
            }
            return BadRequest(ModelState);
        }

        private bool PokemonExists(int id)
        {
            return _context.Pokemon.Any(e => e.ID == id);
        }
    }
}
