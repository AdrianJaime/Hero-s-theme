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
        //por cada slot guardado, coge el valor de cada stat y lo guarda. Esta acción se llama cada vez que se elimina o se guarda un valor en la lista de slots!
    }

    public void SetValoresNuevos()//botón de confirmar.
    {
        //Suma el valor que de los newStats y
        //busca todos los slots del inventario, con los identificadores guardados en la lista y los elimina.
    }

    public void RemoveConfiguracion()
    {
        listaItemsParaFusionar = new List<SlotInfo>();
    }
} 

