using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject CameraMain;
    public GameObject Rocket;

    public Text MeterTextMenu;
    public Text MeterInstanceTextMenu;
    private void Start()
    {
        MeterTextMenu.text = "Record: " + PlayerPrefs.GetFloat("Meter", 0).ToString() + "mt.";
    }

    private void Update()
    {
        if(CameraMain != null && Rocket != null)
            CameraMain.transform.position = new Vector3(CameraMain.transform.position.x, Rocket.transform.position.y+1, CameraMain.transform.position.z);


        if(PlayerPrefs.GetFloat("Meter", 0) < PlayerPrefs.GetFloat("MeterInstance", 0))
        {
            PlayerPrefs.SetFloat("Meter", PlayerPrefs.GetFloat("MeterInstance"));
            if(MeterInstanceTextMenu != null)
                MeterInstanceTextMenu.text = "Distance: " + PlayerPrefs.GetFloat("MeterInstance", 0).ToString() + "mt.";
            PlayerPrefs.SetFloat("Meter", PlayerPrefs.GetFloat("MeterInstance"));
            if(MeterTextMenu != null)
                MeterTextMenu.text = "Record: " + PlayerPrefs.GetFloat("Meter", 0).ToString() + "mt.";
        }
        else
        {
            if (MeterInstanceTextMenu != null)
                MeterInstanceTextMenu.text = "Distance: " + PlayerPrefs.GetFloat("MeterInstance", 0).ToString() + "mt.";
            if (MeterTextMenu != null)
                MeterTextMenu.text = "Record: " + PlayerPrefs.GetFloat("Meter", 0).ToString() + "mt.";
        }
    }
}
