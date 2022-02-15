using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    // UI面板
    public GameObject panelReady;
    public GameObject panelGaming;
    public GameObject panelGameOver;
    public Slider hpBar;

    // 玩家引用
    public Player player;

    // 积分显示
    public int score;
    public Text uiScore1;
    public Text uiScore2;

    public int Score
    {
        get { return score; }
        set {
            this.score = value;
            uiScore1.text = value.ToString();
            uiScore2.text = value.ToString();
        }
    }


    public PipelineManager pipelineManager;
    public UnitManager unitManager;
    public enum GAME_STATUS
    {
        READY,
        GAMING,
        GAMEOVER,
    }
    GAME_STATUS status;
    private GAME_STATUS Status
    {
        get{return status;}
        set
        {
            status = value;
            this.UpdateUI();
        }
    }


	void Start () {
        this.panelReady.SetActive(true);
        this.Status = GAME_STATUS.READY;
        this.player.OnDeath += Player_OnDeath;
        this.player.OnScore = OnPlayerScore;
	}

    void OnPlayerScore(int score)
    {
        this.Score += score;
    }

    private void Player_OnDeath()
    {
        this.Status = GAME_STATUS.GAMEOVER;
        this.pipelineManager.Stop();
        this.unitManager.Stop();
    }

    public void UpdateUI()
    {
        this.panelReady.SetActive(this.Status == GAME_STATUS.READY);
        this.panelGaming.SetActive(this.Status == GAME_STATUS.GAMING);
        this.panelGameOver.SetActive(this.Status == GAME_STATUS.GAMEOVER);
    }

    private void Update()
    {
        this.hpBar.value = Mathf.Lerp(this.hpBar.value, player.HP, Time.deltaTime);
    }

    public void StartGame()
    {
        this.Status = GAME_STATUS.GAMING;
        Debug.LogFormat("StartGame : {0}", this.Status);

        pipelineManager.StartRun();
        unitManager.Begin();
        player.Fly();
        this.hpBar.value = this.player.HP;
    }

    public void Restart()
    {
        this.Status = GAME_STATUS.READY;
        this.pipelineManager.Init();
        this.player.Init();
    }
}
