using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingEnemy : MonoBehaviour
{
    public List<GameObject> active;
    public List<GameObject> deactive;
    public Transform parentZom;
    GameObject obj;
    public GameObject create(GameObject prefap, Vector2 pos)
    {
        int length = deactive.Count-1;
        string name = prefap.name+ "(Clone)";
        
        if(deactive  == null|| deactive.Count <=0)
        {
            obj = obj = Instantiate(prefap, pos, Quaternion.identity, parentZom);
            return obj;
        }
        for (int i = 0; i <= length; i++)
        {
            Debug.Log("debug"+name + " " + deactive[i].name );
            if (name == deactive[i].name)
            {
                return  deactive[i];
                
            }
            if (name == deactive[length - i].name)
            {
                return deactive[length - i];
            }
            if (i == (length - i)||i+1==length-i)
            {
                obj = Instantiate(prefap, pos, Quaternion.identity, parentZom);
                break;
            }
        }
        return obj;
    }
    public void pooling(GameObject prefap,Vector2 pos) 
    {
        GameObject obj = create(prefap,pos);
        
        
        obj.SetActive(true);
        ActionOfzombie aczom = obj.GetComponent<ActionOfzombie>() ;
        aczom.setDefault();
        obj.transform.position = pos;
        deactive.Remove(obj);
        active.Add(obj);
    }

    public void destroy(GameObject obj)
    {
        active.Remove(obj);
        deactive.Add(obj);
        obj.SetActive(false);
    }

    public void destroyAll()
    {
        foreach(GameObject obj in active)
        {
            deactive.Add(obj);
            obj.SetActive(false);
        }
        active.Clear();
    }

}
