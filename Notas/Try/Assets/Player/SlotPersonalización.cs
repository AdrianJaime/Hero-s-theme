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

    public Item itemSlotPersonalizacion;
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

            itemImagen.sprite = baseDeDatos.FindItem(itemSlotPersonalizacion.identificador).imagenItem;

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
        personalizacionInfo.statsInfo.StatsACero();
        inventory.EncontrarSlot(personalizacionInfo.statsInfo.identificadorSlotInventario).slotInfo.equipado = false;
        

        ActualizarInterfazSlotPersonalizacion();

    }



}

[System.Serializable]
public class SlotPersonalizacionInfo
{
    [System.Serializable]
    public struct Stats
    {
        public int combo;
        public int vida;
        public int damage;
        public int identificadorSlotInventario;

        public void StatsACero()
        {
            combo = 0;
            vida = 0;
            damage = 0;
            identificadorSlotInventario = -1;
        }
    }

    public int tipoItem;
    public int itemIdentificador;
    public bool libre;
    public Stats statsInfo;
    public void SlotPersonalizacionInfoDefault(int _tipoItem)
    {
        tipoItem = _tipoItem;
        itemIdentificador = -1;
        libre = true;
    }


}
