using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Api
{
    public class PokeApi
    {
        private static PokeApi _instance;
        public static PokeApi Instance => _instance ??= new PokeApi();

        public async Task<Pokemon> GetPokemonByNameAsync(string pokemonName)
        {
            var url = new Uri($"https://pokeapi.co/api/v2/pokemon/{pokemonName}");
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;
            var pokemon = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Pokemon>(pokemon);
        }
    }
}