using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScript : MonoBehaviour {

    float time;
    float a = 4;

    public GameObject Stars;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        Stars.transform.position += Vector3.down * Time.deltaTime * 150 * 1.7f;
        if (time >= a)
        {
            Destroy(Stars);
        }
    }
}
