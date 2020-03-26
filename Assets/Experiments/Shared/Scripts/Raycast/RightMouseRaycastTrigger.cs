using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared
{

    public class RightMouseRaycastTrigger : MonoRaycastTrigger
    {
        public override event Action onCastRay;

        public void Update()
        {
            if (onCastRay != null && Input.GetMouseButtonDown(1))
            {
                onCastRay();
            }
        }
    }
}