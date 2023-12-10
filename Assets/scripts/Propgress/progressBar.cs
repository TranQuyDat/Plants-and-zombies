using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressBar : MonoBehaviour
{
    public Slider fillbar;
    public float speed; 

    private void Start()
    {
        fillbar.value = 0;
    }
    private void Update()
    {
        fillbar.value = fillbar.value + 0.01f*speed *Time.deltaTime;

    }

}
