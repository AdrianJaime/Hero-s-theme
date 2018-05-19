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
            monedero.monedasNormales = monedero.monedasNormales - costeDeSummon;
            int a = Random.Range(0, 100);
            if (a <= 90)
            {
                if (a <= 80)
                {
                    if (a <= 60)
                        inventory.AñadirItem(1);//4 es el numero maximo de items en la base de datos
                    else
                        inventory.AñadirItem(2);
                }
                else inventory.AñadirItem(3);
            }
            else
                inventory.AñadirItem(4);
        }
    }
}
