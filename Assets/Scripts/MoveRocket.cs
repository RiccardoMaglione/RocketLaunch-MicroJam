using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocket : MonoBehaviour
{
    public Rigidbody2D rb;
    static public bool CanImpulse;

    void Update()
    {
        print(CanImpulse);
        if(CanImpulse == true)
        {
            rb.AddForce(Vector2.up * BarSystem.ValueTotal, ForceMode2D.Impulse);
            print("hey");
            CanImpulse = false;
        }
    }
}
