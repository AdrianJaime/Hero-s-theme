using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarraVida : MonoBehaviour {
    public EnemySpawnController enemySpawnController;
    public PlayerStats playerStats;
	public Scrollbar HealthBar;

    float HealthMax;
    public float vidaTotalPlayer;
    public float vidaCurada;
    private void Start()
    {
     playerStats.ReadString();
     SetValueOfStats();
     HealthMax = vidaTotalPlayer;
    }


    public void Damage()
	{
        vidaTotalPlayer -= enemySpawnController.actualEnemy.stats.damage ;
		HealthBar.size = vidaTotalPlayer / HealthMax;
	}
    public void Curar()
    {
        vidaTotalPlayer += vidaCurada;
        if (vidaTotalPlayer >= HealthMax)
            vidaTotalPlayer = HealthMax;
        HealthBar.size = vidaTotalPlayer / HealthMax;
    }

    public bool NoSalud()
    {
        if (vidaTotalPlayer <= 0)
            return true;
        else
            return false;
    }

    void SetValueOfStats()
    {
        vidaCurada = playerStats.curacion;
        vidaTotalPlayer = playerStats.totalVida;

    }
}
