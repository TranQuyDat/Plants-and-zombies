using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject selectMapPanel;
    public soundManager soundManager;
    public SceneINFO sceneINFO;
    private void Start()
    {
        soundManager = FindObjectOfType<soundManager>();
        soundManager.musicTheme.mute = false;
        soundManager.playMusic(sceneINFO.st,true);
        
    }
    public void StartGame()
    {
        selectMapPanel.SetActive(true);
        
        soundManager.playSFX(SoundType.sfx_click);
    }

    public void BtnSetting_Pressed()
    {
        settingPanel.SetActive(true);
        soundManager.playSFX(SoundType.sfx_click);
    }

    public void BtnBack(GameObject obj)
    {
        // Khi ấn nút "BacktoMenu", chúng ta chuyển trạng thái về "Menu"
        obj.SetActive(false);
        soundManager.playSFX(SoundType.sfx_click);
    }
    public void BtnQuit()
    {
        Application.Quit();
    }

}
