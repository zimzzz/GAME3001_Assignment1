using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoidance : MonoBehaviour
{
    public Transform target;
    public GameObject obstacle;
    public float speed = 10f;
    public float avoidRadius;
    public float avoidStrength;
    void Update()
    {
        if(target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;

            Vector3 avoidDirection = Vector3.zero;
            if(obstacle != null)
            {
                float distance = Vector3.Distance(transform.position,obstacle.transform.position);
                if(distance < avoidRadius)
                {
                    Vector3 directionAway = transform.position - obstacle.transform.position;
                    avoidDirection = directionAway.normalized / distance;
                }
            }
            Vector3 finalDirection = direction + avoidDirection * avoidStrength;
            transform.position += finalDirection.normalized * speed * Time.deltaTime;
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                targetRotation = Quaternion.Euler(0f, 0f, angle);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }
        }
    }
}
