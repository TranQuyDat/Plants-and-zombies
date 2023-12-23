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
    public SpawnEnemiManager SpawnEnemi;
    public int curWavecount;

    public List<GameObject> listtriggeractive;
    private void Start()
    {
        fillbar.value = 0;
    }
    private void Update()
    {
        fillbar.value = fillbar.value + 0.01f*speed *Time.deltaTime;
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
