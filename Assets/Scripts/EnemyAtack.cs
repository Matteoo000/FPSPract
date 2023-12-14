using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Enemy enemyMovement;
    private Transform player;
    public float attackRange = 3f; // Adjust this value to your desired attack range
    public int damageAmount = 10;
    public float attackCooldown = 2f; // Time between attacks
    private float nextAttackTime;
    public Material defaultMaterial;
    public Material alertMaterial;
    public Renderer rend;
    private bool foundPlayer = false; // Initialize to false


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMovement = GetComponent<Enemy>();
        rend = GetComponent<Renderer>();
        foundPlayer = false; // Make sure it's initialized to false
        nextAttackTime = 0f; // Initialize nextAttackTime
    }

    private void Update()
    {
        //Debug.Log("Distance to player: " + Vector3.Distance(transform.position, player.position));

        if (foundPlayer)
        {
            if (CanAttack())
            {
                AttackPlayer();
            }
            else
            {
                // Player is not in attack range, continue chasing
                rend.material = alertMaterial;
                enemyMovement.EnemyAgent.SetDestination(player.position);
            }
        }
        else
        {
            // Player not found, check for player within attack range to start chasing
            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                foundPlayer = true;
                rend.material = alertMaterial;
                enemyMovement.EnemyAgent.SetDestination(player.position);
            }
            else
            {
                // Player is not in attack range, revert to default material and search
                rend.material = defaultMaterial;
                enemyMovement.newLocation();
            }
        }
    }

    private bool CanAttack()
    {
        return Time.time >= nextAttackTime;
    }

    private void AttackPlayer()
    {
        // Deal damage to the player (you can replace this with your own damage logic)
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }

        // Set the next attack time based on the cooldown
        nextAttackTime = Time.time + attackCooldown;

        // Additional logic for attacking, if needed
    }

    private void FixedUpdate()
    {
        if (foundPlayer && Vector3.Distance(transform.position, player.position) > attackRange)
        {
            // Player is out of attack range, revert to default material and search
            rend.material = defaultMaterial;
            enemyMovement.newLocation();
            foundPlayer = false;
        }
    }
}