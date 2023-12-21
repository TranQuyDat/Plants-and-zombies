using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boardchooseTree : MonoBehaviour
{
    public List<GameObject> listslotCard_view;

    public GameObject[] listTreeSelected;

    public GameManager gameManager;
    
    GameObject cur_selectTree;

    private void Update()
    {
        if(listTreeSelected.Length != listslotCard_view.Count)
        {
            listTreeSelected = new GameObject[listslotCard_view.Count];
        }
    }
    public void btn_Add()
    {
        if (cur_selectTree == null) return;
        
        for (int i =0; i<listslotCard_view.Count;i++)
        {
            GameObject item = listslotCard_view[i].
                transform.Find("item").gameObject;
            
            if (item.GetComponent<Image>().sprite != null) continue;

            item.SetActive(true);
            listTreeSelected.SetValue(cur_selectTree, i);
            item.GetComponent<Image>()
                .sprite = cur_selectTree.transform.Find("item")
                .GetComponent<Image>().sprite;
            
            return;
        }
        cur_selectTree = null;
    }

    public void btn_remove()
    {
        for (int i = 0; i < listslotCard_view.Count; i++)
        {
            listTreeSelected.SetValue(null, i);
            GameObject item = listslotCard_view[i].
                transform.Find("item").gameObject;
            item.GetComponent<Image>().sprite = null;
            item.SetActive(false);
        }
    }

    public void btn_start()
    {

    }

    public void setcur_selectTree( GameObject obj)
    {
        if (obj == null) return;
        cur_selectTree = obj;
    }
    
}
