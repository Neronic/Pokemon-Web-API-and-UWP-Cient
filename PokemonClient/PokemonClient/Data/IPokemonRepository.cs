using PokemonClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonClient.Data
{
    public interface IPokemonRepository
    {
        Task<List<Pokemon>> GetPokemons();
        Task<Pokemon> GetPokemon(int PokemonID);
        Task<Pokemon> GetPokemonsByName(string PokemonName);
        Task<List<Pokemon>> GetPokemonsByRoute(int RouteID);
        Task<List<Pokemon>> GetPokemonsByTypes(int TypesID);
        Task<List<Pokemon>> GetPokemonsContains(string pokemon);
        Task<List<Pokemon>> GetPokemonsTypeIs(string types);
        Task AddPokemon(Pokemon pokemonToAdd);
        Task UpdatePokemon(Pokemon pokemonToUpdate);
        Task DeletePokemon(Pokemon pokemonToDelete);
    }
}
