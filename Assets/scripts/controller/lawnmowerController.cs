using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lawnmowerController : MonoBehaviour
{
    public float speed;
    bool ismoving;
    private void Start()
    {
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

    public void dead()
    {
        if (transform.position.x > 15)
        {
            Destroy(this.gameObject);
        }
    }
}
