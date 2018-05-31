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

        if (inventory.isOnSellMenu)
            panelConfirmarVenta.SetActive(false);

    }
    private void Update()
    {
        //comprovar si es nivel max o no.

        SetValueOfMaxLevel();
        SetValueOfDineroAlVender();
        SetValueStatsLevel();
        SetValueOfLevel();
        ComprobarSiEsNivelMax();
        SetValueOfStats();
        SetValueOfExpProporcionada();

    }
    public void CreateSlot(int _identificador)
    {
       // slotInfo = new SlotInfo();
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
            representacionItem.sprite = slotInfo.itemGuardado.imagenItem;//Imagen
            representacionItem.enabled = true;

            if (inventory.isOnSellMenu)
                eliminarSlot.enabled = true;

            nivel.text = slotInfo.itemGuardado.nivel.ToString();//Nivel
            nivel.gameObject.SetActive(true);

            rango.text = slotInfo.itemGuardado.rareza.ToString();//Rango
            rango.gameObject.SetActive(true);

        }
    }

    public void EliminarSlot_VenderSlot()
    {

       /* if (inventory.isOnEquipMenu)
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
                    EliminarItem();
            }

        }*/

        if (inventory.isOnSellMenu == true )
        {
            if (!slotInfo.equipado)
            {
                monedero.AñadirMonedasNormales(slotInfo.itemGuardado.dineroAlVender);
                EliminarItem();
            }
        }
        if (inventory.isOnMejoraMenu==true)
        {
            if (!slotInfo.equipado)
            {
                EliminarItem();
            }
        }
    }

    private void EliminarItem()
    {
        if (slotInfo.cantidad == 1)
            slotInfo.SetEmptySlot();
        else
            slotInfo.cantidad--;
        ActualizarInterfaz();
    }

    public void SetItemInSlotPersonalizacion()
    {
        if (inventory.isOnEquipMenu)
        {
            SlotPersonalización SlotPersonalizacion = panelPersonalizacion.EncontrarSlotPersonalizacion(slotInfo.itemGuardado.tipoItem);
            if (SlotPersonalizacion.personalizacionInfo.libre)
            {
                slotInfo.equipado = true;
                SlotPersonalizacion.personalizacionInfo.itemSlotPersonalizacion = slotInfo.itemGuardado;
                SlotPersonalizacion.personalizacionInfo.libre = false;

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
        if (inventory.isOnSellMenu)
            panelConfirmarVenta.GetComponent<PanelConfirmacionVenta>().MostrarPanel(true);
    }

<<<<<<< HEAD:Notas/Try/Assets/Scripts/Inventarios y Slots/Slot.cs
<<<<<<< HEAD:Notas/Try/Assets/Scripts/Inventarios y Slots/Slot.cs
=======
    public void PulsarEnEvolucion()
    {
        if (inventory.isOnEvolutionMenu)
        {
            if (slotInfo.itemGuardado.identificadorItemEvolucionado != -1)
            {
                EvolucionMenu evolucionMenu = GameObject.Find("EvoluciónDeArmasPanel").GetComponent<EvolucionMenu>();
                evolucionMenu.SlotItemAEvolucionar = this;
                evolucionMenu.EncontrarItemMejorado();
            }
        }
    }
>>>>>>> parent of 837c9ce... Bastantes cambios:Notas/Try/Assets/Scripts/Menús/Inventarios y Slots/Slot.cs
=======
>>>>>>> parent of f8664d2... Merge branch 'Branca-de-seguridad' into General:Notas/Try/Assets/Scripts/Inventarios y Slots/Slot.cs
    public void PulsarEnMejorarDeEquipo()
    {
        if (inventory.isOnMejoraMenu)
        {
            MejoraArmas mejoraArmas = GameObject.Find("MejoraDeArmasPanel").GetComponent<MejoraArmas>();

            if (mejoraArmas.huecoItemMejorarLibre && !slotInfo.nivelMax)
            {

                mejoraArmas.atk.text = slotInfo.itemGuardado.stats.damage.ToString();
                mejoraArmas.curacion.text = slotInfo.itemGuardado.stats.curacion.ToString();
                mejoraArmas.vida.text = slotInfo.itemGuardado.stats.vida.ToString();

                this.GetComponent<Image>().color = new Color(0, 255, 0);
                mejoraArmas.SlotInfoItemAMejorar = this;
                mejoraArmas.expAntesDeMejorar = slotInfo.itemGuardado.expAcumulada; // aqui tambien está la solución

                mejoraArmas.imagenItemAMejorar.sprite = slotInfo.itemGuardado.imagenItem;
                mejoraArmas.huecoItemMejorarLibre = false;
                slotInfo.seleccionadoParaMejorarse = true;
            }
            else if (!mejoraArmas.huecoItemMejorarLibre)
            {
                if (slotInfo.seleccionadoParaMejorarse)
                {
                    mejoraArmas.atk.text = 0.ToString();
                    mejoraArmas.curacion.text = 0.ToString();
                    mejoraArmas.vida.text = 0.ToString();

                    mejoraArmas.newAtk.text = 0.ToString();
                    mejoraArmas.newCuracion.text = 0.ToString();
                    mejoraArmas.newVida.text = 0.ToString();

                    mejoraArmas.SlotInfoItemAMejorar.slotInfo.itemGuardado.expAcumulada = mejoraArmas.expAntesDeMejorar;
                    mejoraArmas.expAntesDeMejorar = 0;
                    this.GetComponent<Image>().color = new Color(255, 255, 255);
                    //mejoraArmas.SlotInfoItemAMejorar = new SlotInfo();
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
                else if (!slotInfo.seleccionadoParaMejorar && !slotInfo.seleccionadoParaMejorarse&&!slotInfo.equipado)
                {
                    //añadir el item a una lista de items del mejoraArmas
                    SlotInfo newslotInfo = this.slotInfo;
                    mejoraArmas.listaItemsParaFusionar.Add(newslotInfo);
                    slotInfo.seleccionadoParaMejorar = true;
                    this.GetComponent<Image>().color = new Color(255, 0, 0);
                }

                else if (slotInfo.seleccionadoParaMejorar && !slotInfo.seleccionadoParaMejorarse)
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




    //************************************************************
    public void SetValueStatsLevel()
    {

        slotInfo.itemGuardado.stats.damageLevel = (slotInfo.itemGuardado.stats.maxDamage - slotInfo.itemGuardado.stats.damageBase) / slotInfo.itemGuardado.nivelMax;
        slotInfo.itemGuardado.stats.curacionLevel = (slotInfo.itemGuardado.stats.maxCuracion - slotInfo.itemGuardado.stats.curacionBase) / slotInfo.itemGuardado.nivelMax;
        slotInfo.itemGuardado.stats.vidaLevel = (slotInfo.itemGuardado.stats.maxVida - slotInfo.itemGuardado.stats.vidaBase) / slotInfo.itemGuardado.nivelMax;
        if (slotInfo.itemGuardado.stats.damageLevel == 0)
            slotInfo.itemGuardado.stats.damageLevel = 1;
        if (slotInfo.itemGuardado.stats.curacionLevel == 0)
            slotInfo.itemGuardado.stats.curacionLevel = 1;
        if (slotInfo.itemGuardado.stats.vidaLevel == 0)
            slotInfo.itemGuardado.stats.vidaLevel = 1;

    }

    public void SetValueOfMaxLevel()
    {
        {
            switch (slotInfo.itemGuardado.rareza)
            {
                case (1):
                    slotInfo.itemGuardado.nivelMax = 40;
                    break;
                case (2):
                    slotInfo.itemGuardado.nivelMax = 60;
                    break;
                case (3):
                    slotInfo.itemGuardado.nivelMax = 80;
                    break;
                case (4):
                    slotInfo.itemGuardado.nivelMax = 100;
                    break;
                case (5):
                    slotInfo.itemGuardado.nivelMax = 120;
                    break;
            }
        }
    }

    public void SetValueOfDineroAlVender()
    {

        slotInfo.itemGuardado.dineroAlVender = slotInfo.itemGuardado.rareza * 100;

    }

    public void SetValueOfLevel()
    {

        if (slotInfo.itemGuardado.expAcumulada <= 2000 && slotInfo.itemGuardado.expAcumulada >= 0)
            slotInfo.itemGuardado.nivel = slotInfo.itemGuardado.expAcumulada / 50; //50== exp por nivel

        else if (slotInfo.itemGuardado.expAcumulada <= 5000 && slotInfo.itemGuardado.expAcumulada >= 2000)
            slotInfo.itemGuardado.nivel = 40 + ((slotInfo.itemGuardado.expAcumulada - 2000) / 150);//150== exp por nivel

        else if (slotInfo.itemGuardado.expAcumulada <= 9000 && slotInfo.itemGuardado.expAcumulada >= 5000)
            slotInfo.itemGuardado.nivel = 60 + ((slotInfo.itemGuardado.expAcumulada - 5000) / 200); //200== exp por nivel

        else if (slotInfo.itemGuardado.expAcumulada <= 14000 && slotInfo.itemGuardado.expAcumulada >= 9000)
            slotInfo.itemGuardado.nivel = 80 + ((slotInfo.itemGuardado.expAcumulada - 9000) / 250); //250== exp por nivel

        else if (slotInfo.itemGuardado.expAcumulada <= 20000 && slotInfo.itemGuardado.expAcumulada >= 14000)
            slotInfo.itemGuardado.nivel = 100 + ((slotInfo.itemGuardado.expAcumulada - 14000) / 300); //300== exp por nivel

        if (slotInfo.nivelMax)
            slotInfo.itemGuardado.nivel = slotInfo.itemGuardado.nivelMax;
    }

    public void SetValueOfExpProporcionada()
    {
        slotInfo.itemGuardado.expProporcionada = (slotInfo.itemGuardado.rareza * 500) + (slotInfo.itemGuardado.expAcumulada / 5);
    }

    public void ComprobarSiEsNivelMax()
    {

        switch (slotInfo.itemGuardado.rareza)
        {
            case (1):
                slotInfo.nivelMax = (slotInfo.itemGuardado.expAcumulada >= 2000);
                break;
            case (2):
                slotInfo.nivelMax = (slotInfo.itemGuardado.expAcumulada >= 5000);
                break;
            case (3):
                slotInfo.nivelMax = (slotInfo.itemGuardado.expAcumulada >= 9000);
                break;
            case (4):
                slotInfo.nivelMax = (slotInfo.itemGuardado.expAcumulada >= 14000);
                break;
            case (5):
                slotInfo.nivelMax = (slotInfo.itemGuardado.expAcumulada >= 20000);
                break;
              
        }

    }

    public void SetValueOfStats()
    {
        slotInfo.itemGuardado.stats.damage = Mathf.RoundToInt(slotInfo.itemGuardado.stats.damageBase + slotInfo.itemGuardado.stats.damageLevel * slotInfo.itemGuardado.nivel);
        slotInfo.itemGuardado.stats.curacion = Mathf.RoundToInt(slotInfo.itemGuardado.stats.curacionBase + slotInfo.itemGuardado.stats.curacionLevel * slotInfo.itemGuardado.nivel);
        slotInfo.itemGuardado.stats.vida = Mathf.RoundToInt(slotInfo.itemGuardado.stats.vidaBase + slotInfo.itemGuardado.stats.vidaLevel * slotInfo.itemGuardado.nivel);
    }

    //************************************************************
}


[System.Serializable]
    public class SlotInfo
    {

        public int identificador;
        public bool isEmpty;

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
            seleccionadoParaMejorarse = false;

            isEmpty = true;

            cantidad = 0;
            identificadorItem = -1;
            equipado = false;
            itemGuardado = new Item();
            itemGuardado.rareza = 1;

        }




}


