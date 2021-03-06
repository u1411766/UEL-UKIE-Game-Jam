﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SM_PlayerHealth : MonoBehaviour 
{
    [SerializeField] internal int in_startingHealth = 100;
    //[SerializeField] internal int in_scoreValue;
    [SerializeField] internal float fl_sinkSpeed = 2.5f;

    [Header("Health regen")]
    [SerializeField] internal float fl_healthRegen = 5f; //when to start regeneration
    [SerializeField] internal int in_RegenRate = 5; //rate of regeneration
    [SerializeField] internal bool bl_isRegenHealth; //is health regenerating

    [Header("Not for Editing!!!")]
    [SerializeField] internal int in_currentHealth;

    BoxCollider boxCollider;
    internal bool bl_isDead;
    bool bl_isSinking;
    // Use this for initialization
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();

        in_currentHealth = in_startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (bl_isSinking)
        {
            transform.Translate(-Vector3.up * fl_sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int in_amount/*, Vector3 hitPoint*/)
    {
        if (bl_isDead)
            return;

        in_currentHealth -= in_amount;

        if (in_currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        bl_isDead = true;

        boxCollider.isTrigger = true;
        StartSinking();
    }

    void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        bl_isSinking = true;

        Destroy(gameObject, 2f);
    }

    //private IEnumerator RegainHealthOverTime()
    //{
    //    bl_isRegenHealth = true; //set health regen to true
    //    while (in_currentHealth < in_startingHealth)
    //    {
    //        in_currentHealth += in_RegenRate; //increase current health by specified amount
    //        yield return new WaitForSeconds(fl_healthRegen);
    //    }
    //    bl_isRegenHealth = false; //set health regen to false
    //}
}
