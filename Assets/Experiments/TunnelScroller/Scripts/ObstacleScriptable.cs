using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TunnelScroller
{
    public enum obstableColor { none, blue, orange, black }

    [CreateAssetMenu]
    public class ObstacleScriptable : ScriptableObject
    {
        [SerializeField]
        public obstableColor bottom = obstableColor.blue;

        [SerializeField]
        public obstableColor left = obstableColor.blue;

        [SerializeField]
        public obstableColor right = obstableColor.blue;
    }
}