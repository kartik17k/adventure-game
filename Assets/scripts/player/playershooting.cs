using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class playershooting : MonoBehaviour
{
    PlayerController controller;
    public GameObject bullet;
    public Transform bulletHole;
    public float force = 200f;


    private void Awake()
    {
        controller = new PlayerController();
        controller.Enable();

        controller.land.shoot.performed += ctx => Fire();
    }

    void Fire()
    {
        GameObject go = Instantiate(bullet, bulletHole.position, bullet.transform.rotation);
        if (GetComponent<playerMovement>().isFacingRight)
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
        else
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);

        Destroy(go, 2.5f);
    }
}
