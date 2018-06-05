using UnityEngine;
using System.Collections;


public class Notas : MonoBehaviour {
    private BarraVida BarravidaScript;
    private PuntosDeJuego PuntosDeJuegoScript;
    public Activator activator;
    public int speed;
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed*-1);
        activator = GameObject.Find("Blue Note Button").GetComponent<Activator>();
        BarravidaScript=GameObject.Find("Controlador de Vida Player").GetComponent<BarraVida>(); //esto se supone que consume muchos recursos
        PuntosDeJuegoScript = GameObject.Find("Controlador De Puntos Player").GetComponent<PuntosDeJuego>(); //esto se supone que consume muchos recursos

    }

    // Update is called once per frame
    void Update () {
        if (!GetComponent< Renderer >().isVisible)
        {
            Destroy(gameObject);
            activator.AnimaciónHitEnemy();
            BarravidaScript.Damage();
            PuntosDeJuegoScript.MultiplicadorDeCombo = 1;
        }
    }
}
