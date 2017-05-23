using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SM_EnemyController : MonoBehaviour 
{
    [Header("Enemy Setup")]
    [SerializeField] internal GameObject go_closestTarget;
    [SerializeField] internal GameObject[] go_players;

    [Header("Movement")]
    [SerializeField] internal float fl_movementSpeed;

    [Header("Enemy Attack")]
    [SerializeField] internal int in_attackDamage;
    [SerializeField] internal float fl_attackDistance;
    [SerializeField] internal float fl_attackSpeed;

    [Header("Random Target")]
    [SerializeField] internal int in_chosenTarget;
    [SerializeField] internal bool bl_isRandomTarget;
    [SerializeField] string st_playerTag;

    [Header("DO NOT EDIT!!!")]
    [SerializeField] internal float fl_attackTimer;
    NavMeshAgent nm_agent;

    // Use this for initialization
    void Start()
    {
        nm_agent = GetComponent<NavMeshAgent>();
        nm_agent.speed = fl_movementSpeed;
        nm_agent.stoppingDistance = fl_attackDistance; //stopping distance is equals attack distance
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        go_players = GameObject.FindGameObjectsWithTag(st_playerTag);

        FindClosestPlayer();
        if (nm_agent.enabled == false)
        {
            return;
        }
        if (go_closestTarget != null)
        {
            nm_agent.destination = go_closestTarget.transform.position;
        }
        else
        {
            nm_agent.destination = nm_agent.transform.position;
        }

        if (bl_isRandomTarget)
        {
            FindRandomTarget();
        }
    }

    void FindClosestPlayer()
    {
        if (bl_isRandomTarget)
        {
            return;
        }
        go_closestTarget = null;

        float distance = Mathf.Infinity;

        foreach (GameObject go_player in go_players)
        {
            Vector3 diff = go_player.transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                go_closestTarget = go_player;
                distance = curDistance;
            }
        }
    }

    void FindRandomTarget()
    {
        foreach (GameObject go_player in go_players)
        {
            in_chosenTarget = Random.Range(0, go_players.Length);
            go_closestTarget = go_players[in_chosenTarget];
            if (go_closestTarget != null)
            {
                bl_isRandomTarget = false;
            }
        }
        //Debug.Log(transform.gameObject.name + " choose " + go_closestTarget.name);
    }
}
