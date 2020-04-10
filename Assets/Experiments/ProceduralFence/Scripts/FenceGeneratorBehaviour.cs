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

		private FenceGeneratorState generatorState;

		public void GenerateFence(Vector3 source, Vector3 target, bool startPole = false, bool endPole = false)
		{
			List<GenerationPoint> generationPoints = this.fenceGenerator.GetGenerationPoints(source, target, startPole, endPole);

			foreach (GenerationPoint generationPoint in generationPoints)
			{
				GameObject go = Instantiate(generationPoint.gameObject, generationPoint.position, generationPoint.rotation, transform);

				go.transform.localScale = new Vector3(generationPoint.scale.x, 1, generationPoint.scale.z);
			}
		}

		public void SetGeneratorState(FenceGeneratorState state)
		{
			this.generatorState = state;
		}

		private void OnEnable()
		{
			SetGeneratorState(new NewFenceState(this));
		}

		private void Start()
		{
			List<GameObject> fenceVariations = new List<GameObject>();
			
			fenceVariations.Add(planks);

			fenceGenerator = new FenceGenerator(pole, fenceVariations, plankSize);
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{

				RaycastHit hit;
				Ray ray = camera.ScreenPointToRay(Input.mousePosition);
				Physics.Raycast(ray, out hit);

				generatorState.Click(hit);
			}
		}
		public abstract class FenceGeneratorState
		{
			protected FenceGeneratorBehaviour generator;

			public FenceGeneratorState(FenceGeneratorBehaviour generator)
			{
				this.generator = generator;
			}

			public abstract void Click(RaycastHit hit);
		}

		public class NewFenceState : FenceGeneratorState
		{
			public NewFenceState(FenceGeneratorBehaviour generator) : base(generator)
			{
			}

			public override void Click(RaycastHit hit)
			{
				Vector3 inPlaneTarget = new Vector3(hit.point.x, 0, hit.point.z);

				if (hit.transform.tag == "Pole")
				{
					generator.SetGeneratorState(new NewFenceNodeState(generator, inPlaneTarget));
				}
				else if (hit.transform.tag == "RaycastPlane")
				{
					generator.SetGeneratorState(new NewFenceNodeState(generator, inPlaneTarget, true));
				}

			}
		}

		public class NewFenceNodeState : FenceGeneratorState
		{
			private Vector3 lastPoint;

			private bool isInitialNode = false;

			public NewFenceNodeState(FenceGeneratorBehaviour generator, Vector3 lastPoint, bool isInitialNode = false) : base(generator)
			{
				this.lastPoint = lastPoint;
				this.isInitialNode = isInitialNode;
			}

			public override void Click(RaycastHit hit)
			{
				if (hit.transform.tag == "Pole")
				{
					Vector3 inPlaneTarget = new Vector3(hit.transform.position.x, 0, hit.transform.position.z);

					if (Vector3.Distance(inPlaneTarget, lastPoint) > 1)
					{
						generator.GenerateFence(lastPoint, inPlaneTarget, isInitialNode);
					}

					generator.SetGeneratorState(new NewFenceState(generator));
				}
				else
				{
					Vector3 inPlaneTarget = new Vector3(hit.point.x, 0, hit.point.z);

					generator.GenerateFence(lastPoint, inPlaneTarget, isInitialNode, true);

					lastPoint = inPlaneTarget;
				}

				isInitialNode = false;
			}
		}
	}
}