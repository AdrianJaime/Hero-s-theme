using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPersonalizacion : MonoBehaviour {

    public BaseDeDatos baseDeDatos;
    public Transform panelPersonalizacion;

    public BaseDeDatos BaseDeDatosScript;
    public GameObject slotPersonalizacionPrefab;

    private string saveDataPersonalizacion;

    public List<SlotPersonalización> slotPersonalizacionListInfo;

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
            newSlotP.libre = true;
            newSlotP.TipoSlotPersonalización = (TipoItem)i;



            newSlotP.baseDeDatos = BaseDeDatosScript;   
        }

    }

    private void CargarSlotsPersonalizacion()
    {
        saveDataPersonalizacion = PlayerPrefs.GetString("equipamiento");
        PersonalizacionGuardada guardarPersonalizacion = JsonUtility.FromJson<PersonalizacionGuardada>(saveDataPersonalizacion);
        this.slotPersonalizacionListInfo = guardarPersonalizacion.slotPersonalizacionInfoList;
        for (int i = 0; i < 4; i++)
        {

            GameObject slotP = Instantiate<GameObject>(slotPersonalizacionPrefab, panelPersonalizacion);
            SlotPersonalización newSlotP = slotP.GetComponent<SlotPersonalización>();

            newSlotP = slotPersonalizacionListInfo[i];
            newSlotP.ActualizarInterfazSlotPersonalizacion();
        }

    }

    public SlotPersonalización EncontrarSlotPersonalizacion(TipoItem _identificador)
    {
        panelPersonalizacion = GameObject.Find("Panel Personalixacion").transform;

        return panelPersonalizacion.GetChild((int)_identificador).gameObject.GetComponent<SlotPersonalización>(); //getchild lo que hace es buscar en el panale de inventario el componente con el identificador, hijo del panel. En este caso tanto el identificador del slot como idenificador hijo concuerdan por lo que de puta madre.Delvolviendo el slot
    }


    private class PersonalizacionGuardada
    {
        public List<SlotPersonalización> slotPersonalizacionInfoList;
    }

    public void GuardarInventario()
    {
        PersonalizacionGuardada guardarPersonalizacion = new PersonalizacionGuardada();
        guardarPersonalizacion.slotPersonalizacionInfoList = this.slotPersonalizacionListInfo;
        saveDataPersonalizacion = JsonUtility.ToJson(guardarPersonalizacion);
        PlayerPrefs.SetString("equipamiento", saveDataPersonalizacion);
    }




    public void SetItemInSlotPersonalizacion() //Lo que quiero es que al puslar un botón del inventrio se encuentre 
    {//comparar el item tipo con el del slotpersonalizacion

        SlotPersonalización SlotPersonalizacion = EncontrarSlotPersonalizacion(baseDeDatos.FindItem(slotInventario.slotInfo.identificadorItem).tipoItem);
        if (SlotPersonalizacion.libre)
        {
            SlotPersonalizacion.itemSlotPersonalizacion = baseDeDatos.FindItem(slotInventario.slotInfo.identificadorItem);
            SlotPersonalizacion.libre = false;
            SlotPersonalizacion.ActualizarInterfazSlotPersonalizacion();

           // GuardarInventario();
        }
    }
}
