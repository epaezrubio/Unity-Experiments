using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraTests
{
    public class CameraSmoothCollision : CameraCollision
    {
        [SerializeField]
        private float easeSpeed = 3f;

        protected override void SetCameraDistance(float distance)
        {
            float currentDistance = Vector3.Distance(transform.position, cameraTarget.position);

            if (currentDistance < distance)
            {
                SetCameraDistanceSmooth(distance);
            }
            else
            {
                base.SetCameraDistance(distance);
            }
        }

        private void SetCameraDistanceSmooth(float distance)
        {

            transform.position = Vector3.Lerp(transform.position, cameraTarget.position + Vector3.ClampMagnitude(angleVector.normalized * maxDistance, distance), Time.deltaTime * easeSpeed);
        }
    }
}