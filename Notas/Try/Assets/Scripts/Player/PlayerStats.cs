using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayerStats : MonoBehaviour {

    public BaseDeDatos items,evolutions;

    public EnemySpawnController enemySpawnController;

    public string saveDataRepresentacionPlayer_;
    public int totalDamage = 0;
    public int totalVida = 0;
    public int curacion = 0;

    public Image prefabArma, prefabCabeza, prefabCuerpo, prefabPiernas;

    public Item arma, cabeza, cuerpo, piernas;

    private void Start()
    {
        if (PlayerPrefs.HasKey("representacionPlayer"))
        {
            CargarRepresentacionPlayer();
        }
        else
        {
            arma = new Item();
            cabeza = new Item();
            cuerpo = new Item();
            piernas = new Item();
        }
    }
    private void Update()
    {
        ReadString();
    }



    public void ReadString()
    {
        string path = @".\Assets\TXT\Player_info\PlayerStats.txt";
        string[] stats=new string[3];
        string line;
        int counter=0;
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        while ((line = reader.ReadLine()) != null)
        {
            stats [counter]=  line;
            counter++;
        }
        totalDamage = 1+int.Parse(stats[0]);
        curacion =1+ int.Parse(stats[1]);
        totalVida =1+ int.Parse(stats[2]);


        reader.Close();

      
    }



    public void Atack()
    {
        enemySpawnController.actualEnemy.stats.vidaMax -= totalDamage;
    }


    public void SetRepresentationOfPlayer()
    {
        if(!arma.evolved)
            prefabArma.sprite = items.FindItem(arma.identificador).imagenItem;
        else
            prefabArma.sprite = evolutions.FindItem(arma.identificador).imagenItem;

        if (!cabeza.evolved)
            prefabCabeza.sprite = items.FindItem(cabeza.identificador).imagenItem;
        else
            prefabCabeza.sprite = evolutions.FindItem(cabeza.identificador).imagenItem;

        if (!cabeza.evolved)
            prefabCuerpo.sprite = items.FindItem(cuerpo.identificador).imagenItem;
        else
            prefabCuerpo.sprite = evolutions.FindItem(cuerpo.identificador).imagenItem;


        if (!cabeza.evolved)
            prefabPiernas.sprite = items.FindItem(piernas.identificador).imagenItem;
        else
            prefabPiernas.sprite = evolutions.FindItem(piernas.identificador).imagenItem;



    }

    public void CargarRepresentacionPlayer()
    {
        saveDataRepresentacionPlayer_ = PlayerPrefs.GetString("representacionPlayer");
        RepresentacionPlayer aux = JsonUtility.FromJson<RepresentacionPlayer>(saveDataRepresentacionPlayer_);
        arma=aux.arma;       //poneridentificador -1 si no hay item o no hay imagen en el item
        cabeza = aux.cabeza;
        cuerpo = aux.cuerpo;
        piernas = aux.piernas;

        GuardarRepresentación();
    }

    public void GuardarRepresentación()
    {
        if (enemySpawnController != null)
        {
            prefabArma.sprite = arma.imagenItem;
            prefabCabeza.sprite = cabeza.imagenItem;
            prefabCuerpo.sprite = cuerpo.imagenItem;
            prefabPiernas.sprite = piernas.imagenItem;
        }
    }
}
