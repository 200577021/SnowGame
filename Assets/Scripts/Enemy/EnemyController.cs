using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Settings")]
    public int offsetToTarget = 5;
    public float speed = 3f;
    public float waitTimeAtTarget = 3.0f;
    public float rotationDuration = 1.0f;
    public float rotationAngle = 180.0f;

    private Vector3 targetPosition = Vector3.zero;
    private Vector3 startPosition = Vector3.zero;
    private bool reachedTarget = false;

    private void Start()
    {
        targetPosition = new Vector3(transform.position.x, transform.position.y - offsetToTarget, transform.position.z);
        startPosition = transform.position;
    }

    private void Update()
    {
        if(!reachedTarget)
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        // Move the enemy towards the target position
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // Check if the enemy has reached the target position
        if(Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            reachedTarget = true;
            StartCoroutine(WaitAndReturn());
        }
    }

    private IEnumerator WaitAndReturn()
    {
        // Wait at the target position
        yield return new WaitForSeconds(waitTimeAtTarget);

        // Rotate 90 degrees over a period of time
        yield return StartCoroutine(RotateOverTime(rotationAngle, rotationDuration));

        // Move back to the start position
        while(Vector3.Distance(transform.position, startPosition) > 0.001f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, startPosition, step);
            yield return null;
        }

        // Destroy the enemy
        Destroy(gameObject);
    }

    private IEnumerator RotateOverTime(float angle, float duration)
    {
        float startRotation = transform.eulerAngles.z;
        float endRotation = startRotation + angle;
        float t = 0.0f; // Time for LERP

        while(t < duration)
        {
            t += Time.deltaTime;
            float zRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            transform.eulerAngles = new Vector3(0, 0, zRotation);
            yield return null;
        }

        transform.eulerAngles = new Vector3(0, 0, endRotation);
    }
}
