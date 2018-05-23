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
    public PanelConfirmacionVenta panelConfirmacionVenta;

    public Image eliminarSlot;
    public Image representacionItem; //Atributos refernetes al aspecto visual del slot
    public Text nivel;
    public Text rango;

    private void Awake() 
    {
        inventory = GameObject.Find("Inventario").GetComponent<Inventory>();

        if (inventory.isOnSellMenu)
        {
            panelConfirmarVenta = GameObject.Find("PanelConfirmarVenta");
            panelConfirmacionVenta = panelConfirmarVenta.GetComponent<PanelConfirmacionVenta>();
            //panelConfirmarVenta.SetActive(false); //error no lo desactiva

        }
    }
    private void Start()
    {
        if(inventory.isOnSellMenu)
            panelConfirmarVenta.SetActive(false);

    }
    private void Update()
    {
        slotInfo.itemGuardado.dineroAlVender = slotInfo.itemGuardado.rareza * 100;




        switch (slotInfo.itemGuardado.rareza)
        {
            case (1):
                slotInfo.nivelMax = (slotInfo.itemGuardado.expAcumulada == 2000);
                break;
            case (2):
                slotInfo.nivelMax = (slotInfo.itemGuardado.expAcumulada == 5000);
                break;
            case (3):
                slotInfo.nivelMax = (slotInfo.itemGuardado.expAcumulada == 9000);
                break;
            case (4):
                slotInfo.nivelMax = (slotInfo.itemGuardado.expAcumulada == 14000);
                break;
            case (5):
                slotInfo.nivelMax = (slotInfo.itemGuardado.expAcumulada == 20000);
                break;
        }
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
                SlotPersonalización auxSlotPers = panelPersonalizacion.EncontrarSlotPersonalizacion(slotInfo.itemGuardado.tipoItem);

                if (auxSlotPers.personalizacionInfo.itemSlotPersonalizacion.identificador == slotInfo.itemGuardado.identificador)
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
                player.LeerYGuardarItems();
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
                monedero.AñadirMonedasNormales(slotInfo.itemGuardado.dineroAlVender);
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
                SlotPersonalizacion.personalizacionInfo.itemSlotPersonalizacion.identificador = slotInfo.identificadorItem;
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
            panelConfirmacionVenta.MostrarPanel(activar);
            if (activar)
            {
                panelConfirmacionVenta._identifadorSlot = slotInfo.identificador;
                panelConfirmacionVenta.SetInfoSlotVenta();
            }
        }
    }

    public void AbrirPanelVenta()
    {
        if(inventory.isOnSellMenu)
        panelConfirmarVenta.GetComponent<PanelConfirmacionVenta>().MostrarPanel(true);
    }

    public void PulsarEnMejorarDeEquipo()
    {
        if (inventory.isOnMejoraMenu)
        {
            MejoraArmas mejoraArmas = GameObject.Find("MejoraDeArmasPanel").GetComponent<MejoraArmas>();
            if (mejoraArmas.huecoItemMejorarLibre&&!slotInfo.nivelMax)
            {
                
                mejoraArmas.atk.text = slotInfo.itemGuardado.stats.damage.ToString();
                mejoraArmas.curacion.text = slotInfo.itemGuardado.stats.curacion.ToString();
                mejoraArmas.vida.text = slotInfo.itemGuardado.stats.vida.ToString();

                this.GetComponent<Image>().color = new Color(0, 255, 0);
                mejoraArmas.itemAMejorar = slotInfo.itemGuardado;
                mejoraArmas.imagenItemAMejorar.sprite = slotInfo.itemGuardado.imagenItem;
                mejoraArmas.huecoItemMejorarLibre = false;
                slotInfo.seleccionadoParaMejorarse = true;
            }
            else if(!mejoraArmas.huecoItemMejorarLibre)
            {
                if (slotInfo.seleccionadoParaMejorarse)
                {
                    mejoraArmas.atk.text = 0.ToString();
                    mejoraArmas.curacion.text = 0.ToString();
                    mejoraArmas.vida.text = 0.ToString();

                    this.GetComponent<Image>().color = new Color(255, 255, 255);
                    mejoraArmas.itemAMejorar = new Item();
                    mejoraArmas.imagenItemAMejorar.sprite = null;
                    mejoraArmas.huecoItemMejorarLibre = true;
                    slotInfo.seleccionadoParaMejorarse = false;

                    // eliminar el resto 
                    foreach (SlotInfo slot in inventory.slotInfoList)
                    {
                        if (slot.seleccionadoParaMejorar)
                        {
                            //eliminar el item de la lista de items del mejoraArmas
                            SlotInfo newslotInfo = slot;
                            mejoraArmas.listaItemsParaFusionar.Remove(mejoraArmas.EncontarItemEnListaDeFusion(newslotInfo.identificador));
                            slot.seleccionadoParaMejorar = false;
                            inventory.EncontrarSlot(slot.identificador).GetComponent<Image>().color = new Color(255, 255, 255);
                        }

                    }
                }
                else if (!slotInfo.seleccionadoParaMejorar&&!slotInfo.seleccionadoParaMejorarse)
                {
                    //añadir el item a una lista de items del mejoraArmas
                    SlotInfo newslotInfo = this.slotInfo;
                    mejoraArmas.listaItemsParaFusionar.Add(newslotInfo);
                    slotInfo.seleccionadoParaMejorar = true;
                    this.GetComponent<Image>().color = new Color(255, 0, 0);
                }

                else if (slotInfo.seleccionadoParaMejorar&& !slotInfo.seleccionadoParaMejorarse)
                {
                    //eliminar el item de la lista de items del mejoraArmas
                    SlotInfo newslotInfo = this.slotInfo;
                    mejoraArmas.listaItemsParaFusionar.Remove(mejoraArmas.EncontarItemEnListaDeFusion(newslotInfo.identificador));
                    slotInfo.seleccionadoParaMejorar = false;
                    this.GetComponent<Image>().color = new Color(255, 255, 255);
                }


            } 

           
        }
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

        public bool nivelMax;
        public bool seleccionadoParaMejorarse;
        public bool seleccionadoParaMejorar;

        public bool equipado;
        public Item itemGuardado;

        public void SetEmptySlot()
        {
            seleccionadoParaMejorar = false;
            seleccionadoParaMejorarse=false;

            isEmpty = true;
           // used = false;
            cantidad = 0;
            identificadorItem = -1;
            equipado = false;
            itemGuardado= new Item();

        }
    
}
