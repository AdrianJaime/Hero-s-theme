using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class PanelConfirmacionVenta : MonoBehaviour {

    public BaseDeDatos baseDeDatos;
    public Inventory inventory;
    public Text dineroDelItem;
    public Image imagenItem;
    public int _identifadorSlot;

    private void Start()
    {
        this.SetActiveMIO(false);
    }
    public void setInfoSlotVenta()
    {
        Slot slotAux = inventory.EncontrarSlot(_identifadorSlot);
        imagenItem.sprite = baseDeDatos.FindItem(slotAux.slotInfo.identificadorItem).imagenItem;
        dineroDelItem.text = baseDeDatos.FindItem(slotAux.slotInfo.identificadorItem).dineroAlVender.ToString();
    }
    
    public void EliminarDesdeElPanel()
    {
        Slot slotAux = inventory.EncontrarSlot(_identifadorSlot);
        slotAux.EliminarSlot_VenderSlot();
    }
    public void SetActiveMIO(bool _value)
    {
        this.enabled = _value;      
    }

}
