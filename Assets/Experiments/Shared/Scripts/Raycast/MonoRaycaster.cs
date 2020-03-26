using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared
{
    public abstract class MonoRaycaster : MonoBehaviour, IRaycaster
    {
        public abstract Ray CastRay();
    }
}