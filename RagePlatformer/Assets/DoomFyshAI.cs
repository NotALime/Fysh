using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoomFyshAI : MonoBehaviour
{
    SpriteRenderer sr;
    public Transform player;
    public Rigidbody2D rb;

    public float propelForce;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector3 dir = (player.position - transform.position).normalized;

        rb.AddForce(dir * propelForce);

        transform.position = Vector3.MoveTowards(transform.position, player.position, propelForce / 20f);

        if (player.position.x < transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
