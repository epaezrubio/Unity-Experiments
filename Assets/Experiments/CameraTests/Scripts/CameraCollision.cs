using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraTests
{
    public class CameraCollision : MonoBehaviour
    {
        [SerializeField]
        protected Transform cameraTarget;

        [SerializeField]
        protected float maxDistance = 25f;

        [SerializeField]
        protected float clearance = 0f;

        [SerializeField]
        protected bool debug = true;

        protected Vector3 angleVector;
        private void Update()
        {
            UpdateCameraDistance();
        }

        private bool GetCameraCollision(out RaycastHit ray)
        {
            RaycastHit[] hits = Physics.RaycastAll(cameraTarget.position, angleVector, maxDistance);

            foreach (RaycastHit hit in hits)
            {
                if (hit.transform != cameraTarget)
                {
                    ray = hit;
                    return true;
                }
            }

            ray = new RaycastHit();
            return false;
        }

        private void UpdateCameraDistance()
        {
            angleVector = (transform.position - cameraTarget.position).normalized * maxDistance;

            if (debug)
            {
                Debug.DrawRay(cameraTarget.position, angleVector);
            }

            RaycastHit cameraCollision;

            if (GetCameraCollision(out cameraCollision))
            {
                SetCameraDistance(cameraCollision.distance - clearance);

            if (debug)
            {
                Debug.DrawRay(cameraTarget.position, angleVector);
            }
            }
            else
            {
                SetCameraDistance(maxDistance);
            }
        }

        protected virtual void SetCameraDistance(float distance)
        {
            transform.position = cameraTarget.position + Vector3.ClampMagnitude(angleVector.normalized * maxDistance, distance);
        }
    }
}