using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class PlayerStats : MonoBehaviour {

    public EnemySpawnController enemySpawnController;

    public int totalDamage = 0;
    public int totalVida = 0;
    public int curacion = 0;


    private void Update()
    {
        ReadString();
    }



    [MenuItem("Tools/Read file")]
    public void ReadString()
    {
        string path = @".\Assets\TXT\Player_info\PlayerStats.txt";
        string[] stats=new string[3];
        string line;
        int counter=0;
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        while ((line = reader.ReadLine()) != null)
        {
            stats [counter]=  line;
            counter++;
        }
        totalDamage = int.Parse(stats[0]);
        totalVida = int.Parse(stats[1]);
        curacion = int.Parse(stats[2]);

        reader.Close();
    }



    public void Atack()
    {
        enemySpawnController.actualEnemy.stats.vidaMax -= totalDamage;
    }
}
