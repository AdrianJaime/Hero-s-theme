using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvolucionMenu : MonoBehaviour {

    public Inventory inventory;
    public Monedero monedero;
    public BaseDeDatos baseDeDatos;//A confirmar si se usará la establecida o crearemos una nueva solo para las evoluciones.

    public Slot SlotInfoItemAEvolucionar;
    public Item Evolucion;

    public Image imagenItemAEvolucionar, imagenEvolucion;
    public Text atk, newAtk, curacion, newCuracion, vida, newVida, costeAMejorar, dineroMonedero;
    public int  costeMejora;


    private void Update()
    {
        ActualizarDatosEnSlots();    
    }

    public void ActualizarDatosEnSlots()
    {
        if (SlotInfoItemAEvolucionar != null)
        {
            atk.text = SlotInfoItemAEvolucionar.slotInfo.itemGuardado.stats.damage.ToString();
            curacion.text = SlotInfoItemAEvolucionar.slotInfo.itemGuardado.stats.curacion.ToString();
            vida.text = SlotInfoItemAEvolucionar.slotInfo.itemGuardado.stats.vida.ToString();

            newAtk.text = Evolucion.stats.damage.ToString();
            newCuracion.text = Evolucion.stats.curacion.ToString();
            newVida.text = Evolucion.stats.vida.ToString();
        }
    }

    public void EncontrarItemMejorado()
    {
        Evolucion = baseDeDatos.FindItem(SlotInfoItemAEvolucionar.slotInfo.itemGuardado.identificadorItemEvolucionado);

    }
}
