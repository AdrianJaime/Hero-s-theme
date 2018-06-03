using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class Name : MonoBehaviour {
    public InputField named;

      public void GetInput(string scene)
      {
          StreamWriter nameFile = new StreamWriter(@".\Assets\TXT\Player_Info\PlayerName.txt");
          nameFile.Write(named.text,false);
        nameFile.Close();
        SceneManager.LoadScene(scene);
      }

}

