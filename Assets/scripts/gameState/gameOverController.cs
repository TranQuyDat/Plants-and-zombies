using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class gameOverController : MonoBehaviour
{
    public GameManager gameManager;

    public void btn_retry()
    {
        gameManager.ischangeState = true;
        gameManager.setGamestate(State.gameplay);
        gameManager.playable.time = 0;
        gameManager.playable.Play();

    }
}
