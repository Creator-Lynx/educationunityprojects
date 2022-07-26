using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotatingByAccelerometer : MonoBehaviour
{
    [SerializeField]
    float lerpSpeed = 1f, accelerationFactor = 2.5f;

    [SerializeField]
    Transform target;
    void Start()
    {
        shift = transform.position;
    }
    Vector3 acceleration;
    Vector3 shift;
    Vector3 delta = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        var acc = Input.acceleration * accelerationFactor;
        acceleration = new Vector3(-acc.x, acc.z, 0);
        var moving = Vector3.Lerp(transform.position, shift + acceleration, lerpSpeed);
        transform.position = moving;
        /*transform.position = new Vector3(Mathf.Clamp(moving.x, shift.x - 8, shift.x + 8),
                                        Mathf.Clamp(moving.y, shift.y - 8, shift.y + 8),
                                        Mathf.Clamp(moving.z, shift.z - 3, shift.z + 3));*/
    }
}
