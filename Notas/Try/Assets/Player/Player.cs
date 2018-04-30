using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public EnemySpawnController enemySpawnController;
    public SlotPersonalización slotPersonalizacionCabeza;
    public SlotPersonalización slotPersonalizacionCuerpo;
    public SlotPersonalización slotPersonalizacionPies;

    public SlotPersonalización slotPersonalizacionArma;

    public int totalDamage;
    public int totalVida;
    public int totalCombo;
     
    public void SetValueOfItems(int _identificadorItem)
    {
        totalDamage = slotPersonalizacionArma.item.stats.damage + slotPersonalizacionCabeza.item.stats.damage + slotPersonalizacionCuerpo.item.stats.damage + slotPersonalizacionPies.item.stats.damage;
        totalVida = slotPersonalizacionArma.item.stats.vida + slotPersonalizacionCabeza.item.stats.vida  + slotPersonalizacionCuerpo.item.stats.vida + slotPersonalizacionPies.item.stats.vida;
        totalCombo = slotPersonalizacionArma.item.stats.combo + slotPersonalizacionCabeza.item.stats.combo + slotPersonalizacionCuerpo.item.stats.combo + slotPersonalizacionPies.item.stats.combo;
    }

    public void Atack()
    {
        enemySpawnController.actualEnemy.enemyInfo.vida -= 1;
    }
}
