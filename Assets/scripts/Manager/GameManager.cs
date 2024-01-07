using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public enum State
{
    gameplay,
    gamepause,
    gameover,
    gamewin
}

public class GameManager : MonoBehaviour
{
    public selectBarController selectBarController;
    public boardchooseTree boardchooseTree;
    public SelectedCusor cursor;
    public progressBar progressBar;
    public LawnMowerManager lawnMowerManager;
    public particleManager particleManager;
    public SceneINFO sceneINFO;

    public PointsManager pointsManager;
    public SpawnEnemiManager SpawnEnemi;
    public TreeManager treeManager;
    public soundManager soundManager;
    public LoadSceneSmoothy load;

    public int zombiecount;
    public State state;
    public bool GameStart;
    [Header("******gameState**********")]
    public gamePlayController gamePlayctrl;
    public gameOverController gameOverctrl;
    public gamePauseController gamePausectrl;
    public gameWinController gameWinctrl;
    public bool ischangeState;
    public bool iswin;
    [HideInInspector] public PlayableDirector playable;

    private void Awake()
    {
        soundManager = FindObjectOfType<soundManager>();
        state = State.gameplay;
        playable = this.GetComponent<PlayableDirector>();
        ischangeState = true;
    }
    private void Start()
    {
        gameStart();
    }
    private void Update()
    {
        if (soundManager == null) soundManager = FindObjectOfType<soundManager>();
        updateGamestate();
        GameWin();
    }
    public void updateGamestate()
    {
        if (!ischangeState) return;
        gamePlayctrl.gameObject.SetActive(state == State.gameplay);
        gamePausectrl.gameObject.SetActive(state == State.gamepause);
        gameOverctrl.gameObject.SetActive(state == State.gameover);
        gameWinctrl.gameObject.SetActive(state == State.gamewin);
        ischangeState = false;
    }
    public void updateZombiescount()
    {
        zombiecount = SpawnEnemi.getAllzombiescount();
    }

    public void GameWin()
    {
        if (zombiecount > 0 || iswin) return;
        iswin = true;
        GameStart = false;
        ischangeState = true;
        state = State.gamewin;
        soundManager.playMusic(SoundType.music_win,false);
    }

    public void GameOver()
    {
        soundManager.playMusic(SoundType.music_gameover,false);
        GameStart = false;
        ischangeState = true;
        state = State.gameover;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("zombie"))
        {
            //Debug.Log("game over");
            GameOver();
        }
    }

    
    public void setGamestate( State newsate )
    {
        state = newsate;
    }

    public void changeScene(Scene nameScene)
    {
        load.LoadSceneWithtransition(nameScene,tranType.transitionOpen);
    }

    public void gameStart()
    {
        load.callTransition(tranType.transitionClose);
        soundManager.playMusic(sceneINFO.st, true);
        boardchooseTree.isReStart = true;
        progressBar.fillbar.value = 0;
        iswin = false;
        SpawnEnemi.destroyAllzombies();
        SpawnEnemi.defaultSetting();
        treeManager.destroyAllTree();
        pointsManager.destroyAllSun();
        
        pointsManager.cur_points = pointsManager.df_points;//diem khi bat dau choi
        GameStart = false;
        
        lawnMowerManager.setDf_LawnMowers();
        updateZombiescount();
    }

    public void UpdateAliveZB(int num)
    {
        zombiecount += num;
    }

   public void btn_click()
    {
        soundManager.playSFX(SoundType.sfx_click);
    }
}

