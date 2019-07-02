using PokemonClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonClient.Data
{
    public interface ITypesRepository
    {
        Task<List<Types>> GetTypess();
        Task<Types> GetTypes(int TypesID);
        Task<Types> GetTypesByName(string TypeName);
        Task<List<Types>> GetTypesByOne(string TypeOne);
        Task<List<Types>> GetTypesContains(string types);
        Task AddTypes(Types typesToAdd);
        Task UpdateTypes(Types typesToUpdate);
        Task DeleteTypes(Types typesToDelete);
    }
}
