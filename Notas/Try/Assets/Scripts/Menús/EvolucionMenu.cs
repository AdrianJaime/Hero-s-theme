using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvolucionMenu : MonoBehaviour {

    public Inventory inventory;
    public Monedero monedero;
    public BaseDeDatos baseDeDatos;//A confirmar si se usará la establecida o crearemos una nueva solo para las evoluciones.

    public Slot SlotItemAEvolucionar, Evolucion;

    public Sprite defaultImagen;
    public Image imagenItemAEvolucionar, imagenEvolucion;
    public Text atk, newAtk, curacion, newCuracion, vida, newVida, costeAMejorar, dineroMonedero;
    public int  costeMejora;


    private void Update()
    {
        ActualizarDatosEnSlots();    
    }

    public void ActualizarDatosEnSlots()
    {
        if (SlotItemAEvolucionar != null)
        {
            atk.text = SlotItemAEvolucionar.slotInfo.itemGuardado.stats.damage.ToString();
            curacion.text = SlotItemAEvolucionar.slotInfo.itemGuardado.stats.curacion.ToString();
            vida.text = SlotItemAEvolucionar.slotInfo.itemGuardado.stats.vida.ToString();
            imagenItemAEvolucionar.sprite = SlotItemAEvolucionar.slotInfo.itemGuardado.imagenItem;

            newAtk.text = Evolucion.slotInfo.itemGuardado.stats.damage.ToString();
            newCuracion.text = Evolucion.slotInfo.itemGuardado.stats.curacion.ToString();
            newVida.text = Evolucion.slotInfo.itemGuardado.stats.vida.ToString();
            imagenEvolucion.sprite = Evolucion.slotInfo.itemGuardado.imagenItem;

        }
        else
        {
            atk.text = 0.ToString();
            curacion.text = 0.ToString();
            vida.text = 0.ToString();
            imagenItemAEvolucionar.sprite = defaultImagen;

            newAtk.text = 0.ToString();
            newCuracion.text = 0.ToString();
            newVida.text = 0.ToString();
            imagenEvolucion.sprite = defaultImagen;
        }
    }

    public void EncontrarItemMejorado()
    {
        Item item = baseDeDatos.FindItem(SlotItemAEvolucionar.slotInfo.itemGuardado.identificadorItemEvolucionado);

        Evolucion.slotInfo.itemGuardado = item ;

    }

    public void ReiniciarEvolucion()
    {
        SlotItemAEvolucionar = new Slot();
        SlotItemAEvolucionar = null;
    }

    public void ConfirmarEvolucion()
    {
        inventory.EncontrarSlot(SlotItemAEvolucionar.slotInfo.identificador).slotInfo.itemGuardado = Evolucion.slotInfo.itemGuardado;
        inventory.EncontrarSlot(SlotItemAEvolucionar.slotInfo.identificador).ActualizarInterfaz();
        ReiniciarEvolucion();
    }
}
