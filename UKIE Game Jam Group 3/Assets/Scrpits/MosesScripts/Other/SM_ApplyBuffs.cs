using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializePrivateVariables]
public class SM_ApplyBuffs : MonoBehaviour
{
    [Header("Setup")]
    GameObject target;
    int in_target;

    [Header("Timers and Cooldowns")]
    float fl_abilityTimer;
    float fl_buffTimer;

    [Header("Buffs")]
    int in_damageBuff;

    bool bl_isCoolingdown = true;
    float fl_abilityCooldown;
    float fl_buffCooldown;
    bool bl_buffActive = false;
    SM_PlayerController _players;
    SM_PlayerHealth _playersHealth;
    GameObject[] players;
    // Use this for initialization
    void Start()
    {
        _players = GetComponent<SM_PlayerController>();
        fl_buffCooldown = fl_buffTimer;
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        PlayerBuffs();

        if (bl_buffActive)
        {
            fl_buffCooldown -= Time.deltaTime;
            if (fl_buffCooldown <= 0)
            {
                bl_buffActive = false;
                fl_buffCooldown = fl_buffTimer;
                target.GetComponent<SM_PlayerController>().in_attackDamage = target.GetComponent<SM_PlayerController>().in_curAttackDamage;
            }
        }
    }

    void PlayerBuffs()
    {
        fl_abilityCooldown += Time.deltaTime;

        if (fl_abilityCooldown <= fl_abilityTimer)
            bl_isCoolingdown = true;
        else
            bl_isCoolingdown = false;

        foreach (GameObject player in players)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                in_target = Random.Range(0, players.Length);
                target = players[in_target];
            }
            if (Input.GetKeyDown(KeyCode.Alpha1) && !bl_isCoolingdown) //damage buff
            {
                bl_buffActive = true;
                target.GetComponent<SM_PlayerController>().in_attackDamage = in_damageBuff;
                fl_abilityCooldown = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && !bl_isCoolingdown)
            {
                bl_buffActive = true;
                StartCoroutine(RegainHealthOverTime());
                fl_abilityCooldown = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && !bl_isCoolingdown)
            {
                bl_buffActive = true;
                _players.AOEDamage();
                fl_abilityCooldown = 0;
            }
        }
    }

    IEnumerator DamageIncrease()
    {
        yield return null;
    }

    private IEnumerator RegainHealthOverTime()
    {
        while (bl_buffActive)
        {
            target.GetComponent<SM_PlayerHealth>().in_currentHealth += target.GetComponent<SM_PlayerHealth>().in_RegenRate; //increase current health by specified amount
        }
        yield return null;
    }
}
