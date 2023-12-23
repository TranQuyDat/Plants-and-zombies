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
<<<<<<< HEAD
   
        
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
        public void GameOver()
        {
            Debug.Log("GameOver");
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("zombie"))
            {
                GameOver();
            }
        }
=======
    private void Start()
    {
        zombiecount = SpawnEnemi.getAllzombiescount();
        GameStart = false;
    }
    private void Update()
    {
        updateZombiescount();
        GameOver();
    }

    public void updateZombiescount()
    {
        if (zombiecount != SpawnEnemi.getAllzombiescount())
        {
            zombiecount = SpawnEnemi.getAllzombiescount();
        }
    }

    public void GameOver()
    {
        if (zombiecount > 0) return;
        Debug.Log("Gameover");
>>>>>>> 8532154 (24/12/2023 update fix)
    }

