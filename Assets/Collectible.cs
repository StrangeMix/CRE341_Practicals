using UnityEngine;
using UnityEngine.AI;

public class Collectible : MonoBehaviour
{
    public GameObject player;
    public float spawnRadius = 10f;  // Radius around where the food will spawn
    public float collectionRadius = 2f;  // Radius at which the player can "collect" the food

    private bool isCollected = false;
    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");

        // Get the NavMeshAgent component 
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;  // cancel movement

        // Randomly spawn on the NavMesh
        SpawnCollectible();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCollected)
        {
            // Check if the player is close enough to collect
            if (Vector3.Distance(transform.position, player.transform.position) <= collectionRadius)
            {
                Collect();
            }
        }
    }

    // Function to spawn on the NavMesh within a certain radius
    void SpawnCollectible()
    {
        Vector3 randomPosition = transform.position + (Random.insideUnitSphere * spawnRadius);
        NavMeshHit hit;

        // Find a valid NavMesh position for the spawn
        if (NavMesh.SamplePosition(randomPosition, out hit, spawnRadius, NavMesh.AllAreas))
        {
            transform.position = hit.position; 
        }
    }

    void Collect()
    {
        // If is collected, set it as collected and destroy it
        isCollected = true;
        Destroy(gameObject);

    }
}