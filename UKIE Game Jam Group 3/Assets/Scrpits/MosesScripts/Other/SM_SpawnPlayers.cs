using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializePrivateVariables]
public class SM_SpawnPlayers : MonoBehaviour
{
    GameObject Norty;
    GameObject Krispy;
    GameObject McLatte;
    Transform t_spawnPoint;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}
