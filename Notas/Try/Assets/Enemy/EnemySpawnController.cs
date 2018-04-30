using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnController : MonoBehaviour {

    //public BarraVida vida;       lo dejo comentado pero despues se tiene que poner que pare cuando la vida del juaador sea =<0;
    public EnemyCode actualEnemy;
    public GameObject enemyPrefab;     // The enemy prefab to be spawned.
    public BaseDeDatosEnemigos baseDeDatosEnemigos;
    public Transform panelEnemy;
    public int primerIdentificadorEnemigo=0;
    

    public List<EnemyInfo> enemyInfoList;

    void Start()
    {
        SetFirtsEnemy();
    }
    void Update()
    {


        //comprobar que el enemigo del start sigue vivo, y si no spawnear el siguiente en la lista.
        if (actualEnemy.enemyInfo.vida <= 0)
        {

            SpawnEnemy();
    
        }
        
    }
    
    public void SetFirtsEnemy()
    {

        GameObject enemy = Instantiate<GameObject>(enemyPrefab, panelEnemy);
        actualEnemy = enemy.GetComponent<EnemyCode>();
        actualEnemy.createEnemy(primerIdentificadorEnemigo);
        actualEnemy.baseDeDatosEnemigos = baseDeDatosEnemigos;
        EnemyInfo newEnemyInfo = actualEnemy.enemyInfo;
        enemyInfoList.Add(newEnemyInfo);

        actualEnemy.ActualizarInterfazEnemy();
     
    }

    public void SpawnEnemy()
    {
        
        primerIdentificadorEnemigo++;
        actualEnemy = null;

        if (baseDeDatosEnemigos.FindEnemy(primerIdentificadorEnemigo) != null) {
            GameObject enemy = Instantiate<GameObject>(enemyPrefab, panelEnemy);
            actualEnemy = enemy.GetComponent<EnemyCode>();
            actualEnemy.createEnemy(primerIdentificadorEnemigo);
            actualEnemy.baseDeDatosEnemigos = baseDeDatosEnemigos;
            EnemyInfo newEnemyInfo = actualEnemy.enemyInfo;
            enemyInfoList.Add(newEnemyInfo);

            actualEnemy.ActualizarInterfazEnemy(); 
        }
        
    }





}

