﻿using Api;
using Instances;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Factories
{
    public class PokemonFactory : MonoBehaviour
    {
        public PokemonInstance pokemonPrefab;

        private static PokemonFactory _instance;
        public static PokemonFactory Instance => _instance ??= FindObjectOfType<PokemonFactory>();

        [Button(ButtonStyle.FoldoutButton)]
        public async void CreatePokemon(string pokemonName)
        {
#if UNITY_EDITOR
            if (pokemonName.IsNullOrWhitespace())
                pokemonName = "pikachu";
#endif

            var pokemon = await PokeApi.Instance.GetPokemonDataByNameAsync(pokemonName);
            if (pokemon == null) return;
            var instance = Instantiate(pokemonPrefab, Vector3.zero, Quaternion.identity);
            instance.Init(pokemon);
        }
    }
}