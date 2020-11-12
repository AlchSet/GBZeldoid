using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItem : WeaponBase {


    public GameObject bomb;

    public override void Dispose()
    {
        //throw new System.NotImplementedException();
    }

    public override bool GetInUse()
    {
        return false;
    }

    public override void OnButtonDown()
    {
        Instantiate(bomb, transform.position, Quaternion.identity);
    }

    public override void OnButtonUp()
    {
        //throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        

	}
}
