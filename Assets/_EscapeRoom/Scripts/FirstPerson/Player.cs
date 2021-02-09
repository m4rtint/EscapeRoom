using Sirenix.OdinInspector;
using System;
using System.Linq;
using UnityEngine;

namespace EscapeRoom
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Camera _camera = null;
        [SerializeField] private UICrosshair _crosshair = null;

        [SerializeField] private float _interactDistance = 2.0f;

        public PlayerInventory Inventory => _inventory;
        [ReadOnly] [SerializeField] private PlayerInventory _inventory = new PlayerInventory();

        private IInteractable GetInteractable()
        {
            // Raycast to try and find an interactable
            var hits = Physics.RaycastAll(_camera.transform.position, _camera.transform.forward, _interactDistance);
            if (hits.Length < 1) return null;
            var closestHit = hits
                .Where(x => x.transform.GetComponent<IInteractable>() != null)
                .OrderBy(r => r.distance)
                .First();
            var interactable = closestHit.transform.GetComponent<IInteractable>();
            return interactable;
        }

        private void Update()
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
    }
}