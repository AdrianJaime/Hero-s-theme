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
    public int valueAtakNew,valueCuracionNew,valueVidaNew, experienciaExtra, costeMejora, expAntesDeMejorar, experienciaTotal;

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
        listaItemsParaFusionar = new List<SlotInfo>();
    }
} 

