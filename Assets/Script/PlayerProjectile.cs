using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip sound;

    Rigidbody2D rb;
    public static float force = 15;
    Vector3 mousepos;

    public float lifetime;
    float lifetimecounter = 0;

    public Transform particle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousepos - transform.position;
        Vector3 rotation = transform.position - mousepos;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        audioPlayer.clip = sound;
        audioPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        lifetimecounter += Time.deltaTime;
        if (lifetimecounter > lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }
}
