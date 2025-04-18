using UnityEngine;

public class EnemyBeamController : MonoBehaviour
{
    public Vector2 direction = Vector2.down;    // Default direction down.
    public float speed = 5.0f;  // Default speed of 5

    void Start()
    {
        Destroy(this.gameObject, 5.0f); // Destroy the beam after 5 seconds.
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);        
    }
}

