using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PointsManager pointsManager;
    public SelectedCusor cursor;
    public bool GameStart;
    public selectBarController selectBarController;
    public SpawnEnemiManager SpawnEnemi;
    int zombiecount;
    private void Start()
    {
        zombiecount = SpawnEnemi.getAllzombiescount();
        GameStart = false;
    }
    private void Update()
    {
        updateZombiescount();
        GameWin();
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
        Debug.Log("GameWin");
    }

}
