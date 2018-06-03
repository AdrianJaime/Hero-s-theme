using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador_escena : MonoBehaviour {

    public void CambioEscena(string scena)
    {
        SceneManager.LoadScene(scena);

    }

}
