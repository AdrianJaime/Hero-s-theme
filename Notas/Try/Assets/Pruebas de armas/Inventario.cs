using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour {

    public BaseDeDatos BaseDeDatosScript;
    public GameObject slotPefab;
    private List<SlotInfo> slotInfoList;
    private int capacity;

    private void CrearInventarioVacío()
    {
        for (int i = 0; i < capacity; i++)
        {
            GameObject slot = Instanciate<GameObject>(slotPefab, this.transform);
            slot newSlot = slorPrefab.GetComponent<slot>();
            newSlot.CreateSlot(i);
            SlotInfo newSlotInfo = newSlot.slotInfo;
            slotInfoList.Add(newSlotInfo);
        }
    }


    public void AñadirItem(int _identificadorItem)
    {
        Item
    }
}
