using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Scene
{
    Menu,
    Map1,
    Map2,
    Map3
}
public class SceneINFO : MonoBehaviour
{
    public Scene NextScene;
    public SoundType st;
    GameManager gameManager;
 
}
