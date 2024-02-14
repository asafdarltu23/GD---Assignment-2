using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoscroll : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = transform.position;

        newpos += transform.up * speed * Time.deltaTime;
        transform.position = newpos;
    }
}
