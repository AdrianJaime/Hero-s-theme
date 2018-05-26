using System.Collections;
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

    private void Start()
    {
        SelectTypeOfReward();
    }

    public void SelectTypeOfReward()
    {
        int dineroGanado=0;
        int probabilidadDeItem = Random.Range(0,20);

        switch (nivelRecompensa)
        {
            case 1:
                dineroGanado = Random.Range(0, 101);
                monedero.monedasNormales += dineroGanado;
                break;
            case 2:
                dineroGanado = Random.Range(0, 201);
                monedero.monedasNormales += dineroGanado;
                break;
            case 3:
                dineroGanado = Random.Range(0, 301);
                monedero.monedasNormales += dineroGanado;

                break;
            case 4:
                dineroGanado = Random.Range(0, 401);
                monedero.monedasNormales += dineroGanado;
                break;
            case 5:
                dineroGanado = Random.Range(0, 501);
                monedero.monedasNormales += dineroGanado;                
                break;
            default:
                break;

        }
        if (probabilidadDeItem == 0&&nivelRecompensa<6&&nivelRecompensa>0)
            AñadirItem(nivelRecompensa);
    }

    public void AñadirItem(int _nivelRecompensa)
    {
        int identificadorItem = -1;
        do { identificadorItem = Random.Range(0, 5); } while (baseDeDatos.FindItem(identificadorItem).rareza!=_nivelRecompensa);
        inventory.AñadirItem(identificadorItem);

    }

    public void ActivarPanel(bool _value)
    {
        if (_value)
            panelItemRecibido.SetActive(_value);

    }
}
