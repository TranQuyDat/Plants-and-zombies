using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShovelController : MonoBehaviour
{
    public GameObject shovel;
    bool isSelectShovel;
    public SelectedCusor cusor;
    private void Start()
    {
        isSelectShovel = false;
    }
    private void OnMouseDown()
    {
        isSelectShovel = !isSelectShovel;
        if (isSelectShovel)
        {
            selectShovel();
        }
        else shovelDropToBox();
    }
   

    public void selectShovel()
    {
        cusor.cur_Item = shovel;
        shovel.transform.SetParent(cusor.transform);
    }

    public void shovelDropToBox()
    {
        cusor.cur_Item = null;
        shovel.transform.SetParent(this.transform) ;
        shovel.transform.position = this.transform.position;
    }
}
