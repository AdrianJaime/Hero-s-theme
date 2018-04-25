using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//para poder ver los atributos
public class Item
{
    public int identificador;
    public string name;
    public int rareza;//del 0 al 4;
    public int nivel;
    public int precioVenta;
    public int expProportcionada;//exp que da el arma al fusionarla
    public Stats stats;

    [System.Serializable]//para poder ver los atributos
    public struct Stats
    {
        public int damage;
        public int combo;
        public int vida;
    }
}
[CreateAssetMenu(menuName ="Inventory System/BaseDeDatos")]
public class BaseDeDatos : ScriptableObject {
    public List<Item> items = new List<Item>();

	public Item FindItem (int _identificador)
    {
        foreach(Item item in items)
        {
            if (item.identificador == _identificador)
                return item;

        }
        return null;
    }	
	
}
