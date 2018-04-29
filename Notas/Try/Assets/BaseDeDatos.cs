using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//para poder ver los atributos
public class Item
{
    public Sprite imagenItem; //Imagen que representa al Item

    public int identificador; //DNI del arma;
    public string name;//Nombre
    public int rareza;//del 0 al 4;
    public int nivel;//Asignación del calculo hecho a partir de la experiencia acumulada
    public int rango;//Nivel de rngo == al nivel de fusión de armas (creo, o de veces evolucionada).
    public int expAcumulada; //Atributo que nos sirve para hacer el calculo de nivel

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
