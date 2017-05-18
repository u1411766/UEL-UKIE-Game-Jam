using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializePrivateVariables]

public class HL_ApplyBuff : MonoBehaviour
{
    internal int int_buffsApplyed;

    internal int HP_Increase;
    internal int Attack_Increase;
    internal int Range_Increase;

    float StartHP;

    int StartAttack;
    float StartRange;


    internal bool bl_applyChanges;

    public int test;
    // Use this for initialization
    void Start()
    {
        StartHP = gameObject.GetComponent<SM_PlayerHealth>().fl_healthRegen;
        StartAttack = gameObject.GetComponent<SM_PlayerController>().in_attackDamage;
        StartRange = gameObject.GetComponent<SM_PlayerController>().fl_attackDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (bl_applyChanges == true)
        {

            gameObject.GetComponent<SM_PlayerController>().in_attackDamage = StartAttack;
            gameObject.GetComponent<SM_PlayerController>().fl_attackDistance = StartRange;
            gameObject.GetComponent<SM_PlayerHealth>().fl_healthRegen = StartHP;
            TriggerChangeInStats();
            bl_applyChanges = false;
        }
    }
    void TriggerChangeInStats()
    {
        for (int i = 0; i < int_buffsApplyed; i++)
        {
            //assasing attack increase
            if (gameObject.name == "McLatte")
            {
                gameObject.GetComponent<SM_PlayerController>().in_attackDamage += Attack_Increase;
            }

                // tank helth regen rate
            else if (gameObject.name == "Norty")
            {
                gameObject.GetComponent<SM_PlayerHealth>().fl_healthRegen += HP_Increase;
            }
            //ranged character range modifier
            else if (gameObject.name == "Krispy")
            {
                gameObject.GetComponent<SM_PlayerController>().fl_attackDistance += Range_Increase;
            }
        }
    }
}
