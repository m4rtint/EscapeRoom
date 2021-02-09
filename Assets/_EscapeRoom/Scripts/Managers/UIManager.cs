using System;
using UnityEngine;

namespace EscapeRoom
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private BookBehaviour _bookBehaviour = null;

        public void PresentBook(Book book)
        {
            _bookBehaviour.SetBook(book);
            _bookBehaviour.gameObject.SetActive(true);
        }
        
        private void OnEnable()
        {
            StateManager.Instance.OnStateChanged += HandleOnStateChanged;
            _bookBehaviour.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            StateManager.Instance.OnStateChanged -= HandleOnStateChanged;
        }

        private void HandleOnStateChanged(State state)
        {
            switch (state)
            {
                case State.Play:
                    HandleOnPlay();
                    break;
                case State.Reading:
                    HandleOnReading();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void HandleOnPlay()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void HandleOnReading()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}