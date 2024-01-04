using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walnut : ActionOfTree
{
    float curhp;
    Animator animator;
    private void Start()
    {
        animator = this.GetComponent<Animator>();
        curhp = hp;
        animator.SetFloat("hp", curhp / hp);
    }
    public override void action()
    {
        
    }

    public override void Hit(float damage)
    {
        
        curhp -= damage;
        animator.SetFloat("hp", curhp / hp);
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
