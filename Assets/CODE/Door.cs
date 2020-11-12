using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum DoorType { SwitchDoorDouble, KeyDoorSingle }

    public DoorType type;

    public Transform door1;
    public Transform door2;

    public PressureSwitch sw;

    public Collider2D collider;
    public bool isOpen;


    Vector2 ClosePos1 = Vector3.zero;
    Vector2 ClosePos2 = Vector3.zero;

    public Vector2 OpenPos1;
    public Vector2 OpenPos2;


    public Vector2 GlobalOpenPos1;
    public Vector2 GlobalClosePos1;

    public Vector2 GlobalOpenPos2;
    public Vector2 GlobalClosePos2;
    public float i = 0;

    //SW;
    // Use this for initialization
    void Awake()
    {
        switch (type)
        {

            case DoorType.SwitchDoorDouble:
                GlobalClosePos1 = door1.TransformPoint(ClosePos1);
                GlobalOpenPos1 = door1.TransformPoint(OpenPos1);

                GlobalClosePos2 = door2.TransformPoint(ClosePos1);
                GlobalOpenPos2 = door2.TransformPoint(OpenPos1);

                break;


            case DoorType.KeyDoorSingle:
                GlobalClosePos1 = door1.TransformPoint(ClosePos1);
                GlobalOpenPos1 = door1.TransformPoint(OpenPos1);
                collider = GetComponentInChildren<Collider2D>();
                break;
        }



    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case DoorType.SwitchDoorDouble:

                isOpen = sw.state;
                if (isOpen)
                {
                    i = Mathf.Clamp(i + Time.deltaTime, 0, 1);

                }

                else
                {
                    i = Mathf.Clamp(i - Time.deltaTime, 0, 1);

                }

                door1.position = Vector2.Lerp(GlobalClosePos1, GlobalOpenPos1, i);
                door2.position = Vector2.Lerp(GlobalClosePos2, GlobalOpenPos2, i);


                break;

            case DoorType.KeyDoorSingle:

                collider.enabled = !isOpen;
                //isOpen = sw.state;
                if (isOpen)
                {
                    i = Mathf.Clamp(i + Time.deltaTime, 0, 1);

                }

                else
                {
                    i = Mathf.Clamp(i - Time.deltaTime, 0, 1);

                }

                door1.position = Vector2.Lerp(GlobalClosePos1, GlobalOpenPos1, i);
                //door2.position = Vector2.Lerp(GlobalClosePos2, GlobalOpenPos2, i);


                break;



        }


    }


    void OpenDoor()
    {

    }

    void CloseDoor()
    {


    }


    private void OnDrawGizmosSelected()
    {
        switch (type)
        {


            case DoorType.SwitchDoorDouble:
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(door1.TransformPoint(OpenPos1), .1f);
                Gizmos.DrawWireSphere(door2.TransformPoint(OpenPos2), .1f);

                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(door1.TransformPoint(ClosePos1), .1f);
                Gizmos.DrawWireSphere(door2.TransformPoint(ClosePos2), .1f);


                break;

            case DoorType.KeyDoorSingle:
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(door1.TransformPoint(OpenPos1), .1f);
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(door1.TransformPoint(ClosePos1), .1f);
                break;
        }

    }

   
}
