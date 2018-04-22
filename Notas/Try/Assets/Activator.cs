using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {

    public PuntosDeJuego PuntosDeJuegoScript;
    public BarraVida BarraVidaScript;

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
            PuntosDeJuegoScript.PuntosTotales += (PuntosDeJuegoScript.MultiplicadorDeCombo * PuntosDeJuegoScript.PuntosPorNota);
            PuntosDeJuegoScript.MultiplicadorDeCombo++;

        }
        else if  (Input.GetKeyDown(key) && !active)
            {
            PuntosDeJuegoScript.MultiplicadorDeCombo = 1;
            BarraVidaScript.Damage(25.0f);
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
