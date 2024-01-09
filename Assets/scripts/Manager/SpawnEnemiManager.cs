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
    [SerializeField] private List<Level> Levels ;
    public float timedelaySpawn;
    public bool nextWave;
    public Transform parentZom;
    [Range(0,20)] public float timeWaitPlayer;
    public float curtimeWaitPlayer;
    int levelnum, wavenum;
    int Cur_ZombiesCount;
    Level curLevel;

    public PoolingEnemy poolingEnemy;

    public bool zombiesIsComing;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        poolingEnemy = this.GetComponent<PoolingEnemy>();
    }
    private void Start()
    {
        defaultSetting();
        InvokeRepeating("spawnZombies", timedelaySpawn, timedelaySpawn);
    }

    private void Update()
    {
        if (gameManager.GameStart && curtimeWaitPlayer > 0)
        {
            curtimeWaitPlayer -= 0.5f * Time.deltaTime;
        }
        if (gameManager.GameStart && curtimeWaitPlayer <= 0 && !zombiesIsComing)
        {
            zombiesIsComing = true;
            gameManager.soundManager.playSFX(SoundType.sfx_zomcoming);
        }
    }

    public void defaultSetting()
    {
        zombiesIsComing = false;
        Cur_ZombiesCount = 0;
        curtimeWaitPlayer = timeWaitPlayer;
        levelnum = 0;
        wavenum = -1;
        curLevel = Levels[levelnum];
        poolingEnemy.destroyAll();
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
        if (!gameManager.GameStart || curtimeWaitPlayer > 0) return;
        if (levelnum>=0 && Cur_ZombiesCount > 0) // check so luong zombies cua moi wave
        {
            
            GameObject randomZombie = curLevel.cur_wave.zombiesType[
                Random.Range(0, curLevel.cur_wave.zombiesType.Length)]; // lay random type zombies
            Transform randomSpawn =listPosSpawn[ Random.Range(0, listPosSpawn.Count) ]; // lay random pos spawn zombies
            //GameObject zombie = Instantiate(randomZombie,
            //    randomSpawn.position,Quaternion.identity, parentZom);
            poolingEnemy.pooling(randomZombie, randomSpawn.position);//sinh ra zombies
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
    
}
