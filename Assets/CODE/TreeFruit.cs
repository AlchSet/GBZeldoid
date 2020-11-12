using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFruit : MonoBehaviour {

    public Transform fruit;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void DropFruit()
    {
        StartCoroutine(Drop());
    }



    IEnumerator Drop()
    {
        Vector2 oPos = fruit.transform.position;
        Vector2 droppedPos = (Vector2)fruit.transform.position + Vector2.down * 1.5f;

        float i = 0; 



        while(true)
        {
            i += Time.deltaTime;


            fruit.position = Vector2.Lerp(oPos, droppedPos, i);

            if(i>=1)
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        }

          
    }
}
