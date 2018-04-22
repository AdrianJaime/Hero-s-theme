using UnityEngine;
using System.Collections;


public class Notas : MonoBehaviour {
    private BarraVida BarravidaScript;
    private PuntosDeJuego PuntosDeJuegoScript;
    public int speed;
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed*-1);
        BarravidaScript=GameObject.Find("Controlador de Vida").GetComponent<BarraVida>(); //esto se supone que consume muchos recursos
        PuntosDeJuegoScript = GameObject.Find("Controlador De Puntos").GetComponent<PuntosDeJuego>(); //esto se supone que consume muchos recursos

    }

    // Update is called once per frame
    void Update () {
        if (!GetComponent< Renderer >().isVisible)
        {
            Destroy(gameObject);
            BarravidaScript.Damage(BarravidaScript.damageValue);
            PuntosDeJuegoScript.MultiplicadorDeCombo = 1;
        }
    }
}
