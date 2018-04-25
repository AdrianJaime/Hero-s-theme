using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    public SlotInfo slotInfo;

    public void CreateSlot(int _identificador)
    {
        slotInfo = new SlotInfo();
        slotInfo.identificador = _identificador;
        slotInfo.SetEmptySlot;
    }

}

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