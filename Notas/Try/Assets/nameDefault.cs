using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nameDefault : MonoBehaviour {

    public string savedName;
	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("nombrePlayer"))
        GuardarNombre();

    }


    public void GuardarNombre()
    {
        NombreJugador guardarNombre = new NombreJugador();
        guardarNombre.name = "";
        savedName = JsonUtility.ToJson(guardarNombre);
        PlayerPrefs.SetString("nombrePlayer", savedName);
    }
}
