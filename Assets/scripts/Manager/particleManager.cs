using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleManager : MonoBehaviour
{
    ParticleSystem fx;
    
    public void callParticleFx(Vector2 pos,GameObject fxobj)
    {
        GameObject obj = Instantiate(fxobj, pos, Quaternion.identity, this.transform);
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
