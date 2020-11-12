using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBlock : MonoBehaviour {


    Rigidbody2D spikeblock;

    bool hasSpikeBlock;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnDisable()
    {
        //Debug.Log(hasSpikeBlock);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Debug.Log(collision.name);
        if (collision.gameObject.tag == "Arrow")
        {
            Destroy(collision.gameObject);
        }


       



        //if (collision.gameObject.tag=="SpikeBlock")
        //{
        //    spikeblock = collision.gameObject.GetComponent<Rigidbody2D>();
        //    spikeblock.GetComponent<Collider2D>().isTrigger = false;
        //    spikeblock.bodyType = RigidbodyType2D.Dynamic;
        //}

        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("ENEMY SHIELDED");

            //collision.gameObject.GetComponent<Damageable>().OnHit.Invoke();

            Damageable.CollisionInfo i = new Damageable.CollisionInfo();
            i.position = transform.position;
            i.totalDmg = 0;
            collision.gameObject.GetComponent<Damageable>().DealDamage(i);

        }
    }




    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("DDD");
    //}
}
