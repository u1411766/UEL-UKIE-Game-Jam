using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SM_PlayerController : MonoBehaviour
{
    [Header("Player Setup")]
    [SerializeField] internal GameObject go_closestTarget;
    [SerializeField] internal GameObject[] go_enemies;

    [Header("Player Attack")]
    [SerializeField] internal int in_attackDamage;
    [SerializeField] internal float fl_attackDistance;
    [SerializeField] internal float fl_attackSpeed;

    [Header("Random Target")]
    [SerializeField] internal int in_chosenTarget;
    [SerializeField] internal bool bl_isRandomTarget;
    [SerializeField] string st_enemyTag;

    [Header("DO NOT EDIT!!!")]
    [SerializeField]internal float fl_attackTimer;
    NavMeshAgent nm_agent;
    SM_EnemyHealth enemyHealth;
    internal bool bl_enemyInRange;

    // Use this for initialization
    void Awake()
    {
        nm_agent = GetComponent<NavMeshAgent>();
        //enemyHealth = GetComponent<SM_EnemyHealth>();
        nm_agent.stoppingDistance = fl_attackDistance; //stopping distance is equals attack distance
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        go_enemies = GameObject.FindGameObjectsWithTag(st_enemyTag);

        FindClosestEnemy();
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

    void FindClosestEnemy()
    {
        go_closestTarget = null;

        float distance = Mathf.Infinity;

        foreach (GameObject go_enemy in go_enemies)
        {
            Vector3 diff = go_enemy.transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                go_closestTarget = go_enemy;
                distance = curDistance;
            }
        }
    }

    void FindRandomTarget()
    {
        go_closestTarget = null;

        foreach (GameObject go_player in go_enemies)
        {
            in_chosenTarget = Random.Range(0, go_enemies.Length);
            go_closestTarget = go_enemies[in_chosenTarget];
            if (go_closestTarget != null)
            {
                bl_isRandomTarget = false;
            }
            Debug.Log(transform.gameObject.name + " choose " + go_closestTarget.name);
        }
    }
}
