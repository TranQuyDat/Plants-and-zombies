using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class  wave
{
    public int ZombiesCount;
    public GameObject[] zombiesType;
}

[System.Serializable]
class Level
{
    public List<wave> listwave;
    [HideInInspector] public wave cur_wave;
    public void updateWave(int index)
    {
        if (index > listwave.Count) return;
        cur_wave = listwave[index];
    }
}
public class SpawnEnemiManager : MonoBehaviour
{
    public GameManager gameManager;
    public List<Transform> listPosSpawn;
    public List<GameObject> listZombiesSpawned;
    [SerializeField] private List<Level> Levels ;
    public float timedelaySpawn;
    public bool nextWave;
    public Transform parentZom;

    int levelnum, wavenum;
    int Cur_ZombiesCount;
    Level curLevel;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        defaultSetting();
        InvokeRepeating("spawnZombies", timedelaySpawn, timedelaySpawn);
    }

    public void defaultSetting()
    {
        Cur_ZombiesCount = 0;
        levelnum = 0;
        wavenum = -1;
        curLevel = Levels[levelnum];
    }
    public void updateLevel()
    {
        levelnum++;
        if (levelnum >= Levels.Count) return;
            curLevel = Levels[levelnum];
    }
    public void NextWave()
    {
        wavenum++;
        if ( wavenum > curLevel.listwave.Count) //check khi het so luong wave cua 1 level
        {
            wavenum = 0;
            updateLevel();
        }
        curLevel.updateWave(wavenum);
        Cur_ZombiesCount = curLevel.cur_wave.ZombiesCount; // gan lai so luong zombies cua wave
        nextWave = false;
    }
    public void spawnZombies()
    {
        if (!gameManager.GameStart) return;
        if (levelnum>=0 && Cur_ZombiesCount > 0) // check so luong zombies cua moi wave
        {
            
            GameObject randomZombie = curLevel.cur_wave.zombiesType[
                Random.Range(0, curLevel.cur_wave.zombiesType.Length-1)]; // lay random type zombies
            Transform randomSpawn =listPosSpawn[ Random.Range(0, listPosSpawn.Count-1) ]; // lay random pos spawn zombies
            GameObject zombie = Instantiate(randomZombie,
                randomSpawn.position,Quaternion.identity, parentZom);//sinh ra zombies

            listZombiesSpawned.Add(zombie);
            Cur_ZombiesCount--;
            return;
        }

        if (nextWave == false) return;
        NextWave();
    }

    public int getWavecount()
    {
        return curLevel.listwave.Count;
    }
    public int getAllzombiescount()
    {
        int sum = 0 ;
        foreach(Level lv in Levels)
        {
            foreach ( wave w in lv.listwave)
            {
                sum += w.ZombiesCount;
            }
        }
        return sum;
    }
    public void destroyAllzombies()
    {
        foreach (GameObject zom in listZombiesSpawned) 
        {
            Destroy(zom);
        }
        listZombiesSpawned.Clear();
           
    }
}
