using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressBar : MonoBehaviour
{
    public Slider fillbar;
    public float speed; 
    public GameObject wavetrigger;
    public Transform trigger;
    public GameManager gameManager;
    public int curWavecount;
    public SpawnEnemiManager SpawnEnemi;
    public List<GameObject> listtriggeractive;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        SpawnEnemi = gameManager.SpawnEnemi;
    }
    private void Start()
    {
        fillbar.value = 0;
    }
    private void Update()
    {

        if(gameManager.GameStart && SpawnEnemi.zombiesIsComing)
        {
            fillbar.value = fillbar.value + 0.01f * speed * Time.deltaTime;
        }
        
        if(curWavecount!= SpawnEnemi.getWavecount())
        {
            curWavecount = SpawnEnemi.getWavecount();
            createWavetrigger();
        }

      
    }
    public void createWavetrigger()
    {
        DestroyAlltriggerWave();
        for (int i = 0; i < curWavecount; i++)
        {
            GameObject trig = Instantiate(wavetrigger, trigger);
            listtriggeractive.Add(trig);
        }
    }
    
    public void DestroyAlltriggerWave()
    {
        foreach(GameObject trigger in listtriggeractive)
        {
            Destroy(trigger);
        }
        listtriggeractive.Clear();
    }

}
