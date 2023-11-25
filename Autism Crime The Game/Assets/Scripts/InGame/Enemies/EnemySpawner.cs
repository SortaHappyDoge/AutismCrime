using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [Header("SpawnerAttributes")]
    public Vector2 topLeftBoundary;
    public Vector2 bottomRightBoundary;
    public List<GameObject> enemies = new List<GameObject>();
    public float spawnTimer;
    public bool waitForClearance;
    public int spawnWaveCount;
    public int spawnWavePower;
    public int rangedChance;
    public bool spawnEnemies = true;
    public float closestSpawn;
    public string nextMap;
    public bool spawnBoss = false;

    [Header("SpawnerReferences")]
    public Transform player;
    public GameObject meleeEnemy;
    public GameObject rangedEnemy;
    public GameObject boss;

    private void Update()
    {
        enemies.RemoveAll(s => s == null);
        
        _ = spawnWaveCount <= 0 ? spawnEnemies = false : spawnEnemies = true;
        
        
        if(enemies.Count == 0 && spawnWaveCount == 0 && boss == null) { SceneManager.LoadScene(nextMap); }

        if (waitForClearance && enemies.Count > 0 && spawnWaveCount > 0 || !spawnEnemies) { return; }
        
        /*if(spawnWaveCount == 1 && spawnBoss) {
            spawnBoss = false;
            GameObject bos = Instantiate(boss, GetRandomPos(), Quaternion.identity);
            bos.GetComponentInChildren<RangedEnemyAI>().target = player;
            bos.GetComponentInChildren<EnemyManager>().player = player;
            enemies.Add(bos);
            "
        }*/
        for(int i = spawnWavePower;  i>0; i--)
        {
            if (Random.Range(0, 100) > rangedChance) 
            {
                GameObject enemy = Instantiate(meleeEnemy, GetRandomPos(), Quaternion.identity);
                enemy.GetComponentInChildren<EnemyAI>().target = player;
                enemy.GetComponentInChildren<EnemyManager>().player = player;
                enemy.GetComponentInChildren<EnemyMelee>().player = player;
                enemies.Add(enemy);
                if((enemy.transform.position - player.position).magnitude < closestSpawn) { ++i; Destroy(enemy); }
            }
            else
            {
                GameObject enemy = Instantiate(rangedEnemy, GetRandomPos(), Quaternion.identity);
                enemy.GetComponentInChildren<RangedEnemyAI>().target = player;
                enemy.GetComponentInChildren<EnemyManager>().player = player;
                enemies.Add(enemy);
                if ((enemy.transform.position - player.position).magnitude < closestSpawn) { ++i; Destroy(enemy); }
            }
        }
        
        --spawnWaveCount;
        
    }

    public Vector2 GetRandomPos()
    {
        Vector2 finalPos = new Vector2(
        Random.Range(topLeftBoundary.x, bottomRightBoundary.x),
        Random.Range(topLeftBoundary.y, bottomRightBoundary.y)
        );
        return finalPos;
    }
}
