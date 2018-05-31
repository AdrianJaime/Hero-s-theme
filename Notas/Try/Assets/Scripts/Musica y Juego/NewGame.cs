using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewGame : MonoBehaviour
{


    public void CambioScena(string Activador)
    {
        System.IO.StreamReader file = new System.IO.StreamReader(@".\Assets\TXT\Player_Info\PlayerName.txt");
        if (file.ReadLine() == null)
            SceneManager.LoadScene(Activador);
   
    }
}
