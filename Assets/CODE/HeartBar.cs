using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBar : MonoBehaviour
{


    public Damageable dmg;
    public RectTransform bar;

    float max;

    // Use this for initialization
    void Start()
    {
        bar = transform.Find("Bar").GetComponent<RectTransform>();

        if (dmg)
        {
            max = bar.sizeDelta.x;
            UpdateHeartBar();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }




    public void UpdateHeartBar()
    {
        Vector2 s = bar.sizeDelta;
        //float x = s.x;
        
        float i= dmg.life / 3f;

        //Debug.Log("DMG=" + dmg.life+"/3="+i);
        s.x = i * max;

        //Debug.Log(i);

        bar.sizeDelta = s;

    }


}
