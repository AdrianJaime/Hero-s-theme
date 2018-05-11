using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public PanelPersonalizacion panelPersonalizacion;
    public Transform panelInventrio;
    public BaseDeDatos BaseDeDatosScript;
    public GameObject slotPrefab;

    [SerializeField]
    public List<SlotInfo> slotInfoList;

    public int capacity;
    public string saveDataInventario;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        slotInfoList = new List<SlotInfo>();
        if(PlayerPrefs.HasKey("inventario"))
        {
            CargarInventario();
        }
        else
        {
            CrearInventarioVacío();
        }
    }

    private void Update()
    {
        GuardarInventario();
    }

    private void CrearInventarioVacío()
    {
        for (int i = 0; i < capacity; i++)
        {
            GameObject slot = Instantiate <GameObject>(slotPrefab, panelInventrio);
            Slot newSlot = slot.GetComponent<Slot>();
            newSlot.CreateSlot(i);
            newSlot.baseDeDatos = BaseDeDatosScript;
            SlotInfo newSlotInfo = newSlot.slotInfo;
            slotInfoList.Add(newSlotInfo);

            newSlot.ActualizarInterfaz();
            //problema arreglado la funcion no sirv de nada ponerla aqui xD parezco subnormal
        }

    }

    private void CargarInventario()
    {
        saveDataInventario = PlayerPrefs.GetString("inventario");
        InventarioGuardado guardarInventario = JsonUtility.FromJson<InventarioGuardado>(saveDataInventario);
        this.slotInfoList = guardarInventario.slotInfoList;
        for (int i = 0; i < capacity; i++)
        {
            GameObject slot = Instantiate<GameObject>(slotPrefab, panelInventrio);
            Slot newSlot = slot.GetComponent<Slot>();
            newSlot.CreateSlot(i);
            newSlot.baseDeDatos = BaseDeDatosScript;
            newSlot.slotInfo = slotInfoList[i];

            newSlot.ActualizarInterfaz();
            //problema arreglado la funcion no sirv de nada ponerla aqui xD parezco subnormal
        }
    }

    private SlotInfo EncontrarItemEnInventario(int _identificadorItem)
    {
        foreach(SlotInfo slotInfo in slotInfoList)
        {
            if (slotInfo.identificadorItem == _identificadorItem && !slotInfo.isEmpty)
                return slotInfo;
        }
        return null;
    }

    public Slot EncontrarSlot(int _identificador)
    {
        return panelInventrio.GetChild(_identificador).GetComponent<Slot>(); //getchild lo que hace es buscar en el panale de inventario el componente con el identificador, hijo del panel. En este caso tanto el identificador del slot como idenificador hijo concuerdan por lo que de puta madre.Delvolviendo el slot
    }

    private SlotInfo SlotAccesible(int _identificadorItem)
    {
        foreach (SlotInfo slotinfo in slotInfoList) //encntrar un slot con el donde se guarden el mismo equipo
        {
            if (slotinfo.identificadorItem == _identificadorItem && slotinfo.cantidad < slotinfo.cantidadMax && !slotinfo.isEmpty) //Cambio de planes, al final por cada slot solo habrá un eemento asi que el codigo hay que retocarlo. de momento se quedará así simplemente modificando los parametros
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
            SlotInfo slotInfo = SlotAccesible(_identificadorItem);//encontrar el slor donde debe estar y guardar la información del itemm
            if (slotInfo != null)
            {
                slotInfo.cantidad++;
                slotInfo.identificadorItem = _identificadorItem;
                slotInfo.isEmpty = false;

                EncontrarSlot(slotInfo.identificador).ActualizarInterfaz();
            }
        }
    }
    /*
    public void EliminarItem(int _identificadorItem)
    {
        SlotInfo slotInfo = EncontrarItemEnInventario(_identificadorItem);
        SlotPersonalización auxSlotPers = panelPersonalizacion.EncontrarSlotPersonalizacion(BaseDeDatosScript.FindItem(slotInfo.identificadorItem).tipoItem);


        if (auxSlotPers.TipoSlotPersonalización == BaseDeDatosScript.FindItem(slotInfo.identificadorItem).tipoItem)
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
        EncontrarSlot(slotInfo.identificador).ActualizarInterfaz();

    }
    */

    private class InventarioGuardado
    {
        public List<SlotInfo> slotInfoList;
    }

    public void GuardarInventario()
    {
        InventarioGuardado guardarInventario = new InventarioGuardado();
        guardarInventario.slotInfoList = this.slotInfoList;
        saveDataInventario = JsonUtility.ToJson(guardarInventario);
        PlayerPrefs.SetString("inventario", saveDataInventario);
    }

    

    [ContextMenu("Instrucción_1")]
    public void Instrucción_1()
    {
        AñadirItem(2);
    }

    [ContextMenu("Instrucción_3")]
    public void AlmacenarInventario()
    {
        AñadirItem(3);
    }

    [ContextMenu("Instrucción_4")]
    public void AlmacenarInventario_()
    {
        AñadirItem(4);
    }
}

