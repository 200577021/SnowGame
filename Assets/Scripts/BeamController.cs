using UnityEngine;

public class BeamController : MonoBehaviour
{
    [Range(5.0f, 15.0f)]
    public float speed = 10.0f;

    [SerializeField] private float _timeToDestroy = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        MoveBeam();
    }

    private void MoveBeam()
    {
        // Move the beam to the up
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
