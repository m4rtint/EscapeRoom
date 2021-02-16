using Sirenix.OdinInspector;
using System;
using System.Linq;
using UnityEngine;

namespace EscapeRoom
{
    public class Player : MonoBehaviour
    {
        private const string InputMouseScrollWheel = "Mouse ScrollWheel";

        [SerializeField] private Camera _camera = null;
        [SerializeField] private UICrosshair _crosshair = null;
        [SerializeField] private ToolbarBehaviour _toolbarUI = null;

        [SerializeField] private float _interactDistance = 2.0f;

        public PlayerInventory Inventory => _inventory;
        [ReadOnly] [SerializeField] private PlayerInventory _inventory = new PlayerInventory();

        private IInteractable GetInteractable()
        {
            // Raycast to try and find an interactable
            var hits = Physics.RaycastAll(_camera.transform.position, _camera.transform.forward, _interactDistance);
            if (hits.Length < 1) return null;
            var interactableHits = hits
                .Where(x => x.transform.GetComponent<IInteractable>() != null)
                .OrderBy(r => r.distance);
            if (!interactableHits.Any()) return null;
            var closestHit = interactableHits.First();
            return closestHit.transform.GetComponent<IInteractable>();
        }

        private void OnEnable()
        {
            _inventory.OnSelectedItemChanged += HandleOnSelectedItemChanged;
            _inventory.OnItemCountChanged += HandleOnItemCountChanged;
        }

        private void OnDisable()
        {
            _inventory.OnSelectedItemChanged -= HandleOnSelectedItemChanged;
            _inventory.OnItemCountChanged -= HandleOnItemCountChanged;
        }

        private void HandleOnSelectedItemChanged(int itemIndex, GenericItem item)
        {
            _toolbarUI.ChangeSelectedSlot(itemIndex);
        }

        private void HandleOnItemCountChanged(int itemCount)
        {
            _toolbarUI.SetItems(_inventory.Items);
        }

        private void Update()
        {
            // Check for interactables / interacting
            {
                var interactable = GetInteractable();
                if (interactable != null && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)))
                {
                    interactable.InteractWith(this);
                }

                _crosshair.State = interactable == null
                    ? UICrosshair.CrosshairStates.Default
                    : UICrosshair.CrosshairStates.Interactable;
            }

            // Check for selecting item in toolbar
            {
                var scrollDirection = (int)Input.GetAxis(InputMouseScrollWheel);
                if (scrollDirection != 0)
                {
                    if (scrollDirection > 0)
                        _inventory.SelectNextItem();
                    else
                        _inventory.SelectPreviousItem();
                }
            }
        }
    }
}