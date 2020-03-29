using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TunnelScroller
{
    public class PlayerModeChanger : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer playerMesh;

        [SerializeField]
        private PlayerModeScriptable[] playerModes;

        public PlayerModeScriptable currentPlayerMode;

        private int currentMaterialIndex = -1;
        private void Start()
        {
            SetNextPlayerMaterial();
        }

        private void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                SetNextPlayerMaterial();
            }
        }

        private void SetNextPlayerMaterial()
        {
            currentMaterialIndex = (currentMaterialIndex + 1) % playerModes.Length;

            currentPlayerMode = playerModes[currentMaterialIndex];
            playerMesh.material = currentPlayerMode.material;
        }
    }
}