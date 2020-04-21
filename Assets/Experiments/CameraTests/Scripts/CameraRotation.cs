using UnityEngine;
using JetBrains.Annotations;

namespace CameraTests
{
	public class CameraRotation : MonoBehaviour
	{
		[SerializeField]
		private float speed = 5f;

		private void Update()
		{
			transform.Rotate(Vector3.up, speed * Time.deltaTime);			
		}
	}
}