using UnityEngine;

namespace EscapeRoom
{
    public class BooksManager : MonoBehaviour
    {
        private UIManager _uiManager = null;
        [SerializeField] private BookInteractable[] _books = null;

        public void Initialize(UIManager uiManager)
        {
            _uiManager = uiManager;
        }

        private void OnEnable()
        {
            foreach (var book in _books)
            {
                book.OnInteractedWith += HandleBookInteractedWith;
            }
        }

        private void OnDisable()
        {
            foreach (var book in _books)
            {
                book.OnInteractedWith -= HandleBookInteractedWith;
            }
        }

        private void HandleBookInteractedWith(Book book)
        {
            _uiManager.PresentBook(book);
        }
    }
}