using PokemonClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonClient.Data
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetRegions();
        Task<Region> GetRegion(int RegionID);
        Task<Region> GetRegionsByName(string RegionName);
        Task<List<Region>> GetRegionsContains(string region);
        Task AddRegion(Region regionToAdd);
        Task UpdateRegion(Region regionToUpdate);
        Task DeleteRegion(Region regionToDelete);
    }
}
