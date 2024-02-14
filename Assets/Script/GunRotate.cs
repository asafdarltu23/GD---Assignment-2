using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    void Update()
    {
        /*GD-Assingment 1*/



        Vector3 mousepos = Input.mousePosition;
        mousepos.z = 5.23f;

        Vector3 objectpos = Camera.main.WorldToScreenPoint(transform.position);
        mousepos.x = mousepos.x - objectpos.x;
        mousepos.y = mousepos.y - objectpos.y;

        float angle = Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg;
       // if (!Pause.isPaused)
       if (angle < 90 && angle > -90)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
}
