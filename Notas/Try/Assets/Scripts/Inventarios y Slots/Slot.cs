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
        if (inventory.isOnEquipMenu == true)
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
                SlotPersonalizacion.itemSlotPersonalizacion = baseDeDatos.FindItem(slotInfo.identificadorItem);
                SlotPersonalizacion.personalizacionInfo.libre = false;
                SlotPersonalizacion.personalizacionInfo.itemIdentificador = baseDeDatos.FindItem(slotInfo.identificadorItem).identificador;
                SlotPersonalizacion.personalizacionInfo.tipoItem = (int)baseDeDatos.FindItem(slotInfo.identificadorItem).tipoItem;
                SlotPersonalizacion.personalizacionInfo.statsInfo.curacion = baseDeDatos.FindItem(slotInfo.identificadorItem).stats.curacion;
                SlotPersonalizacion.personalizacionInfo.statsInfo.vida = baseDeDatos.FindItem(slotInfo.identificadorItem).stats.vida;
                SlotPersonalizacion.personalizacionInfo.statsInfo.damage = baseDeDatos.FindItem(slotInfo.identificadorItem).stats.damage;
                SlotPersonalizacion.personalizacionInfo.statsInfo.identificadorSlotInventario = slotInfo.identificador;

                SlotPersonalizacion.ActualizarInterfazSlotPersonalizacion();

            }
        }

    }
    
    public void MostrarPanelVenta(bool activar)
    {


        if (activar)
        {
            panelConfirmarVenta.GetComponent<PanelConfirmacionVenta>()._identifadorSlot = slotInfo.identificador;
            panelConfirmarVenta.GetComponent<PanelConfirmacionVenta>().setInfoSlotVenta();
        }
    }

    public void AbrirPanelVenta()
    {
        panelConfirmarVenta.GetComponent<PanelConfirmacionVenta>().MostrarPanel(true);
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

        public bool equipado;


        public void SetEmptySlot()
        {
            isEmpty = true;
            used = false;
            cantidad = 0;
            identificadorItem = -1;
            equipado = false;
        }
    }
