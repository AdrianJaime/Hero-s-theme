using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPersonalizacion : MonoBehaviour {

    public BaseDeDatos baseDeDatos;
    public Transform panelPersonalizacion;

    public GameObject slotPersonalizacionPrefab;
    public Slot slotInventario;

    public string saveDataPersonalizacion;

    [SerializeField]
    public List<SlotPersonalizacionInfo> slotPersonalizacionInfo;



    void Start () {

        //PlayerPrefs.DeleteAll();

        slotPersonalizacionInfo = new List<SlotPersonalizacionInfo>();
        if (PlayerPrefs.HasKey("equipamiento"))
        {
            CargarSlotsPersonalizacion();
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
            newSlotP.CrearSlotPersonalizacion(i);
            newSlotP.TipoSlotPersonalización = (TipoItem)newSlotP.personalizacionInfo.tipoItem;

            SlotPersonalizacionInfo persInfo = newSlotP.personalizacionInfo;
            slotPersonalizacionInfo.Add(persInfo);
            

            newSlotP.baseDeDatos = baseDeDatos;
            newSlotP.ActualizarInterfazSlotPersonalizacion();
        }

    }
    

    private void CargarSlotsPersonalizacion()
    {
        saveDataPersonalizacion = PlayerPrefs.GetString("equipamiento");
        PersonalizacionGuardada guardarPersonalizacion = JsonUtility.FromJson<PersonalizacionGuardada>(saveDataPersonalizacion);
        slotPersonalizacionInfo = guardarPersonalizacion.slotPersonalizacionInfo;

        for (int i = 0; i < 4; i++)
        {

            GameObject slotP = Instantiate<GameObject>(slotPersonalizacionPrefab, panelPersonalizacion);
            SlotPersonalización newSlotP = slotP.GetComponent<SlotPersonalización>();

            newSlotP.personalizacionInfo = slotPersonalizacionInfo[i];//El problema esta en el ndice i que no se porque no funca

            newSlotP.itemSlotPersonalizacion = baseDeDatos.FindItem(newSlotP.personalizacionInfo.itemIdentificador);
            newSlotP.TipoSlotPersonalización = (TipoItem)newSlotP.personalizacionInfo.tipoItem;
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
        public List<SlotPersonalizacionInfo> slotPersonalizacionInfo;
    }

    public void GuardarPersonalizacion()
    {
        PersonalizacionGuardada guardarPersonalizacion = new PersonalizacionGuardada();

        guardarPersonalizacion.slotPersonalizacionInfo = this.slotPersonalizacionInfo;
        

        saveDataPersonalizacion = JsonUtility.ToJson(guardarPersonalizacion);
        PlayerPrefs.SetString("equipamiento", saveDataPersonalizacion);
    }

    
}

