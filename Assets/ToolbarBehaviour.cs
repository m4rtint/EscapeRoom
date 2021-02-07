using System;
using UnityEngine;

namespace EscapeRoom
{
    public class ToolbarBehaviour : MonoBehaviour
    {
        private const string InputMouseScrollWheel = "Mouse ScrollWheel";
        [SerializeField] private RectTransform _selectedSlot = null;

        private Toolbar _toolbar = null;
        
        private void OnEnable()
        {
            _toolbar = new Toolbar();
            _toolbar.OnSlotChange += OnHandSlotChange;
        }

        private void OnDisable()
        {
            _toolbar.OnSlotChange -= OnHandSlotChange;
        }

        private void Start()
        {
            _toolbar.UpdateSelectedToolIndex(0);
        }

        private void Update()
        {
            var scrollDirection = (int) Input.GetAxis(InputMouseScrollWheel);
            if (scrollDirection != 0)
            {
                _toolbar.UpdateSelectedToolIndex(scrollDirection);
            }
        }

        private void OnHandSlotChange(Vector2 position)
        {
            _selectedSlot.anchoredPosition = position;
        }
        
    }

    public class Toolbar
    {
        private const float OffsetStart = 50f;
        private const float OffsetPosition = 100f;
        private const int NumberOfToolbarSlots = 11;
        private int _selectedToolIndex = 0;

        public event Action<Vector2> OnSlotChange;

        private Vector2 GetSlotPosition()
        {
            var position = (_selectedToolIndex * OffsetPosition) + OffsetStart;
            return new Vector2(position, 0);
        }

        public void UpdateSelectedToolIndex(int direction)
        {
            _selectedToolIndex += direction;
            if (_selectedToolIndex >= NumberOfToolbarSlots)
            {
                _selectedToolIndex = 0;
            }
            
            if (_selectedToolIndex < 0)
            {
                _selectedToolIndex = NumberOfToolbarSlots - 1;
            }
            

            if (OnSlotChange != null)
            {
                OnSlotChange(GetSlotPosition());
            }
        }
    }
}