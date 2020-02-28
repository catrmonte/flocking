using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoid 
{
    float avoidDistance = 4f; // radius to avoid within, greater than character radius
    float maxAcceleration = 4f;
    float lookahead = 15f;  // distance to look ahead / raycast length

    public GameObject target;
    public Kinematic character;

    public SteeringOutput GetSteering()
    {
       RaycastHit hit;

        // If no collision deteted up to lookahead distance away in direction of linVelocity...
        if (!Physics.Raycast(character.transform.position, character.linearVelocity, out hit, lookahead))
        {
            // We don't need to do anything, return null
            //return null;
        }
        else
        {
            // change the target position to seek to
            target.transform.position = hit.point + hit.normal * avoidDistance;
        }

        SteeringOutput result = new SteeringOutput();
        result.linear = target.transform.position - character.transform.position;
        result.linear.Normalize();
        result.linear *= maxAcceleration;
        return result;
    }
}
