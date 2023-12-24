using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOfzombie : MonoBehaviour
{
    public float speed;
    public int hp;
    public int range;
    public int damage;
    public float cooldown;
    public LayerMask plantMask;
    private bool canWalk = true;
    private bool canEat = true;
    public void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, plantMask);

        if (hit.collider && hit.collider.CompareTag("tree"))
        {
            AIaction targetTree = hit.collider.GetComponent<AIaction>();
            canWalk = false;
            // Zombie detected a plant, stop walking
            Debug.Log("Da gap plant");
            // Zombie detected a plant, stop walking
            Eat(targetTree);
            
        }
        else
        {
            // No plant detected, resume walking
            canWalk = true;
        }

        if (canWalk)
        {
            Walk();
        }
    }
    public void Walk()
    {
        Vector2 pos = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        transform.position = pos;
    }
    public void Eat(AIaction targetTree)
    {
        Debug.Log("Goi Ham Eat");
        if (!canEat)
            return;
        canEat = false;
        Debug.Log("Before invoking EatCooldown");
        Invoke("EatCooldown", cooldown);
        Debug.Log("After invoking EatCooldown");
        targetTree.Hit(damage);
    }
    public void EatCooldown()
    {
        Debug.Log("Goi ham eat cool down");
        canEat = true;
    }
}
