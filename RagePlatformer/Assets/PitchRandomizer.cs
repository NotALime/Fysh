using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchRandomizer : MonoBehaviour
{
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;
    public void RandomizeSound()
    {
        GetComponent<AudioSource>().pitch = Random.Range(minPitch, maxPitch);
    }

    private void Start()
    {
        if(GetComponent<AudioSource>().clip != null)
        RandomizeSound();
    }
}
