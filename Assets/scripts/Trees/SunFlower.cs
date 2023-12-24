using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : ActionOfTreeGetSun
{
    // Start is called before the first frame update
    void Start()
    {
         InvokeRepeating("action", timeDelayAct, timeDelayAct);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void action()
    {
        Instantiate(prefapSun, posSpawnSun.position, Quaternion.identity);
    }
}
