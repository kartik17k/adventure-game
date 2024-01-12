using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public Transform mainCam;
    public Transform middleBG;
    public Transform sideBG;

    public float len = 10f;
   
    void Update()
    {
        if (mainCam.position.x > middleBG.position.x)
            sideBG.position = middleBG.position + Vector3.right*len;

        if (mainCam.position.x < middleBG.position.x)
            sideBG.position = middleBG.position + Vector3.left * len;

        if (mainCam.position.x > sideBG.position.x || mainCam.position.x < sideBG.position.x)
        {
            Transform z = middleBG;
            middleBG = sideBG;
            sideBG = z;
        }
    }
}
