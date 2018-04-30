using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]//para poder ver los atributos
public class EnemigoCode
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
    public List<EnemigoCode> enemys = new List<EnemigoCode>();

    public EnemigoCode FindEnemy (int _identificadorEnemigo)
    {
        foreach (EnemigoCode enemy in enemys)
        {
            if (enemy.identificador == _identificadorEnemigo)
                return enemy;

        }
        return null;
    }

}
