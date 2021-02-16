using System;
using UnityEngine;

namespace EscapeRoom
{
    public class BookInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private Book _book = null;

        public event Action<Book> OnInteractedWith;
        
        public void InteractWith(Player player)
        {
            if (OnInteractedWith != null)
            {
                OnInteractedWith(_book);
            }
        }
    }
}