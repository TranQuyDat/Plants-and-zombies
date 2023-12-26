using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectBarController : MonoBehaviour
{
    public List<GameObject> listselectbar;//list chua cac prefap lay tu board
    public GameObject[] listslot;// cac slot de lam tranform cho treeCard
    public List<GameObject> listTreeCard; // list chua cac prefap_treecard trong slot
    private void Update()
    {
        updateSelectbar();
    }

    public void setDF()
    {
        listselectbar.Clear();
        foreach(GameObject treecard in listTreeCard)
        {
            Destroy(treecard);
        }
        listTreeCard.Clear();
    }
    public void updateSelectbar()
    {
        if (listselectbar.Count <= 0) return;
        for(int i=0; i < listslot.Length; i++)
        {
            if (listselectbar.Count == i) return;
            if (listslot[i].transform.childCount > 0) continue;
            GameObject treecard =  Instantiate(listselectbar[i], listslot[i].transform);
            listTreeCard.Add(treecard);
        }
    }
}
