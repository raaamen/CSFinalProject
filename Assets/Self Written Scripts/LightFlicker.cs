using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light light;
    public bool coroutineRunning;
    void Start()
    {
        StartCoroutine("FlickerTheLightBaby");
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineRunning == false)
        {
            StartCoroutine("FlickerTheLightBaby");
        }
    }

    IEnumerator FlickerTheLightBaby(){
        coroutineRunning=true;
        //it is october 5th. im going insane at this point
        light.intensity = 6.94f;
        yield return new WaitForSeconds(Random.Range(0.01f,1f));
        light.intensity = 3.00f;
        coroutineRunning=false;
        yield return null;
    }

}

