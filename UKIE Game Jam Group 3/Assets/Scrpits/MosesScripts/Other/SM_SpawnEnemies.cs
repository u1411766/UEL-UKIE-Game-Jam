using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_SpawnEnemies : MonoBehaviour
{
    public GameObject[] go_Enemy;
    [SerializeField] internal static int in_NumberofEnemies;
    [SerializeField] internal static int in_EnemyKilled;
    [SerializeField] [Range(0, 100)] internal int in_MaxEnemySpawn;
    [SerializeField] [Range(0f, 5f)] internal float fl_SpawnTime = 5f;
    [SerializeField] internal Transform[] SpawnPoints;

    public bool bl_infinite;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnEnemy", fl_SpawnTime, fl_SpawnTime);
    }

    // Update is called once per frame
    void Update()
    {

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
}
