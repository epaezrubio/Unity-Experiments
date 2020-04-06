using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralFence
{
    public class FenceGenerator
    {
        private GameObject pole;
        private List<GameObject> plankVariations;

        public FenceGenerator(GameObject pole, List<GameObject> plankVariations)
        {
            this.pole = pole;
            this.plankVariations = plankVariations;
        }

        public List<GenerationPoint> GetGenerationPoints(Vector3 origin, Vector3 target)
        {
            List<GenerationPoint> generationPoints = new List<GenerationPoint>();

            generationPoints.Add(
                new GenerationPoint(pole, origin, Quaternion.identity)
            );

            generationPoints.Add(
                new GenerationPoint(pole, target, Quaternion.identity)
            );

            return generationPoints;
        }
    }

}