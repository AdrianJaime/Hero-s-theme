using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

    public PanelPersonalizacion panelPersonalizacion;

    public SlotInfo slotInfo;

    public BaseDeDatos baseDeDatos;

    public Image representacionItem; //Atributos refernetes al aspecto visual del slot
    public Text nivel;
    public Text rango;

    public void CreateSlot(int _identificador)
    {
        slotInfo = new SlotInfo();
        slotInfo.identificador = _identificador;
        slotInfo.SetEmptySlot();
    }

    public void ActualizarInterfaz()
    {
        if (slotInfo.isEmpty) //representacion del slot cuando no hay ningun item
        {
            representacionItem.sprite = null;
            representacionItem.enabled = false;

            nivel.gameObject.SetActive(false);

            rango.gameObject.SetActive(false);

        }
        else //representacion del slot cuando hay un iteem
        {
            representacionItem.sprite = baseDeDatos.FindItem(slotInfo.identificadorItem).imagenItem;//Imagen
            representacionItem.enabled = true;

            nivel.text = baseDeDatos.FindItem(slotInfo.identificadorItem).nivel.ToString();//Nivel
            nivel.gameObject.SetActive(true);

            rango.text = baseDeDatos.FindItem(slotInfo.identificadorItem).rango.ToString();//Rango
            rango.gameObject.SetActive(true);

        }
    }

    public void EliminarSlot()
    {
      
        SlotPersonalización auxSlotPers = panelPersonalizacion.EncontrarSlotPersonalizacion(baseDeDatos.FindItem(slotInfo.identificadorItem).tipoItem);


        if (auxSlotPers.TipoSlotPersonalización == baseDeDatos.FindItem(slotInfo.identificadorItem).tipoItem)
        {
            auxSlotPers.DeleteItemInSlotPersonalizacion();
        }

        if (slotInfo != null)
        {
            if (slotInfo.cantidad == 1)
                slotInfo.SetEmptySlot();
            else
                slotInfo.cantidad--;
        }
        ActualizarInterfaz();

    }

    public void SetItemInSlotPersonalizacion()
    {

        SlotPersonalización SlotPersonalizacion = panelPersonalizacion.EncontrarSlotPersonalizacion(baseDeDatos.FindItem(slotInfo.identificadorItem).tipoItem);
        if (SlotPersonalizacion.personalizacionInfo.libre)
        {
            slotInfo.equipado = true;
            SlotPersonalizacion.itemSlotPersonalizacion = baseDeDatos.FindItem(slotInfo.identificadorItem);
            SlotPersonalizacion.personalizacionInfo.libre = false;
            SlotPersonalizacion.personalizacionInfo.itemIdentificador = baseDeDatos.FindItem(slotInfo.identificadorItem).identificador;
            SlotPersonalizacion.personalizacionInfo.tipoItem = (int)baseDeDatos.FindItem(slotInfo.identificadorItem).tipoItem;
            SlotPersonalizacion.personalizacionInfo.statsInfo.combo = baseDeDatos.FindItem(slotInfo.identificadorItem).stats.combo;
            SlotPersonalizacion.personalizacionInfo.statsInfo.vida = baseDeDatos.FindItem(slotInfo.identificadorItem).stats.vida;
            SlotPersonalizacion.personalizacionInfo.statsInfo.damage = baseDeDatos.FindItem(slotInfo.identificadorItem).stats.damage;


            SlotPersonalizacion.ActualizarInterfazSlotPersonalizacion();



        }

    }
}
[System.Serializable]
public class SlotInfo
{
    public int identificador;
    public bool isEmpty;
    public bool used;
    public int identificadorItem;
    public int cantidad;
    public int cantidadMax;

    public bool equipado;


    public void SetEmptySlot()
    {
        isEmpty = true;
        used = false;
        cantidad = 0;
        identificadorItem = -1;
        equipado = false;
    }
}