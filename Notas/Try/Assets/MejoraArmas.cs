using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MejoraArmas : MonoBehaviour {

    public Inventory inventory;
    public Monedero monedero;

    public SlotInfo SlotInfoItemAMejorar;


    public Image imagenItemAMejorar;
    public Text atk, newAtk, curacion, newCuracion, vida, newVida,costeAMejorar;
    public int valueAtakNew,valueCuracionNew,valueVidaNew, experienciaExtra, costeMejora, expAntesDeMejorar, experienciaTotal, auxExp;

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
        ExperienciaExtra();
        NuevosStats();
        if(experienciaTotal!=0)
            AñadirExpAlItem();

        CosteMejora();
        costeAMejorar.text = costeMejora.ToString();
    }

    public void CosteMejora()
    {
        costeMejora = 0;
        foreach (SlotInfo slotInfo in listaItemsParaFusionar)
        {
            costeMejora += SlotInfoItemAMejorar.itemGuardado.rareza * 50;
        }
    }

    public void ConfirmarSeleccion()//botón de confirmar.
    {

        foreach (SlotInfo slotInfo in listaItemsParaFusionar)
        {
            Slot auxSlot = inventory.EncontrarSlot(slotInfo.identificador);
            auxSlot.EliminarSlot_VenderSlot();
        }

        RemoveConfiguracion();

    }

    public void ExperienciaExtra()
    {
        experienciaExtra = 0;
        foreach (SlotInfo slotInfo in listaItemsParaFusionar)
        {
            experienciaExtra += slotInfo.itemGuardado.expProporcionada;
        }
    }

    public void NuevosStats()
    {
         experienciaTotal = expAntesDeMejorar + experienciaExtra;
    }

    public void AñadirExpAlItem()
    {
        SlotInfoItemAMejorar.itemGuardado.expAcumulada = experienciaTotal;
        newAtk.text = SlotInfoItemAMejorar.itemGuardado.stats.damage.ToString();
        newVida.text = SlotInfoItemAMejorar.itemGuardado.stats.vida.ToString();
        newCuracion.text = SlotInfoItemAMejorar.itemGuardado.stats.curacion.ToString();
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
} 

