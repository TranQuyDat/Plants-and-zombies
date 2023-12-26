using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public List<GameObject> listTree;

    public void destroyAllTree()
    {
        foreach(GameObject tree in listTree)
        {
            Destroy(tree);
        }
        listTree.Clear();
    }
}
