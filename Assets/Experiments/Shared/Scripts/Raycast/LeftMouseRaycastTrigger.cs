using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared
{

    public class LeftMouseRaycastTrigger : MonoRaycastTrigger
    {
        public override event Action onCastRay;

        public void Update()
        {
            if (Input.GetMouseButtonDown(0) && onCastRay != null)
            {
                onCastRay();
            }
        }
    }
}