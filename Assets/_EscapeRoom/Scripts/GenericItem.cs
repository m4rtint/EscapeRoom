using UnityEngine;

namespace EscapeRoom
{
    [CreateAssetMenu(fileName = "Item", menuName = "EscapeRoom/Create Item", order = 0)]
    public class GenericItem : ScriptableObject
    {
        public string Name;

        public Sprite ItemSprite;

        public Mesh ItemModel;
        public Material ItemMaterial;
    }
}
