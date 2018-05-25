using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recompensas : MonoBehaviour {
    public Monedero monedero;
    public int nivelRecompensa;
    
    public void SelectTypeOfReward()
    {
        switch (nivelRecompensa)
        {
            case 0:
                monedero.monedasNormales += Random.Range(0,101) ;
                break;
            case 1:
                monedero.monedasNormales += Random.Range(0, 201);
                break;
            case 2:
                monedero.monedasNormales += Random.Range(0, 301);
                break;
            case 3:
                monedero.monedasNormales += Random.Range(0, 401);
                break;
            case 4:
                monedero.monedasNormales += Random.Range(0, 501);
                break;
        }
    }

}
