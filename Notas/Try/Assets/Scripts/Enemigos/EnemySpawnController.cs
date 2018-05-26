using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnController : MonoBehaviour {

    public BarraVidaEnemigo vidaEnemigo;
    public BarraVida vidaPlayer;    
    
    [SerializeField]
    public EnemyCode enemyCode;
    public GameObject enemyPrefab;     // The enemy prefab to be spawned.
    public BaseDeDatosEnemigos baseDeDatosEnemigos;
    public Transform panelEnemy;
    public int primerIdentificadorEnemigo,contadorDeDerrotas;

    public Enemy actualEnemy;

    public List<EnemyInfo> enemyInfoList;

    void Start()
    {
        contadorDeDerrotas = 0;
        primerIdentificadorEnemigo = 0;
        SetFirtsEnemy();
        vidaEnemigo.HealthMax = actualEnemy.stats.vidaMax;

    }
    void Update()
    {

        DestroyEnemyAndSpawn();
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

    public void DestroyEnemyAndSpawn()
    {
        if (actualEnemy.stats.vidaMax <= 0)
        {
            contadorDeDerrotas++;
            actualEnemy=new Enemy();
            SpawnEnemy();
            vidaEnemigo.HealthMax = actualEnemy.stats.vidaMax;
        }
    }





}

