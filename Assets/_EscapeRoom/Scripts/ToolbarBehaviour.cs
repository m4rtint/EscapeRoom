using System;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeRoom
{
    public class ToolbarBehaviour : MonoBehaviour
    {
        [SerializeField] private RectTransform _selectedSlot = null;
        [SerializeField] private List<ItemSlot> _itemSlots = new List<ItemSlot>();
        private ItemSlot _currentSelectedSlot = null;

        public int NumberOfToolbarSlots { get; set; } = 11;

        private void Start()
        {
            _itemSlots = new List<ItemSlot>(GetComponentsInChildren<ItemSlot>());

            // Start by positioning the select item at position 0
            ChangeSelectedSlot(0);
            SetItems(null);
        }

        public void SetItems(IReadOnlyList<GenericItem> items)
        {
            int count = items?.Count ?? 0;
            int i;

            // Activate toolbar slots for the first items
            for (i = 0; i < count; i++)
            {
                _itemSlots[i].SetItem(items[i]);
            }

            // Deactivate the remaining toolbar slots
            for (; i < _itemSlots.Count; i++)
            {
                _itemSlots[i].SetItem(null);
            }
        }

        public void ChangeSelectedSlot(int itemIndex)
        {
            _currentSelectedSlot?.SetSelected(false);
            _currentSelectedSlot = _itemSlots[itemIndex];
            _currentSelectedSlot.SetSelected(true);
        }
    }
}