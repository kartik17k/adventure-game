using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    Transform target;
    public Transform bodercheck;
    public int enemyHP = 100;
    public Animator animator;

    public GameObject male;
    public GameObject female;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(0.5f, 0.5f);
        }
        else
        {
            transform.localScale = new Vector2(-0.5f, 0.5f);
        }

        if (CompareTag("female"))
        {
            if (target.position.x > transform.position.x)
            {
                transform.localScale = new Vector2(1.1f, 1.1f);
            }
            else
            {
                transform.localScale = new Vector2(-1.1f, 1.1f);
            }

        }
    }

    public void takeDamage(int damageHP)
    {
        enemyHP -= damageHP;
        if(enemyHP > 0) {
            animator.SetTrigger("damage");
        }
        else {
            animator.SetTrigger("death");
            GetComponent<BoxCollider2D>().enabled = false;
            //if(CompareTag("male"))
           //     Destroy(gameObject);
            //if (CompareTag("female"))
            //    Destroy(gameObject);
            this.enabled = false;
        }
    }
}
