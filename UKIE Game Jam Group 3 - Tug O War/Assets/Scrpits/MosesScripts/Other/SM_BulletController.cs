using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SM_BulletController : MonoBehaviour
{
    public float speed = 50f;
    public int in_damage;
    public Transform target;

    SM_PlayerHealth playerHealth;
    SM_TurretController damage;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        playerHealth = target.GetComponent<SM_PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(in_damage);
            Destroy(gameObject);
        }
        Debug.Log(gameObject.name + " Hit " + target.name);
    }

    public void Seek (Transform _target)
    {
        target = _target;
    }
}
