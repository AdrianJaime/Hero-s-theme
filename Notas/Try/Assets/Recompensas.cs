﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recompensas : MonoBehaviour {
    public BaseDeDatos baseDeDatos;
    public Inventory inventory;
    public Monedero monedero;

    public int nivelRecompensa;//{1,5}

    public GameObject panelItemRecibido;

    public Text dineroRecompensa, nombreItemRecompensa;
    public Image imagenItemRecompensa;

    private void Start()
    {
        panelItemRecibido.SetActive(false);
        SelectTypeOfReward();
    }

    public void SelectTypeOfReward()
    {
        int dineroGanado=0;
        int probabilidadDeItem = Random.Range(0,2);

        switch (nivelRecompensa)
        {
            case 1:
                dineroGanado = 50 + Random.Range(0, 101);
                monedero.monedasNormales += dineroGanado;
                break;
            case 2:
                dineroGanado = 100+ Random.Range(0, 201);
                monedero.monedasNormales += dineroGanado;
                break;
            case 3:
                dineroGanado = 150 + Random.Range(0, 301);
                monedero.monedasNormales += dineroGanado;

                break;
            case 4:
                dineroGanado = 200 + Random.Range(0, 401);
                monedero.monedasNormales += dineroGanado;
                break;
            case 5:
                dineroGanado = 250 + Random.Range(0, 501);
                monedero.monedasNormales += dineroGanado;                
                break;
            default:
                break;

        }
        dineroRecompensa.text = dineroGanado.ToString();
        if (probabilidadDeItem == 0&&nivelRecompensa<6&&nivelRecompensa>0)
            AñadirItem(nivelRecompensa);
    }

    public void AñadirItem(int _nivelRecompensa)
    {
        int identificadorItem = -1;
        do { identificadorItem = Random.Range(1, 4); }
        while (baseDeDatos.FindItem(identificadorItem).rareza==_nivelRecompensa);
        ActivarPanel(true, identificadorItem);
        inventory.AñadirItem(4);

    }

    public void ActivarPanel(bool _value, int _identificadorItem)
    {
            nombreItemRecompensa.text = baseDeDatos.FindItem(_identificadorItem).name;
            imagenItemRecompensa.sprite = baseDeDatos.FindItem(_identificadorItem).imagenItem;
            panelItemRecibido.SetActive(_value);
    }

    public void DesactivarPanel()
    {
        panelItemRecibido.SetActive( false);
    }
}
