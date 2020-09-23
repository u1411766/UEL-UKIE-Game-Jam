using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SM_SpawnPlayers : MonoBehaviour
{
    public GameObject Norty;
    public GameObject Krispy;
    public GameObject McLatte;
    public Transform t_spawnPoint;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ButtonSpawn();
    }

    public void SpawnNorty()
    {
        Instantiate(Norty, t_spawnPoint.position, t_spawnPoint.rotation);
    }

    public void SpwanKrispy()
    {
        Instantiate(Krispy, t_spawnPoint.position, t_spawnPoint.rotation);
    }

    public void SpawnMcLatte()
    {
        Instantiate(McLatte, t_spawnPoint.position, t_spawnPoint.rotation);
    }

    void ButtonSpawn()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Instantiate(Norty, t_spawnPoint.position, t_spawnPoint.rotation);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(Krispy, t_spawnPoint.position, t_spawnPoint.rotation);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(McLatte, t_spawnPoint.position, t_spawnPoint.rotation);
        }
    }
}
