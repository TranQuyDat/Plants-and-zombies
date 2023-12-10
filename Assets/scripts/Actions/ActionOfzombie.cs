using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionOfzombie : MonoBehaviour, AIaction
{
    public float hp;
    public abstract void action();
}
