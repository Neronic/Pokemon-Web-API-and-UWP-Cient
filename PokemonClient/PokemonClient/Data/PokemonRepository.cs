using System;
using PokemonClient.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using PokemonClient.Models;

namespace PokemonClient.Data
{
    public class PokemonRepository : IPokemonRepository
    {
        HttpClient client = new HttpClient();

        public PokemonRepository()
        {
            client.BaseAddress = ProfessorOak.DBUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //Get single pokemon
        public async Task<Pokemon> GetPokemon(int PokemonID)
        {
            var response = await client.GetAsync($"/api/pokemons/{PokemonID}");
            if (response.IsSuccessStatusCode)
            {
                Pokemon pokemon = await response.Content.ReadAsAsync<Pokemon>();
                return pokemon;
            }
            else
            {
                return new Pokemon();
            }
        }

        //Get all pokemon
        public async Task<List<Pokemon>> GetPokemons()
        {
            var response = await client.GetAsync("/api/pokemons");
            if (response.IsSuccessStatusCode)
            {
                List<Pokemon> pokemons = await response.Content.ReadAsAsync<List<Pokemon>>();
                return pokemons;
            }
            else
            {
                return new List<Pokemon>();
            }
        }

        //Get Pokemon by name
        public async Task<Pokemon> GetPokemonsByName(string PokemonName)
        {
            var response = await client.GetAsync($"/api/pokemons/byname/{PokemonName}");
            if (response.IsSuccessStatusCode)
            {
                Pokemon pokemon = await response.Content.ReadAsAsync<Pokemon>();
                return pokemon;
            }
            else
            {
                return new Pokemon();
            }
        }

        //Get pokemon by route
        public async Task<List<Pokemon>> GetPokemonsByRoute(int RouteID)
        {
            var response = await client.GetAsync($"/api/pokemons/byroute/{RouteID}");
            if (response.IsSuccessStatusCode)
            {
                List<Pokemon> pokemons = await response.Content.ReadAsAsync<List<Pokemon>>();
                return pokemons;
            }
            else
            {
                return new List<Pokemon>();
            }
        }

        //Get pokemon by types
        public async Task<List<Pokemon>> GetPokemonsByTypes(int TypesID)
        {
            var response = await client.GetAsync($"/api/pokemons/bytypes/{TypesID}");
            if (response.IsSuccessStatusCode)
            {
                List<Pokemon> pokemons = await response.Content.ReadAsAsync<List<Pokemon>>();
                return pokemons;
            }
            else
            {
                return new List<Pokemon>();
            }
        }

        //Get pokemon by their name containing string
        public async Task<List<Pokemon>> GetPokemonsContains(string pokemon)
        {
            var response = await client.GetAsync($"/api/pokemons/contains/{pokemon}");
            if (response.IsSuccessStatusCode)
            {
                List<Pokemon> pokemons = await response.Content.ReadAsAsync<List<Pokemon>>();
                return pokemons;
            }
            else
            {
                return new List<Pokemon>();
            }
        }

        //Get pokemon by their type string
        public async Task<List<Pokemon>> GetPokemonsTypeIs(string types)
        {
            var response = await client.GetAsync($"/api/pokemons/typeis/{types}");
            if (response.IsSuccessStatusCode)
            {
                List<Pokemon> pokemons = await response.Content.ReadAsAsync<List<Pokemon>>();
                return pokemons;
            }
            else
            {
                return new List<Pokemon>();
            }
        }

        //Add Pokemon
        public async Task AddPokemon(Pokemon pokemonToAdd)
        {
            var response = await client.PostAsJsonAsync("/api/pokemons", pokemonToAdd);
            if (!response.IsSuccessStatusCode)
            {
                var ex = ProfessorOak.CreateApiException(response);
                throw ex;
            }
        }

        //Update Pokemon
        public async Task UpdatePokemon(Pokemon pokemonToUpdate)
        {
            var response = await client.PutAsJsonAsync($"/api/pokemons/{pokemonToUpdate.ID}", pokemonToUpdate);
            if (!response.IsSuccessStatusCode)
            {
                var ex = ProfessorOak.CreateApiException(response);
                throw ex;
            }
        }

        //Delete Pokemon
        public async Task DeletePokemon(Pokemon pokemonToDelete)
        {
            var response = await client.DeleteAsync($"/api/pokemons/{pokemonToDelete.ID}");
            if (!response.IsSuccessStatusCode)
            {
                var ex = ProfessorOak.CreateApiException(response);
                throw ex;
            }
        }
    }
}
