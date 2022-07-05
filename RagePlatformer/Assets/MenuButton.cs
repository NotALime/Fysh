using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public float screenSwipeSpeed;
    public Transform CanvasToSwipeTo;
    Transform currentCanvas;
    Camera cam;
    bool isSwitching;
    GameObject beep;

    public string sceneToSwitchTo;

    public string link;
    // Start is called before the first frame update
    void Start()
    {
        beep = GameObject.Find("beemp");
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToNewScreen()
    {
        Instantiate(beep, transform.position, Quaternion.identity);
        cam.transform.position = CanvasToSwipeTo.position + new Vector3(0, 0, -10);
    }

    public void LoadScene()
    {
        Instantiate(beep, transform.position, Quaternion.identity);
        SceneManager.LoadScene(sceneToSwitchTo);
    }

    public void Escape()
    {
        Instantiate(beep, transform.position, Quaternion.identity);
        Application.Quit();
    }

    public void OpenLink()
    {
        Instantiate(beep, transform.position, Quaternion.identity);
        Application.OpenURL(link);
    }
}
