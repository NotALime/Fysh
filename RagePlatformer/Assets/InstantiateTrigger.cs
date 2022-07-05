using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTrigger : MonoBehaviour
{
    public GameObject objectThing;
    public void InstantiationTrigger()
    {
        Instantiate(objectThing, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
