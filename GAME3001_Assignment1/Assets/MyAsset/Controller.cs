using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public GameObject targetPrefab;
    public GameObject obstaclePrefab;

    private GameObject NewTarget;
    private GameObject NewObstacle;

    public Seeking seekingScript;
    public Fleeing fleeingScript;
    public Arrival arrivalScript;
    public Avoidance avoidanceScript;

    void Start()
    {
        seekingScript = GetComponent<Seeking>();
        fleeingScript = GetComponent<Fleeing>();
        arrivalScript = GetComponent<Arrival>();
        avoidanceScript = GetComponent<Avoidance>();

        seekingScript.enabled = false;
        fleeingScript.enabled = false;
        arrivalScript.enabled = false;
        avoidanceScript.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(NewObstacle);
            SpawnTarget();
            seekingScript.enabled = true;
            fleeingScript.enabled = false;
            arrivalScript.enabled = false;
            avoidanceScript.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(NewObstacle);
            SpawnTarget();
            fleeingScript.enabled = true;
            seekingScript.enabled = false;
            arrivalScript.enabled = false;
            avoidanceScript.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Destroy(NewObstacle);
            SpawnTarget();
            arrivalScript.enabled = true;
            seekingScript.enabled = false;
            fleeingScript.enabled = false;
            avoidanceScript.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SpawnTarget();
            SpawnObstacle();
            avoidanceScript.enabled = true;
            seekingScript.enabled = false;
            fleeingScript.enabled = false;
            arrivalScript.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Destroy(NewTarget);
            Destroy(NewObstacle);
            seekingScript.enabled = false;
            fleeingScript.enabled = false;
            arrivalScript.enabled = false;
            avoidanceScript.enabled = false;
        }
    }
    void SpawnTarget()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-12, 12), Random.Range(-9, 9), 0);
        if(NewTarget != null)
        {
            Destroy(NewTarget);
        }
        NewTarget = Instantiate(targetPrefab, randomPosition, Quaternion.identity);
        AssignTarget(NewTarget.transform);
    }
    void SpawnObstacle()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-12, 12), Random.Range(-9, 9), 0);
        if(NewObstacle != null)
        {
            Destroy(NewObstacle);
        }
        NewObstacle = Instantiate(obstaclePrefab, randomPosition, Quaternion.identity);
        AssignObstacle(NewObstacle);
    }
    void AssignTarget(Transform target)
    {
        if(seekingScript != null)
            seekingScript.target = target;

        if(fleeingScript != null)
            fleeingScript.target = target;

        if(arrivalScript != null)
            arrivalScript.target = target;

        if (avoidanceScript != null)
            avoidanceScript.target = target;
    }
    void AssignObstacle(GameObject obstacle)
    {
        if(avoidanceScript != null)
        {
            avoidanceScript.obstacle = obstacle;
        }
    }
}
