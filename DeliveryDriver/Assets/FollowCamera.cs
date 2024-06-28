using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    // camera's position should be the same as the car's position
    [SerializeField] GameObject ThingToFollow;

    // initializing a vector inline to back the camera up from the car
    // late update is compiled at the end of the update methods compliling
    // creating an thing to follow, using unity to make it the car, then attaching the cameras position to the car
    void LateUpdate()
    {
        transform.position = ThingToFollow.transform.position + new Vector3 (0,0,-10);
    }
}
