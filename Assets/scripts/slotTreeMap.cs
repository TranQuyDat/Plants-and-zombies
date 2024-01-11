using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slotTreeMap : MonoBehaviour
{
    public GameObject ShadownTree;
    public string SlotType;
    public GameManager gameManager;
    SelectedCusor selectedCusor;

    bool isnotEmty;
    GameObject curTree;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        isnotEmty = false;
        selectedCusor = GameObject.FindObjectOfType<SelectedCusor>();
    }
    private void Update()
    {

        if (isnotEmty && curTree == null)
        {
            isnotEmty = false;
        }
    }
    private void OnMouseOver()
    {
       // Debug.Log("mouse in " + this.name);
        if( selectedCusor.cur_tree == null || isnotEmty)
        {
            ShadownTree.SetActive(false);
            return;
        }
        if(selectedCusor.cur_tree != null && !ShadownTree.active &&
            !selectedCusor.cur_tree.CompareTag(this.gameObject.tag))
        {
            showShadowNotTree();
            showShadowTree();
        }
    }
    public void showShadowNotTree() // khi slot ko phai dat thi kkong trong cay dc
    {
        if (selectedCusor.cur_tree.CompareTag("tree")) return;
        if (selectedCusor.cur_tree != null && !ShadownTree.active)
        {
            ShadownTree.SetActive(true);
            ShadownTree.GetComponent<SpriteRenderer>().sprite
                = selectedCusor.cur_tree.GetComponent<SpriteRenderer>().sprite;
        }
    }
    public void showShadowTree()
    {
        if (SlotType != "ground") return;
        if (selectedCusor.cur_tree != null && !ShadownTree.active)
        {
            ShadownTree.SetActive(true);
            ShadownTree.GetComponent<SpriteRenderer>().sprite
                = selectedCusor.cur_tree.GetComponent<SpriteRenderer>().sprite;
        }
    }
    private void OnMouseExit()
    {
        //Debug.Log("mouse out " + this.name);
        if (ShadownTree.active)
        {
            ShadownTree.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        //Debug.Log("mouse down " + this.name);
        if (selectedCusor.cur_tree != null && selectedCusor.cur_tree.CompareTag("tree") && SlotType != "ground") return;
        if(selectedCusor.cur_tree != null && isnotEmty == false && 
            !selectedCusor.cur_tree.CompareTag(this.tag))
        {
            gameManager.soundManager.playSFX(SoundType.sfx_planting);
            isnotEmty = true;
            curTree = Instantiate(selectedCusor.cur_tree,ShadownTree.transform.position
                ,Quaternion.identity,this.transform);
            gameManager.treeManager.listTree.Add(curTree);
            selectedCusor.cur_tree = null;
            curTree.transform.localScale = ShadownTree.transform.localScale;
            curTree.GetComponent<SpriteRenderer>().color = Color.white;
            selectedCusor.treeCard.mask.fillAmount = 1;
        }
    }
}
