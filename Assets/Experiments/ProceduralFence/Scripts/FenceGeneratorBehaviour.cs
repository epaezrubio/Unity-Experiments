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

		[SerializeField]
		private float plankSize = 1f;

		private FenceGenerator fenceGenerator;

		private Vector3 lastPoint = Vector3.zero;

		private void Start()
		{
			List<GameObject> fenceVariations = new List<GameObject>();
			
			fenceVariations.Add(planks);

			fenceGenerator = new FenceGenerator(pole, fenceVariations, plankSize);
		}

		private void GenerateFence(Vector3 source, Vector3 target, bool closingFence = false)
		{
			List<GenerationPoint> generationPoints = this.fenceGenerator.GetGenerationPoints(source, target, lastPoint == Vector3.zero, closingFence);

			foreach (GenerationPoint generationPoint in generationPoints)
			{
				GameObject go = Instantiate(generationPoint.gameObject, generationPoint.position, generationPoint.rotation, transform);

				go.transform.localScale = new Vector3(generationPoint.scale.x, 1, generationPoint.scale.z);
			}
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{

				RaycastHit hit;
				Ray ray = camera.ScreenPointToRay(Input.mousePosition);
				Physics.Raycast(ray, out hit);

				Vector3 target;

				if (hit.transform.tag == "Pole")
				{
					target = hit.transform.parent.position;
				} 
				else
				{
					target = hit.point;
				}

				Vector3 inPlaneTarget = new Vector3(target.x, 0, target.z);

				GenerateFence(lastPoint, inPlaneTarget, hit.transform.tag != "Pole");

				lastPoint = inPlaneTarget;
			}
		}
	}
}