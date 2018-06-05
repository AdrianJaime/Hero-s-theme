using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class Name : MonoBehaviour {
    public InputField named;
    public string savedName;
      public void GetInput()
      {
        GuardarNombre();     
      }
    public void GuardarNombre()
    {


        NombreJugador guardarNombre = new NombreJugador();
        guardarNombre.name = this.named.text;
        savedName = JsonUtility.ToJson(guardarNombre);
        PlayerPrefs.SetString("nombrePlayer", savedName);
    }
}

public class NombreJugador{public string name; }



