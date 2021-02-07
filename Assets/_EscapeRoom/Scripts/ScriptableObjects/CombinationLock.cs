using UnityEngine;

namespace EscapeRoom
{
    [CreateAssetMenu(fileName = "CombinationLock", menuName = "EscapeRoom/CombinationLock", order = 1)]
    public class CombinationLock : ScriptableObject
    {
        public int Answer = 0;
        public Sprite[] SpriteCombinations = null;
    }
}
