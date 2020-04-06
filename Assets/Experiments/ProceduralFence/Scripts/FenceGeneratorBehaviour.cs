using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralFence
{
	public class FenceGeneratorBehaviour : MonoBehaviour
	{

		[SerializeField]
		private GameObject pole;

		[SerializeField]
		private GameObject planks;

		private FenceGenerator fenceGenerator;

		private void Start()
		{
			List<GameObject> fenceVariations = new List<GameObject>();
			
			fenceVariations.Add(planks);

			fenceGenerator = new FenceGenerator(pole, fenceVariations);

			GenerateFence();
		}

		private void GenerateFence()
		{
			List<GenerationPoint> generationPoints = this.fenceGenerator.GetGenerationPoints(Vector3.zero, Vector3.right);

			foreach (GenerationPoint generationPoint in generationPoints)
			{
				Instantiate(generationPoint.gameObject, generationPoint.position, generationPoint.rotation, transform);
			}
		}
	}
}