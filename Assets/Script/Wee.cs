using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wee : MonoBehaviour
{
    Rigidbody2D rb;
    float Randomx;
    float Randomy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Randomx = Random.value;
        Randomy = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        rb.rotation = rb.rotation + 1;
        rb.velocity = new Vector3(Randomx, Randomy, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bounds"))
        {
            Randomx = Random.value * -1;
            Randomy = Random.value * -1;
        }
    }
}
