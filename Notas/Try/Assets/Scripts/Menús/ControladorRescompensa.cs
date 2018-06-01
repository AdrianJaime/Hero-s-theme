using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;


public class ControladorRescompensa : MonoBehaviour {

    public AudioSource song;

    public int nivelRecompensa;//{1,5}
    public BaseDeDatosEnemigos enemyDataBase;
    public int numeroTotalEnemigos, contadorDeDerrotas;

    public void Awake()
    {
        contadorDeDerrotas = 0;
        numeroTotalEnemigos = enemyDataBase.SizeBaseDeDatosEnemy();
    }

    private void Update()
    {
        if (numeroTotalEnemigos <= 0 || !song.isPlaying) {

            WriteString();
            SceneManager.LoadScene("ScenaRecompensa");

        }
    }

    [MenuItem("Tools/Write file")]
    public void WriteString()
    {
        string path = @".\Assets\TXT\Player_info\ConfiguracionControladorRecompensas.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(nivelRecompensa);
        writer.WriteLine(contadorDeDerrotas);

        writer.Close();
    }
}
