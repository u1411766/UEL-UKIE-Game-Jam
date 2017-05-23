using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour 
{
    GameObject go_closestSpawnPoint;
    GameObject[] SpawnPoints;
	// Use this for initialization
	void Awake () 
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");
        FindClosestSpawnPoint();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!GameObject.Find("SpawnPoint1") && GameObject.Find("SpawnPoint2") != null)
        {
            GameObject.Find("SpawnPoint2").GetComponent<SM_SpawnEnemies>().enabled = true;
        }
	}

    void FindClosestSpawnPoint()
    {
        go_closestSpawnPoint = null;
        float distance = Mathf.Infinity;

        foreach (GameObject _spawnPoint in SpawnPoints)
        {
            if (_spawnPoint == null)
            {
                return;
            }
            _spawnPoint.GetComponent<SM_SpawnEnemies>().enabled = false;
            Vector3 diff = _spawnPoint.transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                go_closestSpawnPoint = _spawnPoint;
                distance = curDistance;
            }
        }
        go_closestSpawnPoint.GetComponent<SM_SpawnEnemies>().enabled = true;
        InvokeRepeating("FindClosestSpawnPoint", 2f, 5f);
    }
}
