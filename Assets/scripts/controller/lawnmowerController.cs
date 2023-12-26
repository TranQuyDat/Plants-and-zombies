using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lawnmowerController : MonoBehaviour
{
    public float speed;
    bool ismoving;
    Vector2 posStart;
    private void Awake()
    {
        posStart = this.transform.position;
    }
    private void Start()
    {
        posStart = this.transform.position;
        ismoving = false;
    }
    private void Update()
    {
        if (ismoving)
        {
            moving();
            dead();
        }
    }

    public void moving()
    {
        Vector2 pos = new Vector2(this.transform.position.x + 1 * speed * Time.deltaTime
            , this.transform.position.y);
        this.transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("zombie"))
        {
            Destroy(collision.gameObject);
            ismoving = true;
        }
    }

    public void setDefault() 
    {
        ismoving = false;
        this.transform.position = posStart;
    }

    public void dead()
    {
        if (transform.position.x > 15)
        {
            this.gameObject.SetActive(false);
        }
    }
}
