using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittablePhysics : MonoBehaviour {


    Rigidbody2D rigidbody;

    public Damageable dmgable;

    public float knockbackForce = 5;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	


    public void ActivatePhysics()
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic;


    }

    public void DeActivatePhysics()
    {
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        rigidbody.velocity = Vector2.zero;

    }



    public void Hit()
    {
        if(dmgable)
        {

            ActivatePhysics();
            rigidbody.velocity = Vector2.zero;
            Vector2 dir =  (Vector2)transform.position- (Vector2)dmgable.info.position;

            rigidbody.AddForce(dir.normalized * knockbackForce, ForceMode2D.Impulse);
        }

        
    }

}
