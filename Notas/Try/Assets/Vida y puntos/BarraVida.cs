using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarraVida : MonoBehaviour {

	public Scrollbar HealthBar;
    float HealthMax;
    public float Health = 100.0f;
    public float damageValue=10.0f;
    public float vidaCurada = 5.0f;
    private void Start()
    {
     HealthMax = Health;
    }


    public void Damage(float value)
	{
		Health -= value;
		HealthBar.size = Health / HealthMax;
;
	}
    public void Curar(float value)
    {
        Health += value;
        if (Health >= HealthMax)
            Health = HealthMax;
        HealthBar.size = Health / HealthMax;
    }

    public bool NoSalud()
    {
        if (Health <= 0)
            return true;
        else
            return false;
    }
}
