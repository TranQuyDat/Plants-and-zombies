using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCusor : MonoBehaviour
{
    
    public GameObject slotTree ;// slot de chua anh cua tree
    public GameObject cur_tree = null;// chua prefab cua trees
    public GameObject cur_Item = null;// chua prefab item (shovel)
    public ShovelBoxController shovelboxctrl;
    GameManager gameManager;
    [HideInInspector] public bool isSelected;
    [HideInInspector] public int priceOftree;
    private void Start()
    {
        isSelected = false;
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if (!gameManager.GameStart) return;
        selectTree();
        selectItem();
        ResetCursor();
    }

    public void selectTree()
    {
        if (cur_Item!=null||(cur_tree == null && !slotTree.active)) return;
        if (cur_tree == null && slotTree.active)
        {
            slotTree.SetActive(false);
            isSelected = false;
            return;
        }
        if (!isSelected )
        {
            slotTree.SetActive(true);
            slotTree.GetComponent<SpriteRenderer>().sprite
                = cur_tree.GetComponent<SpriteRenderer>().sprite;
            isSelected = true;
        }
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        slotTree.transform.position = new Vector2( pos.x,pos.y-1.5f);

    }
    public void selectItem()
    {
        if (cur_Item == null) return;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cur_Item.transform.position = new Vector2(pos.x, pos.y);

    }

    public void ResetCursor()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse1)) return;
        if(cur_tree != null)
        {
            gameManager.pointsManager.addPoint(priceOftree);
            priceOftree = 0;
        }
        cur_tree = null;
        cur_Item = null;
        isSelected = false;
        slotTree.SetActive(false);
        shovelboxctrl.shovelDropToBox();
    }
}
