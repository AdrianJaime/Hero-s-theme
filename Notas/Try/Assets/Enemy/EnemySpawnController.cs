using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

    public BarraVida vida;       // Reference to the player's heatlh.
    public GameObject enemyPrefab;     // The enemy prefab to be spawned.
    public BaseDeDatosEnemigos baseDeDatosEnemigos;
    public EnemyCode enemyCode;
    public Transform panelEnemy;

    public List<EnemyInfo> enemyInfoList;

    void Start()
    {
        SetFirtsEnemy();
    }

    public void SetFirtsEnemy()
    {
        GameObject enemy = Instantiate<GameObject>(enemyPrefab, panelEnemy);
        EnemyCode newEnemy = enemy.GetComponent<EnemyCode>();
        newEnemy.createEnemy(0);
        newEnemy.baseDeDatosEnemigos = baseDeDatosEnemigos;
        EnemyInfo newEnemyInfo = newEnemy.enemyInfo;
        enemyInfoList.Add(newEnemyInfo);

        newEnemy.ActualizarInterfazEnemy();
    }
     void Update()
    {
        //comprobar que el enemigo del start sigue vivo, y si no spawnear el siguiente en la lista.
    }
    void Spawn()
    {
        if (vida.Health <= 0)
        {

            return;
        }
        if (enemy == null)
        {

        }
    }
    public bool checkEnemy()
    {
        if()
    }
}

