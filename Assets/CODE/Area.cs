using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{


    public static CinemachineVirtualCamera lastAreaCamera;

    CinemachineVirtualCamera areaCamera;

    public RectTransform mapRef;
    public RectTransform playerLoc;


    public GameObject[] OffLightList;
    public GameObject[] OnLightList;



    // Use this for initialization
    void Awake()
    {
        areaCamera = transform.Find("AreaCam").GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            foreach(GameObject g in OffLightList)
            {
                //g.SetActive(false);
                g.GetComponent<LightControl>().SwitchLightOff();
            }
            foreach(GameObject g in OnLightList)
            {
                //g.SetActive(true);
                g.GetComponent<LightControl>().SwitchLightOn();
            }


            if (lastAreaCamera != null)
            {
                lastAreaCamera.Priority = 0;

            }
            areaCamera.Priority = 10;
            lastAreaCamera = areaCamera;
            if (mapRef)
            {
                mapRef.gameObject.SetActive(true);
                playerLoc.anchoredPosition = mapRef.anchoredPosition;
            }
        }
    }
}
