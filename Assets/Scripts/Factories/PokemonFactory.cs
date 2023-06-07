using System.Threading.Tasks;
using Api;

namespace Factories
{
    public class PokemonFactory
    {
        private static PokemonFactory _instance;
        public static PokemonFactory Instance => _instance ?? new PokemonFactory();
        
        public async Task<Pokemon> CreatePokemon(string pokemonName)
        {
            var pokemon = await PokeApi.Instance.GetPokemonByNameAsync(pokemonName);
            return pokemon;
        }
    }
}