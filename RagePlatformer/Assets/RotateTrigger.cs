using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrigger : MonoBehaviour
{
    public Transform ObjectToRotate;

    public Transform objectToRotateAs;
    public float rotateSpeed;

    bool moving = false;
    public void RotateObject()
    {
        moving = true;
    }

    private void FixedUpdate()
    {
        if (moving == true)
            Quaternion.LerpUnclamped(ObjectToRotate.rotation, objectToRotateAs.rotation, rotateSpeed * Time.deltaTime);
    }
}
