using System;
using UnityEngine;

namespace EscapeRoom
{
    public class BookInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private Book _book = null;

        public event Action<Book> OnInteractedWith;
        
        public void InteractWith()
        {
            if (OnInteractedWith != null)
            {
                OnInteractedWith(_book);
            }
        }
    }
}