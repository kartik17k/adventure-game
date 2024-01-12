using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformController : MonoBehaviour
{
    public Transform platform;
    public Transform start;
    public Transform end;
    public float speed = 1.5f; 
    int direction = 1;


    // Update is called once per frame
    void Update()
    {
        Vector2 target = currentMovementTarget();

        platform.position = Vector2.Lerp(platform.position, target, speed*Time.deltaTime);

        float distance = (target - (Vector2)platform.position).magnitude;

        if(distance <= 0.1f)
        {
            direction *= -1;
        }
        
    }

    Vector2 currentMovementTarget()
    {
        if( direction == 1) {
            return end.position;
        }
        else
        {
            return start.position;
        }
    }


    private void OnDrawGizmos()
    {
        if(platform != null && start!=null && end!=null) {
            Gizmos.DrawLine(platform.transform.position, start.position);
            Gizmos.DrawLine(platform.transform.position, end.position);
        }
    }
}
