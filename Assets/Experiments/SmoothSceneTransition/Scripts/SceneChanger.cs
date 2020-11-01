using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SmoothSceneTransition {
	public class SceneChanger : MonoBehaviour
	{
		private GameObject player;
		private Animator animator;
		
	    void Start()
		{
			animator = GetComponent<Animator>();
			player = GameObject.FindGameObjectWithTag("Player");
			
			DontDestroyOnLoad(this);
			DontDestroyOnLoad(player);
	    }
	    
		public void ChangeScene() {
			animator.SetBool("doors_closed", true);
		}
	    
		public void OnDoorOpened() {
		}
	    
		public void OnDoorClosed() {
			if (animator.GetBool("doors_closed")) {
				if (SceneManager.GetActiveScene().name == "SmoothSceneTransition2") {
					SceneManager.LoadSceneAsync("SmoothSceneTransition1");
				} else {
					SceneManager.LoadSceneAsync("SmoothSceneTransition2");
				}
				
				animator.SetBool("doors_closed", false);
			}
		}
	}
}