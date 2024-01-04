using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ActionOfTree : MonoBehaviour, AIaction
{
    public float hp;
    public float damage;
    public abstract void action();
    public abstract void Hit(float damage);
}
public abstract class ActionOfTreeShooter : ActionOfTree
{
    public float timeDelayAct;
    public GameObject projectile;
    public Transform posshoot;
}
public abstract class ActionOfTreeGetSun : ActionOfTree
{
    public float timeDelayAct;
    public GameObject prefapSun;
    public Transform posSpawnSun;
}
public abstract class ActionOfTreeBomber : ActionOfTree
{
    public float rangeBom;
    public float disToAction;
    public float timeMaturation;
    public LayerMask layerzom;
}
