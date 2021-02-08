using UnityEngine;
using UnityEngine.UI;

namespace EscapeRoom
{
    public class UICrosshair : MonoBehaviour
    {
        public enum CrosshairStates
        {
            None,
            Interactable,
        }

        [SerializeField] private Image _crosshairImage = null;
        [SerializeField] private Sprite _noneCrosshairSprite = null;
        [SerializeField] private Sprite _interactableCrosshairSprite = null;
        private Sprite GetSpriteForState(CrosshairStates state)
        {
            switch (state)
            {
                case CrosshairStates.None:
                    return _noneCrosshairSprite;
                case CrosshairStates.Interactable:
                    return _interactableCrosshairSprite;
                default:
                    throw new System.Exception($"Unsupported crosshair state: {state}");
            }
        }


        private CrosshairStates _state;
        public CrosshairStates State
        {
            get => _state;
            set
            {
                if (_state == value)
                    return;

                _state = value;
                var sprite = GetSpriteForState(_state);
                _crosshairImage.sprite = sprite;
                _crosshairImage.SetNativeSize();

            }
        }
    }
}
