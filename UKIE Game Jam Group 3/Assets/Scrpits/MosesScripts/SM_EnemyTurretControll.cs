using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_EnemyTurretControll : MonoBehaviour
{
    [Header("Turret Setup")]
    [SerializeField] internal Transform t_target;
    [SerializeField] internal GameObject go_closestTarget;
    [SerializeField] internal GameObject[] go_targets;
    [SerializeField] internal float fl_range = 15f;
    [SerializeField] internal float fl_turnSpeed = 10f;

    [SerializeField] internal string st_targetTag;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (t_target == null)
            return;
        LockOnTarget();
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fl_range);
    }
}
