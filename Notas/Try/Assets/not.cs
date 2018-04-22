using UnityEngine;
using System.Collections;


public class not : MonoBehaviour {
    public int speed;

    //BarraVida BarraVidaScript; 

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed*-1);
     //   BarraVidaScript=GameObject.Find("Controlador de Vida").GetComponent<BarraVida>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!GetComponent< Renderer >().isVisible)
        {
            Destroy(gameObject);
            //BarraVidaScript.Damage(BarraVidaScript.damageValue);
        }
    }
}
