using System.Collections;
using Models;
using UnityEngine;
using Utilities;

namespace Pokeballs
{
    public abstract class PokeBallBase : MonoBehaviour
    {
        public const float BallFactor = 1;
        
        public virtual void Throw(Pokemon pokemon){}

        public virtual IEnumerator TryCatch(Pokemon pokemon)
        {
            yield return null;
        }

        public virtual void Break()
        {
        }

        public virtual void Catch()
        {
        }
        
        public float GetCatchProbability(Pokemon pokemon)
        {
            return BallFactor / (2 * CombatPower.GetCpm(pokemon.level));
        }
    }
}