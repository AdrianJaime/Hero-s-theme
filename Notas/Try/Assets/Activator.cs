using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {
    public Player player;
    public BarraVidaEnemigo vidaEnemigo;

    public PuntosDeJuego PuntosDeJuegoScript;
    public BarraVida BarraVidaScript;

    public KeyCode key;
    bool active = false;
    GameObject Note;



	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(key) && active)
        {
            Destroy(Note);
            PuntosDeJuegoScript.PuntosTotales += (PuntosDeJuegoScript.MultiplicadorDeCombo * PuntosDeJuegoScript.PuntosPorNota);
            if (PuntosDeJuegoScript.MultiplicadorDeCombo % 5 == 00) //cada combo de 5...
            {
                BarraVidaScript.Curar(BarraVidaScript.vidaCurada);
            }
            PuntosDeJuegoScript.MultiplicadorDeCombo++;
            player.Atack();
            vidaEnemigo.Damage();

        }
        else if  (Input.GetKeyDown(key) && active==false)
            {
            PuntosDeJuegoScript.MultiplicadorDeCombo = 1;
            BarraVidaScript.Damage(BarraVidaScript.damageValue);
            }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if (col.gameObject.tag == "Note")
        {

            Note = col.gameObject;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        active = false;
    }
}
