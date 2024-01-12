using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections;

public class playerCollison : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "enemy")
        {
            HealthManneger.health--;
            if(HealthManneger.health <= 0)
            {
                playerMannager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(Gethurts());
            }
        }
    }

    IEnumerator Gethurts()
    {
        Physics2D.IgnoreLayerCollision(6,7);
        GetComponent<Animator>().SetLayerWeight(1,1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 7,false);
    }
    
}
