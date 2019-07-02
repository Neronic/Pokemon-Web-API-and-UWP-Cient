using PokemonClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonClient.Data
{
    public interface IRouteRepository
    {
        Task<List<Route>> GetRoutes();
        Task<Route> GetRoute(int RouteID);
        Task<Route> GetRoutesByName(string RouteName);
        Task<List<Route>> GetRoutesByRegion(int RegionID);
        Task<List<Route>> GetRoutesRegionContains(string region);
        Task AddRoute(Route routeToAdd);
        Task UpdateRoute(Route routeToUpdate);
        Task DeleteRoute(Route routeToDelete);
    }
}
