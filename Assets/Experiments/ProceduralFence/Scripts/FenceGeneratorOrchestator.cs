using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralFence {
    public class FenceGeneratorOrchestator : MonoBehaviour
    {

        [SerializeField]
        List<FenceGeneratorBehaviour> generators;

        private int currentGeneratorIndex = 0;

        private void ActivateNextGenerator()
        {
            generators[currentGeneratorIndex].GetComponent<FenceGeneratorBehaviour>().enabled = false;

            currentGeneratorIndex = (currentGeneratorIndex + 1) % generators.Count;

            generators[currentGeneratorIndex].GetComponent<FenceGeneratorBehaviour>().enabled = true;
        }

        // Start is called before the first frame update
        void Start()
        {
            foreach (FenceGeneratorBehaviour generator in generators)
            {
                generator.GetComponent<FenceGeneratorBehaviour>().enabled = false;
            }

            if (generators.Count > 0)
            {
                generators[0].GetComponent<FenceGeneratorBehaviour>().enabled = true;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(1) && generators.Count > 0)
            {
                ActivateNextGenerator();
            }
        }
    }
}