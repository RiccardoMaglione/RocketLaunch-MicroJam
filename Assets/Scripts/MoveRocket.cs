using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRocket : MonoBehaviour
{
    public Rigidbody2D rb;
    static public bool CanImpulse;

    public float Meter;
    public Text MeterText;

    public GameObject Explosion;

    public GameObject GameOverPanel;

    private void Start()
    {
        Explosion.SetActive(false);
        BarSystem.ValueTotal = 0;
    }

    void Update()
    {
        if(Meter < transform.position.y)
        {
            Meter = transform.position.y;
            if(MeterText != null)
            {
                MeterText.text = Meter.ToString("#.##") + "mt.";
            }
        }
        if (rb.velocity.y < -0.1f && Meter != 0)
        {
            PlayerPrefs.SetFloat("MeterInstance", Meter);
            Explosion.transform.position = transform.position;
            Explosion.SetActive(true);
            GameOverPanel.SetActive(true);
            Destroy(this.gameObject);
        }
        
        if (CanImpulse == true)
        {
            rb.AddForce(Vector2.up * BarSystem.ValueTotal, ForceMode2D.Impulse);
            CanImpulse = false;
        }
    }
}
