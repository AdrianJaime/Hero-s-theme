using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class Player : MonoBehaviour {


    
    public PanelPersonalizacion panelPersonalizacion;

    public SlotPersonalización slotPersonalizacionArma;
    public SlotPersonalización slotPersonalizacionCabeza;
    public SlotPersonalización slotPersonalizacionCuerpo;
    public SlotPersonalización slotPersonalizacionPies;



    public int totalDamage=0;
    public int totalVida=0;
    public int curacion=0;
    
     void Start()
    {
        slotPersonalizacionArma = panelPersonalizacion.EncontrarSlotPersonalizacion((TipoItem)0);
        slotPersonalizacionCabeza = panelPersonalizacion.EncontrarSlotPersonalizacion((TipoItem)1);
        slotPersonalizacionCuerpo = panelPersonalizacion.EncontrarSlotPersonalizacion((TipoItem)2);
        slotPersonalizacionPies = panelPersonalizacion.EncontrarSlotPersonalizacion((TipoItem)3);

        SetValueOfItems();


    }


    public void SetValueOfItems()
    {
        totalDamage = slotPersonalizacionArma.personalizacionInfo.itemSlotPersonalizacion.stats.damage + slotPersonalizacionCabeza.personalizacionInfo.itemSlotPersonalizacion.stats.damage + slotPersonalizacionCuerpo.personalizacionInfo.itemSlotPersonalizacion.stats.damage + slotPersonalizacionPies.personalizacionInfo.itemSlotPersonalizacion.stats.damage;
        totalVida = slotPersonalizacionArma.personalizacionInfo.itemSlotPersonalizacion.stats.vida + slotPersonalizacionCabeza.personalizacionInfo.itemSlotPersonalizacion.stats.vida + slotPersonalizacionCuerpo.personalizacionInfo.itemSlotPersonalizacion.stats.vida + slotPersonalizacionPies.personalizacionInfo.itemSlotPersonalizacion.stats.vida;
        curacion = slotPersonalizacionArma.personalizacionInfo.itemSlotPersonalizacion.stats.curacion + slotPersonalizacionCabeza.personalizacionInfo.itemSlotPersonalizacion.stats.curacion + slotPersonalizacionCuerpo.personalizacionInfo.itemSlotPersonalizacion.stats.curacion + slotPersonalizacionPies.personalizacionInfo.itemSlotPersonalizacion.stats.curacion;

        //Actualizar las variables i meterlas en el archivo de texto
        WriteString();
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
        
        writer.Close();
    }

}
