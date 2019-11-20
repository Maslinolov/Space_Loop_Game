using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolutionScript : MonoBehaviour {
    int width;
    //Player Script
    public static float LeftBorder;
    public static float RightBorder;
    //Create Remove Script
    public static Vector3 M1Position;
    public static Vector3 M2Position;
    public static Vector3 M3Position;
    public static Vector3 M4Position;
    public static Vector3 M5Position;
    public static Vector3 MScale;
    public static Vector3 PScale;
    void Start ()
    {
        width = Screen.width;
        
            //Player Script
            LeftBorder = -80.6F;
            RightBorder = 81.6F;
            //Create Romove Script
            M1Position.x = -78F;
            M1Position.y = 325;
            M2Position.x = -22.2F;
            M2Position.y = 325;
            M3Position.x = 31.2F;
            M3Position.y = 325;
            M4Position.x = 79.1F;
            M4Position.y = 325;            
            MScale = new Vector3(0,0,0);
            PScale = new Vector3(0, 0, 0);



        if (width == 1080 || width == 720)
        {
            //Player Script
            LeftBorder = -71F;
            RightBorder = 72F;
            //Create Romove Script
            M1Position.x = -70.4F;
            M1Position.y = 325;
            M2Position.x = -21.2F;
            M2Position.y = 325;
            M3Position.x = 23.7F;
            M3Position.y = 325;
            M4Position.x = 71.8F;
            M4Position.y = 325;           
            MScale = new Vector3(2, 2, 2);
            PScale = new Vector3(10, 10, 10);
        }
    }

}
