using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DeleteDATA : MonoBehaviour {


	public void BorrarDatos() {

        PlayerPrefs.DeleteAll();
        WriteString();
        WriteString2();
        WriteString3();


    }

    public void WriteString()
    {
        string path = @".\Assets\TXT\Player_info\ConfiguracionControladorRecompensas.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(0);
        writer.WriteLine(0);

        writer.Close();
    }
    public void WriteString2()
    {
        string path = @".\Assets\TXT\Player_info\PlayerStats.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(0);
        writer.WriteLine(0);
        writer.WriteLine(0);


        writer.Close();
    }
    public void WriteString3()
    {
        string path = @".\Assets\TXT\Player_info\Rank.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine("0");


        writer.Close();
    }

}
