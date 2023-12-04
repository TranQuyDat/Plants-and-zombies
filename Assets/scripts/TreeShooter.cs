using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class TreeShooter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
=======
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
>>>>>>> b9561e574c37c843f4c2db1374bbe11a58712448
    }
}
