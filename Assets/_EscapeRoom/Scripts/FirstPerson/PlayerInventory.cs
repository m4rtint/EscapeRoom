using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeRoom
{
    [Serializable]
    public class PlayerInventory
    {
        public event System.Action<GenericItem> OnSelectedItemChanged;

        public GenericItem SelectedItem { get; private set; }

        [ReadOnly] [SerializeField] private List<GenericItem> _items = new List<GenericItem>();
        private int _selectedItemIndex = 0;

        public void SelectNextItem()
        {
            if (_items.Count == 0) return;
            _selectedItemIndex = (_selectedItemIndex + 1) % _items.Count;
        }

        public void SelectPreviousItem()
        {
            if (_items.Count == 0) return;
            _selectedItemIndex = (_selectedItemIndex - 1) % _items.Count;
        }

        public void SelectItem(int index)
        {
            if (index < 0 || index >= _items.Count)
                throw new System.ArgumentOutOfRangeException(nameof(index));
        }

        public void AddItem(GenericItem item)
        {
            Debug.Log($"Giving player item '{item.Name}'");

            _items.Add(item);
            // Auto select the item
            SelectItem(_items.Count - 1);
        }
    }
}