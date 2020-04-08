using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralFence
{
    public class GenerationPoint
    {
        public GameObject gameObject;
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

        public GenerationPoint(GameObject gameObject, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            this.gameObject = gameObject;
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }
    }
}