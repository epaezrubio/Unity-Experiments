using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared
{
    [RequireComponent(typeof(Camera))]
    public class CameraRaycaster : MonoRaycaster
    {
        private Camera camera;

        public void Start()
        {
            camera = GetComponent<Camera>();
        }

        public override Ray CastRay()
        {
            return camera.ScreenPointToRay(Input.mousePosition);
        }
    }
}