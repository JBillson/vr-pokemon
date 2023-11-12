using System.Collections;
using Models;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pokeballs
{
    public class PokeBall : PokeBallBase
    {
        private const string LogTag = "[PokeBall]";
        private Pokemon _pokemon;
        private int _catchAttempts;
        
        public override void Throw(Pokemon pokemon)
        {
            base.Throw(pokemon);
            
            Debug.Log($"{LogTag} Used");
            StartCoroutine(TryCatch(_pokemon));
        }

        public override IEnumerator TryCatch(Pokemon pokemon)
        {
            if (_catchAttempts > 3)
            {
                Break();
                yield break;
            }
            
            yield return new WaitForSeconds(1);

            var catchProbability = GetCatchProbability(pokemon);
            var rand = Random.Range(0, 100);
            if (catchProbability > rand)
            {
                Catch();
                yield break;
            }
            
            _catchAttempts++;
        }

        public override void Catch()
        {
            Debug.Log($"{LogTag} {_pokemon.data.name} caught!");
            base.Catch();
        }

        public override void Break()
        {
            Debug.Log($"{LogTag} Catch failed");
            base.Break();
        }
    }
}