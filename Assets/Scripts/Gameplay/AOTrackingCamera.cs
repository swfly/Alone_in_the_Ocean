using UnityEngine;
using System.Collections;

public class AOTrackingCamera : MonoBehaviour {
    public Transform target;
    public float distance = 8;
    void FixedUpdate()
    {
        transform.position = target.position - transform.forward * distance;
    }
}
