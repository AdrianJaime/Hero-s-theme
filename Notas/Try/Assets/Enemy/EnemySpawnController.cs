using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnController : MonoBehaviour {

    public BarraVida vidaPlayer;      
    [SerializeField]
    public EnemyCode enemyCode;
    public GameObject enemyPrefab;     // The enemy prefab to be spawned.
    public BaseDeDatosEnemigos baseDeDatosEnemigos;
    public Transform panelEnemy;
    public int primerIdentificadorEnemigo;

    public Enemy actualEnemy;

    public List<EnemyInfo> enemyInfoList;

    void Start()
    {
        primerIdentificadorEnemigo = 0;
        SetFirtsEnemy();
    }
    void Update()
    {


        //comprobar que el enemigo del start sigue vivo, y si no spawnear el siguiente en la lista.
        if (actualEnemy.stats.vidaMax <= 0)
        {

            SpawnEnemy();
    
        }
        
    }
    
    public void SetFirtsEnemy()
    {

        GameObject enemy = Instantiate<GameObject>(enemyPrefab, panelEnemy);
        enemyCode = enemy.GetComponent<EnemyCode>();
        enemyCode.createEnemy(primerIdentificadorEnemigo);
        enemyCode.baseDeDatosEnemigos = baseDeDatosEnemigos;
        EnemyInfo newEnemyInfo = enemyCode.enemyInfo;
        enemyInfoList.Add(newEnemyInfo);

        actualEnemy.stats.vidaMax = enemyCode.enemyInfo.vida;
        actualEnemy.stats.damage = enemyCode.enemyInfo.damage;

        enemyCode.ActualizarInterfazEnemy();
     
    }

    public void SpawnEnemy()
    {
        
        primerIdentificadorEnemigo++;
        enemyCode = null;

        if (baseDeDatosEnemigos.FindEnemy(primerIdentificadorEnemigo) != null) {
            GameObject enemy = Instantiate<GameObject>(enemyPrefab, panelEnemy);
            enemyCode = enemy.GetComponent<EnemyCode>();
            enemyCode.createEnemy(primerIdentificadorEnemigo);
            enemyCode.baseDeDatosEnemigos = baseDeDatosEnemigos;
            EnemyInfo newEnemyInfo = enemyCode.enemyInfo;
            enemyInfoList.Add(newEnemyInfo);

            actualEnemy.stats.vidaMax = enemyCode.enemyInfo.vida;
            actualEnemy.stats.damage = enemyCode.enemyInfo.damage;

            enemyCode.ActualizarInterfazEnemy(); 
        }
        
    }

    public void enemyAtack()
    {
        vidaPlayer.Health -= actualEnemy.stats.damage;
        //opcional curarse al atacar.

        
        //actualEnemy.stats.vidaMax
    }




}

