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
    public PointsManager pointsManager;
    public SelectedCusor cursor;
    public bool GameStart;
    public selectBarController selectBarController;
    public SpawnEnemiManager SpawnEnemi;
    int zombiecount;
    public State  state;

    [Header("******gameState**********")]
    public gamePlayController gamePlayctrl;
    public gameOverController gameOverctrl;
    public gamePauseController gamePausectrl;
    public gameWinController gameWinctrl;
    public bool ischangeState;

    [HideInInspector] public PlayableDirector playable;
    public Scene nextScene;
    private void Start()
    {
        playable = this.GetComponent<PlayableDirector>();
        zombiecount = SpawnEnemi.getAllzombiescount();
        GameStart = false;
        
    }
    private void Update()
    {
        updateGamestate();
        updateZombiescount();
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
        if (zombiecount != SpawnEnemi.getAllzombiescount())
        {
            zombiecount = SpawnEnemi.getAllzombiescount();
        }
    }

    public void GameWin()
    {
        if (zombiecount > 0) return;
        state = State.gamewin;
    }

    public void GameOver()
    {
        state = State.gameover;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("zombie"))
        {
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

}

