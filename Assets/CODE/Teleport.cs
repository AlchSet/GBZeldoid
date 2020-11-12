using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {


    public static bool inTeleport;
    public static bool isTeleporting;

    public Transform destination;

    public Vector2 offset;

    public bool triggerTransition;


    public delegate void Action();

    public static Action OnTeleport;

    Transform teleportee;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="PlayerInbound"&&!inTeleport&&!isTeleporting)
        {
            
            inTeleport = true;
            if (OnTeleport != null)
            {
                OnTeleport();
            }
            //collision.transform.parent.position = destination.position + (Vector3)offset;
            teleportee = collision.transform.root;
            StartCoroutine(TeleportDelay());
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerInbound"&&!isTeleporting)
        {
            inTeleport = false;
        }
    }


    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.magenta;
        try
        {
            Gizmos.DrawLine(transform.position, destination.position+(Vector3)offset);
        }
        catch (Exception e) { }
        }


    IEnumerator TeleportDelay()
    {
        


        isTeleporting = true;

        //yield return new WaitForSecondsRealtime(.1f);
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(.5f);

        teleportee.position= destination.position + (Vector3)offset;

        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1;

        inTeleport = false;
        isTeleporting = false;
    }
}
