using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleManager : MonoBehaviour
{
    public GameObject hitfx;
    public GameObject bomfx;
    ParticleSystem fx;
    
    public void getParticleHitFx(Vector2 pos)
    {
        GameObject obj = Instantiate(hitfx, pos, Quaternion.identity, this.transform);
        fx = obj.GetComponent<ParticleSystem>();
        fx.Play();
        StartCoroutine(deactiveFx(fx));
    }

    public void getParticleBomFx(Vector2 pos)
    {
        GameObject obj =  Instantiate(bomfx, pos, Quaternion.identity, this.transform);
        fx = obj.GetComponent<ParticleSystem>();
        fx.Play();
        StartCoroutine(deactiveFx(fx));
    }

    IEnumerator deactiveFx(ParticleSystem fx)
    {
        yield return new WaitUntil(() => !fx.isPlaying);
        Destroy(fx.gameObject);
    }
}
