using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo : ActionOfzombie
{
    [HideInInspector] public SpawnEnemiManager spawn;
    private GameObject zombies;
    private void Update()
    {
        action();
    }
    public override void action()
    {
        walk();
    }

    public void walk()
    {
        Vector2 pos = new Vector2(this.gameObject.transform.position.x-1*Time.deltaTime, this.gameObject.transform.position.y);
        this.gameObject.transform.position = pos;
    }
}
