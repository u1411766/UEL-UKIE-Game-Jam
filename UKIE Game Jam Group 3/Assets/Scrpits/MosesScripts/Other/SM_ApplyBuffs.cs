using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SM_ApplyBuffs : MonoBehaviour
{
    [Header("Setup")]
    public GameObject target;
    public int in_target;

    [Header("Timers and Cooldowns")]
    public float fl_abilityTimer;
    public float fl_buffTimer;

    [Header("Buffs")]
    public int in_damageBuff;

    [SerializeField] internal bool bl_isCoolingdown = true;
    [SerializeField] float fl_abilityCooldown;
    [SerializeField] float fl_buffCooldown;
    [SerializeField] internal bool bl_buffActive = false;

    SM_PlayerHealth _playersHealth;
    [SerializeField] internal GameObject[] players;
    // Use this for initialization
    void Start()
    {
        fl_buffCooldown = fl_buffTimer;
    }

    // Update is called once per frame
    void LateUpdate()
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
                target.GetComponent<SM_BuffLight>().buffLight.enabled = false;
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
                target.GetComponent<SM_BuffLight>().selectLight.enabled = true;
                player.GetComponent<SM_BuffLight>().selectLight.enabled = false;
            }
            if (Input.GetKeyDown(KeyCode.T) && !bl_isCoolingdown) //damage buff
            {
                bl_buffActive = true;
                target.GetComponent<SM_PlayerController>().in_attackDamage += (in_damageBuff);
                target.GetComponent<SM_BuffLight>().buffLight.enabled = true;
                fl_abilityCooldown = 0;
            }

            if (Input.GetKeyDown(KeyCode.Y) && !bl_isCoolingdown)
            {
                bl_buffActive = true;
                target.GetComponent<SM_BuffLight>().buffLight.enabled = true;
                target.GetComponent<SM_PlayerController>().AOEDamage();
                fl_abilityCooldown = 0;
            }

            //if (Input.GetKeyDown(KeyCode.Alpha3) && !bl_isCoolingdown)
            //{
            //    bl_buffActive = true;
            //    StartCoroutine(RegainHealthOverTime());
            //    fl_abilityCooldown = 0;
            //}
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
        yield return new WaitForSeconds(1.2f);
    }
}
