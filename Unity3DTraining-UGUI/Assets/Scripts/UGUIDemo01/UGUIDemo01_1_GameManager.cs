using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UGUIDemo01_1_GameManager : MonoBehaviour {
	public void OnStartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
	
    public void OnStartGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
