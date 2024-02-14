using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class EnemyProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    public float force;

    public float lifetime;
    float lifetimecounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.down * force;

        lifetimecounter += Time.deltaTime;
        if (lifetimecounter > lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            PlayerMechanics.Health = PlayerMechanics.Health - 1;
            Destroy(gameObject);
        }
    }
}
