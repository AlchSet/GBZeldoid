using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : MonoBehaviour {

    public int SignID;

    Animator anim;


	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        anim.SetInteger("PostID",SignID);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
