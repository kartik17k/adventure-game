using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw : MonoBehaviour
{
    public float speed = 2;
    int dir = 1;
    public Transform rightcheck;
    public Transform leftcheck;

    
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * dir * Time.fixedDeltaTime);
        if (Physics2D.Raycast(rightcheck.position, Vector2.down, 3) == false)
            dir = -1;

        if (Physics2D.Raycast(leftcheck.position, Vector2.down, 3) == false)
            dir = 1;
    }
}
