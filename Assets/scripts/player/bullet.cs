using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if(collision.tag == "female" || collision.tag == "male")
        {
            collision.GetComponent<zombie>().takeDamage(25);
        }
    }
}
