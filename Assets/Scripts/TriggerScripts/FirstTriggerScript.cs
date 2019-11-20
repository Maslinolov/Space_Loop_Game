using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTriggerScript : MonoBehaviour {

    public static bool FirstTrigger;

    void OnTriggerEnter2D(Collider2D other)
    {
        FirstTrigger = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        FirstTrigger = false;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (GenerationFixScript.A == 1)
        {
            Destroy(other.gameObject);
            GenerationFixScript.A = 0;
        }
    }
}
