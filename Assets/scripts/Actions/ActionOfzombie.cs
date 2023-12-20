using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionOfzombie : MonoBehaviour, AIaction
{
    public float speed;
    public int hp;
    
    public abstract void action();
}
