using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TreeCardController : MonoBehaviour
{
    public GameObject Tree;
    SelectedCusor selectedCusor;
    private void Start()
    {
        selectedCusor = GameObject.FindAnyObjectByType<SelectedCusor>()
            .GetComponent<SelectedCusor>();
    }
    private void OnMouseDown()
    {
        if (selectedCusor.cur_Item != null) return;
        Debug.Log("this ok ");
        selectedCusor.cur_tree = Tree;
        selectedCusor.isSelected = false;
    }
}
