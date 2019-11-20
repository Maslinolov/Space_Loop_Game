using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTriigerScript : MonoBehaviour {

    public static bool SecondTrigger;

    void OnTriggerEnter2D(Collider2D other)
    {
        SecondTrigger = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        SecondTrigger = false;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (GenerationFixScript.A == 2)
        {
            Destroy(other.gameObject);
            GenerationFixScript.A = 0;
        }
    }
}
