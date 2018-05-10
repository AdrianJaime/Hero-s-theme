using UnityEngine;
using System.Collections;

public class play : MonoBehaviour
{
    //bool played;
    System.IO.StreamReader file = new System.IO.StreamReader(@".\Assets\TXT\BS&T.txt");
    string line;
    public GameObject Redobject;
    public GameObject Blueobject;
    public GameObject Greenobject;
    public GameObject Yellowobject;


    public IEnumerator Yellow(float tme)
    {
        yield return new WaitForSeconds(tme - 0.56f);
        Instantiate(Yellowobject, new Vector2(2, 1), Quaternion.Euler(0, 0, 0));

    }
    public IEnumerator Red(float tme)
    {
        yield return new WaitForSeconds(tme - 0.56f);
        Instantiate(Redobject, new Vector2(-2, 1), Quaternion.Euler(0, 0, 0));
    }
    public IEnumerator Blue(float tme)
    {
        yield return new WaitForSeconds(tme - 0.56f);
        Instantiate(Blueobject, new Vector2(-0.7f, 1), Quaternion.Euler(0, 0, 0));
    }
    public IEnumerator Green(float tme)
    {
        yield return new WaitForSeconds(tme - 0.56f);
        Instantiate(Greenobject, new Vector2(0.7f, 1), Quaternion.Euler(0, 0, 0));
    }


void Start()
    {
        //SongStart

    }
void Update()
    {
        songStart();
        //Na Pi ttam nunmul
    }
    void songStart()
    {
        while ((line = file.ReadLine()) != null)
        {
            string[] words = line.Split(';');
            switch (words[0])
            {
                case "1":
                    StartCoroutine(Yellow(float.Parse(words[1])));
                    break;
                case "2":
                    StartCoroutine(Red(float.Parse(words[1])));
                    break;
                case "3":
                    StartCoroutine(Blue(float.Parse(words[1])));
                    break;
                case "4":
                    StartCoroutine(Green(float.Parse(words[1])));
                    break;
            }
        }
    }
       
        };

