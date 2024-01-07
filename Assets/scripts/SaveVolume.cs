using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "saveVolume", menuName = "soundManager/createSaveVolume")]
public class volume : ScriptableObject
{
    [Range(0.01f, 1)] public float CurvolumeMusic;
    [Range(0.01f, 1)] public float CurvolumeSFX;
}