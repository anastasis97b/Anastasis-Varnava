using System.Collections;
using UnityEngine;

namespace SojaExiles
{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController controller;
        public float speed = 5f;
        public float gravity = -15f;

        private Vector3 velocity;

        void Start()
        {
          
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        void Update()
        {
            HandlePlayerMovement();
        }

        private void HandlePlayerMovement()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
