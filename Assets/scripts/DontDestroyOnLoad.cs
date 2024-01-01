using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public string objectid;
    private void Awake()
    {
        objectid = name;
        for (int i = 0; i < Object.FindObjectsOfType<DontDestroyOnLoad>().Length; i++)
        {
            if (Object.FindObjectsOfType<DontDestroyOnLoad>()[i].objectid == objectid &&
                Object.FindObjectsOfType<DontDestroyOnLoad>()[i] != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}