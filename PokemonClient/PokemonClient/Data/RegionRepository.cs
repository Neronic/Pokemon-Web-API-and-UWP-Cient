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
    public class RegionRepository : IRegionRepository
    {
        HttpClient client = new HttpClient();

        public RegionRepository()
        {
            client.BaseAddress = ProfessorOak.DBUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //Get Region by ID
        public async Task<Region> GetRegion(int RegionID)
        {
            var response = await client.GetAsync($"/api/regions/{RegionID}");
            if (response.IsSuccessStatusCode)
            {
                Region region = await response.Content.ReadAsAsync<Region>();
                return region;
            }
            else
            {
                return new Region();
            }
        }

        //Get regions
        public async Task<List<Region>> GetRegions()
        {
            var response = await client.GetAsync("/api/regions");
            if (response.IsSuccessStatusCode)
            {
                List<Region> regions = await response.Content.ReadAsAsync<List<Region>>();
                return regions;
            }
            else
            {
                return new List<Region>();
            }
        }

        //Get Region by name
        public async Task<Region> GetRegionsByName(string RegionName)
        {
            var response = await client.GetAsync($"/api/regions/byname/{RegionName}");
            if (response.IsSuccessStatusCode)
            {
                Region region = await response.Content.ReadAsAsync<Region>();
                return region;
            }
            else
            {
                return new Region();
            }
        }

        //Get Region by name contains string
        public async Task<List<Region>> GetRegionsContains(string region)
        {
            var response = await client.GetAsync($"/api/regions/contains/{region}");
            if (response.IsSuccessStatusCode)
            {
                List<Region> r = await response.Content.ReadAsAsync<List<Region>>();
                return r;
            }
            else
            {
                return new List<Region>();
            }
        }

        //Add Region
        public async Task AddRegion(Region regionToAdd)
        {
            var response = await client.PostAsJsonAsync("/api/regions", regionToAdd);
            if (!response.IsSuccessStatusCode)
            {
                var ex = ProfessorOak.CreateApiException(response);
                throw ex;
            }
        }

        //Update Region
        public async Task UpdateRegion(Region regionToUpdate)
        {
            var response = await client.PutAsJsonAsync($"/api/regions/{regionToUpdate.ID}", regionToUpdate);
            if (!response.IsSuccessStatusCode)
            {
                var ex = ProfessorOak.CreateApiException(response);
                throw ex;
            }
        }

        //Delete Region
        public async Task DeleteRegion(Region regionToDelete)
        {
            var response = await client.DeleteAsync($"/api/regions/{regionToDelete.ID}");
            if (!response.IsSuccessStatusCode)
            {
                var ex = ProfessorOak.CreateApiException(response);
                throw ex;
            }
        }
    }
}
