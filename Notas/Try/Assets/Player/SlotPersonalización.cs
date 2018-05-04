using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotPersonalización : MonoBehaviour {

    public BaseDeDatos baseDeDatos;

    public Item itemSlotPersonalizacion;
    public TipoItem TipoSlotPersonalización;
    public Image itemImagen;
    public bool desocupado=true;
    
    public void ActualizarInterfazSlotPersonalizacion()
    {
        if (desocupado)
        {
            itemImagen.enabled = true;
            itemImagen.sprite = baseDeDatos.FindItem(itemSlotPersonalizacion.identificador).imagenItem;
        }
        else
        {
            itemImagen.enabled = false;
            itemImagen.sprite = null;

        }
    }
}
