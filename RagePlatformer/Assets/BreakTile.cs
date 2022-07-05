using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTile : MonoBehaviour
{
    public GameObject destroyEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().currentJumps = 2;
            Destruction();
        }
    }

    void Destruction()
    {
        GameObject currentRB = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        currentRB.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle.normalized * 100);
        Destroy(this.gameObject);
    }
}
