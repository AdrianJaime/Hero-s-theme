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
        yield return new WaitForSeconds(tme - 1.13f);
        Instantiate(Yellowobject, new Vector2(2, 1), Quaternion.Euler(0, 0, 0));

    }
    public IEnumerator Red(float tme)
    {
        yield return new WaitForSeconds(tme - 1.13f);
        Instantiate(Redobject, new Vector2(-2, 1), Quaternion.Euler(0, 0, 0));
    }
    public IEnumerator Blue(float tme)
    {
        yield return new WaitForSeconds(tme - 1.13f);
        Instantiate(Blueobject, new Vector2(-0.7f, 1), Quaternion.Euler(0, 0, 0));
    }
    public IEnumerator Green(float tme)
    {
        yield return new WaitForSeconds(tme - 1.13f);
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
            StartCoroutine(Yellow(4.42f));
            StartCoroutine(Red(4.59f));
            StartCoroutine(Blue(4.99f));
            StartCoroutine(Green(5.41f));
            StartCoroutine(Blue(5.66f));
            StartCoroutine(Blue(6.84f));
            StartCoroutine(Blue(7.07f));
            StartCoroutine(Blue(7.35f));
            StartCoroutine(Blue(7.49f));
            StartCoroutine(Blue(7.85f));
            StartCoroutine(Blue(8.21f));
            StartCoroutine(Blue(8.79f));
            StartCoroutine(Blue(9.71f));
            StartCoroutine(Blue(9.99f));
            StartCoroutine(Red(10.39f));
            StartCoroutine(Blue(10.54f));
            StartCoroutine(Green(10.72f));
            StartCoroutine(Yellow(10.89f));
            StartCoroutine(Green(11.26f));
            StartCoroutine(Blue(11.41f));
            StartCoroutine(Red(11.54f));
            StartCoroutine(Yellow(11.69f));
            StartCoroutine(Green(12.01f));
            StartCoroutine(Blue(12.37f));
            StartCoroutine(Red(12.92f));
            StartCoroutine(Yellow(13.08f));
            StartCoroutine(Green(13.23f));
            StartCoroutine(Blue(13.38f));
            StartCoroutine(Red(13.77f));
            StartCoroutine(Yellow(13.92f));
            StartCoroutine(Green(14.06f));
            StartCoroutine(Blue(14.2f));
            StartCoroutine(Red(14.68f));
            StartCoroutine(Yellow(14.85f));
            StartCoroutine(Green(15.19f));
            StartCoroutine(Blue(15.53f));
            StartCoroutine(Red(15.86f));
            //asdf
            StartCoroutine(Yellow(17.12f));
            StartCoroutine(Red(17.29f));
            StartCoroutine(Blue(17.65f));
            StartCoroutine(Green(17.81f));
            StartCoroutine(Blue(18.17f));
            StartCoroutine(Blue(18.47f));
            StartCoroutine(Blue(19.09f));
            StartCoroutine(Blue(20.02f));
            StartCoroutine(Blue(20.88f));
            StartCoroutine(Blue(21.01f));
            StartCoroutine(Blue(21.18f));
            StartCoroutine(Blue(21.53f));
            StartCoroutine(Blue(21.67f));
            StartCoroutine(Blue(21.80f));
            StartCoroutine(Red(21.95f));
            StartCoroutine(Blue(22.35f));
            StartCoroutine(Green(22.67f));
            StartCoroutine(Yellow(23.21f));
            StartCoroutine(Green(23.65f));
            StartCoroutine(Blue(24.09f));
            StartCoroutine(Red(24.24f));
            StartCoroutine(Yellow(24.37f));
            StartCoroutine(Green(24.51f));
            StartCoroutine(Blue(25.85f));
            StartCoroutine(Red(26.14f));
            StartCoroutine(Yellow(26.51f));
            StartCoroutine(Green(26.82f));
            StartCoroutine(Blue(27.16f));
            StartCoroutine(Red(27.49f));
            StartCoroutine(Yellow(28.0f));
            StartCoroutine(Green(28.15f));
            StartCoroutine(Blue(28.15f));
            StartCoroutine(Red(28.73f));
            StartCoroutine(Yellow(28.88f));
            StartCoroutine(Green(29.02f));
            StartCoroutine(Blue(29.12f));
            StartCoroutine(Red(29.45f));
            //-
            StartCoroutine(Yellow(29.72f));
            StartCoroutine(Red(30.06f));
            StartCoroutine(Blue(30.20f));
            StartCoroutine(Green(30.47f));
            
            played = true;
        }
    }
};
