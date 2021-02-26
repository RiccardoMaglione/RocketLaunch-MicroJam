using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarSystem : MonoBehaviour
{
    public float delta = 1.5f;
    public float speed = 2.0f;
    private Vector3 startPos;
    public bool Move = true;

    public GameObject[] ArrayLimitLeft;
    public GameObject[] ArrayLimitRight;

    public int Count = 0;
    public bool ActiveMove = false;

    public float CooldownMove;

    public float ValueRed;
    public float ValueOrange;
    public float ValueYellow;
    public float ValueGreen;

    public float ValueTotal;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if(Move == true)
        {
            ActiveMove = false;
            Vector3 v = startPos;
            v.x += delta * Mathf.Sin(Time.time * speed);
            transform.position = v;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move = false;
            if(transform.position.x <= ArrayLimitRight[0].transform.position.x && transform.position.x >= ArrayLimitRight[1].transform.position.x)
            {
                print("1a");
                Count++;
                ActiveMove = true;
                ValueTotal += ValueRed;
            }
            if (transform.position.x < ArrayLimitRight[1].transform.position.x && transform.position.x >= ArrayLimitRight[2].transform.position.x)
            {
                print("2a");
                Count++;
                ActiveMove = true;
                ValueTotal += ValueOrange;
            }
            if (transform.position.x < ArrayLimitRight[2].transform.position.x && transform.position.x >= ArrayLimitRight[3].transform.position.x)
            {
                print("3a");
                Count++;
                ActiveMove = true;
                ValueTotal += ValueYellow;
            }
            if (transform.position.x < ArrayLimitRight[3].transform.position.x && transform.position.x >= ArrayLimitLeft[3].transform.position.x)
            {
                print("4");
                Count++;
                ActiveMove = true;
                ValueTotal += ValueGreen;
            }
            if (transform.position.x < ArrayLimitLeft[3].transform.position.x && transform.position.x >= ArrayLimitLeft[2].transform.position.x)
            {
                print("3b");
                Count++;
                ActiveMove = true;
                ValueTotal += ValueYellow;
            }
            if (transform.position.x < ArrayLimitLeft[2].transform.position.x && transform.position.x >= ArrayLimitLeft[1].transform.position.x)
            {
                print("2b");
                Count++;
                ActiveMove = true;
                ValueTotal += ValueOrange;
            }
            if (transform.position.x < ArrayLimitLeft[1].transform.position.x && transform.position.x >= ArrayLimitLeft[0].transform.position.x)
            {
                print("1b");
                Count++;
                ActiveMove = true;
                ValueTotal += ValueRed;
            }
        }

        if (Count < 5 && ActiveMove == true)
        {
            StartCoroutine(Cooldown());
        }
    }
    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(CooldownMove);
        Move = true;
    }
}
