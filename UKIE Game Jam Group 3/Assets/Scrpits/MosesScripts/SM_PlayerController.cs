﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SM_PlayerController : MonoBehaviour
{
    [Header("Player Setup")]
    [SerializeField] internal GameObject go_closestTarget;
    [SerializeField] internal GameObject[] go_enemies;

    [Header("Player Attack")] 
    [SerializeField] internal float fl_attackDistance;
    [SerializeField] internal float fl_attackSpeed;

    [Header("DO NOT EDIT!!!")]
    [SerializeField] float fl_attackTimer;
    [SerializeField] string st_enemyTag;
    [SerializeField] NavMeshAgent nm_agent;
    // Use this for initialization
    void Start()
    {
        nm_agent = GetComponent<NavMeshAgent>();
        nm_agent.stoppingDistance = fl_attackDistance; //stopping distance is equals attack distance
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        go_enemies = GameObject.FindGameObjectsWithTag(st_enemyTag);

        FindClosestEnemy();
        if (go_closestTarget != null)
        {
            nm_agent.destination = go_closestTarget.transform.position;
        }
        else
        {
            nm_agent.destination = nm_agent.transform.position;
        }

        AttackEnemy();
    }

    GameObject FindClosestEnemy()
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
        return go_closestTarget;
    }

    void AttackEnemy()
    {
        fl_attackTimer += Time.deltaTime; //increase timer

        if (Vector3.Distance(nm_agent.destination, nm_agent.transform.position) <= fl_attackDistance) //if agant destination is less than attack distance
        {
            if (fl_attackTimer >= fl_attackSpeed) //if attack timer is more than or equal to attack intervals
            {
                fl_attackTimer = 0; //set attack timer to zero
            }
        }
    }
}
