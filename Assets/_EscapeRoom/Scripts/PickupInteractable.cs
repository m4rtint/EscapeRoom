using UnityEngine;

namespace EscapeRoom
{
    public class PickupInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private GenericItem _itemObject = null;

        public void InteractWith(Player player)
        {
            player.Inventory.AddItem(_itemObject);
            Destroy(this.gameObject);
        }
    }
}
