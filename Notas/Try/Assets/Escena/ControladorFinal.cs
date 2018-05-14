using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControladorFinal : MonoBehaviour {

    public BarraVida BarraVidaScript;
    public bool Finish;

    private void Start()
    {
        Finish = false;
    }
    private void Update()
    {
       Finish= BarraVidaScript.NoSalud();
        if (Finish)
        {            SceneManager.LoadScene("Game_Over");

        }
    }


}
