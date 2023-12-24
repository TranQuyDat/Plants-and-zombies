using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public  class TreeShooter : ActionOfTreeShooter
{
    public Transform PosCheckZom;
    public bool SeeingZom;
    public LayerMask zombieLayer;
    SelectedCusor selectedCusor;
    private void Start()
    {
        selectedCusor = FindObjectOfType<SelectedCusor>();
        PosCheckZom = GameObject.FindGameObjectWithTag("Poscheckzombie").transform;
        InvokeRepeating("action", timeDelayAct, timeDelayAct);
        InvokeRepeating("checkingzom", 1f, 1f);

    }
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && selectedCusor.cur_Item!=null)
        {
            treeDead();
        }
    }
    public override void action()
    {
        if (SeeingZom == false) return;
        Instantiate(projectile, posshoot.position, Quaternion.identity);
    }

    public void checkingzom()
    {
        float distance = (PosCheckZom.position - transform.position).magnitude;
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.right,distance,zombieLayer);
        if (hit.collider != null && hit.collider.CompareTag("zombie"))
        {
            SeeingZom = true;
        }
        else SeeingZom = false;
    }

    public void treeDead()
    {
        Destroy(this.gameObject);
    }
}
