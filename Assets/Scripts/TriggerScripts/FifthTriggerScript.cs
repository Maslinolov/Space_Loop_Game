using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthTriggerScript : MonoBehaviour {

    public static bool FifthTrigger;

    void OnTriggerEnter2D(Collider2D other)
    {
        FifthTrigger = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        FifthTrigger = false;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (GenerationFixScript.A == 5)
        {
            Destroy(other.gameObject);
            GenerationFixScript.A = 0;
        }
    }
}
