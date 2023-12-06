using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo : MonoBehaviour
{
    public SpawnEnemiManager spawn;
    public void destroyenemy()
    {
        spawn.alivezombiecount--;
    }
}
