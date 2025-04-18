using System;
using UnityEngine;

public class SineWaveMoveController : MonoBehaviour
{
    public float speed = 5f; // Speed of the enemy movement down the screen
    public float frequency = 5f; // Frequency of the sine wave
    public float amplitude = 1f; // Amplitude of the sine wave

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

     void Update()
    {
        // Forward movement
        transform.position += Vector3.down * speed * Time.deltaTime;

        // Sine wave oscillation
        float sineWaveOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPosition.x + sineWaveOffset, transform.position.y, transform.position.z);
    }
}
