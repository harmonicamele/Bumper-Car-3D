using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    Transform targetWaypoint;
    int targetWaypointIndex;
    
    int lastWaypointIndex;

    float movementSpeed = 7f;
    float rotatioSpeed = 3;

    bool crash;
    private void Start()
    {
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex];
        
    }

    private void Update()
    {
        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotatioSpeed * Time.deltaTime;
       
        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation,rotationToTarget,rotationStep);

        //float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint();
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
        
    }

    void CheckDistanceToWaypoint()
    {
        
        if (crash==true)
        {
            targetWaypointIndex=Random.Range(0,waypoints.Count);
            //targetWaypointIndex++;
            UpdateTargetWaypoint();
            crash = false;
        }
    }

    void UpdateTargetWaypoint()
    {
        if (targetWaypointIndex>lastWaypointIndex)
        {
            targetWaypointIndex = 0;
        }
        targetWaypoint = waypoints[targetWaypointIndex];
    }

    private void OnCollisionEnter(Collision collision)
    {

       
        if (collision.collider.CompareTag("Player"))
        {
            int magnitude = 800;
            Vector3 force = transform.position - collision.transform.position;
            force.Normalize();
            gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);

        }
                   
        crash = true;
    }
}
