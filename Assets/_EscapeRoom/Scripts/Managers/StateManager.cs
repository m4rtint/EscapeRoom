using System;

namespace EscapeRoom
{
    public enum State
    {
        Play,
        Reading
    }
    
    /// <summary>
    /// The 'Singleton' class
    /// </summary>
    public class StateManager
    {
        private static readonly StateManager _instance = new StateManager();

        private State _gameState = State.Play;
        public event Action<State> OnStateChanged;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static StateManager()
        {
        }

        private StateManager()
        {
        }

        public static StateManager Instance
        {
            get { return _instance; }
        }
        
        public State GetState()
        {
            return _gameState;
        }
        
        public void SetState(State state)
        {
            _gameState = state;
            OnStateChanged?.Invoke(state);
        }
    }
}