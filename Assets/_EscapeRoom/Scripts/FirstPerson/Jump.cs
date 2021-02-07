using UnityEngine;

namespace EscapeRoom
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] 
        private GroundCheck groundCheck;
        private Rigidbody rigidbody;
        [SerializeField]
        private float jumpStrength = 2;
        [SerializeField]
        private event System.Action Jumped;


        private void Reset()
        {
            groundCheck = GetComponentInChildren<GroundCheck>();
            if (!groundCheck)
                groundCheck = GroundCheck.Create(transform);
        }

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void LateUpdate()
        {
            if (Input.GetButtonDown("Jump") && groundCheck.isGrounded)
            {
                rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
                Jumped?.Invoke();
            }
        }
    }
}