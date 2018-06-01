using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;

public class Recompensas : MonoBehaviour {
    public BaseDeDatos baseDeDatos;
    public Inventory inventory;
    public Monedero monedero;

    public int nivelRecompensa, enemyDefeated;//{1,5}

    //Nivel de enemigos abatados en la mision

    public GameObject panelItemRecibido;

    public Text dineroRecompensa, nombreItemRecompensa;
    public Image imagenItemRecompensa;



    private void Start()
    {
        panelItemRecibido.SetActive(false);
        ReadString();
        SelectTypeOfReward();
    }

    public void SelectTypeOfReward()
    {
        int dineroGanado=0;
        int probabilidadDeItem=-1;

        switch (nivelRecompensa)
        {
            case 1:
                dineroGanado = 50 + Random.Range(0, 101);
                probabilidadDeItem = Random.Range(0, 40 - enemyDefeated * 10) ;
                monedero.monedasNormales += dineroGanado;
                break;
            case 2:
                dineroGanado = 100+ Random.Range(0, 201);
                probabilidadDeItem = Random.Range(0, 60 - enemyDefeated * 10) ;
                monedero.monedasNormales += dineroGanado;
                break;
            case 3:
                dineroGanado = 150 + Random.Range(0, 301);
                probabilidadDeItem = Random.Range(0, 60 - enemyDefeated * 10) ;
                monedero.monedasNormales += dineroGanado;

                break;
            case 4:
                dineroGanado = 200 + Random.Range(0, 401);
                probabilidadDeItem = Random.Range(0, 90 - enemyDefeated * 10) ;
                monedero.monedasNormales += dineroGanado;
                break;
            case 5: //creo que no se podrán spawnear items de nivel 5 preguntar a adri que decidimos.
                dineroGanado = 250 + Random.Range(0, 501);
                probabilidadDeItem = Random.Range(0, 100 - enemyDefeated * 10);
                monedero.monedasNormales += dineroGanado;                
                break;
            default:
                break;

        }
        dineroRecompensa.text = dineroGanado.ToString();
        if (inventory.EspaciosVacios() >= 1&& nivelRecompensa < 6 && nivelRecompensa > 0 && probabilidadDeItem==0)
        { 
            AñadirItem(nivelRecompensa);
        }
    }

    public void AñadirItem(int _nivelRecompensa)
    {
        int identificadorItem = -1;
        do { identificadorItem = Random.Range(1, 17); }
        while (baseDeDatos.FindItem(identificadorItem).rareza!=_nivelRecompensa);
        ActivarPanel(true, identificadorItem);
        inventory.AñadirItem(identificadorItem);

    }

    public void ActivarPanel(bool _value, int _identificadorItem)
    {
            nombreItemRecompensa.text = baseDeDatos.FindItem(_identificadorItem).name;
            imagenItemRecompensa.sprite = baseDeDatos.FindItem(_identificadorItem).imagenItem;
            panelItemRecibido.SetActive(_value);
    }

    public void DesactivarPanel()
    {
        panelItemRecibido.SetActive( false);
    }

    [MenuItem("Tools/Read file")]
    public void ReadString()
    {
        string path = @".\Assets\TXT\Player_info\ConfiguracionControladorRecompensas.txt";

        string[] datos = new string[2];
        string line;
        int counter = 0;

        StreamReader reader = new StreamReader(path);
        while ((line = reader.ReadLine()) != null)
        {
            datos[counter] = line;
            counter++;
        }
        nivelRecompensa = int.Parse(datos[0]);
        enemyDefeated = int.Parse(datos[1]);


        reader.Close();
    }

}
