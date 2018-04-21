using UnityEngine;
using System.Collections;

public class play : MonoBehaviour
{
    bool played;
    public GameObject Redobject;
    public GameObject Blueobject;
    public GameObject Greenobject;
    public GameObject Yellowobject;


    public IEnumerator Yellow(float tme)
    {
        yield return new WaitForSeconds(tme);
        Instantiate(Yellowobject, new Vector2(2, 1), Quaternion.Euler(0, 0, 0));

    }
    public IEnumerator Red(float tme)
    {
        yield return new WaitForSeconds(tme);
        Instantiate(Redobject, new Vector2(-2, 1), Quaternion.Euler(0, 0, 0));
    }
    public IEnumerator Blue(float tme)
    {
        yield return new WaitForSeconds(tme);
        Instantiate(Blueobject, new Vector2(-0.7f, 1), Quaternion.Euler(0, 0, 0));
    }
    public IEnumerator Green(float tme)
    {
        yield return new WaitForSeconds(tme);
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
        if (!played)
        {
            StartCoroutine(Yellow(4.474f));
            StartCoroutine(Yellow(4.619f));
            StartCoroutine(Yellow(4.915f));
            played = true;
        }
    }
};
