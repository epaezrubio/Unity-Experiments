using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralFence
{
    public class FenceGenerator
    {
        private GameObject pole;

        private float plankWidth;

        private List<GameObject> plankVariations;

        public FenceGenerator(GameObject pole, List<GameObject> plankVariations, float plankWidth = 1f)
        {
            this.pole = pole;
            this.plankVariations = plankVariations;
            this.plankWidth = plankWidth;
        }

        public List<GenerationPoint> GetGenerationPoints(Vector3 origin, Vector3 target, bool startPole = true, bool endPole = true)
        {

            float fenceLength = Vector3.Distance(origin, target);

            float fenceCount = fenceLength / plankWidth;
            float roundedFenceCount = Mathf.Floor(fenceCount) + 1;
            float plankLeftOver = fenceCount - roundedFenceCount;

            float computedPlankWidth = plankWidth + ((plankLeftOver / roundedFenceCount) * plankWidth);
            float computedPlankScale = computedPlankWidth / plankWidth;

            List<GenerationPoint> generationPoints = new List<GenerationPoint>();

            Vector3 direction = target - origin;
            Quaternion rotation = Quaternion.Euler(0, Vector3.SignedAngle(Vector3.right, direction, Vector3.up), 0);

            for (int i = 0; i < roundedFenceCount + 1; i++)
            {
                bool createPole = (i > 0 && i < roundedFenceCount) || (i == 0 && startPole) || (i == roundedFenceCount && endPole);
                bool createPlank = i < roundedFenceCount;

                if (createPole)
                {
                    Vector3 posePosition = Vector3.ClampMagnitude(direction, computedPlankWidth * i);

                    generationPoints.Add(
                        new GenerationPoint(pole, origin + posePosition, rotation, Vector3.one)
                    );
                }

                if (createPlank)
                {
                    Vector3 plankPosition = Vector3.ClampMagnitude(direction, computedPlankWidth * (i + 0.5f));

                    generationPoints.Add(
                        new GenerationPoint(plankVariations[0], origin + plankPosition, rotation, Vector3.one * computedPlankScale)
                    );
                }
            }

            return generationPoints;
        }
    }

}