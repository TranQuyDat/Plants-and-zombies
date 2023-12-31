using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float timedelay;
    public int sunPoint;
    public GameObject target;
    GameManager gameManager;
    public bool isaddpoint;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        target = GameObject.FindGameObjectWithTag("posSun");
    }
    private void Update()
    {
        if (!gameManager.GameStart)
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            return;
        }
        StartCoroutine(movetoAndaddpoint());
    }
    public void addpoint()
    {
        gameManager.pointsManager.addPoint(sunPoint);
        Destroy(this.gameObject);
        isaddpoint = false;
    }

    IEnumerator movetoAndaddpoint()
    {
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.01f;
        yield return new WaitForSeconds(5f);
        MoveTo();
        yield return new WaitUntil(()=> isaddpoint);
        addpoint();
    }
    public void MoveTo()
    {

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("posSun");
        }
        Vector3 pos = target.transform.position;
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.transform.position = Vector2.Lerp(this.transform.position, pos, 0.1f);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("posSun"))
        {
            isaddpoint = true;
        }
    }
}
