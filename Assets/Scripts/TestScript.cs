using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    public GameObject Test;

    int a = 0;
	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        if(InGameMenuScript.GlobalPause == false)
        {
            a--;
            Test.transform.rotation = Quaternion.Euler(0, 0, a);
            Test.transform.position += Vector3.down * 1;
        }
	}
}
