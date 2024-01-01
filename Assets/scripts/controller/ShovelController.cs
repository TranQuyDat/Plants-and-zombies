using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelController : MonoBehaviour
{
    public GameManager gameManager;
    public bool isSelectShovel;
    public GameObject boxshovel;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("tree"))
        {
            SpriteRenderer ren = collision.GetComponent<SpriteRenderer>();
            ren.color = Color.gray;
            if (!Input.GetMouseButton(0)) return;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("tree"))
        {
            SpriteRenderer ren = collision.GetComponent<SpriteRenderer>();
            ren.color = Color.white;
        }
    }
}
