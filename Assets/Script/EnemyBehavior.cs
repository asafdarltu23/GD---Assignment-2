using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class EnemyBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform particle;
    public GameObject shieldSprite;
    int shieldLives = 2;
    public Transform projectile;
    public Transform projectileTransform;

    public bool Basic;
    public bool Shielded;
    public bool Shooter;

    public float speed;
    public float cooldown;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Basic)
        {
            rb.velocity = Vector3.down * speed;
        }

        if (Shielded) 
        {
            rb.velocity = Vector3.down * speed;
            if (shieldLives < 1)
            {
                shieldSprite.SetActive(false);
            }

            if (shieldLives < 0)
            {
                Instantiate(particle, this.transform.position, this.transform.rotation);
                AudioManagerScript.playExplosion  = true;
                Destroy(gameObject);
            }
        }

        if (Shooter)
        {
            rb.velocity = new Vector3(1 * speed, 1 * Mathf.Abs(speed), 0);

            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                Instantiate(projectile, projectileTransform.position, Quaternion.identity);
                timer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Shielded && other.CompareTag("Bullet"))
        {
            shieldLives = shieldLives - 1;
            Destroy(other.gameObject);
        }

        if (Shooter && other.CompareTag("Bounds"))
        {
            Flip();
        }
        //Death conditions minus shielded its stated above
        if ((Shooter || Basic) && other.CompareTag("Bullet"))
        {
            Instantiate(particle, this.transform.position, this.transform.rotation);
            Destroy(other.gameObject);
            AudioManagerScript.playExplosion = true;
            Destroy(gameObject);
        }

        //For setting player damage
        if (Shielded && other.CompareTag("Player"))
        {
            PlayerMechanics.Health = PlayerMechanics.Health - 5;
            Instantiate(particle, this.transform.position, this.transform.rotation);
            AudioManagerScript.playExplosion = true;
            Destroy(gameObject);
        }

        if (Basic && other.CompareTag("Player"))
        {
            PlayerMechanics.Health = PlayerMechanics.Health - 10;
            Instantiate(particle, this.transform.position, this.transform.rotation);
            AudioManagerScript.playExplosion = true;
            Destroy(gameObject);
        }

        if (Shooter && other.CompareTag("Player"))
        {
            PlayerMechanics.Health = PlayerMechanics.Health - 0;
            Instantiate(particle, this.transform.position, this.transform.rotation);
            AudioManagerScript.playExplosion = true;
            Destroy(gameObject);
        }
    }

    void Flip()
    {
        speed = -speed;
        /*Vector2 localscale = gameObject.transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;*/
    }
}
