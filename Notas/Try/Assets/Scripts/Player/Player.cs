using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class Player : MonoBehaviour {
    
    public PanelPersonalizacion panelPersonalizacion;

    public Item itemArma, ItemCabeza, ItemCuerpo, ItemPiernas;

    public string saveDataRepresentationPlayer;

    public int totalDamage=0;
    public int totalVida=0;
    public int curacion=0;
    
     void Start()
    {
        LeerYGuardarItems();
        SetValueOfItems();
    }
    private void Update()
    {
        LeerYGuardarItems();//para acceder a los items de los slots continuamente y tener actualizadas las variables del player
    }


    public void SetValueOfItems()
    {
        totalDamage = itemArma.stats.damage + ItemCabeza.stats.damage + ItemCuerpo.stats.damage + ItemPiernas.stats.damage;
        totalVida = itemArma.stats.vida + ItemCabeza.stats.vida + ItemCuerpo.stats.vida + ItemPiernas.stats.vida;
        curacion = itemArma.stats.curacion + ItemCabeza.stats.curacion + ItemCuerpo.stats.curacion + ItemPiernas.stats.curacion;

        //Actualizar las variables i meterlas en el archivo de texto
        WriteString();
    }
    public void LeerYGuardarItems()
    {


        itemArma = panelPersonalizacion.EncontrarSlotPersonalizacion((TipoItem)0).personalizacionInfo.itemSlotPersonalizacion;
        ItemCabeza = panelPersonalizacion.EncontrarSlotPersonalizacion((TipoItem)1).personalizacionInfo.itemSlotPersonalizacion;
        ItemCuerpo = panelPersonalizacion.EncontrarSlotPersonalizacion((TipoItem)2).personalizacionInfo.itemSlotPersonalizacion;
        ItemPiernas = panelPersonalizacion.EncontrarSlotPersonalizacion((TipoItem)3).personalizacionInfo.itemSlotPersonalizacion;

        GuardarRepresentación();
    }

    [MenuItem("Tools/Write file")]
    public void WriteString()
    {
        string path = @".\Assets\TXT\Player_info\PlayerStats.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(totalDamage);
        writer.WriteLine(curacion);
        writer.WriteLine(totalVida);
        /*
        writer.WriteLine(identificadorArma);
        writer.WriteLine(identificadorCabeza);
        writer.WriteLine(identificadorCuerpo);
        writer.WriteLine(identificadorPiernas);
    */

        writer.Close();
    }

    public void GuardarRepresentación()
    {
        RepresentacionPlayer aux = new RepresentacionPlayer();
        aux.arma = itemArma;
        aux.cabeza = ItemCabeza;
        aux.cuerpo = ItemCuerpo;
        aux.piernas = ItemPiernas;
        saveDataRepresentationPlayer = JsonUtility.ToJson(aux);
        PlayerPrefs.SetString("representacionPlayer", saveDataRepresentationPlayer);

    }


}

public class RepresentacionPlayer
{

    public Item arma, cabeza, cuerpo, piernas;
}