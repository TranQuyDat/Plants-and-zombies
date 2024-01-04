using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : ActionOfTreeBomber
{
    public GameManager gameManager;
    public Collider2D[] objs;
    RaycastHit2D hit;
    public float cur_time;
    Animator animator;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        animator = this.GetComponent<Animator>();
        cur_time = timeMaturation;
    }
    private void Update()
    {
        
        if (cur_time > 0)
        {
            cur_time = cur_time - 1 / timeMaturation * Time.deltaTime;
            animator.SetFloat("timeMaturation", cur_time);
            return;
        }
        objs = Physics2D.OverlapCircleAll(this.transform.position, rangeBom, layerzom);
        hit = Physics2D.Raycast(this.transform.position, Vector2.right, disToAction, layerzom);
        action();
    }
    public override void action()
    {
        if (hit.collider != null)
        {
            gameManager.particleManager.getParticleBomFx(this.transform.position);
            foreach (Collider2D obj in objs)
            {
                ActionOfzombie zom = obj.gameObject.GetComponent<ActionOfzombie>();
                zom.hit(zom.hp);
            }
            Destroy(this.gameObject);
        }
    }

    public override void Hit(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, rangeBom);
        Gizmos.color = Color.black;
        Gizmos.DrawRay(this.transform.position, Vector2.right*disToAction);
    }

}
