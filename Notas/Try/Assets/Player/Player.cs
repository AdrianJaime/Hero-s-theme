using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public EnemySpawnController enemySpawnController;
    
    public PanelPersonalizacion panelPersonalizacion;

    public SlotPersonalización slotPersonalizacionArma;
    public SlotPersonalización slotPersonalizacionCabeza;
    public SlotPersonalización slotPersonalizacionCuerpo;
    public SlotPersonalización slotPersonalizacionPies;


    
    public int totalDamage=0;
    public int totalVida=0;
    public int totalCombo=0;
    
     void Start()
    {
        slotPersonalizacionArma = panelPersonalizacion.EncontrarSlotPersonalizacion((TipoItem)0);
        slotPersonalizacionCabeza = panelPersonalizacion.EncontrarSlotPersonalizacion((TipoItem)1);
        slotPersonalizacionCuerpo = panelPersonalizacion.EncontrarSlotPersonalizacion((TipoItem)2);
        slotPersonalizacionPies = panelPersonalizacion.EncontrarSlotPersonalizacion((TipoItem)3);

    }
    
    
    public void SetValueOfItems()
    {
        totalDamage = slotPersonalizacionArma.personalizacionInfo.statsInfo.damage + slotPersonalizacionCabeza.personalizacionInfo.statsInfo.damage + slotPersonalizacionCuerpo.personalizacionInfo.statsInfo.damage + slotPersonalizacionPies.personalizacionInfo.statsInfo.damage;
        totalVida = slotPersonalizacionArma.personalizacionInfo.statsInfo.vida + slotPersonalizacionCabeza.personalizacionInfo.statsInfo.vida  + slotPersonalizacionCuerpo.personalizacionInfo.statsInfo.vida + slotPersonalizacionPies.personalizacionInfo.statsInfo.vida;
        totalCombo = slotPersonalizacionArma.personalizacionInfo.statsInfo.combo + slotPersonalizacionCabeza.personalizacionInfo.statsInfo.combo + slotPersonalizacionCuerpo.personalizacionInfo.statsInfo.combo + slotPersonalizacionPies.personalizacionInfo.statsInfo.combo;
    }
    
    public void Atack()
    {
        enemySpawnController.actualEnemy.stats.vidaMax -= totalDamage;
    }
    
}
