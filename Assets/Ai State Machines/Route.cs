﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour {


    
    //public Dictionary<char, Vector3> nodes = new Dictionary<char, Vector3>();
    public Dictionary<char, Vector3> nodes;
    public Vector3[] Points;

    public Color pathColor;




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 GetGlobalPoint(int i)
    {
        return transform.TransformPoint(Points[i]);
    }


   

    }
