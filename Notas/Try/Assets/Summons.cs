using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summons : MonoBehaviour {

    public Inventory inventory;
    public Monedero monedero;

    public int costeDeSummon;

    public void Summon()
    {
        if (monedero.monedasNormales >= costeDeSummon)
        {
            monedero.EliminarMonedasNormales(costeDeSummon);
            int a = Random.Range(0, 100);
            if (a <= 90)
            {
                if (a <= 80)
                {
                    if (a <= 60)
                        inventory.AñadirItem(1);
                    else
                        inventory.AñadirItem(2);
                }
                else inventory.AñadirItem(3);
            }
            else
                inventory.AñadirItem(4);
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
