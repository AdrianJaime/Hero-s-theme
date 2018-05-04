using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {



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


    public void SetEmptySlot()
    {
        isEmpty = true;
        used = false;
        cantidad = 0;
        identificadorItem = -1;
    }
}