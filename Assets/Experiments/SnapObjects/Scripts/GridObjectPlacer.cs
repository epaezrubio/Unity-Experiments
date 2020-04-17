using System.Collections;
using System.Collections.Generic;
using Shared;
using UnityEngine;

namespace SnapObjects {
public class GridObjectPlacer : MonoBehaviour
{

        [SerializeField]
        public float gridSize = 5f;

        [SerializeField]
        private Transform prefab;

        private Transform modelPreview;

        private Bounds bounds;

        [SerializeField]
        private RaycastObjectGetter raycastObjectGetter;

        void Start()
        {
            modelPreview = Instantiate(prefab, transform.position, Quaternion.identity);
            bounds = modelPreview.GetComponent<BoxCollider>().bounds;

            raycastObjectGetter.onRayHit += onRayHit;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(prefab, modelPreview.position, Quaternion.identity);
            }
        }

        private void OnDestroy()
        {
        raycastObjectGetter.onRayHit -= onRayHit;
        }


        private void onRayHit(RaycastHit hit)
        {
            modelPreview.position = new Vector3(
                ToGrid(hit.point.x) + bounds.extents.x,
                hit.point.y,
                ToGrid(hit.point.z) + bounds.extents.z
            );
        }

        private float ToGrid(float number)
        {
            return Mathf.FloorToInt(number / gridSize) * gridSize;
        }
}
}