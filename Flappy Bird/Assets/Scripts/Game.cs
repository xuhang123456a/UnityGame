using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public enum GAME_STATUS
    {
        Ready,
        Gaming,
        GameOver,
    }
    private GAME_STATUS status;

    //public GAME_STATUS Status
    //{
    //    get { return status; }
    //    set { status = value; }
    //}

    public GameObject panelReady;
    public GameObject panelGaming;
    public GameObject panelGameOver;

    public PipelineManager pipelineManager;

	void Start () {
        this.panelReady.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        this.status = GAME_STATUS.Gaming;
        UpdateUI();
        pipelineManager.StartRun();
        Debug.LogFormat("StartGame : {0}",this.status);
    }

    public void UpdateUI()
    {
        this.panelReady.SetActive(this.status == GAME_STATUS.Ready);
        this.panelGaming.SetActive(this.status == GAME_STATUS.Gaming);
        this.panelGameOver.SetActive(this.status == GAME_STATUS.GameOver);
    }
}
