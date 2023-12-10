using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public  class TreeShooter : ActionOfTreeShooter
{
    private void Start()
    {
        InvokeRepeating("action", timeDelayAct, timeDelayAct);
    }
    public override void action()
    {
        Instantiate(projectile, posshoot.position, Quaternion.identity);
    }
}
