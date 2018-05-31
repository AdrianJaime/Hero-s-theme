using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//para poder ver los atributos
public class Item
{
    public Sprite imagenItem; //Imagen que representa al Item

    public int identificador; //DNI del arma;
    public int identificadorItemEvolucionado;//Si es -1 no tiene evo

    public string name;//Nombre
    public int rareza;//del 0 al 4;
    public int nivel;//Asignación del calculo hecho a partir de la experiencia acumulada
    public int nivelMax;
    public int expAcumulada; //Atributo que nos sirve para hacer el calculo de nivel
    public int dineroAlVender;
    public int expProporcionada;

    public Stats stats;
  
    public TipoItem tipoItem ;

    [System.Serializable]//para poder ver los atributos
    public struct Stats
    {
        public int maxDamage;
        public int maxCuracion;
        public int maxVida;

        public int damage;
        public int curacion;
        public int vida;

        public float damageLevel;
        public float curacionLevel;
        public float vidaLevel;

        public int damageBase;
        public int curacionBase;
        public int vidaBase;


        public void StatsAcero()
        {
            damage = 0;
            curacion = 0;
            vida = 0;

            damageLevel = 0;
            curacionLevel = 0;
            vidaLevel = 0;
        }
    }
    public void ItemDefault()
    {
        identificador = -1;
        identificadorItemEvolucionado = -1;
        name = "nada";
        rareza = 1;
        nivel = 0;
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