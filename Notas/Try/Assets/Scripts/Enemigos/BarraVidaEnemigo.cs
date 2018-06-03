using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarraVidaEnemigo : MonoBehaviour
{
    public EnemySpawnController enemySpawnController;

    public Scrollbar HealthBar;
    public float HealthMax;
    public float Health;

    private void Update()
    {
        Health = enemySpawnController.actualEnemy.stats.vidaMax;

        ActualizarBarraSalud();

    }

    public void Damage()
    {
        Health -= enemySpawnController.actualEnemy.stats.damage; ;
        ActualizarBarraSalud();

    }
    public void Curar(float value)
    {
        Health += value;
        if (Health >= HealthMax)
            Health = HealthMax;
        ActualizarBarraSalud();
    }

    public bool NoSaludEnemy()
    {
        if (Health <= 0)
            return true;
        else
            return false;
    }

    public void ActualizarBarraSalud() {
        HealthBar.size = Health / HealthMax;
    }
}
