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
    public int dineroAlVender;
    public int expProporcionada;

    public Stats stats;
  
    public TipoItem tipoItem ;

    [System.Serializable]//para poder ver los atributos
    public struct Stats
    {
        public int damage;
        public int curacion;
        public int vida;

        public void StatsAcero()
        {
            damage = 0;
            curacion = 0;
            vida = 0;
        }
    }
    public void ItemDefault()
    {
        identificador = -1;
        name = "nada";
        rareza = 1;
        nivel = 0;
        rango = 0;
        expAcumulada = 0;
        dineroAlVender = 0;
        imagenItem = null;
        stats.StatsAcero();
    }
}

public enum TipoItem {Arma=0,Cabeza=1,Cuerpo=2,Piernas=3};

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
