using System.Linq;
using UnityEngine;

namespace EscapeRoom
{
    public class InteractBehaviour : MonoBehaviour
    {
        [SerializeField] private UICrosshair _crosshair = null;

        [SerializeField] private float _interactDistance = 2.0f;

        private IInteractable GetInteractable()
        {
            // Raycast to try and find an interactable
            var hits = Physics.RaycastAll(transform.position, transform.forward, _interactDistance);
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
                interactable.InteractWith();
            }

            _crosshair.State = interactable == null
                ? UICrosshair.CrosshairStates.None
                : UICrosshair.CrosshairStates.Interactable;
        }
    }
}