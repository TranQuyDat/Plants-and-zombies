using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public  class TreeShooter : MonoBehaviour
{
    public float HP;
    public float timeDelayAct;
    public GameObject projectile;
    public Transform posshoot;
    private void Start()
    {
        InvokeRepeating("ActionOfTree", timeDelayAct, timeDelayAct);
    }
    public void ActionOfTree() 
    {
        Instantiate(projectile, posshoot.position, Quaternion.identity);

    }
}
