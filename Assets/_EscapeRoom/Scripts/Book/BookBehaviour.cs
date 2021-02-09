using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EscapeRoom
{
    public class BookBehaviour : MonoBehaviour
    {
        [SerializeField] private Book _book = null;
        [Title("Components")]
        [SerializeField] private TMP_Text _title = null;
        [SerializeField] private Button _backButton = null;
        [SerializeField] private Button _forwardButton = null;
        [SerializeField] private PageBehaviour _leftPageView = null;
        [SerializeField] private PageBehaviour _rightPageView = null;

        private int _pageNumber = 0;

        private int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = Mathf.Clamp(value, 0, _book.Pages.Length - 1);
        }

        public void SetBook(Book book)
        {
            _book = book;
        }

        private void OnEnable()
        {
            PageNumber = 0;
            _backButton.onClick.AddListener(() =>
            {
                UpdatePage(false);
            });
            _forwardButton.onClick.AddListener(() =>
            {
                UpdatePage(true);
            });
            
            StateManager.Instance.SetState(State.Reading);
        }

        private void OnDisable()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            StateManager.Instance.SetState(State.Play);
            _backButton.onClick.RemoveAllListeners();
            _forwardButton.onClick.RemoveAllListeners();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && StateManager.Instance.GetState() == State.Reading)
            {
                gameObject.SetActive(false);
            }
        }

        private void Start()
        {
            SetTitle();
            SetPages();
        }

        private void SetTitle()
        {
            _title.text = _book.Title;
        }

        private void UpdatePage(bool isForward)
        {
            var direction = isForward ? 1 : -1;
            PageNumber += direction * 2;
            SetPages();
        }
        
        private void SetPages()
        {
            var leftPage = 0;
            var rightPage = 0;
            if (PageNumber % 2 == 0)
            {
                leftPage = PageNumber;
                rightPage = PageNumber + 1;
            }
            else
            {
                leftPage = PageNumber - 1;
                rightPage = PageNumber;
            }
            
            
            _leftPageView.SetPage(_book.Pages[leftPage], leftPage + 1);
            if (rightPage < _book.Pages.Length)
            {
                _rightPageView.SetPage(_book.Pages[rightPage], rightPage + 1);
            }
            else
            {
                // Empty Page
                _rightPageView.SetPage(new Page());
            }
        }
    }
}