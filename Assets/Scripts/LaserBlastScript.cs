using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlastScript : MonoBehaviour {

    public GameObject LaserBlast;

     

    float a = 0;

  

    void Update()
    {
        if (InGameMenuScript.GlobalPause == false)
        {
            LaserBlast.transform.position += Vector3.up;
            a += Time.deltaTime;
            if (a >= 4.5f)
            {
                Destroy(LaserBlast);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerScript.LsrExplsn = true;        
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
