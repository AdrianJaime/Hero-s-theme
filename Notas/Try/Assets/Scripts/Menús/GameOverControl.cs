using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour {


    public BarraVida barraVida;
    public bool final;

    private void Start()
    {
        final = false;
    }
    private void Update()
    {
        final = barraVida.NoSalud();
        if (final)
        {
            SceneManager.LoadScene("Game_Over");

        }
    }

}
