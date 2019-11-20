using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRemoveScript : MonoBehaviour {

    public GameObject meter1;
    public GameObject meter2;
    public GameObject meter3;
    public GameObject meter4;
    public GameObject coin1;
    public GameObject Stars;
    GameObject meteorite;

    float a = 0;
    float b = 0;
    float c = 0;
    float d = 0;
    float s = 0;
    float aa = 0;
    float bb = 0;
    float cc = 0;
    float dd = 0;
 

    public static float time = 1;


    int u, cn;
    int p = 0;
    float r = 0;

    Vector3 meter1_1;
    Vector3 meter2_1;
    Vector3 meter3_1;
    Vector3 meter4_1;
    Vector3 stars;

    // Use this for initialization
    void Start ()
    {
        stars.x = -22;
        stars.y = 348;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (p != 1)
        {
            meter1_1 = ScreenResolutionScript.M1Position;
            meter2_1 = ScreenResolutionScript.M2Position;
            meter3_1 = ScreenResolutionScript.M3Position;
            meter4_1 = ScreenResolutionScript.M4Position;
            p = 1;
        }
        if (InGameMenuScript.GlobalPause == false)
        {
            s += Time.deltaTime;
            if (s >= 0.5f)
            {
                s = 0;
                Instantiate(Stars, stars, Quaternion.Euler(0, 0, 0));
            }
            time += Time.deltaTime/60;
            u = Random.Range(1, 4);
            cn = Random.Range(1, 10);
            if (cn == 5)
            {
                u = cn;
            }
            r = 0.4f;
            switch (u)
            {
                case 1:
                    meteorite = meter1;
                    break;
                case 2:
                    meteorite = meter2;
                    break;
                case 3:
                    meteorite = meter3;
                    break;
                case 4:
                    meteorite = meter4;
                    break;
                case 5:
                    meteorite = coin1;
                    break;
            }

            aa = Random.Range(1, 5);
            bb = Random.Range(1, 5);
            cc = Random.Range(1, 5);
            dd = Random.Range(1, 5);
            if(aa == 3)
            {
                a += Time.deltaTime;
                if (a >= r)
                {
                    a = 0;
                    Instantiate(meteorite, meter1_1, Quaternion.Euler(0, 0, 180));
                }
            }
            
            if(bb == 3)
            {
                b += Time.deltaTime;
                if (b >= r)
                {
                    b = 0;
                    Instantiate(meteorite, meter2_1, Quaternion.Euler(0, 0, 180));
                }
            }
            if (cc == 3)
            {
                c += Time.deltaTime;
                if (c >= r)
                {
                    c = 0;
                    Instantiate(meteorite, meter3_1, Quaternion.Euler(0, 0, 180));
                }
            }
            if (dd == 3)
            {
                d += Time.deltaTime;
                if (d >= r)
                {
                    d = 0;
                    Instantiate(meteorite, meter4_1, Quaternion.Euler(0, 0, 180));
                }
            }
            /*
            switch (m)
            {
                case 1:
                    {
                        a += Time.deltaTime;
                        if (a >= r)
                        {
                            a = 0;
                            Instantiate(meteorite, meter1_1, Quaternion.Euler(0, 0, 180));
                        }                        
                    }
                    break;
                case 2:
                    {
                        b += Time.deltaTime;
                        if (b >= r)
                        {
                            b = 0;
                            Instantiate(meteorite, meter2_1, Quaternion.Euler(0, 0, 180));
                        }
                    }
                    break;
                case 3:
                    {
                        c += Time.deltaTime;
                        if (c >= r)
                        {
                            c = 0;
                            Instantiate(meteorite, meter3_1, Quaternion.Euler(0, 0, 180));
                        }
                    }
                    break;
                case 4:
                    {
                        d += Time.deltaTime;
                        if (d >= r)
                        {
                            d = 0;
                            Instantiate(meteorite, meter4_1, Quaternion.Euler(0, 0, 180));
                        }
                    }
                    break;
                default:
                break;
            }   
            */
        }

    }
}
