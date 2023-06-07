using Api;
using UnityEngine;

namespace Factories
{
    public class PokemonFactory : MonoBehaviour
    {
        public PokemonInstance pokemonPrefab;

        private static PokemonFactory _instance;
        public static PokemonFactory Instance => _instance ??= FindObjectOfType<PokemonFactory>();

        public async void CreatePokemon(string pokemonName)
        {
            var pokemon = await PokeApi.Instance.GetPokemonByNameAsync(pokemonName);
            if (pokemon == null) return;
            var instance = Instantiate(pokemonPrefab, Vector3.zero, Quaternion.identity);
            instance.Init(pokemon);
        }
    }
}