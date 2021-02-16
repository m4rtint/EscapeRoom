using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeRoom
{
    [Serializable]
    public class PlayerInventory
    {
        public event System.Action<int, GenericItem> OnSelectedItemChanged;
        public event System.Action<int> OnItemCountChanged;

        public GenericItem SelectedItem { get; private set; }

        public IReadOnlyList<GenericItem> Items => _items.AsReadOnly();
        [ReadOnly] [SerializeField] private List<GenericItem> _items = new List<GenericItem>();
        private int _selectedItemIndex = 0;

        public void SelectNextItem()
        {
            if (_items.Count == 0) return;
            _selectedItemIndex = (_selectedItemIndex + 1) % _items.Count;
            //Debug.Log($"Next: {_selectedItemIndex}");
            SelectItem(_selectedItemIndex);
        }

        public void SelectPreviousItem()
        {
            if (_items.Count == 0) return;
            _selectedItemIndex = (_selectedItemIndex - 1) % _items.Count;
            if (_selectedItemIndex < 0)
                _selectedItemIndex += _items.Count;
            //Debug.Log($"Prev: {_selectedItemIndex}");
            SelectItem(_selectedItemIndex);
        }

        public void SelectItem(int index)
        {
            if (index < 0 || index >= _items.Count)
                throw new System.ArgumentOutOfRangeException(nameof(index));
            _selectedItemIndex = index;
            SelectedItem = _items[index];
            OnSelectedItemChanged?.Invoke(index, SelectedItem);
        }

        public void AddItem(GenericItem item)
        {
            Debug.Log($"Giving player item '{item.Name}'");

            _items.Add(item);
            // Auto select the item
            //Debug.Log($"Curr: {_items.Count - 1}");
            SelectItem(_items.Count - 1);

            OnItemCountChanged?.Invoke(_items.Count);
        }
    }
}