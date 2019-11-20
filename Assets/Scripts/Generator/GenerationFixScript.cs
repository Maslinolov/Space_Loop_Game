using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationFixScript : MonoBehaviour {

    bool FirstTrigger;
    bool SecondTrigger;
    bool ThirdTrigger;
    bool ForthTrigger;
    public static int A;
    float time;
    float o = 0.8f;
	
	// Update is called once per frame
	void Update ()
    {
        FirstTrigger = FirstTriggerScript.FirstTrigger;
        SecondTrigger = SecondTriigerScript.SecondTrigger;
        ThirdTrigger = ThirdTriggerScript.ThirdTrigger;
        ForthTrigger = ForthTriggerScript.ForthTrigger;
        time += Time.deltaTime;
        if (FirstTrigger && SecondTrigger && ThirdTrigger && ForthTrigger && time >= o || FirstTrigger && SecondTrigger && ThirdTrigger  && time >= o || SecondTrigger && ThirdTrigger && ForthTrigger && time >= o || FirstTrigger && ThirdTrigger && ForthTrigger && time >= o)
        {
            A = Random.Range(1, 4);
            time = 0;            
        }

	}
}
