using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    public TextMeshProUGUI txt_name;
    public Image Img;
    public Sprite MapSprite;
    public Scene mapScene;
    private void Start()
    {
        Img.sprite = MapSprite;
        txt_name.text = mapScene.ToString();
    }
    public void clickToMap()
    {
        SceneManager.LoadScene(mapScene.ToString());
    } 
}
