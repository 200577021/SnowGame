using UnityEngine;

   

public class CollideWithBeamController : MonoBehaviour
{

     
    [Header("Explosion Object")]
    public GameObject explosionPrefab = null;
    public GameObject explosionInstance = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Beam"))
        {
            // Destroy the beam
            Destroy(other.gameObject);
            // Create the explosion
            explosionInstance = Instantiate(explosionPrefab, transform.position, transform.rotation);
            // Destroy the enemy
            Destroy(gameObject);
            Destroy(explosionInstance, 1f);
            GameManager.Instance.HandleFoodCollision("Food");
        }
    }
}
