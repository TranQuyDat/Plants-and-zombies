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
    public List<Transform> listPosSpawn;
    [SerializeField] private List<Level> Levels ;
    public float timedelaySpawn;
    Level curLevel;
    int levelnum, wavenum;
    [HideInInspector] public int alivezombiecount;
    int Cur_ZombiesCount;
    private void Start()
    {
        defaultSetting();
        InvokeRepeating("spawnZombies", timedelaySpawn, timedelaySpawn);
    }

    public void defaultSetting()
    {
        levelnum = 0;
        wavenum = 0;
        curLevel = Levels[levelnum];
        curLevel.updateWave(wavenum);
        Cur_ZombiesCount = curLevel.cur_wave.ZombiesCount;
        alivezombiecount = Cur_ZombiesCount;
    }
    public void updateLevel()
    {
        levelnum++;
        curLevel = Levels[levelnum];
    }
    public void spawnZombies()
    {
        if (Cur_ZombiesCount > 0) // check so luong zombies cua moi wave
        {
            
            GameObject randomZombie = curLevel.cur_wave.zombiesType[
                Random.Range(0, curLevel.cur_wave.zombiesType.Length)]; // lay random type zombies
            Transform randomSpawn =listPosSpawn[ Random.Range(0, listPosSpawn.Count) ]; // lay random pos spawn zombies
            Instantiate(randomZombie,randomSpawn.position,Quaternion.identity);//sinh ra zombies
            Cur_ZombiesCount--;
            return;
        }
        if (alivezombiecount > 0) return;
        wavenum++;
        if (wavenum > curLevel.listwave.Count) //check khi het wave cua 1 level
        {
            wavenum = 0;
            updateLevel();
        }
        curLevel.updateWave(wavenum);
        Cur_ZombiesCount = curLevel.cur_wave.ZombiesCount;
        alivezombiecount = Cur_ZombiesCount;

    }


}
