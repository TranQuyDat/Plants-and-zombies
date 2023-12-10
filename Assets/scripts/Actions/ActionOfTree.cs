using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionOfTreeShooter : MonoBehaviour, AIaction
{
    public float hp;
    public float timeDelayAct;
    public GameObject projectile;
    public Transform posshoot;
    public abstract void action();
}
public abstract class ActionOfTreeGetSun : MonoBehaviour, AIaction
{
    public float hp;
    public float timeDelayAct;
    public GameObject prefapSun;
    public Transform posSpawnSun;
    public abstract void action();
}
public abstract class ActionOfTreeShield : MonoBehaviour, AIaction
{
    public float hp;
    public abstract void action();
}