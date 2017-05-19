using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[SelectionBase]
public class SM_PlayerController : MonoBehaviour
{
    [Header("Player Setup")]
    [SerializeField] internal GameObject go_closestTarget;
    [SerializeField] internal GameObject[] go_enemies;

    [Header("Movement")]
    internal float fl_movementSpeed = 3.5f;

    [Header("Player Attack")]
    [SerializeField] internal int in_attackDamage;
    [SerializeField] internal float fl_attackDistance;
    [SerializeField] internal float fl_attackSpeed;
    [Range(0f, 10f)] internal int in_explosionRadius;
    internal int in_aoeDamage;

    [Header("Random Target")]
    [SerializeField] internal int in_chosenTarget;
    [SerializeField] internal bool bl_isRandomTarget;
    [SerializeField] string st_enemyTag;

    [Header("DO NOT EDIT!!!")]
    [SerializeField]internal float fl_attackTimer;
    NavMeshAgent nm_agent;
    SM_EnemyHealth enemyHealth;
    internal bool bl_enemyInRange;

    internal int in_curAttackDamage;

    // Use this for initialization
    void Awake()
    {
        nm_agent = GetComponent<NavMeshAgent>();
        nm_agent.speed = fl_movementSpeed;
        nm_agent.stoppingDistance = fl_attackDistance; //stopping distance is equals attack distance
        in_curAttackDamage = in_attackDamage;
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
            //Debug.Log(transform.gameObject.name + " choose " + go_closestTarget.name);
        }
    }

    internal void AOEDamage()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, in_explosionRadius);

        foreach (Collider collided in colliders)
        {
            SM_EnemyHealth health = collided.GetComponent<SM_EnemyHealth>();

            Debug.Log(collided.name);
            if (health != null && in_aoeDamage > 0)
            {
                enemyHealth.TakeDamage(in_aoeDamage);
            }
        }
    }
}
