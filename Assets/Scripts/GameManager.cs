using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Variables
    public GameObject CameraMain;           //Indica la main camera
    public GameObject Rocket;               //Indica il razzo

    public Text MeterTextMenu;              //Testo per i metri record
    public Text MeterInstanceTextMenu;      //Testo per i metri correnti dell'instanza
    #endregion

    private void Start()
    {
        MeterTextMenu.text = "Record: " + PlayerPrefs.GetFloat("Meter", 0).ToString("#.##") + "mt.";
    }

    private void Update()
    {
        if(CameraMain != null && Rocket != null)
            CameraMain.transform.position = new Vector3(CameraMain.transform.position.x, Rocket.transform.position.y+1, CameraMain.transform.position.z);   //Uguaglia la posizione della camera ad una altezza +1 rispetto al razzo


        if(PlayerPrefs.GetFloat("Meter", 0) < PlayerPrefs.GetFloat("MeterInstance", 0))             //Se il record è minore dell'instanza corrente, sostituisce il valore del record, altrimenti tiene lo stesso 
        {
            PlayerPrefs.SetFloat("Meter", PlayerPrefs.GetFloat("MeterInstance"));
            if(MeterInstanceTextMenu != null)
                MeterInstanceTextMenu.text = "Distance: " + PlayerPrefs.GetFloat("MeterInstance", 0).ToString("#.##") + "mt.";
            PlayerPrefs.SetFloat("Meter", PlayerPrefs.GetFloat("MeterInstance"));
            if(MeterTextMenu != null)
                MeterTextMenu.text = "Record: " + PlayerPrefs.GetFloat("Meter", 0).ToString("#.##") + "mt.";
        }
        else
        {
            if (MeterInstanceTextMenu != null)
                MeterInstanceTextMenu.text = "Distance: " + PlayerPrefs.GetFloat("MeterInstance", 0).ToString("#.##") + "mt.";
            if (MeterTextMenu != null)
                MeterTextMenu.text = "Record: " + PlayerPrefs.GetFloat("Meter", 0).ToString("#.##") + "mt.";
        }
    }
}
