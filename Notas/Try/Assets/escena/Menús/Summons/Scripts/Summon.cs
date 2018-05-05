using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Summon : MonoBehaviour
{
    public void CambioScena(string Activador)
    {
        if (/*mondeda de juego*/ >= 5) {
            /*moneda de juego*/ - 5;
            SceneManager.LoadScene(Activador);
        }
    }
}
