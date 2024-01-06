using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum tranType
{
    transitionClose,
    transitionOpen,
}
public class LoadSceneSmoothy : MonoBehaviour
{
    Animator animator;
    public bool endTransition;
    public soundManager sound;
    Image img;
    private void Start()
    {
        sound = FindObjectOfType<soundManager>();
        img = this.GetComponent<Image>();
        animator = GetComponent<Animator>();
    }

    public void callTransition(tranType type)
    {
        sound.musicTheme.mute = true;
        sound.SFX.Stop();
        img.enabled = true;
        animator.Play(type.ToString());
        StartCoroutine(waitActiveimg());
    }

    IEnumerator waitActiveimg()
    {
        yield return new WaitForSeconds(1f);
        img.enabled = false;
        yield return new WaitForSeconds(0.05f);
        sound.musicTheme.mute = false;
    }

    public void LoadSceneWithtransition(Scene scene,tranType type)
    {
        sound.musicTheme.mute = true;
        StartCoroutine(waitTransition(type, scene));
    }

    IEnumerator waitTransition(tranType name,Scene scene)
    {
        img.enabled = true;
        animator.Play(name.ToString());
        yield return new WaitForSeconds(1f);
        endTransition = false;
        SceneManager.LoadScene(scene.ToString());
    }
}
