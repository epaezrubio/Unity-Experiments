using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared
{
    public class ObjectRaycaster : MonoRaycaster
    {
        public override Ray CastRay()
        {
            return new Ray(transform.position, transform.forward);
        }
    }
}