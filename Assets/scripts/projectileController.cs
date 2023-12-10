using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{

    public float speed;
    public float damage;

    float timelife;
    // Start is called before the first frame update
    void Start()
    {
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
}
