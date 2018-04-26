using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

    public SlotInfo slotInfo;

    public BaseDeDatos baseDeDatos;
    public Image representacionItem;
    public Text nivel;

    public void CreateSlot(int _identificador)
    {
        slotInfo = new SlotInfo();
        slotInfo.identificador = _identificador;
        slotInfo.SetEmptySlot();
    }

    public void ActualizarInterfaz()
    {
        if (slotInfo.isEmpty)
        {
            representacionItem.sprite = null;
            representacionItem.enabled = false;

            nivel.gameObject.SetActive(false);
        }
        else
        {
           representacionItem.sprite = baseDeDatos.FindItem(slotInfo.identificadorItem).imagenItem;
            representacionItem.enabled = true;

            nivel.text = baseDeDatos.FindItem(slotInfo.identificadorItem).nivel.ToString();
            nivel.gameObject.SetActive(true);
        }
    }

}
[System.Serializable]
public class SlotInfo
{
    public int identificador;
    public bool isEmpty;
    public int identificadorItem;
    public int cantidad;
    public int cantidadMax=5;

    public void SetEmptySlot()
    {
        isEmpty = true;
        cantidad = 0;
        identificadorItem = -1;
    }
}