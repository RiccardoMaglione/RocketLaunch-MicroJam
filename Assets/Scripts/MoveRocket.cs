using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRocket : MonoBehaviour
{
    #region Variables
    public Rigidbody2D rb;
    static public bool CanImpulse;          //Booleano che indica se può muoversi

    public float Meter;
    public Text MeterText;

    public GameObject Explosion;            //Gameobject che indica la sprite dell'esplosione

    public GameObject GameOverPanel;        //Gameobject che indica il pannello del gameover
    #endregion

    private void Start()
    {
        Explosion.SetActive(false);
        BarSystem.ValueTotal = 0;
    }

    void Update()
    {
        CalculateMeter();
        GameOver();
        RocketMove();
    }

    /// <summary>
    /// Metodo che calcola l'altezza del razzo durante l'impulso
    /// </summary>
    public void CalculateMeter()
    {
        if(Meter < transform.position.y)
        {
            Meter = transform.position.y;
            if(MeterText != null)
            {
                MeterText.text = Meter.ToString("#.##") + "mt.";
            }
        }
    }

    /// <summary>
    /// Metodo che viene richiamato quando ha finito l'impulso
    /// </summary>
    public void GameOver()
    {
        if (rb.velocity.y < -0.1f && Meter != 0)
        {
            PlayerPrefs.SetFloat("MeterInstance", Meter);
            Explosion.transform.position = transform.position;
            Explosion.SetActive(true);
            GameOverPanel.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Metodo che muove il razzo tramite un impulso
    /// </summary>
    public void RocketMove()
    {
        if (CanImpulse == true)
        {
            rb.AddForce(Vector2.up * BarSystem.ValueTotal, ForceMode2D.Impulse);
            CanImpulse = false;
        }
    }
}
