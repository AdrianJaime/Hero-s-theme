using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {

    public KeyCode key;
    bool active = false;
    GameObject Note;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(key) && active)
        {
            Destroy(Note);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if (col.gameObject.tag == "Note")
            Note = col.gameObject;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        active = false;
    }
}
