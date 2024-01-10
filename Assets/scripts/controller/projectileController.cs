using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject FXobj;
    public float speed;
    public float damage;
    public Animator animator;
    float timelife;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        animator = FindObjectOfType<Animator>();
        timelife = 4.7f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = new Vector2(transform.position.x+1*speed*Time.deltaTime,
            transform.position.y);
        transform.position = pos;
        if(gameManager.GameStart == false)
        {
            destoyprjt();
        }
        Invoke("destoyprjt", timelife);
        
    }

    public void destoyprjt()
    {
        Destroy(this.gameObject);
        CancelInvoke("lifetime");
    }

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("zombie"))
        {
            gameManager.particleManager.callParticleFx(this.transform.position, FXobj);
            gameManager.soundManager.playSFX(SoundType.sfx_prjtMetzom);
            Destroy(this.gameObject);
        }
    }
    
 
}
