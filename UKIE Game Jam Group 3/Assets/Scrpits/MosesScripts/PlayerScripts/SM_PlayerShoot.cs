using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SM_PlayerShoot : MonoBehaviour
{
    internal Ray shootRay = new Ray();
    internal RaycastHit shootHit;
    internal int shootableMask;
    internal ParticleSystem gunParticles;
    internal LineRenderer gunLine;
    internal AudioSource gunAudio;
    internal Light gunLight;
    public Light faceLight;
    internal float effectsDesplayTime = 0.2f;
    internal int offset = -1;

    NavMeshAgent nm_agent;
    SM_PlayerController playerController;
    SM_EnemyHealth enemyHealth;
    // Use this for initialization
    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        playerController = GetComponentInParent<SM_PlayerController>();
        enemyHealth = GetComponent<SM_EnemyHealth>();
        nm_agent = GetComponentInParent<NavMeshAgent>();
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        AttackEnemy();
    }

    void AttackEnemy()
    {
        playerController.fl_attackTimer += Time.deltaTime; //increase timer

        if (Vector3.Distance(nm_agent.destination, nm_agent.transform.position) <= playerController.fl_attackDistance) //if agant destination is less than attack distance
        {
            if (playerController.fl_attackTimer >= playerController.fl_attackSpeed && playerController.go_closestTarget != null) //if attack timer is more than or equal to attack intervals
            {
                transform.LookAt(playerController.go_closestTarget.transform.position);
                Vector3 pos = playerController.go_closestTarget.transform.position;
                pos -= transform.up * offset;
                transform.LookAt(pos);
                Shoot();
            }
        }

        if (playerController.fl_attackTimer >= playerController.fl_attackSpeed * effectsDesplayTime)
        {
            DisableEffects();
        }
    }

    void Shoot()
    {
        playerController.fl_attackTimer = 0;

        gunAudio.Play();

        // Enable the lights.
        gunLight.enabled = true;
        faceLight.enabled = true;

        // Stop the particles from playing if they were, then start the particles.
        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(1, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, playerController.fl_attackDistance, shootableMask))
        {
            enemyHealth = shootHit.collider.GetComponent<SM_EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(playerController.in_attackDamage);
            }

            gunLine.SetPosition(0, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * playerController.fl_attackDistance);
        }
    }

    public void DisableEffects()
    {
        // Disable the line renderer and the light.
        gunLine.enabled = false;
        faceLight.enabled = false;
        gunLight.enabled = false;
    }
}
