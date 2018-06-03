using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RankScript : MonoBehaviour
{

    public Text countText;
    string line;

    void Start()
    {
        SetCountText();
    }

    void FixedUpdate()
    {
        
    }
    void SetCountText()
    {
        System.IO.StreamReader file = new System.IO.StreamReader(@".\Assets\TXT\Player_info\Rank.txt");
        line = file.ReadLine();
        countText.text = "Rank:\n" + line;
    }

}