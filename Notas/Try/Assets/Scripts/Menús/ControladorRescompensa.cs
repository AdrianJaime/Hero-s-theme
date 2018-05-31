using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class ControladorRescompensa : MonoBehaviour {

    public int nivelRecompensa;//{1,5}


    public void Start()
    {
        WriteString();
    }

    [MenuItem("Tools/Write file")]
    public void WriteString()
    {
        string path = @".\Assets\TXT\Player_info\ConfiguracionControladorRecompensas.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(nivelRecompensa);

        writer.Close();
    }
}
