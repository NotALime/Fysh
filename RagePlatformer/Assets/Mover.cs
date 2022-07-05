using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public List<Transform> points;
    public float speed = 0.02f;

    public Transform objectMoving;

    public bool looping;
    private int index;
    // Update is called once per frame

    private void Start()
    {
        objectMoving.position = points[0].position;
    }
    void FixedUpdate()
    {
        if (index < points.Count)
        {
            objectMoving.position = Vector3.MoveTowards(objectMoving.position, points[index].position, speed * Time.deltaTime);
            if (Vector2.Distance(objectMoving.position, points[index].position) < 0.01f)
            {
                index++;
            }
        }
        else
        {
            index = 0;
        }
    }
}
