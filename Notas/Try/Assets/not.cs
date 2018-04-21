using UnityEngine;
using System.Collections;


public class not : MonoBehaviour {
    public int speed;
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed*-1);
    }
	
	// Update is called once per frame
	void Update () {
        if (!GetComponent< Renderer >().isVisible)
        {
            Destroy(gameObject);
        }
    }
}
