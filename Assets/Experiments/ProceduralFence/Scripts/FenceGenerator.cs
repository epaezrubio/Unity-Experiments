using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralFence
{
    public class FenceGenerator
    {
        private GameObject pole;

        private float plankWidth = 1f;
        private float minPlankWidth = 0.5f;

        private List<GameObject> plankVariations;

        public FenceGenerator(GameObject pole, List<GameObject> plankVariations)
        {
            this.pole = pole;
            this.plankVariations = plankVariations;
        }

        public List<GenerationPoint> GetGenerationPoints(Vector3 origin, Vector3 target)
        {
            Vector3 direction = target - origin;

            float angle = Vector3.SignedAngle(Vector3.right, direction, Vector3.up);

            Quaternion rotation = Quaternion.Euler(0, angle, 0);

            float fenceLength = Vector3.Distance(origin, target);

            float fenceCount = fenceLength / plankWidth;
            int roundedFenceCount = (int)fenceCount;
            float fenceOffset = (fenceCount - roundedFenceCount) * plankWidth;

            if (fenceOffset > 0 && fenceOffset < plankWidth)
            {
                roundedFenceCount--;
            }

            List<GenerationPoint> generationPoints = new List<GenerationPoint>();

            for (int i = 0; i < roundedFenceCount; i++)
            {
                Vector3 posePosition = Vector3.ClampMagnitude(direction, plankWidth * i);

                generationPoints.Add(
                    new GenerationPoint(pole, origin + posePosition, rotation)
                );

                if (i < roundedFenceCount - 1)
                {

                    Vector3 planksPosition = Vector3.ClampMagnitude(direction, plankWidth * (i + 0.5f));

                    generationPoints.Add(
                        new GenerationPoint(plankVariations[0], origin + planksPosition, rotation)
                    );
                }
            }

            return generationPoints;
        }
    }

}