using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{

    public float speed;
    public float damage;
    public Animator animator;
    float timelife;
    // Start is called before the first frame update
    void Start()
    {
        animator = FindObjectOfType<Animator>();
        timelife = Random.Range(5, 7);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = new Vector2(transform.position.x+1*speed*Time.deltaTime,
            transform.position.y);
        transform.position = pos;
        Invoke("lifetime",timelife);
    }

    public void lifetime()
    {
        Destroy(this.gameObject);
        CancelInvoke("lifetime");
    }

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("zombie"))
        {
            SpriteRenderer sprite =  collision.GetComponent<SpriteRenderer>();
            sprite.color = Color.red;
            StartCoroutine(destroyprjt(sprite));
        }
    }
    
    IEnumerator destroyprjt(SpriteRenderer sprite)
    {
        animator.Play("effectshooter");
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);

        if(sprite != null) sprite.color = Color.white;
    }
}
