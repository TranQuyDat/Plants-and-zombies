using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slotTreeMap : MonoBehaviour
{
    public GameObject ShadownTree;
    SelectedCusor selectedCusor;

    bool isSpawn;
    GameObject curTree;
    private void Start()
    {
        isSpawn = false;
        selectedCusor = GameObject.FindObjectOfType<SelectedCusor>();
    }
    private void OnMouseOver()
    {
       // Debug.Log("mouse in " + this.name);
        if(selectedCusor.cur_tree == null || isSpawn)
        {
            ShadownTree.SetActive(false);
            return;
        }
        if(selectedCusor.cur_tree != null && !ShadownTree.active)
        {
            ShadownTree.SetActive(true);
            ShadownTree.GetComponent<SpriteRenderer>().sprite
                = selectedCusor.cur_tree.GetComponent<SpriteRenderer>().sprite;
        }
    }
    private void OnMouseExit()
    {
        Debug.Log("mouse out " + this.name);
        if (ShadownTree.active)
        {
            ShadownTree.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("mouse down " + this.name);
        if(selectedCusor.cur_tree != null && isSpawn == false)
        {
            isSpawn = true;
            curTree = Instantiate(selectedCusor.cur_tree,ShadownTree.transform.position
                ,Quaternion.identity,this.transform);
            selectedCusor.cur_tree = null;
            curTree.transform.localScale = ShadownTree.transform.localScale;
            curTree.GetComponent<SpriteRenderer>().color = Color.white;
        }
        

    }
}
