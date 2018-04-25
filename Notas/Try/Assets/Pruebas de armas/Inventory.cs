using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private BaseDeDatos BaseDeDatosScript;
    private GameObject slotPrefab;
    private List<SlotInfo> slotInfoList;
    private int capacity;

    private void Start()
    {
        slotInfoList = new List<SlotInfo>();
        if(PlayerPrefs.HasKey("inventario"))
        {
            //cargar inventario
        }
        else
        {
            CrearInventarioVacío();
        }
    }


    private void CrearInventarioVacío()
    {
        for (int i = 0; i < capacity; i++)
        {
            GameObject slot = Instantiate <GameObject>(slotPrefab, this.transform);
            Slot newSlot = slotPrefab.GetComponent<Slot>();
            newSlot.CreateSlot(i);
            SlotInfo newSlotInfo = newSlot.slotInfo;
            slotInfoList.Add(newSlotInfo);
        }
    }

    private void CargarInventario()
    {

    }

    private SlotInfo SlotAccesible(int _identificadorItem)
    {
        foreach (SlotInfo slotinfo in slotInfoList) //encntrar un slot con el donde se guarden el mismo equipo
        {
            if (slotinfo.identificadorItem == _identificadorItem && slotinfo.cantidad < slotinfo.cantidadMax && !slotinfo.isEmpty)
                return slotinfo;
        }
        foreach (SlotInfo slotinfo in slotInfoList) //si ese slot no existe o esta ocupado con su maxima capacidad encuentra otro vacío
        {
            if (slotinfo.isEmpty)
                return slotinfo;
        }
        return null; //ningun lugar
    }


    public void AñadirItem(int _identificadorItem)
    {
        Item item = BaseDeDatosScript.FindItem(_identificadorItem);//mirar en la base de datos y encontralo
        if (item != null){
            SlotInfo slotInfo = SlotAccesible(_identificadorItem);//encontrar el item y guardarlo
            if (slotInfo != null)
            {
                slotInfo.cantidad++;
                slotInfo.identificadorItem = _identificadorItem;
                slotInfo.isEmpty = false;
            }
        }
    }
    public void EliminarItem(int _identificadorItem)
    {

    }
}

