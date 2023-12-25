using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectBarController : MonoBehaviour
{
    public List<GameObject> listselectbar;
    public GameObject[] listslot;
    private void Update()
    {
        updateSelectbar();
    }
    public void updateSelectbar()
    {
        if (listselectbar.Count <= 0) return;
        for(int i=0; i < listslot.Length; i++)
        {
            if (listselectbar.Count == i) return;
            if (listslot[i].transform.childCount > 0) continue;
            Instantiate(listselectbar[i], listslot[i].transform);
        }
    }
}
