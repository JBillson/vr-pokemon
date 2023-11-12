using Api;

namespace Models
{
    public abstract class Pokemon
    {
        public int level { get; private set; } = 1;
        public PokemonData data { get; }


        protected Pokemon(string pokemonName)
        {
            data = PokeApi.Instance.GetPokemonDataByNameAsync(pokemonName).Result;
        }

        public void LevelUp()
        {
            level++;
        }
    }
}