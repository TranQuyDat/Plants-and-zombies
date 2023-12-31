using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameWinController : MonoBehaviour
{
    public GameManager gameManager;
    public void btn_restart()
    {
        gameManager.ischangeState = true;
        gameManager.setGamestate(State.gameplay);
        gameManager.playable.time = 0;
        gameManager.playable.Play();
        gameManager.gameStart();
    }

    public void btn_next()
    {
        //chuyen map ke tiep
        string nameScene =  SceneManager.GetActiveScene().name;

        if(gameManager.nextScene != null)
            gameManager.changeScene(gameManager.nextScene);
    }

    public void btn_QuiToMenu()
    {
        //chuyen ve main menu
        gameManager.changeScene(Scene.Menu);
    }
}
