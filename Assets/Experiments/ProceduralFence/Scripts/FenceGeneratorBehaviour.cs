using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralFence
{
	public class FenceGeneratorBehaviour : MonoBehaviour
	{
		[SerializeField]
		private new Camera camera;

		[SerializeField]
		private GameObject pole;

		[SerializeField]
		private GameObject planks;

		private FenceGenerator fenceGenerator;

		private Vector3 lastPoint = Vector3.zero;

		private void Start()
		{
			List<GameObject> fenceVariations = new List<GameObject>();
			
			fenceVariations.Add(planks);

			fenceGenerator = new FenceGenerator(pole, fenceVariations);
		}

		private void GenerateFence(Vector3 source, Vector3 target)
		{
			List<GenerationPoint> generationPoints = this.fenceGenerator.GetGenerationPoints(source, target);

			foreach (GenerationPoint generationPoint in generationPoints)
			{
				Instantiate(generationPoint.gameObject, generationPoint.position, generationPoint.rotation, transform);
			}
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{

				RaycastHit hit;
				Ray ray = camera.ScreenPointToRay(Input.mousePosition);
				Physics.Raycast(ray, out hit);

				Vector3 target = new Vector3(hit.point.x, 0, hit.point.z);

				GenerateFence(lastPoint, target);

				lastPoint = target;
			}
		}
	}
}