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
    public int valueAtakNew,valueCuracionNew,valueVidaNew, experienciaExtra, costeMejora, expAntesDeMejorar;

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
        //Suma el valor que de los newStats y

        foreach(SlotInfo slotInfo in listaItemsParaFusionar)
        {
            SlotInfoItemAMejorar.itemGuardado.expAcumulada += slotInfo.itemGuardado.expProporcionada;
            Slot auxSlot = inventory.EncontrarSlot(slotInfo.identificador);
            listaItemsParaFusionar.Remove(slotInfo);
            auxSlot.EliminarSlot_VenderSlot();
        }
        Slot _slot = inventory.EncontrarSlot(SlotInfoItemAMejorar.identificador);
        _slot.slotInfo = SlotInfoItemAMejorar;
    }

    public void ExperienciaExtra()
    {
        experienciaExtra = 0;
        foreach (SlotInfo slotInfo in listaItemsParaFusionar)
        {
            experienciaExtra += slotInfo.itemGuardado.expProporcionada ;
        }
    }

    public void NuevosStats()
    {


    }
   /* public SlotInfo CopiaDeSlotInfo (SlotInfo anotherSlotInfo)
    {
        SlotInfo aux = new SlotInfo();

        aux.identificador = anotherSlotInfo.identificador;
        aux.isEmpty = anotherSlotInfo.isEmpty;
        aux.identificadorItem = anotherSlotInfo.identificadorItem;
        aux.cantidad = anotherSlotInfo.cantidad;
        aux.cantidadMax = anotherSlotInfo.cantidadMax;
        aux.nivelMax = anotherSlotInfo.nivelMax;
        aux.seleccionadoParaMejorarse = anotherSlotInfo.seleccionadoParaMejorarse;
        aux.seleccionadoParaMejorar = anotherSlotInfo.seleccionadoParaMejorar;
        aux.equipado = anotherSlotInfo.equipado;
        aux.itemGuardado.stats = anotherSlotInfo.itemGuardado.stats;
        

        return aux;
    }
    */

    public void RemoveConfiguracion()
    {
        listaItemsParaFusionar = new List<SlotInfo>();
    }
} 

