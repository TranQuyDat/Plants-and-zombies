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
[HideInInspector] public enum Scene
{
    Menu,
    Map1,
    Map2,
    Map3
}
public class GameManager : MonoBehaviour
{
    public selectBarController selectBarController;
    public boardchooseTree boardchooseTree;
    public SelectedCusor cursor;
    public progressBar progressBar;
    public LawnMowerManager lawnMowerManager;
    public particleManager particleManager;

    public PointsManager pointsManager;
    public SpawnEnemiManager SpawnEnemi;
    public TreeManager treeManager;

    int zombiecount;
    public State  state;
    public bool GameStart;
    [Header("******gameState**********")]
    public gamePlayController gamePlayctrl;
    public gameOverController gameOverctrl;
    public gamePauseController gamePausectrl;
    public gameWinController gameWinctrl;
    public bool ischangeState;
    public Scene nextScene;
    [HideInInspector] public PlayableDirector playable;

    private void Start()
    {
        state = State.gameplay;
        playable = this.GetComponent<PlayableDirector>();
        ischangeState = true;
        
        gameStart();
    }
    private void Update()
    {
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
        Debug.Log(zombiecount);
        if (zombiecount > 0) return;
        GameStart = false;
        ischangeState = true;
        state = State.gamewin;
    }

    public void GameOver()
    {
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
        SceneManager.LoadScene(nameScene.ToString());
    }

    public void gameStart()
    {
        boardchooseTree.isReStart = true;
        progressBar.fillbar.value = 0;
        
        SpawnEnemi.destroyAllzombies();
        SpawnEnemi.defaultSetting();
        treeManager.destroyAllTree();
        pointsManager.destroyAllSun();
        
        pointsManager.cur_points = 200;//diem khi bat dau choi
        GameStart = false;
        
        lawnMowerManager.setDf_LawnMowers();
        updateZombiescount();
    }

    public void UpdateAliveZB(int num)
    {
        zombiecount += num;
    }

   
}

