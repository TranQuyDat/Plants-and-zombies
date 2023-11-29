using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCusor : MonoBehaviour
{
    public GameObject slotTree = null;
    public GameObject cur_tree = null;

    bool isSelected ;
    private void Start()
    {
        isSelected = false; 
    }
    private void Update()
    {
        selectTree();
    }

    public void selectTree()
    {
        if (cur_tree == null && !slotTree.active) return;
        if (cur_tree == null && slotTree.active)
        {
            slotTree.SetActive(false);
            isSelected = false;
            return;
        }
        if (!isSelected)
        {
            slotTree.SetActive(true);
            slotTree.GetComponent<SpriteRenderer>().sprite
                = cur_tree.GetComponent<SpriteRenderer>().sprite;
            isSelected = true;
        }
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        slotTree.transform.position = new Vector2( pos.x,pos.y-2f);

    }
}
