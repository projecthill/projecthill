using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroller : MonoBehaviour
{
    SceneControl sceneControl;

    bool isScrolling = true;

    void Start ()
    {
        sceneControl = FindObjectOfType<SceneControl> ();
        StartCoroutine (ScrollTime ());
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (isScrolling) {
            transform.position += new Vector3 (0, 3, 0);
        } else {
            StartCoroutine (ReleaseTime ());
        }
    }

    IEnumerator ScrollTime ()
    {
        yield return new WaitForSeconds (21);
        isScrolling = false;
    }

    IEnumerator ReleaseTime ()
    {
        new WaitForSeconds (0.1f);
        sceneControl.LoadScene (0);
        yield return null;
    }
}
