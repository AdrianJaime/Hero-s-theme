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
    private void Update()
    {
        SetValueOfItems();
    }

    public void SetValueOfItems()
    {
        totalDamage = slotPersonalizacionArma.itemSlotPersonalizacion.stats.damage + slotPersonalizacionCabeza.itemSlotPersonalizacion.stats.damage + slotPersonalizacionCuerpo.itemSlotPersonalizacion.stats.damage + slotPersonalizacionPies.itemSlotPersonalizacion.stats.damage;
        totalVida = slotPersonalizacionArma.itemSlotPersonalizacion.stats.vida + slotPersonalizacionCabeza.itemSlotPersonalizacion.stats.vida  + slotPersonalizacionCuerpo.itemSlotPersonalizacion.stats.vida + slotPersonalizacionPies.itemSlotPersonalizacion.stats.vida;
        totalCombo = slotPersonalizacionArma.itemSlotPersonalizacion.stats.combo + slotPersonalizacionCabeza.itemSlotPersonalizacion.stats.combo + slotPersonalizacionCuerpo.itemSlotPersonalizacion.stats.combo + slotPersonalizacionPies.itemSlotPersonalizacion.stats.combo;
    }

    public void Atack()
    {
        enemySpawnController.actualEnemy.enemyInfo.vida -= totalDamage;
    }
}
