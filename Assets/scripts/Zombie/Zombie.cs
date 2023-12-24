using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : ActionOfzombie
{
    void Update()
    {
        transform.position -= new Vector3(speed*Time.deltaTime, 0, 0);
    }


}
