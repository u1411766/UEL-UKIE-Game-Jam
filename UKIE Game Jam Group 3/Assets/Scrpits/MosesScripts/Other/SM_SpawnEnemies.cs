using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_SpawnEnemies : MonoBehaviour
{
    public GameObject[] go_Enemy;
    [SerializeField] internal int in_NumberofEnemies;
    [SerializeField] internal int in_EnemyKilled;
    [SerializeField] [Range(0, 100)] internal int in_MaxEnemySpawn;
    [SerializeField] [Range(0f, 30f)] internal float fl_SpawnTime = 5f;
    [SerializeField] [Range(0f, 30f)] internal float fl_spawnDelay = 10;
    [SerializeField] internal Transform[] SpawnPoints;


    GameObject[] go_enemiesAlive;
    public bool bl_infinite;
    internal bool bl_isDoneSpawning = false;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnEnemy", fl_SpawnTime, fl_spawnDelay);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        go_enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");
        DoneSpawning();

        if (bl_isDoneSpawning)
        {
            DestroyImmediate(gameObject);
        }
    }

    public void SpawnEnemy()
    {
        if (in_NumberofEnemies == in_MaxEnemySpawn && !bl_infinite)
        {
            return;
        }
        int SpawnPointIndex = Random.Range(0, SpawnPoints.Length);
        int EnemyIndex = Random.Range(0, go_Enemy.Length);

        Instantiate(go_Enemy[EnemyIndex], SpawnPoints[SpawnPointIndex].position, SpawnPoints[SpawnPointIndex].rotation);
        in_NumberofEnemies++;

        
    }

    void DoneSpawning()
    {
        if (in_MaxEnemySpawn == in_NumberofEnemies && !bl_infinite)
        {
            bl_isDoneSpawning = true;
        }
    }
}
