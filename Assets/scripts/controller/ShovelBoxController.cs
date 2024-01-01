using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelBoxController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Shovel;
    public SelectedCusor cursor;
    public LayerMask layershover;
    [HideInInspector] public bool isSelectShovel;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        isSelectShovel = false;
    }
    private void Update()
    {
        Vector2 dir = (Shovel.transform.position - this.transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, dir, 1f, layershover);
        
        if (hit.collider != null && Shovel.GetComponent<BoxCollider2D>().isActiveAndEnabled)
        {
            Shovel.GetComponent<BoxCollider2D>().enabled = false;
        }
        if(((Vector2)Shovel.transform.position - (Vector2)this.transform.position).magnitude > 1f)
        {
            Shovel.GetComponent<BoxCollider2D>().enabled = true;
        }
       

    }
    private void OnMouseDown()
    {
        if (!gameManager.GameStart|| cursor.cur_tree != null) return;
        if (!isSelectShovel)
        {
            selectShovel();
        }
        else shovelDropToBox();
    }

    public void selectShovel()
    {
        if (isSelectShovel) return;
        cursor.cur_Item = Shovel;
        Shovel.transform.SetParent(cursor.transform);
        isSelectShovel = true;
    }

    public void shovelDropToBox()
    {
        if (isSelectShovel == false) return;
        cursor.cur_Item = null;
        Shovel.transform.SetParent(this.transform);
        Shovel.transform.position = this.transform.position;
        isSelectShovel = false;
    }

    


}
