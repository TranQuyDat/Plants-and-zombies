using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPot : ActionOfTree
{
    public override void action()
    {
        
    }

    public override void Hit(float damage)
    {
        hp -= damage;
        if (hp > 0) return;
        Destroy(this.gameObject);
    }
}
