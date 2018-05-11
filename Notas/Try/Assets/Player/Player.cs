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
        totalDamage = slotPersonalizacionArma.itemSlotPersonalizacion.stats.damage + slotPersonalizacionCabeza.itemSlotPersonalizacion.stats.damage + slotPersonalizacionCuerpo.itemSlotPersonalizacion.stats.damage + slotPersonalizacionPies.itemSlotPersonalizacion.stats.damage;
        totalVida = slotPersonalizacionArma.itemSlotPersonalizacion.stats.vida + slotPersonalizacionCabeza.itemSlotPersonalizacion.stats.vida  + slotPersonalizacionCuerpo.itemSlotPersonalizacion.stats.vida + slotPersonalizacionPies.itemSlotPersonalizacion.stats.vida;
        totalCombo = slotPersonalizacionArma.itemSlotPersonalizacion.stats.combo + slotPersonalizacionCabeza.itemSlotPersonalizacion.stats.combo + slotPersonalizacionCuerpo.itemSlotPersonalizacion.stats.combo + slotPersonalizacionPies.itemSlotPersonalizacion.stats.combo;
    }
    
    public void Atack()
    {
        enemySpawnController.actualEnemy.stats.vidaMax -= totalDamage;
    }
    
}
