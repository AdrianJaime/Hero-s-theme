using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cambioNombre : MonoBehaviour {
    public Text name;
    string name2;
	// Use this for initialization
	void Start () {
        cargarName();
        name.text = name2;
	}
	
	void cargarName()
    {
        string saveName;
        saveName = PlayerPrefs.GetString("nombrePlayer");
        NombreJugador nombreGuardado = JsonUtility.FromJson<NombreJugador>(saveName);
        name2 = nombreGuardado.name;
    }
}
