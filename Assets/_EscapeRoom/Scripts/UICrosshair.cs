using UnityEngine;
using UnityEngine.UI;

namespace EscapeRoom
{
    [RequireComponent(typeof(Image))]
    public class UICrosshair : MonoBehaviour
    {
        public enum CrosshairStates
        {
            Default,
            Interactable,
        }

        [SerializeField] private Sprite _defaultCrosshairSprite = null;
        [SerializeField] private Sprite _interactableCrosshairSprite = null;
        private Sprite GetSpriteForState(CrosshairStates state)
        {
            switch (state)
            {
                case CrosshairStates.Default:
                    return _defaultCrosshairSprite;
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
                _crosshairImage.enabled = sprite != null;
                _crosshairImage.sprite = sprite;
                _crosshairImage.SetNativeSize();

            }
        }

        private Image _crosshairImage;

        private void OnEnable()
        {
            _crosshairImage = GetComponent<Image>();
        }
    }
}
