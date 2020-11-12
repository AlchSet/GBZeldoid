using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTotem : MonoBehaviour {

    public GameObject Projectile;

    float timepassed;

    bool fire;

    Transform p;

	// Use this for initialization
	void Start () {

        p = GameObject.FindGameObjectWithTag("Player").transform;



	}
	
	// Update is called once per frame
	void Update () {

        float distance = Vector2.Distance(p.position, transform.position);
        //Debug.Log(distance);
        if(distance<5)
        {
            
            if(!fire)
            {
                GameObject g=GameObject.Instantiate(Projectile, transform.position, Quaternion.identity);

                Vector2 dir = p.position-transform.position;


                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                g.transform.rotation = Quaternion.Euler(0, 0, angle);
                g.GetComponent<Rigidbody2D>().AddForce(dir.normalized * 5, ForceMode2D.Impulse);

                fire = true;
            }
            else
            {
                timepassed += Time.deltaTime;

                if(timepassed>2f)
                {
                    timepassed = 0;
                    fire = false;
                }
            }

        }


	}
}
