using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TreeCardController : MonoBehaviour
{
    public GameObject Tree;
    public SelectedCusor selectedCusor;

    private void OnMouseDown()
    {
        Debug.Log("this ok ");
        selectedCusor.cur_tree = Tree;
        selectedCusor.isSelected = false;
    }
}
