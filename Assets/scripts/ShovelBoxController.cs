using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelBoxController : MonoBehaviour
{
    public GameObject Shovel;
    public SelectedCusor cursor;

    [HideInInspector] public bool isSelectShovel;
    private void Start()
    {
        isSelectShovel = false;
    }
    private void OnMouseDown()
    {
        if (cursor.cur_tree != null) return;
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
