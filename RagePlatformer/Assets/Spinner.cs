using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
