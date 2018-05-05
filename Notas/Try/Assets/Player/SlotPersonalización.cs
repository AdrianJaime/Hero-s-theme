using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotPersonalización : MonoBehaviour {
    public PanelPersonalización panelPersonalización;
    public BaseDeDatos baseDeDatos;
    public Slot slotInventory;

    public Item itemSlotPersonalizacion;
    public TipoItem TipoSlotPersonalización;
    public Image itemImagen;
    public bool desocupado=true;
    private Item auxItem;


    /*public void RegistarSlot() //Lo que quiero es que al puslar un botón del inventrio se encuentre 
    {
        GameObject auxSlot = panelPersonalización.EncontrarSlotPersonalizacion( baseDeDatos.FindItem(slotInventory.slotInfo.identificadorItem).tipoItem;
        if (desocupado)
        {
            auxItem = baseDeDatos.FindItem(slotInventory.slotInfo.identificadorItem);
            
            if (auxItem.tipoItem == TipoSlotPersonalización)
            {
                itemSlotPersonalizacion = auxItem;
                
                ActualizarInterfazSlotPersonalizacion();
                desocupado = false;

            }
        }
        

    }*/
    
    public void ActualizarInterfazSlotPersonalizacion()
    {
        if (desocupado)
        {
            itemImagen.enabled = true;
            itemImagen.sprite = baseDeDatos.FindItem(auxItem.identificador).imagenItem;
        }
        else
        {
            itemImagen.enabled = false;
            itemImagen.sprite = null;

        }
    }
}
