using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PointsManager pointsManager;
    public SelectedCusor cursor;
    public bool GameStart;
    public selectBarController selectBarController;
    private void Start()
    {
        GameStart = false;
    }
    private void Update()
    {
       
    }

}
