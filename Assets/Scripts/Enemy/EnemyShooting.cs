using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject enemyBeamPrefab; // Reference to the enemy beam prefab.
    public Transform enemyBeamSpawnPoint; // Reference to the spawn point of the enemy beam.
    public float shootingInterval = 2.0f; // Time between shots.

    private void Start()
    {
        InvokeRepeating("Shoot", 1.0f, shootingInterval);
    }

    private void Shoot()
    {
        Instantiate(enemyBeamPrefab, enemyBeamSpawnPoint.position, enemyBeamSpawnPoint.rotation);
    }
}
