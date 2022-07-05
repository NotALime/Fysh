using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModulator : MonoBehaviour
{
    public float gravityScale;
    public float weight;
    public float speed;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().rb.gravityScale = gravityScale;
            collision.gameObject.GetComponent<PlayerMovement>().rb.mass = weight;
            collision.gameObject.GetComponent<PlayerMovement>().moveSpeed = speed;
            collision.gameObject.GetComponent<PlayerMovement>().currentJumps = 99;
        }
    }
}
