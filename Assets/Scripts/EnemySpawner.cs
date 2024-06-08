using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPre;
    [SerializeField] float spawnTime = 1;
    [SerializeField] GameObject strongerenemyPre;
    [SerializeField] float strongerspawnTime = 5;
    [SerializeField] GameObject buffPrefab;
    [SerializeField] float buffDropChance = 0.3f;
    float spawnTimer = 0;
    float strongerspawnTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        strongerspawnTimer += Time.deltaTime;
        if(strongerspawnTimer >= strongerspawnTime)
        {
            SpawnstrongerEnemy();
            strongerspawnTimer = 0; 
        }
        if(spawnTimer >= spawnTime)
        {
            SpawnEnemy();
            spawnTimer = 0;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPos = GetRanSpawnPos();

       GameObject newEnemy = Instantiate(enemyPre, spawnPos, transform.rotation);
        BuffSpawner buffSpawner = newEnemy.AddComponent<BuffSpawner>();
        buffSpawner.Initialize(buffPrefab, buffDropChance);
    }
    private void SpawnstrongerEnemy()
    {
        Vector3 spawnPos = GetRanSpawnPos();
       GameObject newEnemy = Instantiate(strongerenemyPre, spawnPos, transform.rotation);
        BuffSpawner buffSpawner = newEnemy.AddComponent<BuffSpawner>();
        buffSpawner.Initialize(buffPrefab, buffDropChance);
    }
    private Vector3 GetRanSpawnPos()
    {
        Vector3 minPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        float radius = enemyPre.GetComponent<CircleCollider2D>().radius;
        float posX = Random.Range(minPos.x + radius, maxPos.x - radius);
        float posY = Random.Range(minPos.y + radius, maxPos.y - radius);

        return new Vector3(posX, maxPos.y + radius, 0);
    }
    private void SpawnBuff(Vector3 position)
    {
        Instantiate(buffPrefab, position, Quaternion.identity);
    }
}
