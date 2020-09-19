using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OculusDoor
{
    public class DoorOpener : MonoBehaviour
    {
        [SerializeField]
        private Door linkedDoor;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("XRController"))
            {
                linkedDoor.Open();
            }
        }
    }
}
