using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cell_boardselectTree : MonoBehaviour
{
    public GameObject data;
    public GameObject imgitem;
    private void Update()
    {
        updateItem();
    }

    public void updateItem()
    {
        if (data == null) return;
        imgitem.SetActive(data != null);
        Sprite img = data.GetComponent<Image>().sprite;
        imgitem.GetComponent<Image>().sprite = img ;
    }
}
