using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MejoraArmas : MonoBehaviour {

    public Inventory inventory;
    public Monedero monedero;

    public Slot SlotInfoItemAMejorar;


    public Image imagenItemAMejorar;
    public Text atk, newAtk, curacion, newCuracion, vida, newVida,costeAMejorar, dineroMonedero;
    public int /*valueAtakNew,valueCuracionNew,valueVidaNew,*/ experienciaExtra, costeMejora, expAntesDeMejorar, experienciaTotal, auxExp;

    public bool huecoItemMejorarLibre=true;

    public List<SlotInfo> listaItemsParaFusionar;


    public SlotInfo EncontarItemEnListaDeFusion(int _identificador)
    {
        foreach (SlotInfo slotInfo in listaItemsParaFusionar)
        {
            if (slotInfo.identificador == _identificador)
                return slotInfo;

        }
        return null;
    }

    private void Update()
    {
        ExperienciaTotal();
        AñadirExpAlItem();
        dineroMonedero.text = monedero.monedasNormales.ToString() + "€";


        CosteMejora();
        costeAMejorar.text = costeMejora.ToString();
    }

    public void CosteMejora()
    {
        costeMejora = 0;
        foreach (SlotInfo slotInfo in listaItemsParaFusionar)
        {
            costeMejora += SlotInfoItemAMejorar.slotInfo.itemGuardado.rareza * 50;
        }
    }

    public void ConfirmarSeleccion()//botón de confirmar.
    {
        if (monedero.monedasNormales >= costeMejora)
        {
            auxExp = experienciaTotal;
            foreach (SlotInfo slotInfo in listaItemsParaFusionar)
            {
                Slot auxSlot = inventory.EncontrarSlot(slotInfo.identificador);
                auxSlot.EliminarSlot_VenderSlot();
            }
            SlotInfoItemAMejorar.slotInfo.itemGuardado.expAcumulada = auxExp;
            expAntesDeMejorar = auxExp;

            atk.text = SlotInfoItemAMejorar.slotInfo.itemGuardado.stats.damage.ToString();
            curacion.text = SlotInfoItemAMejorar.slotInfo.itemGuardado.stats.curacion.ToString();
            vida.text = SlotInfoItemAMejorar.slotInfo.itemGuardado.stats.vida.ToString();

            monedero.EliminarMonedasNormales(costeMejora);

            RemoveConfiguracion();
            SlotInfoItemAMejorar.ActualizarInterfaz();
            ComprobarSiSeQuiereMeorarNivelMax();
        }
    }

    public void ExperienciaTotal()
    {
        experienciaExtra = 0;
        foreach (SlotInfo slotInfo in listaItemsParaFusionar)
        {
            experienciaExtra += slotInfo.itemGuardado.expProporcionada;
        }
        experienciaTotal = expAntesDeMejorar + experienciaExtra;
    }


    public void AñadirExpAlItem()
    {
        if (SlotInfoItemAMejorar != null)
        {
            if (experienciaTotal != 0)
                SlotInfoItemAMejorar.slotInfo.itemGuardado.expAcumulada = experienciaTotal;
            else if (!huecoItemMejorarLibre)
                SlotInfoItemAMejorar.slotInfo.itemGuardado.expAcumulada = expAntesDeMejorar;
            newAtk.text = SlotInfoItemAMejorar.slotInfo.itemGuardado.stats.damage.ToString();
            newVida.text = SlotInfoItemAMejorar.slotInfo.itemGuardado.stats.vida.ToString();
            newCuracion.text = SlotInfoItemAMejorar.slotInfo.itemGuardado.stats.curacion.ToString();
        }
        if(huecoItemMejorarLibre == true)
        {
            newAtk.text =0.ToString();
            newVida.text = 0.ToString();
            newCuracion.text = 0.ToString();
        }
    }

    public void RemoveConfiguracion()
    {
        foreach (SlotInfo slot in inventory.slotInfoList)
        {
            if (slot.seleccionadoParaMejorar)
            {
                //eliminar el item de la lista de items del mejoraArmas
                SlotInfo newslotInfo = slot;
                listaItemsParaFusionar.Remove(EncontarItemEnListaDeFusion(newslotInfo.identificador));
                slot.seleccionadoParaMejorar = false;
                inventory.EncontrarSlot(slot.identificador).GetComponent<Image>().color = new Color(255, 255, 255);
            }
            if (inventory.EncontrarSlot(slot.identificador).GetComponent<Image>().color == new Color(255, 0, 0))
                inventory.EncontrarSlot(slot.identificador).GetComponent<Image>().color = new Color(255, 255, 255);


        }
        listaItemsParaFusionar = new List<SlotInfo>();
    }


    public void ComprobarSiSeQuiereMeorarNivelMax()
    {
        
        if (SlotInfoItemAMejorar.slotInfo.seleccionadoParaMejorarse && SlotInfoItemAMejorar.slotInfo.nivelMax)
        {
            atk.text = 0.ToString();
            curacion.text = 0.ToString();
            vida.text = 0.ToString();

            expAntesDeMejorar = 0;
            inventory.EncontrarSlot(SlotInfoItemAMejorar.slotInfo.identificador).GetComponent<Image>().color = new Color(255, 255, 255);
            imagenItemAMejorar.sprite = null;
            huecoItemMejorarLibre = true;
            SlotInfoItemAMejorar.slotInfo.seleccionadoParaMejorarse = false;
        }
    }



} 

