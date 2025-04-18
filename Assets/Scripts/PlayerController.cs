using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject beamPrefab; // Reference to the beam prefab
    public Transform beamSpawnPoint; // Reference to the spawn point of the beam
    private Vector2 moveValue;

    private void Awake()
    {
        // Set up references
        moveValue = Vector2.zero;
    }

    private void Update()
    {
        // Yes you can put your movement code in here. But why shouldn't you?
        // The name of the function does not describe what the code is doing.
        Move();
    }

    // Public function that I can use to respond to Input Actions
    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveValue = ctx.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            // Launch our beam attack
            Instantiate(beamPrefab, beamSpawnPoint.position, beamSpawnPoint.rotation);
        }
    }

    private void Move()
    {
        transform.Translate(new Vector3(moveValue.x, moveValue.y, 0) * speed * Time.deltaTime);
    }
}
