using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonalizacionCabeza : MonoBehaviour {

    public GameObject panel; //Para selecciónar el panel donde se acturará

    public Image []lugarDeCambioDeImagen; //lugar donde se cambiará la imagen
    public RawImage[] lugarDeCambioDeImagen2; //lugar donde se cambiará la imagen


    public Image[] ArmasInventory; //Colocamos las armas en un array

    public int identificadorImagen; //Un numero para cada imagen

    public int identificadorDeEuipo;

    public Image []armaSlotEquip;

    public int equipo;



    private void Start()
    {
        panel.SetActive(false);
        
    }
    void Update () {
		for (int i = 0; i < 44; i++)
        {
            if (i == identificadorImagen)
            {
                lugarDeCambioDeImagen[identificadorDeEuipo].sprite = ArmasInventory[i].sprite;
         
                armaSlotEquip[identificadorDeEuipo].sprite = ArmasInventory[i].sprite;
            }
        }
	}

    public void NombrarIdentificador(int identificador)
    {
        identificadorImagen = identificador;
    }
    public void Equipo (int a) {
        identificadorDeEuipo = a;
    }
   
    public void ChangePanelState(bool activo) //funcion para abrir el menú
    {
        panel.SetActive(activo);
    }
}
