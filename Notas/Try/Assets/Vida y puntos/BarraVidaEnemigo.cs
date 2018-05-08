using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarraVidaEnemigo : MonoBehaviour
{
    public EnemySpawnController enemySpawnController;

    public Scrollbar HealthBar;
    float HealthMax;
    public float Health ;
    private void Update()
    {
        Health = enemySpawnController.actualEnemy.stats.vidaMax;
        HealthMax = Health;
    }


    public void Damage()
    {
        Health -= enemySpawnController.actualEnemy.stats.damage; ;
        HealthBar.size = Health / HealthMax;
    }
    public void Curar(float value)
    {
        Health += value;
        if (Health >= HealthMax)
            Health = HealthMax;
        HealthBar.size = Health / HealthMax;
    }

    public bool NoSalud()
    {
        if (Health <= 0)
            return true;
        else
            return false;
    }
}
