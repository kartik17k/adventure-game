using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            playerMannager.numOfCoin++;
            PlayerPrefs.SetInt("NumOfCoin",playerMannager.numOfCoin);
            AudioManager.instance.Play("coins");
            Destroy(gameObject);
        }
    }
}
