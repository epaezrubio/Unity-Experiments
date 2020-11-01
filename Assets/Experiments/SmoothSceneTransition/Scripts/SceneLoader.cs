using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmoothSceneTransition {
	using UnityEngine.SceneManagement;
	public class SceneLoader : MonoBehaviour
	{
	    void Start()
		{
			if (!GameObject.FindGameObjectWithTag("Player")) {
				SceneManager.LoadScene("SmoothSceneTransitionShared", LoadSceneMode.Additive);
			}
	    }
	
	    // Update is called once per frame
	    void Update()
	    {
	        
	    }
	}
}