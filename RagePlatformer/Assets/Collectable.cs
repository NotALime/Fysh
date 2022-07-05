using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject destroyEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destruction();
        }
    }

    void Destruction()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
