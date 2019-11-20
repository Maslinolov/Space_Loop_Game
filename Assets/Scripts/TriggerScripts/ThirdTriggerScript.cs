using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdTriggerScript : MonoBehaviour {

    public static bool ThirdTrigger;

    void OnTriggerEnter2D(Collider2D other)
    {
        ThirdTrigger = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        ThirdTrigger = false;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (GenerationFixScript.A == 3)
        {
            Destroy(other.gameObject);
            GenerationFixScript.A = 0;
        }
    }
}
