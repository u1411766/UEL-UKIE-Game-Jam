using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SM_TurretController : MonoBehaviour
{
    [Header("Turret Setup")]
    public Transform t_target;
    public GameObject go_closestTarget;
    public GameObject[] go_targets;
    public float fl_range = 15f;
    public float fl_turnSpeed = 10f;

    [Header("Turret Attack")]
    public GameObject go_bullet;
    public Transform t_barrel;
    public int in_attackDamage;
    public float fl_fireRate = 1f;

    [Header("DO NOT EDIT!!!")]
    public float fl_fireCountdown = 0f;
    public string st_targetTag;
    SM_BulletController bulletController;
    SM_PlayerBullet playerBulletController;

    public bool bl_isEnemyTurret;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        if (bl_isEnemyTurret)
        {
            bulletController = go_bullet.GetComponent<SM_BulletController>();
            bulletController.in_damage = in_attackDamage;
        }
        else
        {
            playerBulletController = go_bullet.GetComponent<SM_PlayerBullet>();
            playerBulletController.in_damage = in_attackDamage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (t_target == null)
            return;
        LockOnTarget();
         
        if (fl_fireCountdown <= 0f)
        {
            Shoot();
            fl_fireCountdown = 1f / fl_fireRate;
        }
        fl_fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        go_targets = GameObject.FindGameObjectsWithTag(st_targetTag);
        float fl_closestDistance = Mathf.Infinity;
        go_closestTarget = null;
        foreach (GameObject target in go_targets)
        {
            float fl_distanceToEnemy = Vector3.Distance(transform.position, target.transform.position);
            if (fl_distanceToEnemy < fl_closestDistance)
            {
                fl_closestDistance = fl_distanceToEnemy;
                go_closestTarget = target;
            }
        }

        if (go_closestTarget != null && fl_closestDistance <= fl_range)
        {
            t_target = go_closestTarget.transform;
        }
        else
        {
            t_target = null;
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = t_target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * fl_turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        Instantiate(go_bullet, t_barrel.position, t_barrel.rotation);

        if (bl_isEnemyTurret)
        {
            if (bulletController != null)
                bulletController.Seek(t_target);
        }
        else
        {
            if (playerBulletController != null)
                playerBulletController.Seek(t_target);
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fl_range);
    }
}
