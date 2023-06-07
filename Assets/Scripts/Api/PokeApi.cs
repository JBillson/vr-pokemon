using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace Api
{
    public class PokeApi
    {
        private static PokeApi _instance;
        public static PokeApi Instance => _instance ??= new PokeApi();

        private readonly List<Pokemon> _cachedPokemon = new();

        public async Task<Pokemon> GetPokemonByNameAsync(string pokemonName)
        {
            // get from cache
            var pokemon = GetFromCache(pokemonName);
            if (pokemon != null)
            {
                Debug.Log($"Returning [{pokemon.name}] from cache");
                return pokemon;
            }

            // get from api
            var url = new Uri($"https://pokeapi.co/api/v2/pokemon/{pokemonName}");
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;
            var pokemonResponse = await response.Content.ReadAsStringAsync();
            pokemon = JsonConvert.DeserializeObject<Pokemon>(pokemonResponse);
            
            Debug.Log($"Returning [{pokemon.name}] from API");
            AddToCache(pokemon);
            return pokemon;
        }

        private void AddToCache(Pokemon pokemon)
        {
            if (_cachedPokemon.Contains(pokemon)) return;

            Debug.Log($"Adding [{pokemon.name}] to cache");
            _cachedPokemon.Add(pokemon);
        }

        private Pokemon GetFromCache(string pokemonName)
        {
            return _cachedPokemon.FirstOrDefault(x => x.name == pokemonName);
        }
    }
}