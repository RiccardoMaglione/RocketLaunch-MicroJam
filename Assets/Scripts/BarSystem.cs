using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarSystem : MonoBehaviour
{
    #region Variables
    #region Move bar
    public float Delta = 1.5f;                          //Indica quanto va a destra e a sinistra
    public float Speed = 2.0f;                          //Indica la velocità
    Vector3 StartPos;                                   //Indica il punto iniziale
    [HideInInspector] public bool Move = true;          //Boleano che indica se la barra si può muovere

    public GameObject[] ArrayLimitLeft;                 //Array per i vari limiti sulla sinistra della barra
    public GameObject[] ArrayLimitRight;                //Array per i vari limiti sulla destra della barra

    [HideInInspector] public bool ActiveMove = false;   //Booleano che indica se può far partire il cooldown

    public float CooldownMove;                          //Indica quanto dura il cooldown
    #endregion

    #region Count Value
    [HideInInspector] public int Count = 0;
    public float ValueRed;                              //Valore che indica il punteggio dell'area rossa
    public float ValueOrange;                           //Valore che indica il punteggio dell'area arancione
    public float ValueYellow;                           //Valore che indica il punteggio dell'area gialla
    public float ValueGreen;                            //Valore che indica il punteggio dell'area verde

    static public float ValueTotal;                     //Valore totale delle zone colorate

    public bool CanEnter = true;                        //Booleano che indica se può entrare nell'if per far partire l'impulso del razzo
    #endregion
    #endregion
    void Start()
    {
        StartPos = transform.position;
    }

    void Update()
    {
        if(Move == true)
        {
            MoveBar();
        }

        if (Input.GetKeyDown(KeyCode.Space) && Move == true)
        {
            ControlStopBar();
        }

        if (Count < 5 && ActiveMove == true)
        {
            StartCoroutine(Cooldown());
        }
        else if (Count >= 5 && CanEnter == true)
        {
            MoveRocket.CanImpulse = true;
            CanEnter = false;
        }
    }

    /// <summary>
    /// Metodo che fa muovere la barra nel tempo a una determinata velocità
    /// </summary>
    public void MoveBar()
    {
        ActiveMove = false;
        Vector3 v = StartPos;
        v.x += Delta * Mathf.Sin(Time.time * Speed);
        transform.position = v;
    }

    /// <summary>
    /// Metodo che controlla dove si ferma e somma i valori
    /// </summary>
    public void ControlStopBar()
    {
        Move = false;
        if (transform.position.x <= ArrayLimitRight[0].transform.position.x && transform.position.x >= ArrayLimitRight[1].transform.position.x)
        {
            Count++;
            ActiveMove = true;
            ValueTotal += ValueRed;
        }
        if (transform.position.x < ArrayLimitRight[1].transform.position.x && transform.position.x >= ArrayLimitRight[2].transform.position.x)
        {
            Count++;
            ActiveMove = true;
            ValueTotal += ValueOrange;
        }
        if (transform.position.x < ArrayLimitRight[2].transform.position.x && transform.position.x >= ArrayLimitRight[3].transform.position.x)
        {
            Count++;
            ActiveMove = true;
            ValueTotal += ValueYellow;
        }
        if (transform.position.x < ArrayLimitRight[3].transform.position.x && transform.position.x >= ArrayLimitLeft[3].transform.position.x)
        {
            Count++;
            ActiveMove = true;
            ValueTotal += ValueGreen;
        }
        if (transform.position.x < ArrayLimitLeft[3].transform.position.x && transform.position.x >= ArrayLimitLeft[2].transform.position.x)
        {
            Count++;
            ActiveMove = true;
            ValueTotal += ValueYellow;
        }
        if (transform.position.x < ArrayLimitLeft[2].transform.position.x && transform.position.x >= ArrayLimitLeft[1].transform.position.x)
        {
            Count++;
            ActiveMove = true;
            ValueTotal += ValueOrange;
        }
        if (transform.position.x < ArrayLimitLeft[1].transform.position.x && transform.position.x >= ArrayLimitLeft[0].transform.position.x)
        {
            Count++;
            ActiveMove = true;
            ValueTotal += ValueRed;
        }
    }

    /// <summary>
    /// IEnumarator per il cooldown della ripresa del movimento
    /// </summary>
    /// <returns></returns>
    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(CooldownMove);
        Move = true;
    }
}
