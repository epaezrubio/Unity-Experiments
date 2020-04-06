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

        public GenerationPoint(GameObject gameObject, Vector3 position, Quaternion rotation)
        {
            this.gameObject = gameObject;
            this.position = position;
            this.rotation = rotation;
        }
    }
}