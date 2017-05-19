using UnityEngine;
using UnityEngine.AI;
[SerializePrivateVariables]
public class SM_EnemyShoot : MonoBehaviour
{
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    public Light faceLight;
    float effectsDesplayTime = 0.2f;
    int offset = -1;

    NavMeshAgent nm_agent;
    SM_EnemyController enemyController;
    SM_PlayerHealth playerHealth;
    // Use this for initialization
    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        enemyController = GetComponentInParent<SM_EnemyController>();
        playerHealth = GetComponent<SM_PlayerHealth>();
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
        enemyController.fl_attackTimer += Time.deltaTime; //increase timer

        if (Vector3.Distance(nm_agent.destination, nm_agent.transform.position) <= enemyController.fl_attackDistance) //if agant destination is less than attack distance
        {
            if (enemyController.fl_attackTimer >= enemyController.fl_attackSpeed && enemyController.go_closestTarget != null) //if attack timer is more than or equal to attack intervals
            {
                transform.LookAt(enemyController.go_closestTarget.transform.position);
                Vector3 pos = enemyController.go_closestTarget.transform.position;
                pos -= transform.up * offset;
                transform.LookAt(pos);
                Shoot();
            }
        }

        if (enemyController.fl_attackTimer >= enemyController.fl_attackSpeed * effectsDesplayTime)
        {
            DisableEffects();
        }
    }

    void Shoot()
    {
        enemyController.fl_attackTimer = 0;

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

        if (Physics.Raycast(shootRay, out shootHit, enemyController.fl_attackDistance, shootableMask))
        {
            playerHealth = shootHit.collider.GetComponent<SM_PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(enemyController.in_attackDamage);
            }

            gunLine.SetPosition(0, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * enemyController.fl_attackDistance);
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
