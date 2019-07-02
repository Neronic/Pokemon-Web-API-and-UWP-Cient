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
    public class RouteRepository : IRouteRepository
    {
        HttpClient client = new HttpClient();

        public RouteRepository()
        {
            client.BaseAddress = ProfessorOak.DBUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //Get Route by ID
        public async Task<Route> GetRoute(int RouteID)
        {
            var response = await client.GetAsync($"/api/routes/{RouteID}");
            if (response.IsSuccessStatusCode)
            {
                Route route = await response.Content.ReadAsAsync<Route>();
                return route;
            }
            else
            {
                return new Route();
            }
        }

        //Get Routes
        public async Task<List<Route>> GetRoutes()
        {
            var response = await client.GetAsync("/api/routes");
            if (response.IsSuccessStatusCode)
            {
                List<Route> routes = await response.Content.ReadAsAsync<List<Route>>();
                return routes;
            }
            else
            {
                return new List<Route>();
            }
        }

        //Get Route by Name
        public async Task<Route> GetRoutesByName(string RouteName)
        {
            var response = await client.GetAsync($"/api/routes/byname/{RouteName}");
            if (response.IsSuccessStatusCode)
            {
                Route route = await response.Content.ReadAsAsync<Route>();
                return route;
            }
            else
            {
                return new Route();
            }
        }

        //Get Route by Region ID
        public async Task<List<Route>> GetRoutesByRegion(int RegionID)
        {
            var response = await client.GetAsync($"/api/routes/byregion/{RegionID}");
            if (response.IsSuccessStatusCode)
            {
                List<Route> routes = await response.Content.ReadAsAsync<List<Route>>();
                return routes;
            }
            else
            {
                return new List<Route>();
            }
        }

        //Get Route by Region name contains string
        public async Task<List<Route>> GetRoutesRegionContains(string region)
        {
            var response = await client.GetAsync($"/api/routes/regionis/{region}");
            if (response.IsSuccessStatusCode)
            {
                List<Route> routes = await response.Content.ReadAsAsync<List<Route>>();
                return routes;
            }
            else
            {
                return new List<Route>();
            }
        }

        //Add Route
        public async Task AddRoute(Route routeToAdd)
        {
            var response = await client.PostAsJsonAsync("/api/routes", routeToAdd);
            if (!response.IsSuccessStatusCode)
            {
                var ex = ProfessorOak.CreateApiException(response);
                throw ex;
            }
        }

        //Update Route
        public async Task UpdateRoute(Route routeToUpdate)
        {
            var response = await client.PutAsJsonAsync($"/api/routes/{routeToUpdate.ID}", routeToUpdate);
            if (!response.IsSuccessStatusCode)
            {
                var ex = ProfessorOak.CreateApiException(response);
                throw ex;
            }
        }

        //Delete Route
        public async Task DeleteRoute(Route routeToDelete)
        {
            var response = await client.DeleteAsync($"/api/routes/{routeToDelete.ID}");
            if (!response.IsSuccessStatusCode)
            {
                var ex = ProfessorOak.CreateApiException(response);
                throw ex;
            }
        }
    }
}
