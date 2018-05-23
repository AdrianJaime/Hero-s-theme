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
    public int  valorNewAtk ,valorNewCuracion, valorNewVida,costeMejora;

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
        CosteMejora();
        costeAMejorar.text = costeMejora.ToString();
        SaveNewStats();
    }

    public void CosteMejora()
    {
        costeMejora = 0;
        foreach (SlotInfo slotInfo in listaItemsParaFusionar)
        {
            costeMejora += SlotInfoItemAMejorar.itemGuardado.rareza * 50;
        }
    }

    public void ActualizarValoresNuevos() //por cada slot guardado, coge el valor de cada stat y lo guarda. Esta acción se llama cada vez que se elimina o se guarda un valor en la lista de slots!
    {
        ValoresNuevosACero();
        foreach(SlotInfo slotInfo in listaItemsParaFusionar)
        {
           // itemParaMejorar.expAcumulada+=
        }
    }

    public void ValoresNuevosACero()
    {
        valorNewAtk =valorNewCuracion= valorNewVida = 0;
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

     public void CalculoNuevoNivel()
    {

    }









public void SaveNewStats()
    {
        valorNewAtk = valorNewCuracion = valorNewVida = 0;
        foreach (SlotInfo slotInfo in listaItemsParaFusionar)
        {
            valorNewAtk += slotInfo.itemGuardado.stats.damage;
            valorNewCuracion += slotInfo.itemGuardado.stats.curacion;
            valorNewVida += slotInfo.itemGuardado.stats.vida;
        }
        newAtk.text = valorNewAtk.ToString();
        newCuracion.text = valorNewCuracion.ToString();
        newVida.text = valorNewVida.ToString();
    }


    public void RemoveConfiguracion()
    {
        listaItemsParaFusionar = new List<SlotInfo>();
    }
} 

