using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class ControladorScenas : MonoBehaviour {

    public Inventory inventory;
    public MejoraArmas mejoraArmas;
    
    public string newName;

    public void CambioScena(string Activador)
    {
        if (inventory == null)
            SceneManager.LoadScene(Activador);
        else if (inventory.isOnMejoraMenu&&mejoraArmas.huecoItemMejorarLibre)
            SceneManager.LoadScene(Activador);

    }
    public void CambioScenaNuevoJuego(string Activador)
    {
        CargarName();
        if (newName!="")
            SceneManager.LoadScene(Activador);
    }
    public void CambioScenaArranqueAMenú(string Activador)
    {
        CargarName();
        if (newName != ""||newName==null)
            SceneManager.LoadScene(Activador);

    }
    public void CargarName()
    {
        string saveName;
        saveName = PlayerPrefs.GetString("nombrePlayer");
        NombreJugador nombreGuardado = JsonUtility.FromJson<NombreJugador>(saveName);
        newName = nombreGuardado.name;

    }
}
