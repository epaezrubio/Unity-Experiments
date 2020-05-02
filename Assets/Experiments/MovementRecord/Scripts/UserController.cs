using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovementRecord
{
    public class UserController : MonoBehaviour
    {

        [SerializeField]
        private float speed = 5f;

        [SerializeField]
        private float angularSpeed = 5f;

        private float velocity = 0;
        private float angularVelocity = 0;

        private Rigidbody rb;


        public void SetVelocities(float vertical, float horizontal)
        {
            Debug.LogFormat("Setting Velocities to {0} and {1}", vertical, horizontal);
            this.velocity = vertical;
            this.angularVelocity = horizontal;
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            rb.velocity = transform.forward * this.velocity * speed;
            rb.angularVelocity = transform.up * this.angularVelocity * angularSpeed;
        }
    }
}
