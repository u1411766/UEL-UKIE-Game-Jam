using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SM_PlayerHealth : MonoBehaviour 
{
    [SerializeField] internal int in_startingHealth;
    //[SerializeField] internal int in_scoreValue;
    [SerializeField] internal float fl_sinkSpeed;

    [Header("Not for Editing!!!")]
    [SerializeField]
    internal int in_currentHealth;

    BoxCollider boxCollider;
    bool bl_isDead;
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
}
