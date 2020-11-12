using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour {


    Light light;

    float ovalue;

    public bool startOn;


	// Use this for initialization
	void Awake () {
        light = GetComponent<Light>();
        ovalue = light.intensity;

        if (!startOn)
            light.intensity = 0;

    }
	
	



    public void SwitchLightOff()
    {
        StartCoroutine(SwitchOff());
    } 

  public void SwitchLightOn()
    {
        StartCoroutine(SwitchOn());
    }


    IEnumerator SwitchOff()
    {
        do
        {
            light.intensity -= Time.deltaTime*2;
            yield return new WaitForEndOfFrame();
        } while (light.intensity > 0);

    }


    IEnumerator SwitchOn()
    {
        do
        {
            light.intensity += Time.deltaTime*2;
            yield return new WaitForEndOfFrame();
        } while (light.intensity <ovalue);
    }

}
