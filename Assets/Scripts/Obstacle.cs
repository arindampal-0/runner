using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float forceAmount = 10.0f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(forceAmount * Time.deltaTime, 0, 0));
    }
}
