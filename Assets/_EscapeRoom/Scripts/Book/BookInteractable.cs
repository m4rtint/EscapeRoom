using UnityEngine;

namespace EscapeRoom
{
    public class BookInteractable : MonoBehaviour, IInteractable
    {
        public void InteractWith(Player player)
        {
            Debug.Log("Interact with book!");
        }
    }
}