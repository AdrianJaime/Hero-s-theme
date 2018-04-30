using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCode : MonoBehaviour {

    public EnemyInfo enemyInfo;
    public BaseDeDatosEnemigos baseDeDatosEnemigos;
    public Image representacionEnemy;

    public void createEnemy(int _identificadoEnemy)
    {
        enemyInfo = new EnemyInfo();
        enemyInfo.identificadorEnemy = _identificadoEnemy;
        enemyInfo.spawned = true;
    }

    public void ActualizarInterfazEnemy()
    {
        if (enemyInfo.spawned)
        {
            representacionEnemy.enabled = true;
            representacionEnemy.sprite = baseDeDatosEnemigos.FindEnemy(enemyInfo.identificadorEnemy).image;

        }
        else
        {
            representacionEnemy.sprite = null;
            representacionEnemy.enabled = false;
        }

    }

}
[System.Serializable]
public class EnemyInfo
{
    public int identificadorEnemy;
    public bool spawned;

    public EnemyInfo()
    {
        identificadorEnemy = -1;
        spawned = false;
    }
}