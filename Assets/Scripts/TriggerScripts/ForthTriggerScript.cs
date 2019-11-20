using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForthTriggerScript : MonoBehaviour {

    public static bool ForthTrigger;

    void OnTriggerEnter2D(Collider2D other)
    {
        ForthTrigger = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        ForthTrigger = false;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (GenerationFixScript.A == 4)
        {
            Destroy(other.gameObject);
            GenerationFixScript.A = 0;
        }
    }
}
