using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmoothSceneTransition {
	public class SceneChangeTrigger : MonoBehaviour
	{
		[SerializeField]
		private SceneChanger sceneChanger;
		
		private void OnTriggerEnter(Collider other) { 
			if (other.gameObject.CompareTag("Player")) {
				sceneChanger.ChangeScene();
			}
		}
	}
}