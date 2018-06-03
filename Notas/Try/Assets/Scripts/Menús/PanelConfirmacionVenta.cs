using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelConfirmacionVenta : MonoBehaviour {

    public BaseDeDatos baseDeDatos;
    public Inventory inventory;
    public Text dineroDelItem;
    public Image imagenItem;
    public int _identifadorSlot;


    public void SetInfoSlotVenta()
    {
        Slot slotAux = inventory.EncontrarSlot(_identifadorSlot);
        imagenItem.sprite = slotAux.slotInfo.itemGuardado.imagenItem;
        dineroDelItem.text = slotAux.slotInfo.itemGuardado.dineroAlVender.ToString();
    }
    
    public void EliminarDesdeElPanel()
    {
        Slot slotAux = inventory.EncontrarSlot(_identifadorSlot);
        slotAux.EliminarSlot_VenderSlot();
    }

    public void MostrarPanel(bool _value)
    {
        gameObject.SetActive(_value);
    }

}
