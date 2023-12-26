using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class gameOverController : MonoBehaviour
{
    public GameManager gameManager;
    GameObject parentZom;
    GameObject parentSun;
    private void Start()
    {
        parentZom = gameManager.SpawnEnemi.parentZom.gameObject;
        parentSun = gameManager.pointsManager.parentSun.gameObject;
    }

    private void Update()
    {
        if(gameManager.state == State.gameover && 
           (parentZom.active || parentSun.active))
        {
            parentZom.SetActive(false);
            parentSun.SetActive(false);
        }
    }
    public void btn_retry()
    {
        gameManager.ischangeState = true;
        gameManager.setGamestate(State.gameplay);
        gameManager.playable.time = 0;
        gameManager.playable.Play();
        gameManager.gameStart();
        gameManager.SpawnEnemi.parentZom.gameObject.SetActive(true);
        gameManager.pointsManager.parentSun.gameObject.SetActive(true);
    }
}
