using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared
{

    public class UpdateRaycastTrigger : MonoRaycastTrigger
    {
        public override event Action onCastRay;

        public void Update()
        {
            onCastRay();
        }
    }
}