using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class Player : MonoBehaviour {

    public ControladorDeTextos controladorDeTextos;
    
    public PanelPersonalizacion panelPersonalizacion;

    public SlotPersonalización slotPersonalizacionArma;
    public SlotPersonalización slotPersonalizacionCabeza;
    public SlotPersonalización slotPersonalizacionCuerpo;
    public SlotPersonalización slotPersonalizacionPies;


    string line;
    public int totalDamage=50;
    public int totalVida=0;
    public int totalCombo=0;
    
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
        totalDamage = slotPersonalizacionArma.personalizacionInfo.statsInfo.damage + slotPersonalizacionCabeza.personalizacionInfo.statsInfo.damage + slotPersonalizacionCuerpo.personalizacionInfo.statsInfo.damage + slotPersonalizacionPies.personalizacionInfo.statsInfo.damage;
        totalVida = slotPersonalizacionArma.personalizacionInfo.statsInfo.vida + slotPersonalizacionCabeza.personalizacionInfo.statsInfo.vida  + slotPersonalizacionCuerpo.personalizacionInfo.statsInfo.vida + slotPersonalizacionPies.personalizacionInfo.statsInfo.vida;
        totalCombo = slotPersonalizacionArma.personalizacionInfo.statsInfo.combo + slotPersonalizacionCabeza.personalizacionInfo.statsInfo.combo + slotPersonalizacionCuerpo.personalizacionInfo.statsInfo.combo + slotPersonalizacionPies.personalizacionInfo.statsInfo.combo;

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
        writer.WriteLine(totalCombo);
        writer.WriteLine(totalVida);
        
        writer.Close();
    }

}
