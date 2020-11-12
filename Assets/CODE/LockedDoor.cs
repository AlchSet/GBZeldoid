using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour,Interactable {
    public Door door;

    public void Interact()
    {
        if(Player.keys>0)
        {
            door.isOpen = true;
            Player.keys--;
        }
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
