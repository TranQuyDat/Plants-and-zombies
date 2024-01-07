using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public enum SoundType
{
    music_gamePlay, 
    music_menu,
    sfx_potatoBomb,
    sfx_prjtMetzom,
    sfx_point,
    sfx_zombieFall,
    sfx_zombieEat,
    sfx_spawnPrjt,
    sfx_planting,
    sfx_lawnmower,
    sfx_getShovel,
    sfx_cutdownTree,
    music_win,
    sfx_vasebreaking,
    music_gameover,
    sfx_scream,
    sfx_click,
    sfx_zomcoming

}
public class soundManager : MonoBehaviour
{
    public AudioSource musicTheme;
    public AudioSource SFX;
    public AudioMixer mixer;
    public volume saveVolume;
    [Header("Music")]
    public AudioClip music_gamePlay;
    public AudioClip music_menu;
    public AudioClip music_win;
    public AudioClip music_gameover;
    [Header("SFX")]
    public AudioClip sfx_potatoBomb;
    public AudioClip sfx_prjtMetzom;
    public AudioClip sfx_point;
    public AudioClip sfx_zombieFall;
    public AudioClip sfx_zombieEat;
    public AudioClip sfx_spawnPrjt;
    public AudioClip sfx_planting;
    public AudioClip sfx_lawnmower;
    public AudioClip sfx_getShovel;
    public AudioClip sfx_cutdownTree;
    public AudioClip sfx_vasebreaking;
    public AudioClip sfx_scream;
    public AudioClip sfx_click;
    public AudioClip sfx_zomcoming;

    public Dictionary<SoundType, AudioClip> dicSound;
    public SceneINFO sceneINFO;
    public SoundType curMusicScene;
    private void Awake()
    {
         dicSound = new Dictionary<SoundType, AudioClip>
        {
            { SoundType.music_menu , music_menu },
            { SoundType.music_gamePlay , music_gamePlay },
            { SoundType.sfx_point , sfx_point },
            { SoundType.sfx_potatoBomb , sfx_potatoBomb },
            { SoundType.sfx_prjtMetzom , sfx_prjtMetzom },
            { SoundType.sfx_zombieFall , sfx_zombieFall },
            { SoundType.sfx_spawnPrjt , sfx_spawnPrjt },
            { SoundType.sfx_zombieEat , sfx_zombieEat },
            { SoundType.sfx_planting , sfx_planting },
            { SoundType.sfx_lawnmower , sfx_lawnmower },
            { SoundType.sfx_getShovel , sfx_getShovel },
            { SoundType.sfx_cutdownTree , sfx_cutdownTree },
            { SoundType.music_win , music_win },
            { SoundType.sfx_vasebreaking , sfx_vasebreaking },
            { SoundType.music_gameover , music_gameover },
            { SoundType.sfx_scream , sfx_scream },
            { SoundType.sfx_click , sfx_click },
            { SoundType.sfx_zomcoming , sfx_zomcoming },
        };
        sceneINFO = FindObjectOfType<SceneINFO>();
    }
    private void Start()
    {
        mixer.SetFloat("Master", 40 * Mathf.Log10(saveVolume.CurvolumeMusic));
        mixer.SetFloat("SFX", 40 * Mathf.Log10(saveVolume.CurvolumeSFX));
    }

    private void Update()
    {
        if(sceneINFO == null)
        {
            sceneINFO = FindObjectOfType<SceneINFO>();
        }
    
    }

    public void playMusic(SoundType st,bool isloop,float delaytime=0)
    {
        musicTheme.loop = isloop;
        musicTheme.clip = dicSound[st];
        musicTheme.PlayDelayed(delaytime) ;
    }
    public void playSFX(SoundType st)
    {
        SFX.PlayOneShot(dicSound[st]);
    }
 

    public void setVolumeMusic(float v)
    {
        mixer.SetFloat("Master", 40 * Mathf.Log10(v));
    }
    public void setVolumeSFX(float v)
    {
        mixer.SetFloat("SFX", 40*Mathf.Log10(v));
    }
}
