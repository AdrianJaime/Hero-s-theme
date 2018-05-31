using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelStats : MonoBehaviour {

    public Image imagenITEM;
    public Text atk, vida, curacion, nombreItem;

    public bool activo = false;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void SetInactivePanel()
    {
        activo = false;
        this.gameObject.SetActive(false);
    }
}
