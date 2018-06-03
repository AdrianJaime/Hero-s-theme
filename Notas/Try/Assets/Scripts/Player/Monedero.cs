using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedero : MonoBehaviour
{

    public int monedasNormales;
    public int monedasEspeciales;

    public string saveDataMonedero;
    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("monedero"))
        {
            CargarMonedero();
        }
        else
        {
            monedasNormales = 0;
            monedasEspeciales = 0;
            GuardarMonedero();
        }
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey("monedero"))
        {
            CargarMonedero();
        }
    }

    public void AñadirMonedasNormales(int _Value)
    {
        monedasNormales += _Value;
        GuardarMonedero();
    }

    public void EliminarMonedasNormales(int _Value)
    {
        monedasNormales -= _Value;
        GuardarMonedero();
    }

    public void AñadirMonedasEspeciales(int _Value)
    {
        monedasEspeciales += _Value;
        GuardarMonedero();
    }

    public void EliminarMonedasEspeciales(int _Value)
    {
        monedasEspeciales -= _Value;
        GuardarMonedero();

    }



    private class MonederoGuardado
    {
        public int monedasNormalesGuardadas;
        public int monedasEspecialesGuardadas;
    }

    public void GuardarMonedero()
    {
        MonederoGuardado monederoGuardado = new MonederoGuardado();
        monederoGuardado.monedasNormalesGuardadas = monedasNormales;
        monederoGuardado.monedasEspecialesGuardadas = monedasEspeciales;
        saveDataMonedero = JsonUtility.ToJson(monederoGuardado);
        PlayerPrefs.SetString("monedero", saveDataMonedero);
    }
    private void CargarMonedero()
    {
        saveDataMonedero = PlayerPrefs.GetString("monedero");
        MonederoGuardado monederoGuardado = JsonUtility.FromJson<MonederoGuardado>(saveDataMonedero);
        monedasNormales = monederoGuardado.monedasNormalesGuardadas;
        monedasEspeciales = monederoGuardado.monedasEspecialesGuardadas;
    }
}
