using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotPersonalización : MonoBehaviour {

    public SlotPersonalizacionInfo personalizacionInfo;
    public BaseDeDatos baseDeDatos;

    public Item itemSlotPersonalizacion;
    public TipoItem TipoSlotPersonalización;
    public Image itemImagen;

   public void CrearSlotPersonalizacion(int tipoSlot)
    {
        personalizacionInfo = new SlotPersonalizacionInfo();
        personalizacionInfo.libre = true;
        personalizacionInfo.tipoItem =  tipoSlot;
        personalizacionInfo.itemIdentificador = -1;
    }
    

    

    public void ActualizarInterfazSlotPersonalizacion()
    {
        if (!personalizacionInfo.libre)
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
public class SlotPersonalizacionInfo
{
    public int tipoItem;
    public int itemIdentificador;
    public bool libre;
}