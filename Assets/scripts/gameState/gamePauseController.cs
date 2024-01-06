using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePauseController : MonoBehaviour
{
    public GameManager gameManager;
    public void btn_resume()
    {
        Time.timeScale = 1;
        gameManager.ischangeState = true;
        gameManager.setGamestate(State.gameplay);
    }

    public void btn_restart()
    {
        Time.timeScale = 1;
        gameManager.ischangeState = true;
        gameManager.setGamestate(State.gameplay);
        //set lai timeline
        gameManager.playable.time = 0;
        gameManager.playable.Play();
        gameManager.gameStart();
    }

    public void btn_QuitToMenu()
    {
        //chuyen ve main menu
        Time.timeScale = 1;
        gameManager.changeScene(Scene.Menu);
    }
}
