using UnityEngine;

namespace EscapeRoom
{
    public class FirstPersonLook : MonoBehaviour
    {
        [SerializeField] private Transform character;
        private Vector2 currentMouseLook;
        private Vector2 appliedMouseDelta;
        [SerializeField]
        private float sensitivity = 1;
        [SerializeField]
        private float smoothing = 2;


        private void Reset()
        {
            character = GetComponentInParent<FirstPersonMovement>().transform;
        }

        private void Update()
        {
            if (StateManager.Instance.GetState() != State.Play)
            {
                return;
            }
            // Get smooth mouse look.
            Vector2 smoothMouseDelta =
                Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")),
                    Vector2.one * sensitivity * smoothing);
            appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, smoothMouseDelta, 1 / smoothing);
            currentMouseLook += appliedMouseDelta;
            currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, -90, 90);

            // Rotate camera and controller.
            transform.localRotation = Quaternion.AngleAxis(-currentMouseLook.y, Vector3.right);
            character.localRotation = Quaternion.AngleAxis(currentMouseLook.x, Vector3.up);
        }
    }
}