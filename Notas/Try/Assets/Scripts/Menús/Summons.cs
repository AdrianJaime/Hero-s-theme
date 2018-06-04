using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summons : MonoBehaviour {


    public GameObject animacionSummon;

    public ParticleSystem particulasColor;

    public Text dineroMonedero;
    public Text dineroBanner;
    public BaseDeDatos items;
    public Inventory inventory;
    public Monedero monedero;

    public float tiempoAnimación=5;

    public Transform lugarAnimación;

    public GameObject panelStats;
    public PanelStats playerStatsS;

    public int costeDeSummon;

    private void Start()
    {
        
        dineroBanner.text = "Coste del SUMMON "+costeDeSummon.ToString()+ " €";
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
                        {
                            rarity = 1;
                            particulasColor.startColor = new Color(255, 0, 0);
                        }

                        else
                        {
                            rarity = 2;
                            particulasColor.startColor = new Color(0, 0, 255);
                        }
                    }
                    else
                    {
                        rarity = 3;
                        particulasColor.startColor = new Color(0, 255, 0);
                        }
                }
                else
                {
                    rarity = 4;
                    particulasColor.startColor = new Color(0, 0, 0);
                }
                a = Random.Range(1, 32);
                while (items.FindItem(a).rareza != rarity)
                    a = Random.Range(1, 32);

                SlotInfo al = inventory.SlotAccesible(a);
                inventory.AñadirItem(a);

                //***************************************************   Animación Del summon
                GameObject clone = Instantiate<GameObject>(animacionSummon, lugarAnimación.position, new Quaternion());
                Destroy(clone, tiempoAnimación);
                //***************************************************
                
                PanelStats aux = panelStats.GetComponent<PanelStats>();
                StartCoroutine(Wait());
                Wait();
                // esta acción puede que se haga a la par que el inssert del item en el slot y por eso a veces accede a la información antes de que esta contenga algo. de ahi el 0 en stats;
                aux.atk.text = al.itemGuardado.stats.damage.ToString();
                aux.vida.text = al.itemGuardado.stats.vida.ToString();
                aux.curacion.text = al.itemGuardado.stats.curacion.ToString();

                aux.nivel.text = al.itemGuardado.nivel.ToString();
                aux.rareza.text = al.itemGuardado.rareza.ToString();

                aux.nombreItem.text = al.itemGuardado.name.ToString();

                aux.imagenITEM.sprite = al.itemGuardado.imagenItem;

                aux.activo = true;


            }
           
        }
    }




    IEnumerator Wait()
    {


    yield return new WaitForSeconds(tiempoAnimación+0.1f);
    panelStats.SetActive(true);

    }
}
