using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : ActionOfTreeGetSun
{
    // Start is called before the first frame update
    GameManager gameManager;
    public int SunCountSpawn;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
         InvokeRepeating("action", timeDelayAct, timeDelayAct);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void action()
    {
        for (int i = 0; i < SunCountSpawn; i++)
        {
            if (!gameManager.GameStart || posSpawnSun == null) return;
            Vector2 pos = new Vector2(posSpawnSun.position.x + (i*0.5f), posSpawnSun.position.y);
            GameObject mySun = Instantiate(prefapSun, pos, Quaternion.identity);
            gameManager.pointsManager.listSun.Add(mySun);
            SpriteRenderer sunSpriteRenderer = mySun.GetComponent<SpriteRenderer>();
            if (sunSpriteRenderer != null)
            {
                sunSpriteRenderer.sortingOrder = 100;
            }
            Rigidbody2D sunRigidbody = mySun.GetComponent<Rigidbody2D>();
            if (sunRigidbody != null)
            {
                sunRigidbody.gravityScale = 0;
            }
            if (mySun == null) return;
            StartCoroutine(DropToYPos(mySun.transform, posSpawnSun.position.y - 0.5f, 1f));
        }
    }
    IEnumerator DropToYPos(Transform targetTransform, float targetY, float duration)
    {
        
        float elapsedTime = 0f;
        Vector3 initialPosition = targetTransform.position;
        Vector3 targetPosition = new Vector3(initialPosition.x, targetY, initialPosition.z);

        while (elapsedTime < duration)
        {
            targetTransform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Đảm bảo rằng đối tượng đến đúng vị trí cuối cùng
        targetTransform.position = targetPosition;
    }
    public override void Hit(float damage)
    {
        Debug.Log("Bi can Bi Can");
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
