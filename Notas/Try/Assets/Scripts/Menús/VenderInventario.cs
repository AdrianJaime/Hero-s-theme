using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenderInventario : MonoBehaviour {

    Inventory inventory;
    public GameObject panelConfirmacion; 

	void Start () {
        FindAndSetInventory();
        ChangePanelConfirmacionState(false);
    }
	

    public void FindAndSetInventory()
    {
        inventory = GameObject.Find("Inventario").GetComponent<Inventory>();
    }
    public void ChangePanelConfirmacionState(bool activo) //funcion para abrir el menú
    {
        panelConfirmacion.SetActive(activo);
    }

}
