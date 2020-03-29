using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TunnelScroller
{
    public class ContinuousScroll : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] scrollObjects = { };

        [SerializeField]
        private float scrollSpeed = 1f;

        [SerializeField]
        private float scrollZLimit = -50f;

        private GameObject lastResetObject;

        // Start is called before the first frame update
        void Start()
        {
            lastResetObject = scrollObjects[scrollObjects.Length - 1];
        }

        // Update is called once per frame
        void Update()
        {
            foreach (GameObject scrollObject in scrollObjects)
            {
                scrollObject.transform.position = scrollObject.transform.position + new Vector3(0, 0, -(scrollSpeed * Time.deltaTime));
            }

            Physics.SyncTransforms();

            foreach (GameObject scrollObject in scrollObjects)
            {
                float currentZ = scrollObject.transform.position.z;

                if (currentZ < scrollZLimit)
                {
                    Bounds currentBounds = scrollObject.GetComponent<Collider>().bounds;
                    Bounds refBounds = lastResetObject.GetComponent<Collider>().bounds;

                    scrollObject.transform.position = scrollObject.transform.position + new Vector3(0, 0, refBounds.center.z + refBounds.extents.z + currentBounds.extents.z - scrollObject.transform.position.z);

                    lastResetObject = scrollObject;
                }
            }
        }
    }
}