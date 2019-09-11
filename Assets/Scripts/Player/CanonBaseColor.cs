using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBaseColor : MonoBehaviour{

    public List<Sprite> BaseSprites;

    // Start is called before the first frame update
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {

        if (Input.GetKeyDown (KeyCode.Alpha1)) {
            gameObject.GetComponent<SpriteRenderer> ().sprite = BaseSprites[0];
        } else if (Input.GetKeyDown (KeyCode.Alpha2)) {         
            gameObject.GetComponent<SpriteRenderer> ().sprite = BaseSprites[1];
        } else if (Input.GetKeyDown (KeyCode.Alpha3)) {         
            gameObject.GetComponent<SpriteRenderer> ().sprite = BaseSprites[2];
        } else if (Input.GetKeyDown (KeyCode.Alpha4)) {         
            gameObject.GetComponent<SpriteRenderer> ().sprite = BaseSprites[3];
        } else if (Input.GetKeyDown (KeyCode.Alpha5)) {         
            gameObject.GetComponent<SpriteRenderer> ().sprite = BaseSprites[4];
        }
    }
}
