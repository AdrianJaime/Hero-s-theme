using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Monedero monedero;
    Inventory inventory;
    public PanelPersonalizacion panelPersonalizacion;


    public SlotInfo slotInfo;

    public BaseDeDatos baseDeDatos;

    public GameObject panelConfirmarVenta;

    public Image eliminarSlot;
    public Image representacionItem; //Atributos refernetes al aspecto visual del slot
    public Text nivel;
    public Text rango;

    private void Awake() 
    {
        inventory = GameObject.Find("Inventario").GetComponent<Inventory>();

        if (inventory.isOnSellMenu)
        {
            panelConfirmarVenta = GameObject.Find("PanelConfirmar");
            //panelConfirmarVenta.SetActive(false); //error no lo desactiva

        }
    }
    private void Start()
    {
        if(inventory.isOnSellMenu)
            panelConfirmarVenta.SetActive(false);

    }
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
            eliminarSlot.enabled = false;

            nivel.gameObject.SetActive(false);

            rango.gameObject.SetActive(false);

        }
        else //representacion del slot cuando hay un iteem
        {
            representacionItem.sprite = baseDeDatos.FindItem(slotInfo.identificadorItem).imagenItem;//Imagen
            representacionItem.enabled = true;

            eliminarSlot.enabled = true;

            nivel.text = baseDeDatos.FindItem(slotInfo.identificadorItem).nivel.ToString();//Nivel
            nivel.gameObject.SetActive(true);

            rango.text = baseDeDatos.FindItem(slotInfo.identificadorItem).rango.ToString();//Rango
            rango.gameObject.SetActive(true);

        }
    }

    public void EliminarSlot_VenderSlot()
    {
        if (inventory.isOnEquipMenu)
        {
            if (slotInfo.equipado)
            {
                panelPersonalizacion = GameObject.Find("Personalizacion").GetComponent<PanelPersonalizacion>();
                SlotPersonalización auxSlotPers = panelPersonalizacion.EncontrarSlotPersonalizacion(baseDeDatos.FindItem(slotInfo.identificadorItem).tipoItem);

                if (auxSlotPers.TipoSlotPersonalización == baseDeDatos.FindItem(slotInfo.identificadorItem).tipoItem)
                {
                    auxSlotPers.DeleteItemInSlotPersonalizacion();
                    panelPersonalizacion.GuardarPersonalizacion();
                }

                if (slotInfo != null)
                {
                    if (slotInfo.cantidad == 1)
                        slotInfo.SetEmptySlot();
                    else
                        slotInfo.cantidad--;
                }
                Player player = GameObject.Find("Player").GetComponent<Player>();
                player.SetValueOfItems();

                ActualizarInterfaz();
            }
            else
            {
                if (slotInfo != null)
                {
                    if (slotInfo.cantidad == 1)
                        slotInfo.SetEmptySlot();
                    else
                        slotInfo.cantidad--;
                }
                ActualizarInterfaz();
            }

        }
        if (inventory.isOnSellMenu == true)
        {
            if (!slotInfo.equipado)
            {
                monedero.AñadirMonedasNormales(baseDeDatos.FindItem(slotInfo.identificadorItem).dineroAlVender);
                if (slotInfo.cantidad == 1)
                    slotInfo.SetEmptySlot();
                else
                    slotInfo.cantidad--;
                ActualizarInterfaz();
            }
        }
    }

    public void SetItemInSlotPersonalizacion()
    {
        if (inventory.isOnEquipMenu)
        {
            SlotPersonalización SlotPersonalizacion = panelPersonalizacion.EncontrarSlotPersonalizacion(baseDeDatos.FindItem(slotInfo.identificadorItem).tipoItem);
            if (SlotPersonalizacion.personalizacionInfo.libre)
            {
                slotInfo.equipado = true;
                SlotPersonalizacion.personalizacionInfo.itemSlotPersonalizacion = baseDeDatos.FindItem(slotInfo.identificadorItem);
                SlotPersonalizacion.personalizacionInfo.libre = false;
                SlotPersonalizacion.personalizacionInfo.itemIdentificador = slotInfo.identificadorItem;
                SlotPersonalizacion.personalizacionInfo.tipoItem = (int)baseDeDatos.FindItem(slotInfo.identificadorItem).tipoItem;


                SlotPersonalizacion.personalizacionInfo.identificadorSlotInventario = slotInfo.identificador;

                SlotPersonalizacion.ActualizarInterfazSlotPersonalizacion();

            }
        }

    }
    
    public void MostrarPanelVenta(bool activar)
    {

        if (inventory.isOnSellMenu)
        {
            if (activar)
            {
                panelConfirmarVenta.GetComponent<PanelConfirmacionVenta>()._identifadorSlot = slotInfo.identificador;
                panelConfirmarVenta.GetComponent<PanelConfirmacionVenta>().setInfoSlotVenta();
            }
        }
    }

    public void AbrirPanelVenta()
    {
        if(inventory.isOnSellMenu)
        panelConfirmarVenta.GetComponent<PanelConfirmacionVenta>().MostrarPanel(true);
    }

}
[System.Serializable]
public class SlotInfo
{
  
        public int identificador;
        public bool isEmpty;
       // public bool used; //no recuerdo para que se usa esto, y piesno que se utilizaba para lo que utilizo ahora el equipado. Hay que comprobar si se utiliza de lo contrario borrarlo
        public int identificadorItem;
        public int cantidad;
        public int cantidadMax;

        public bool equipado;
        public Item itemGuardado;

        public void SetEmptySlot()
        {
            isEmpty = true;
           // used = false;
            cantidad = 0;
            identificadorItem = -1;
            equipado = false;
            itemGuardado= new Item();

        }
    
}
