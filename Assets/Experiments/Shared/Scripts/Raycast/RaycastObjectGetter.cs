using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared
{
    public class RaycastObjectGetter : MonoBehaviour
    {
        public MonoRaycastTrigger raycastTrigger;
        public MonoRaycaster raycaster;

        public event Action<RaycastHit> onRayHit;

        public void Start()
        {
            raycastTrigger.onCastRay += onCastRay;
        }

        public void OnDestroy()
        {
            raycastTrigger.onCastRay -= onCastRay;
        }

        private void onCastRay()
        {
            Ray ray = raycaster.CastRay();
            RaycastHit hit;

            if (this.onRayHit != null && Physics.Raycast(ray, out hit))
            {
                this.onRayHit(hit);
            }
        }
    }
}