using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reguladorDePuntuación : MonoBehaviour {

    public Transform panelStars;
    public GameObject yellowStarPref, normalStarPref;
    public Recompensas recompensas;

    private void Start()
    {
        SetPuntuationStars();
    }

    public void SetPuntuationStars()
    {
        int i;
        for ( i = 0; i < recompensas.enemyDefeated; i++)
        {
            GameObject star = Instantiate<GameObject>(yellowStarPref, panelStars);
        }
        for (int y = 0; y < 3 - i; y++)
        {
            GameObject star = Instantiate<GameObject>(normalStarPref, panelStars);

        }

    }



}
