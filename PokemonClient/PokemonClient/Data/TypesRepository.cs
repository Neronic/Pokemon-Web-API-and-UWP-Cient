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
    public class TypesRepository : ITypesRepository
    {
        HttpClient client = new HttpClient();

        public TypesRepository()
        {
            client.BaseAddress = ProfessorOak.DBUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //Get Types by ID
        public async Task<Types> GetTypes(int TypesID)
        {
            var response = await client.GetAsync($"/api/types/{TypesID}");
            if (response.IsSuccessStatusCode)
            {
                Types types = await response.Content.ReadAsAsync<Types>();
                return types;
            }
            else
            {
                return new Types();
            }
        }

        //Get Types by TypeOne
        public async Task<List<Types>> GetTypesByOne(string TypeOne)
        {
            var response = await client.GetAsync($"/api/types/byOne/{TypeOne}");
            if (response.IsSuccessStatusCode)
            {
                List<Types> types = await response.Content.ReadAsAsync<List<Types>>();
                return types;
            }
            else
            {
                return new List<Types>();
            }
        }

        //Get Types by Name
        public async Task<Types> GetTypesByName(string TypeName)
        {
            var response = await client.GetAsync($"/api/types/byname/{TypeName}");
            if (response.IsSuccessStatusCode)
            {
                Types types = await response.Content.ReadAsAsync<Types>();
                return types;
            }
            else
            {
                return new Types();
            }
        }

        //Get Types
        public async Task<List<Types>> GetTypess()
        {
            var response = await client.GetAsync("/api/types");
            if (response.IsSuccessStatusCode)
            {
                List<Types> types = await response.Content.ReadAsAsync<List<Types>>();
                return types;
            }
            else
            {
                return new List<Types>();
            }
        }

        //Get Types Name contains string
        public async Task<List<Types>> GetTypesContains(string types)
        {
            var response = await client.GetAsync($"/api/types/contains/{types}");
            if (response.IsSuccessStatusCode)
            {
                List<Types> t = await response.Content.ReadAsAsync<List<Types>>();
                return t;
            }
            else
            {
                return new List<Types>();
            }
        }

        //Add Types
        public async Task AddTypes(Types typesToAdd)
        {
            var response = await client.PostAsJsonAsync("/api/types", typesToAdd);
            if (!response.IsSuccessStatusCode)
            {
                var ex = ProfessorOak.CreateApiException(response);
                throw ex;
            }
        }

        //Update Types
        public async Task UpdateTypes(Types typesToUpdate)
        {
            var response = await client.PutAsJsonAsync($"/api/types/{typesToUpdate.ID}", typesToUpdate);
            if (!response.IsSuccessStatusCode)
            {
                var ex = ProfessorOak.CreateApiException(response);
                throw ex;
            }
        }

        //Delete Types
        public async Task DeleteTypes(Types typesToDelete)
        {
            var response = await client.DeleteAsync($"/api/types/{typesToDelete.ID}");
            if (!response.IsSuccessStatusCode)
            {
                var ex = ProfessorOak.CreateApiException(response);
                throw ex;
            }
        }
    }
}
