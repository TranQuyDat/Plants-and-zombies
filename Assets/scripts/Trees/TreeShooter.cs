using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public  class TreeShooter : ActionOfTreeShooter
{
    public Transform PosCheckZom;
    public bool SeeingZom;
    public bool isShooting;
    public LayerMask zombieLayer;
    public GameManager gameManager;
    public Animator animator;
    SelectedCusor selectedCusor;
    private void Start()
    {
        animator = this.GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        selectedCusor = FindObjectOfType<SelectedCusor>();
        PosCheckZom = GameObject.FindGameObjectWithTag("Poscheckzombie").transform;
        InvokeRepeating("action", timeDelayAct, timeDelayAct);
        InvokeRepeating("checkingzom", 1f, 1f);

    }

    public override void action()
    {
        if (SeeingZom == false) return;
        StartCoroutine(spawnPrjt());
    }
    IEnumerator spawnPrjt()
    {
        animator.SetBool("ishooting", true);
        yield return new WaitUntil(()=> isShooting == true);
        isShooting = false;
        animator.SetBool("ishooting", false);
        GameObject prjt = Instantiate(projectile, posshoot.position, Quaternion.identity);
        prjt.GetComponent<projectileController>().damage = damage;
        gameManager.soundManager.playSFX(SoundType.sfx_spawnPrjt);
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
    public override void Hit(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
