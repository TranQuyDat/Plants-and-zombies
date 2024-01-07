using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePlayController : MonoBehaviour
{
    public GameManager gameManager;
    private void Update()
    {
    }
    public void btn_pause()
    {
        gameManager.ischangeState = true;
        Time.timeScale = 0;
        gameManager.setGamestate(State.gamepause);
    }
}
