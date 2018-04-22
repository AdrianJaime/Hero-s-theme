using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarraVida : MonoBehaviour {

	public Scrollbar HealthBar;
    float HealthMax;
    public float Health = 100;

    private void Start()
    {
     HealthMax = Health;
    }


    public void Damage(float value)
	{
		Health -= value;
		HealthBar.size = Health / HealthMax;
	}

}
