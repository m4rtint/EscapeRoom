using UnityEngine;
using UnityEngine.UI;

namespace EscapeRoom
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField] private GameObject _selectedFrame;
        [SerializeField] private Image _itemImage;

        public void SetItem(GenericItem item)
        {
            _itemImage.sprite = item?.ItemSprite;
            gameObject.SetActive(item != null);
        }

        public void SetSelected(bool isSelected)
        {
            _selectedFrame.SetActive(isSelected);
        }
    }
}