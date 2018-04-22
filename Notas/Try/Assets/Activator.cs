using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {

    public PuntosDeJuego PuntosDeJuegoScript;
    public BarraVida BarraVidaScript;

    public KeyCode key;
    bool active = false;
    GameObject Note;

   public  bool NotaEliminada;
	// Use this for initialization
	void Start () {
        NotaEliminada = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(key) && active)
        {
            Destroy(Note);
            PuntosDeJuegoScript.PuntosTotales += (PuntosDeJuegoScript.MultiplicadorDeCombo * PuntosDeJuegoScript.PuntosPorNota);
            PuntosDeJuegoScript.MultiplicadorDeCombo++;
            NotaEliminada = true;
        }
        else if  (Input.GetKeyDown(key) && !active)
            {
            PuntosDeJuegoScript.MultiplicadorDeCombo = 1;
            BarraVidaScript.Damage(25.0f);
            }
        NotaEliminada = false;
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
