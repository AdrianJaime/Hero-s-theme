using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]//para poder ver los atributos
public class Enemy
{
    public Sprite image;
    public Stats stats;
    public int identificador;

    [System.Serializable]
    public struct Stats {
        public int vidaMax;
        public int damage;
    }


}

[CreateAssetMenu(menuName = "Inventory System/BaseDeDatosEnemy")]
public class BaseDeDatosEnemigos : ScriptableObject
{
    public List<Enemy> enemys = new List<Enemy>();

    public Enemy FindEnemy (int _identificadorEnemigo)
    {
        foreach (Enemy enemy in enemys)
        {
            if (enemy.identificador == _identificadorEnemigo)
                return enemy;

        }
        return null;
    }
    public int SizeBaseDeDatosEnemy()
    {
        int aux = 0;
        foreach (Enemy enemy in enemys)
        {
            aux++;

        }
        return aux;

    }

}
