using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotPersonalización : MonoBehaviour {

    public Inventory inventory;

    [SerializeField]
    public SlotPersonalizacionInfo personalizacionInfo;
    public BaseDeDatos baseDeDatos;
    public PanelPersonalizacion panelPersonalizacion;

    public TipoItem TipoSlotPersonalización;

  
    public Image itemImagen;
    public Image eliminarSlotBotón;

   public void CrearSlotPersonalizacion(int tipoSlot)
    {
        personalizacionInfo = new SlotPersonalizacionInfo();
        personalizacionInfo.SlotPersonalizacionInfoDefault(tipoSlot);
   
    }  

    public void ActualizarInterfazSlotPersonalizacion()
    {
        if (!personalizacionInfo.libre)
        {
            itemImagen.enabled = true;
            eliminarSlotBotón.enabled = true;

            itemImagen.sprite = personalizacionInfo.itemSlotPersonalizacion.imagenItem;

        }
        else
        {
            itemImagen.enabled = false;
            eliminarSlotBotón.enabled = false;

            itemImagen.sprite = null;
        }

    }

    public void DeleteItemInSlotPersonalizacion()
    {

        this.personalizacionInfo.SlotPersonalizacionInfoDefault((int)TipoSlotPersonalización);
        personalizacionInfo.itemSlotPersonalizacion = null;
        inventory.EncontrarSlot(personalizacionInfo.identificadorSlotInventario).slotInfo.equipado = false;
        

        ActualizarInterfazSlotPersonalizacion();

    }



}

[System.Serializable]
public class SlotPersonalizacionInfo
{

    public Item itemSlotPersonalizacion;

    public int identificadorSlotInventario;
    public int tipoItem;
    public int itemIdentificador;
    public bool libre;

    public void SlotPersonalizacionInfoDefault(int _tipoItem)
    {

        tipoItem = _tipoItem;
        itemIdentificador = -1;
        libre = true;
        itemSlotPersonalizacion= new Item();
    }


}
