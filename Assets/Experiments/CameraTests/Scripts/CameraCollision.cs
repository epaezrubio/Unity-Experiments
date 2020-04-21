using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraTests
{
    public class CameraCollision : MonoBehaviour
    {
        [SerializeField]
        private Transform cameraTarget;

        [SerializeField]
        private float maxDistance = 25f;

        [SerializeField]
        private float clearance = 0f;

        private void Update()
        {
            Vector3 angleVector = (transform.position - cameraTarget.position).normalized * maxDistance;

            Debug.DrawRay(cameraTarget.position, angleVector);

            RaycastHit[] hits = Physics.RaycastAll(cameraTarget.position, angleVector, maxDistance);

            bool obstacleFound = false;

            foreach (RaycastHit hit in hits)
            {
                if (hit.transform != cameraTarget)
                {
                    transform.position = cameraTarget.position + Vector3.ClampMagnitude(angleVector.normalized * hit.distance, hit.distance - clearance);
                    obstacleFound = true;
                    break;
                }
            }

            if (!obstacleFound)
            {
                transform.position = cameraTarget.position + angleVector.normalized * maxDistance;
            }
        }
    }
}