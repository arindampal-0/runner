using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject shatteredObstaclePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            print("here");
            if (this.shatteredObstaclePrefab != null)
            {
                Vector3 position = this.transform.position;
                GameObject obj = Instantiate(
                    this.shatteredObstaclePrefab, 
                    this.transform.position, 
                    this.transform.rotation, 
                    this.transform.parent);
                Collider[] colliders = Physics.OverlapSphere(this.transform.position, 1.0f);
                foreach (Collider collider in colliders)
                {
                    if (collider.CompareTag("Obstacle"))
                    {
                        Rigidbody rb = collider.GetComponent<Rigidbody>();
                        if (rb != null)
                        {
                            rb.AddExplosionForce(150.0f, collision.contacts[0].point, 30.0f);
                        }
                    }
                }
                Destroy(this.gameObject);
            }
        }
    }
}
