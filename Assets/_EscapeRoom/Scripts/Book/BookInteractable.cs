using UnityEngine;

namespace EscapeRoom
{
    public class BookInteractable : MonoBehaviour, IInteractable
    {
        public void InteractWith()
        {
            Debug.Log("Interact with book!");
        }
    }
}