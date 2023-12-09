using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleOfFillProgress : MonoBehaviour
{
    public SpawnEnemiManager spawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("nextwave")) return;
        spawn.nextWave = true;
        Debug.Log("nextwave");
    }
}
