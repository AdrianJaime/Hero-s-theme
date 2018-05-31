using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPanel : MonoBehaviour {

    public GameObject panelConfirmacion;
    private void Start()
    {
        panelConfirmacion.SetActive(false);
    }

    public void MostrarPanelVenta(bool activar)
    {
        panelConfirmacion.SetActive(activar);
    }
}
