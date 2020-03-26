using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared
{
    public abstract class MonoRaycastTrigger : MonoBehaviour, IRaycastTrigger
    {
        public abstract event Action onCastRay;
    }
}