using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public GameManager gameManager;
    [Header("********spawnSun*********")]
    public GameObject prefapSun;
    public Transform[] posSpwan;
    [Header("********ManagerPoint*********")]
    public int cur_points;
    public TextMeshProUGUI txt_point;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        InvokeRepeating("spawnSun", 3f, Random.Range(15,30));
    }
    private void Update()
    {
        
        updatePoint();
    }
    public void spawnSun()
    {
        if (!gameManager.GameStart) return;
        float Xmin = posSpwan[0].position.x;
        float Xmax = posSpwan[1].position.x;
        Vector2 pos = new Vector2(Random.Range(Xmin,Xmax),posSpwan[0].position.y);
        Instantiate(prefapSun, pos, Quaternion.identity);
    }

    public void addPoint(int point)
    {
        cur_points += point;
        txt_point.text = cur_points.ToString();
    }

    public void updatePoint()
    {
        if (txt_point.text == cur_points.ToString()) return;
        if (cur_points <= 0) cur_points = 0;
        txt_point.text = cur_points.ToString();
    }
}
