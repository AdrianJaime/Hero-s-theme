using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControladorScenas : MonoBehaviour {

    public Inventory inventory;
    public MejoraArmas mejoraArmas;


    public void CambioScena(string Activador)
    {
        if (inventory == null)
            SceneManager.LoadScene(Activador);
        else if (inventory.isOnMejoraMenu&&mejoraArmas.huecoItemMejorarLibre)
            SceneManager.LoadScene(Activador);

    }
}
