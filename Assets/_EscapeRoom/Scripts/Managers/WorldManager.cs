using Sirenix.OdinInspector;
using UnityEngine;

namespace EscapeRoom
{
    public class WorldManager : MonoBehaviour
    {
        [Title(("Managers"))] 
        [SerializeField] private UIManager _uiManager = null;

        [SerializeField] private BooksManager _booksManager = null;

        public void Start()
        {
            _booksManager.Initialize(_uiManager);
            
            StateManager.Instance.SetState(State.Play);
        }
    }
}