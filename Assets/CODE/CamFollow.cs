using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {


    public Transform follow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void LateUpdate()
    {
        Vector3 target = follow.position + Vector3.back * 10;

       


        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);


        Vector3 fix = transform.position;

        fix.x = Mathf.Round(target.x * 16) / 16;
        fix.y = Mathf.Round(target.y * 16) / 16;

        transform.position = fix;
    }
}
