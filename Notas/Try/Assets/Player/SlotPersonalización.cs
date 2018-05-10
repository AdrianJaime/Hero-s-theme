using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotPersonalización : MonoBehaviour {

    public BaseDeDatos baseDeDatos;

    public Item itemSlotPersonalizacion;
    public TipoItem TipoSlotPersonalización;
    public Image itemImagen;
    public bool libre=true;
    
    public void ActualizarInterfazSlotPersonalizacion()
    {
        if (!libre)
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
