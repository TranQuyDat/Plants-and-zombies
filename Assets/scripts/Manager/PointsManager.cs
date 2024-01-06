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
    public Transform parentSun;
    public int df_points;
    public int cur_points;
    public TextMeshProUGUI txt_point;
    public List<GameObject> listSun;

    private void Start()
    {
        cur_points = df_points;
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
        GameObject sun =  Instantiate(prefapSun, pos, Quaternion.identity, parentSun);
        listSun.Add(sun);
    }

    public void destroyAllSun()
    {
        foreach(GameObject sun in listSun)
        {
            Destroy(sun);
        }
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
