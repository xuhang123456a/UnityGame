using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame(string sceneName)
    {
		SceneManager.LoadScene(sceneName);
    }

	public void StartGame(int sceneIndex)
    {
		SceneManager.LoadScene(sceneIndex);
    }
}
