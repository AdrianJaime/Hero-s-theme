using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPersonalización : MonoBehaviour {

    public BaseDeDatos baseDeDatos;
    public Transform panelPersonalizacion;
    public BaseDeDatos BaseDeDatosScript;
    public GameObject slotPersonalizacionPrefab;
    

    public Slot slotInventario;

    void Start () {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("equipamiento"))
        {
            
        }
        else
        {
            CrearSlotsVacíos();
        }
    }

    private void CrearSlotsVacíos()
    {
        for (int i = 0; i < 4; i++)
        {
            
            GameObject slotP = Instantiate<GameObject>(slotPersonalizacionPrefab, panelPersonalizacion);
            SlotPersonalización newSlotP = slotP.GetComponent<SlotPersonalización>();
            newSlotP.desocupado = true;
            newSlotP.TipoSlotPersonalización = (TipoItem)i;
            
            newSlotP.slotInventory = slotInventario;
            newSlotP.baseDeDatos = BaseDeDatosScript;

            

            
         
        }

    }
    public SlotPersonalización EncontrarSlotPersonalizacion(TipoItem _identificador)
    {
        return panelPersonalizacion.GetChild((int)_identificador).GetComponent<SlotPersonalización>(); //getchild lo que hace es buscar en el panale de inventario el componente con el identificador, hijo del panel. En este caso tanto el identificador del slot como idenificador hijo concuerdan por lo que de puta madre.Delvolviendo el slot
    }
    public void RegistarSlot() //Lo que quiero es que al puslar un botón del inventrio se encuentre 
    {
        GameObject auxSlot = this.EncontrarSlotPersonalizacion((int)baseDeDatos.FindItem(slotInventory.slotInfo.identificadorItem).tipoItem;
        if (desocupado)
        {
            auxItem = baseDeDatos.FindItem(slotInventory.slotInfo.identificadorItem);

            if (auxItem.tipoItem == TipoSlotPersonalización)
            {
                itemSlotPersonalizacion = auxItem;

                ActualizarInterfazSlotPersonalizacion();
                desocupado = false;

            }
        }


    }
}
