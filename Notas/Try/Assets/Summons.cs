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
            inventory.AñadirItem(Random.Range(0, 4));//4 es el numero maximo de items en la base de datos
        }
    }
}
