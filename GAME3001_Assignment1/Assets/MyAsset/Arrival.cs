using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrival : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float stopDistance = 1f;
    public float slowDownRadius = 10f;

    void Update()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > stopDistance)
            {
                float speedFactor = Mathf.Clamp01(distance / slowDownRadius);
                Vector3 direction = (target.position - transform.position).normalized;
                transform.position += direction * speed * speedFactor * Time.deltaTime;
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
}
