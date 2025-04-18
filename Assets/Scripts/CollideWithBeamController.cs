using UnityEngine;

public class CollideWithBeamController : MonoBehaviour
{
    [Header("Explosion Object")]
    public GameObject explosionPrefab = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Beam"))
        {
            // Destroy the beam
            Destroy(other.gameObject);
            // Create the explosion
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            // Destroy the enemy
            Destroy(gameObject);
        }
    }
}
