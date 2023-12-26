using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnMowerManager : MonoBehaviour
{
    public lawnmowerController[] LawnMowers;

    public void setDf_LawnMowers()
    {
        foreach (lawnmowerController law in LawnMowers)
        {
            law.gameObject.SetActive(true);
            law.setDefault();
        }
    }
}
