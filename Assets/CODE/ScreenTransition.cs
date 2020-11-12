using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransition : MonoBehaviour
{
    CanvasGroup g;
    // Use this for initialization
    void Start()
    {
        g = GetComponent<CanvasGroup>();

        Teleport.OnTeleport = StartTransition;

    }

    // Update is called once per frame
    void Update()
    {

    }




    public void StartTransition()
    {
        StartCoroutine(Transit());

    }


    IEnumerator Transit()
    {
        Time.timeScale = 0;

        while (true)
        {
            g.alpha += Time.unscaledDeltaTime * 3;

            if (g.alpha >= 1)
                break;
            yield return new WaitForSecondsRealtime(0.01f);
        }

        yield return new WaitForSecondsRealtime(1f);
        while (true)
        {
            g.alpha -= Time.unscaledDeltaTime * 3;

            if (g.alpha <= 0)
                break;
            yield return new WaitForSecondsRealtime(0.01f);
        }





    }


}
