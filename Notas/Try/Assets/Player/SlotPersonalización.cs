using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotPersonalización : MonoBehaviour {
    
    public BaseDeDatos baseDeDatos;
    public Slot slot;

    public Item item;
    public TipoItem TipoSlotPersonalización;
    public Image itemImagen;

    public void registarSlot() //Lo que quiero es que al puslar un botón del inventrio se encuentre 
    {

        item = baseDeDatos.FindItem(this.slot.slotInfo.identificadorItem);
        itemImagen.sprite = baseDeDatos.FindItem(slot.slotInfo.identificadorItem).imagenItem;
    }
}
