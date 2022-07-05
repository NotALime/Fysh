using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            foreach(KeepBetweenScenes i in GameObject.FindObjectsOfType<KeepBetweenScenes>())
            {
                Destroy(i.gameObject);
            }
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
