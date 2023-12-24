using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : ActionOfzombie
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = new Vector2(transform.position.x-1*speed*Time.deltaTime,
            transform.position.y);
        transform.position = pos;
    }
    public override void action()
    {
    }  
}
