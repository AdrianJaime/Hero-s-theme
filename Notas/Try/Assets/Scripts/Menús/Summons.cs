using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summons : MonoBehaviour {


    public GameObject animacionSummon;

    public Text dineroMonedero;
    public Text dineroBanner;
    public BaseDeDatos items;
    public Inventory inventory;
    public Monedero monedero;

    public float tiempoAnimación=5;
    public float nextAnimationTime=0;
    public Transform lugarAnimación;

    public GameObject panelStats;
    public PanelStats playerStatsS;

    public int costeDeSummon;

    private void Start()
    {
        
        dineroBanner.text = costeDeSummon.ToString()+ " €";
        dineroMonedero.text = monedero.monedasNormales.ToString() + " €";

    }
    public void Summon()
    {
        if (inventory.EspaciosVacios() >= 1 && !playerStatsS.activo)
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
                a = Random.Range(1, 17);
                while (items.FindItem(a).rareza != rarity)
                    a = Random.Range(1, 17);
                SlotInfo al = inventory.SlotAccesible(a);
                inventory.AñadirItem(a);

                //***************************************************   Animación Del summon
                while (Time.time - nextAnimationTime <= tiempoAnimación)
                {
                    nextAnimationTime = Time.time;
                }

                Instantiate<GameObject>(animacionSummon, lugarAnimación.position, new Quaternion());
                //***************************************************

                PanelStats aux = panelStats.GetComponent<PanelStats>();
                panelStats.SetActive(true);
                aux.activo = true;

                aux.atk.text = al.itemGuardado.stats.damage.ToString();
                aux.vida.text = al.itemGuardado.stats.vida.ToString();
                aux.curacion.text = al.itemGuardado.stats.curacion.ToString();

                aux.nombreItem.text = al.itemGuardado.name.ToString();

                aux.imagenITEM.sprite = al.itemGuardado.imagenItem;
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
