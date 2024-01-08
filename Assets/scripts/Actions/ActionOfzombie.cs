using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOfzombie : MonoBehaviour
{
    public bool isIdle;
    public float maxhp;
    public float maxSpeed;
    public float speed;
    public float hp;
    public int range;
    public float damage;
    public float cooldown;
    public LayerMask plantMask;
    private bool canWalk = true;
    private bool canEat = true;
    public Animator myAnimator;
    public GameManager gameManager;
    public PoolingEnemy poolingEnemy;

    private void Awake()
    {
        poolingEnemy = FindObjectOfType<PoolingEnemy>();
        gameManager = FindObjectOfType<GameManager>();
        myAnimator = GetComponent<Animator>();
    }
    public void Start()
    {
        hp = maxhp;
        speed = maxSpeed;
        myAnimator.SetFloat("hp", hp/ maxhp);
        
    }
    public void Update()
    {
        onCollideTheTree();
        Idle();
    }

    public void Idle()
    {
        if(isIdle)
        {
            myAnimator.Play("idle");
            speed = 0;
        }
    }
    public void setDefault()
    {
        hp = maxhp;
        this.GetComponent<SpriteRenderer>().color = Color.white;
        speed = maxSpeed;
        myAnimator.SetFloat("hp", hp / maxhp);
        isIdle = false;
    }
    public void onCollideTheTree()
    {
        if (isIdle) return;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, plantMask);

        if (hit.collider && (hit.collider.CompareTag("tree") || hit.collider.CompareTag("flowerpot")) )
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
        myAnimator.SetBool("walk",true);
        myAnimator.SetBool("eat",false);
        Vector2 pos = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        transform.position = pos;
    }
    public void Eat(AIaction targetTree)
    {
        Debug.Log("Goi Ham Eat");
        if (!canEat)
            return;
        canEat = false;
        myAnimator.SetBool("walk", false);
        myAnimator.SetBool("eat", true);
        gameManager.soundManager.playSFX(SoundType.sfx_zombieEat);
        Debug.Log("Before invoking EatCooldown");
        Invoke("EatCooldown", cooldown);

        Debug.Log("After invoking EatCooldown");
        targetTree.Hit(damage);
    }
    public void EatCooldown()
    {
        canEat = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("projectile"))
        {
            projectileController prj = collision.GetComponent<projectileController>();
            
            hit(prj.damage);
            StartCoroutine(setcolor());
        }
    
    }
    IEnumerator setcolor()
    {
        if (this.gameObject != null)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(1f);
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void hit(float damage)
    {
        hp = hp - damage;
        myAnimator.SetFloat("hp", hp/maxhp);
        if (hp > 0) return;
        StartCoroutine(dead());
        
    }

    IEnumerator dead()
    {
        speed = 0f;
        myAnimator.SetBool("dead", true);
        gameManager.soundManager.playSFX(SoundType.sfx_zombieFall);
        yield return new WaitForSeconds(2f);
        gameManager.UpdateAliveZB(-1);
        poolingEnemy.destroy(this.gameObject);//destroy zom
    }
}
