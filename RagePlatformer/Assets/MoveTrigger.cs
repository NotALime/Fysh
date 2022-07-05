using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour
{
    public Transform ObjectToMove;
    public Transform finishPoint;

    public float moveSpeed;

    bool moving = false;
    public void MoveObject()
    {
        moving = true;
    }

    private void FixedUpdate()
    {
        if(moving == true)
        ObjectToMove.position = Vector3.MoveTowards(ObjectToMove.position, finishPoint.position, moveSpeed);

        if (Vector2.Distance(ObjectToMove.position, finishPoint.position) < 0.01f)
        {
            Destroy(this.gameObject);
        }
    }
}
