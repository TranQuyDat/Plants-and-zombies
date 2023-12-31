using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : ActionOfTreeGetSun
{
    // Start is called before the first frame update
    GameManager gameManager;
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
        if (!gameManager.GameStart) return;
        GameObject mySun = Instantiate(prefapSun, posSpawnSun.position, Quaternion.identity);
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
        StartCoroutine(DropToYPos(mySun.transform, posSpawnSun.position.y - 0.5f, 1f));
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
    public override void Hit(int damage)
    {
        Debug.Log("Bi can Bi Can");
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
