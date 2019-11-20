using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritScript : MonoBehaviour {

    public GameObject Meteorit;
    float a = 0, b = 0;
    private void Start()
    {
        Meteorit.transform.localScale -= ScreenResolutionScript.MScale;
    }


    void Update ()
    {
        if (InGameMenuScript.GlobalPause == false)
        {
            b -= 0.5F;
            Meteorit.transform.position += Vector3.down * CreateRemoveScript.time;
            Meteorit.transform.rotation = Quaternion.Euler(0, 0, b);
            a += Time.deltaTime;
            if (a >= 6)
            {
                Destroy(Meteorit);
            }
        }
	}
}
