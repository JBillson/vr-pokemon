using System.Collections.Generic;

namespace Utilities
{
    public static class CombatPower
    {
        private static Dictionary<int, float> _cpByLevel = new ()
        {
            {1, 0.094f},
            {2, 0.16639787f},
            {3, 0.21573247f},
        };
        
        public static float GetCpm(int level)
        {
            return _cpByLevel[level];
        }
    }
    
}