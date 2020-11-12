using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyLabel : MonoBehaviour {


    public Player player;
    Text text;
	// Use this for initialization
	void Start () {

        text = GetComponentInChildren<Text>();
        if(player)
        {
            player.OnAddCash = UpdateUI;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void UpdateUI()
    {
        Debug.Log("MONEYS");
        text.text =""+ player.money;
    }
}
