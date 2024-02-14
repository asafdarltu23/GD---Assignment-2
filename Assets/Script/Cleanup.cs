using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour
{
    public float lifetime;
    float lifetimecounter = 0;

    void Update()
    {
        lifetimecounter += Time.deltaTime;
        if (lifetimecounter > lifetime)
        {
            Destroy(gameObject);
        }
    }
}
