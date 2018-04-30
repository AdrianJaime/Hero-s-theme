using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControladorScenas : MonoBehaviour {
	
    public void CambioScena(string Activador)
    {
        SceneManager.LoadScene(Activador);
    }
}
