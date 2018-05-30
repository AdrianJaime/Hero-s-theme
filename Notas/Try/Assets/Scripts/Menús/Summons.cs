using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summons : MonoBehaviour {

    public Text dineroMonedero;
    public Text dineroBanner;
    public BaseDeDatos items;
    public Inventory inventory;
    public Monedero monedero;

    public int costeDeSummon;

    private void Start()
    {
        dineroBanner.text = costeDeSummon.ToString()+ " €";
        dineroMonedero.text = monedero.monedasNormales.ToString() + " €";

    }
    public void Summon()
    {
        if (inventory.EspaciosVacios() >= 1)
        {
            if (monedero.monedasNormales >= costeDeSummon)
            {
                int a = Random.Range(0, 100);
                monedero.EliminarMonedasNormales(costeDeSummon);
                dineroMonedero.text = monedero.monedasNormales.ToString() + " €";
                
                int rarity;
                if (a <= 90)
                {
                    if (a <= 80)
                    {
                        if (a <= 60)
                            rarity = 1;
                        else
                            rarity = 2;
                    }
                    else rarity = 3;
                }
                else
                    rarity = 4;
                a = Random.Range(1, 4);
                while (items.FindItem(a).rareza != rarity)
                    a = Random.Range(1, 4);
                inventory.AñadirItem(a);
            }
           
        }
    }

    public void SummonXcapacity(int _capacity)
    {
        if (inventory.EspaciosVacios() >= _capacity&&monedero.monedasNormales>=costeDeSummon*_capacity)
        {
            for (int i = 0; i < _capacity; i++)
            {
                Summon();
            }
        }
    }
}
