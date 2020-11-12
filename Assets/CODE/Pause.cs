using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    bool ispaused;
    public GameObject equipMenu;
    public GameObject mapMenu;
    public Player player;
    bool EquipOrMap;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!ispaused&&!Teleport.inTeleport)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ispaused = true;
                Time.timeScale = 0;
                equipMenu.SetActive(true);
                if (player)
                    player.pause = true;
                EquipOrMap = true;
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                ispaused = true;
                Time.timeScale = 0;
                mapMenu.SetActive(true);
                if (player)
                    player.pause = true;
                EquipOrMap = false;
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Return)&&EquipOrMap)
            {
                ispaused = false;
                Time.timeScale = 1;
                equipMenu.SetActive(false);

                if (player)
                    player.pause = false;
            }

            if (Input.GetKeyDown(KeyCode.Backspace)&&!EquipOrMap)
            {
                ispaused = false;
                Time.timeScale = 1;
                mapMenu.SetActive(false);

                if (player)
                    player.pause = false;
            }


        }
	}
}
