using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MejoraArmas : MonoBehaviour {
    public Inventory inventory;
    public Monedero monedero;

    public Item itemParaMejorar;

    public Text atk, newAtk, curacion, newCuracion, vida, newVida;

    public bool huecoItemMejorarLibre=true;

    public List<SlotInfo> listaItemsParaFusionar;

    private void Start()
    {
        listaItemsParaFusionar = new List<SlotInfo>();
    }
    public SlotInfo EncontarItemEnListaDeFusion(int _identificador)
    {
        foreach (SlotInfo slotInfo in listaItemsParaFusionar)
        {
            if (slotInfo.identificador == _identificador)
                return slotInfo;

        }
        return null;
    }

    public void ActualizarValoresNuevos()
    {

    }

    public void SetValoresNuevos()
    {

    }

    public void RemoveConfiguracion()
    {
        listaItemsParaFusionar = new List<SlotInfo>();
    }
} 

