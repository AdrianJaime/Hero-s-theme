using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameRead : MonoBehaviour {

    public Text countText;
    string line;
    // Use this for initialization
    void Start () {
        SetCountText();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetCountText()
    {
        System.IO.StreamReader file = new System.IO.StreamReader(@".\Assets\TXT\Player_info\PlayerName.txt");
        line = file.ReadLine();
        countText.text = line;
    }
}
