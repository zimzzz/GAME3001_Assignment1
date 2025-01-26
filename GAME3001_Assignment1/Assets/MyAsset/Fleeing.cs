using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleeing : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;

    private float xBound = 12f;
    private float yBound = 9f;

    public void Update()
    {
        if (target != null)
        {
            Vector3 direction = (transform.position - target.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            if (transform.position.x > xBound)
            {
                transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -xBound)
            {
                transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
            }

            if (transform.position.y > yBound)
            {
                transform.position = new Vector3(transform.position.x, yBound, transform.position.z);
            }
            else if (transform.position.y < -yBound)
            {
                transform.position = new Vector3(transform.position.x, -yBound, transform.position.z);
            }

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
